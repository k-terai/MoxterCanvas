// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#define WIN32_LEAN_AND_MEAN             // Windows ヘッダーからほとんど使用されていない部分を除外する

#include"Module/IRendererModule.h"
#include"Module/ModuleContexts.h"

namespace McEngine 
{
	class McFramework 
	{
	public:
		bool Startup();
		bool Initialize(McEnCore::Framework_InitialModuleContext context);
		bool Shutdown();

		static inline McFramework* const GetInstance() { return &s_instance; }

	private:
		static McFramework s_instance;

		McEnCore::IRendererModule* m_renderer;
	};
}