// Copyright(c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#include"Platform.h"

namespace McEnCore
{
	struct InitialModuleContext
	{

	};

	struct Renderer_InitialModuleContext : InitialModuleContext
	{
		whandle Handle;
	};

	struct Framework_InitialModuleContext : InitialModuleContext
	{
		Renderer_InitialModuleContext RendererContext;
	};
}