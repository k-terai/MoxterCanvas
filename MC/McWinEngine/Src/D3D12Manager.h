// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#pragma comment(lib,"d3d12.lib")
#pragma comment(lib,"dxgi.lib")

#include<d3d12.h>
#include<dxgi1_6.h>

#include"Platform.h"
#include"Macro.h"
#include"PtrDeleter.h"

namespace McWinEngine
{
	class D3D12Manager
	{
	public:
		D3D12Manager();
		~D3D12Manager();
		bool Initialize(const McEnCore::whandle handle);

		static inline D3D12Manager* const GetInstance() { return &s_instance; }

	private:
		DISALLOW_COPY_AND_ASSIGN(D3D12Manager);

		bool InitializeFactory();
		bool InitializeCommands();
		bool InitializeSwapChain(McEnCore::whandle windowHandle);
		bool InitializeRenderTargetView();
		bool InitializeFence();

		bool EnableDebugLayer();
		bool TestClearRenderTarget();
		bool TestVertexCreate();

	private:
		static D3D12Manager s_instance;

		D3D_FEATURE_LEVEL m_featureLevel;
		std::unique_ptr<ID3D12Device8, McEnCore::Release_Deleter> m_device;
		std::unique_ptr<IDXGIFactory7, McEnCore::Release_Deleter> m_factory;
		std::unique_ptr<ID3D12CommandAllocator, McEnCore::Release_Deleter> m_allocator;
		std::unique_ptr<ID3D12GraphicsCommandList6, McEnCore::Release_Deleter> m_commandList;
		std::unique_ptr<ID3D12CommandQueue, McEnCore::Release_Deleter> m_commandQueue;
		std::unique_ptr<IDXGISwapChain4, McEnCore::Release_Deleter> m_swapChain;
		std::unique_ptr<ID3D12DescriptorHeap, McEnCore::Release_Deleter> m_rtvHeap;
		std::unique_ptr<ID3D12Fence1, McEnCore::Release_Deleter> m_fence;
		std::vector<ID3D12Resource2*> m_backBuffers;
		std::unique_ptr<ID3D12Resource2, McEnCore::Release_Deleter> m_vertex;

		McEnCore::uint64 m_febceValue;
	};
}