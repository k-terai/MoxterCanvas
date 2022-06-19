// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "McFramework.h"
#include "RendererModule.h"

using namespace std;
using namespace McEnCore;
using namespace McEngine;

McFramework McFramework::s_instance;

bool McEngine::McFramework::Startup()
{
	//NOTE: Lib reference.
	m_renderer = D3D12Renderer::RendererModule::GetInstance();

	InitialModuleContext context;
	m_renderer->Startup(context);

	return true;
}

bool McEngine::McFramework::Initialize()
{
	return true;
}

bool McEngine::McFramework::Shutdown()
{
	m_renderer->Shutdown();

	m_renderer = nullptr;
	return true;
}
