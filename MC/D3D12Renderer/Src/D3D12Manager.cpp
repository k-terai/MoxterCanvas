// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "D3D12Manager.h"
#include"Math/SimpleMath.h"

using namespace std;
using namespace D3D12Renderer;
using namespace McEnCore;
using namespace DirectX::SimpleMath;

D3D12Manager D3D12Manager::s_instance;

D3D12Renderer::D3D12Manager::D3D12Manager() : m_febceValue(0)
{

}

D3D12Renderer::D3D12Manager::~D3D12Manager()
{
	m_fence.reset();
	m_rtvHeap.reset();
	m_allocator.reset();
	m_commandList.reset();
	m_commandQueue.reset();
	m_swapChain.reset();
	m_factory.reset();
	m_device.reset();
}

bool D3D12Renderer::D3D12Manager::Initialize(const McEnCore::whandle handle)
{
#ifdef _DEBUG
	EnableDebugLayer();
#endif

	D3D_FEATURE_LEVEL levels[] =
	{
		D3D_FEATURE_LEVEL_12_1,
		D3D_FEATURE_LEVEL_12_0
	};

	ID3D12Device8* device = nullptr;

	for (auto lv : levels)
	{
		if (D3D12CreateDevice(nullptr, lv, IID_PPV_ARGS(&device)) == S_OK)
		{
			break;
		}
	}

	if (device == nullptr)
	{
		return false;
	}

	m_device.reset(device);

	if (!InitializeFactory())
	{
		return false;
	}

	if (!InitializeCommands())
	{
		return false;
	}

	if (!InitializeSwapChain(handle))
	{
		return false;
	}

	if (!InitializeRenderTargetView())
	{
		return false;
	}

	if (!InitializeFence())
	{
		return false;
	}


	TestClearRenderTarget();
	TestVertexCreate();
	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeFactory()
{
	IDXGIFactory7* factory = nullptr;

#if _DEBUG
	auto result = CreateDXGIFactory2(DXGI_CREATE_FACTORY_DEBUG, IID_PPV_ARGS(&factory));
#else
	auto result = CreateDXGIFactory1(IID_PPV_ARGS(&factory));
#endif


	if (result != S_OK)
	{
		return false;
	}

	m_factory.reset(factory);
	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeCommands()
{
	ID3D12CommandAllocator* allocator = nullptr;
	ID3D12GraphicsCommandList6* commandList = nullptr;
	ID3D12CommandQueue* queue = nullptr;

	auto result = m_device.get()->CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT, IID_PPV_ARGS(&allocator));
	if (result != S_OK)
	{
		return false;
	}

	result = m_device.get()->CreateCommandList(0, D3D12_COMMAND_LIST_TYPE_DIRECT, allocator, nullptr, IID_PPV_ARGS(&commandList));
	if (result != S_OK)
	{
		return false;
	}

	D3D12_COMMAND_QUEUE_DESC desc;
	SecureZeroMemory(&desc, sizeof(D3D12_COMMAND_QUEUE_DESC));
	desc.Flags = D3D12_COMMAND_QUEUE_FLAG_NONE;
	desc.NodeMask = 0;
	desc.Priority = D3D12_COMMAND_QUEUE_PRIORITY_NORMAL;
	desc.Type = D3D12_COMMAND_LIST_TYPE_DIRECT;

	result = m_device.get()->CreateCommandQueue(&desc, IID_PPV_ARGS(&queue));
	if (result != S_OK)
	{
		return false;
	}

	m_allocator.reset(allocator);
	m_commandList.reset(commandList);
	m_commandQueue.reset(queue);

	m_commandList->Close();
	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeSwapChain(McEnCore::whandle handle)
{
	DXGI_SWAP_CHAIN_DESC1 desc;
	SecureZeroMemory(&desc, sizeof(DXGI_SWAP_CHAIN_DESC1));

	RECT rect;
	SecureZeroMemory(&rect, sizeof(RECT));
	GetWindowRect(handle, &rect);

	desc.Width = rect.right;
	desc.Height = rect.bottom;
	desc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	desc.Stereo = false;
	desc.SampleDesc.Count = 1;
	desc.SampleDesc.Quality = 0;
	desc.BufferUsage = DXGI_USAGE_BACK_BUFFER;
	desc.BufferCount = 2;
	desc.Scaling = DXGI_SCALING_STRETCH;
	desc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_DISCARD;
	desc.AlphaMode = DXGI_ALPHA_MODE_UNSPECIFIED;
	desc.Flags = DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH;

	IDXGISwapChain4* swapChain = nullptr;

	auto result = m_factory->CreateSwapChainForHwnd(m_commandQueue.get(), handle, &desc,
		nullptr, nullptr, reinterpret_cast<IDXGISwapChain1**>(&swapChain));

	if (result != S_OK)
	{
		return false;
	}

	m_swapChain.reset(swapChain);
	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeRenderTargetView()
{
	D3D12_DESCRIPTOR_HEAP_DESC heapDesc;
	SecureZeroMemory(&heapDesc, sizeof(D3D12_DESCRIPTOR_HEAP_DESC));

	heapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV;
	heapDesc.NodeMask = 0;
	heapDesc.NumDescriptors = 2; //front,back
	heapDesc.Flags = D3D12_DESCRIPTOR_HEAP_FLAG_NONE;

	ID3D12DescriptorHeap* heap;
	auto result = m_device->CreateDescriptorHeap(&heapDesc, IID_PPV_ARGS(&heap));

	if (result != S_OK)
	{
		return false;
	}
	m_rtvHeap.reset(heap);

	DXGI_SWAP_CHAIN_DESC1 swapDesc;
	SecureZeroMemory(&swapDesc, sizeof(DXGI_SWAP_CHAIN_DESC1));

	result = m_swapChain->GetDesc1(&swapDesc);
	if (result != S_OK)
	{
		return false;
	}

	m_backBuffers.resize(swapDesc.BufferCount);

	for (uint32 i = 0; i < swapDesc.BufferCount; i++)
	{
		result = m_swapChain->GetBuffer(i, IID_PPV_ARGS(&m_backBuffers[i]));
		if (result != S_OK)
		{
			return false;
		}

		auto handle = m_rtvHeap.get()->GetCPUDescriptorHandleForHeapStart();
		handle.ptr += i * m_device.get()->GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV);
		m_device.get()->CreateRenderTargetView(m_backBuffers[i], nullptr, handle);
	}

	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeFence()
{
	ID3D12Fence1* fence = nullptr;
	auto result = m_device->CreateFence(0, D3D12_FENCE_FLAG_NONE, IID_PPV_ARGS(&fence));

	if (result != S_OK)
	{
		return false;
	}

	m_fence.reset(fence);
	return true;
}

bool D3D12Renderer::D3D12Manager::EnableDebugLayer()
{
	ID3D12Debug* debugLayer = nullptr;
	auto result = D3D12GetDebugInterface(IID_PPV_ARGS(&debugLayer));

	debugLayer->EnableDebugLayer();
	debugLayer->Release();

	return true;
}

bool D3D12Renderer::D3D12Manager::TestClearRenderTarget()
{
	auto result = m_allocator->Reset();
	m_commandList->Reset(m_allocator.get(), nullptr);

	auto bbIndex = m_swapChain->GetCurrentBackBufferIndex();
	auto rtvHeap = m_rtvHeap->GetCPUDescriptorHandleForHeapStart();
	rtvHeap.ptr += bbIndex * m_device->GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV);

	D3D12_RESOURCE_BARRIER bd;
	SecureZeroMemory(&bd, sizeof(D3D12_RESOURCE_BARRIER));
	bd.Type = D3D12_RESOURCE_BARRIER_TYPE_TRANSITION;
	bd.Flags = D3D12_RESOURCE_BARRIER_FLAG_NONE;
	bd.Transition.pResource = m_backBuffers[bbIndex];
	bd.Transition.StateBefore = D3D12_RESOURCE_STATE_PRESENT;
	bd.Transition.StateAfter = D3D12_RESOURCE_STATE_RENDER_TARGET;
	bd.Transition.Subresource = 0;
	m_commandList->ResourceBarrier(1, &bd);

	m_commandList->OMSetRenderTargets(1, &rtvHeap, true, nullptr);
	float clearColor[] = { 0.25f,0.2f,0.25f,0 };
	m_commandList->ClearRenderTargetView(rtvHeap, clearColor, 0, nullptr);

	bd.Transition.StateBefore = D3D12_RESOURCE_STATE_RENDER_TARGET;
	bd.Transition.StateAfter = D3D12_RESOURCE_STATE_PRESENT;
	m_commandList->ResourceBarrier(1, &bd);

	m_commandList->Close();
	ID3D12CommandList* cmdLists[] = { m_commandList.get() };

	m_commandQueue->ExecuteCommandLists(1, cmdLists);

	m_commandQueue->Signal(m_fence.get(), ++m_febceValue);
	if (m_fence->GetCompletedValue() != m_febceValue)
	{
		auto event = CreateEvent(nullptr, false, false, nullptr);
		m_fence->SetEventOnCompletion(m_febceValue, event);
		WaitForSingleObject(event, INFINITE);
		CloseHandle(event);
	}

	m_allocator->Reset();
	m_commandList->Reset(m_allocator.get(), nullptr);
	m_swapChain->Present(1, 0);

	return true;
}

bool D3D12Renderer::D3D12Manager::TestVertexCreate()
{
	Vector3 vertices[] =
	{
		{-1.0f,-1.0f,0.0f},
		{-1.0f,1.0f,0.0f},
		{1.0f,-1.0f,0.0f}
	};

	D3D12_HEAP_PROPERTIES hp;
	SecureZeroMemory(&hp, sizeof(D3D12_HEAP_PROPERTIES));
	hp.Type = D3D12_HEAP_TYPE_UPLOAD;
	hp.CPUPageProperty = D3D12_CPU_PAGE_PROPERTY_UNKNOWN;
	hp.MemoryPoolPreference = D3D12_MEMORY_POOL_UNKNOWN;

	D3D12_RESOURCE_DESC rs;
	SecureZeroMemory(&rs, sizeof(D3D12_RESOURCE_DESC));
	rs.Dimension = D3D12_RESOURCE_DIMENSION_BUFFER;
	rs.Width = sizeof(vertices); //vertex size.
	rs.Height = 1;
	rs.DepthOrArraySize = 1;
	rs.MipLevels = 1;
	rs.Format = DXGI_FORMAT_UNKNOWN;
	rs.SampleDesc.Count = 1;
	rs.Flags = D3D12_RESOURCE_FLAG_NONE;
	rs.Layout = D3D12_TEXTURE_LAYOUT_ROW_MAJOR;

	ID3D12Resource2* vb = nullptr;
	auto result = m_device->CreateCommittedResource(&hp, D3D12_HEAP_FLAG_NONE, &rs,
		D3D12_RESOURCE_STATE_GENERIC_READ, nullptr, IID_PPV_ARGS(&vb));

	if (result != S_OK)
	{
		return false;
	}
	m_vertex.reset(vb);


	Vector3* vertMap = nullptr;
	result = m_vertex->Map(0, nullptr, (void**)&vertMap);
	std::copy(std::begin(vertices), std::end(vertices), vertMap);
	m_vertex->Unmap(0, nullptr);



	return true;
}
