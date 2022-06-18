// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#pragma comment(lib,"d3d12.lib")
#pragma comment(lib,"dxgi.lib")

#include<d3d12.h>
#include<dxgi1_6.h>

#include<memory>

#include"Platform.h"
#include"Macro.h"
#include"PtrDeleter.h"

namespace D3D12Renderer
{
	class D3D12Manager
	{
	public:
		D3D12Manager();
		~D3D12Manager();
		bool Initialize();

		static inline D3D12Manager* const GetInstance() { return &s_instance; }

	private:
		DISALLOW_COPY_AND_ASSIGN(D3D12Manager);

		bool InitializeCommands();
		bool InitializeSwapChain(McEnCore::whandle windowHandle);


	private:
		static D3D12Manager s_instance;

		D3D_FEATURE_LEVEL m_featureLevel;
		std::unique_ptr<ID3D12Device8, Release_Deleter> m_device;
		std::unique_ptr<IDXGIFactory7, Release_Deleter> m_factory;
		std::unique_ptr<ID3D12CommandAllocator, Release_Deleter> m_allocator;
		std::unique_ptr<ID3D12GraphicsCommandList6, Release_Deleter> m_commandList;
		std::unique_ptr<IDXGISwapChain4, Release_Deleter> m_swapChain;
	};
}