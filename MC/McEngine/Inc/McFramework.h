// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#define WIN32_LEAN_AND_MEAN             // Windows ヘッダーからほとんど使用されていない部分を除外する

#include"ILibRenderer.h"

namespace McEngine 
{
	class McFramework 
	{
	public:
		bool Startup();
		bool Initialize();
		bool Shutdown();

		static inline McFramework* const GetInstance() { return &s_instance; }

	private:
		static McFramework s_instance;

		McEnCore::ILibRenderer* m_renderer;
	};
}