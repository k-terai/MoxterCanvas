// Copyright(c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "RendererModule.h"
#include"D3D12Manager.h"

using namespace std;
using namespace D3D12Renderer;
using namespace McEnCore;

RendererModule RendererModule::s_instance;

bool D3D12Renderer::RendererModule::Startup(McEnCore::InitialModuleContext context)
{
	return true;
}

void D3D12Renderer::RendererModule::Shutdown()
{

}

bool D3D12Renderer::RendererModule::Initialize(McEnCore::InitialModuleContext context)
{
	D3D12Manager::GetInstance()->Initialize();
	return true;
}
