// Copyright(c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#define WIN32_LEAN_AND_MEAN             // Windows ヘッダーからほとんど使用されていない部分を除外する

#include<memory>
#include"Module/IRendererModule.h"

namespace McWinEngine
{
	class RendererModule : public McEnCore::IRendererModule
	{
	public:
		virtual ~RendererModule() {}

		virtual bool Startup(McEnCore::InitialModuleContext* const context) override;
		virtual void Shutdown() override;
		virtual bool Initialize(McEnCore::InitialModuleContext* const context) override;

		static inline RendererModule* const GetInstance() { return &s_instance; }

	private:
		static RendererModule s_instance;
	};
}
