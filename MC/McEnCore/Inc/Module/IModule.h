// Copyright(c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#include"ModuleContexts.h"

namespace McEnCore
{
	class IModule
	{
	public:
		virtual ~IModule() {}
		
		virtual bool Startup(InitialModuleContext* const context) = 0;
		virtual void Shutdown() = 0;

		virtual bool Initialize(InitialModuleContext* const context) = 0;
	};
}