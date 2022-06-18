// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "D3D12Manager.h"

using namespace std;
using namespace D3D12Renderer;

D3D12Manager D3D12Manager::s_instance;

D3D12Renderer::D3D12Manager::D3D12Manager()
{

}

D3D12Renderer::D3D12Manager::~D3D12Manager()
{
	m_allocator.reset();
	m_commandList.reset();
	m_swapChain.reset();
	m_factory.reset();
	m_device.reset();
}

bool D3D12Renderer::D3D12Manager::Initialize()
{
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

	InitializeCommands();

	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeCommands()
{
	ID3D12CommandAllocator* allocator = nullptr;
	ID3D12GraphicsCommandList6* commandList = nullptr;

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

	m_allocator.reset(allocator);
	m_commandList.reset(commandList);

	return true;
}

bool D3D12Renderer::D3D12Manager::InitializeSwapChain(McEnCore::whandle windowHandle)
{
	DXGI_SWAP_CHAIN_DESC1 desc;
	SecureZeroMemory(&desc, sizeof(DXGI_SWAP_CHAIN_DESC1));

	RECT rect;
	SecureZeroMemory(&rect, sizeof(RECT));
	GetWindowRect(windowHandle, &rect);

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

	auto result = m_factory.get()->CreateSwapChainForHwnd(m_commandList.get(), windowHandle, &desc,
		nullptr, nullptr, reinterpret_cast<IDXGISwapChain1**>(m_swapChain.get()));


	return result == S_OK;
}
