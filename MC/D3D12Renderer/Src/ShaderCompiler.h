// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#include<d3dcompiler.h>
#pragma comment(lib,"d3dcompiler.lib")

#include"Platform.h"
#include"Macro.h"
#include"PtrDeleter.h"
#include"EngineCommon.h"

namespace D3D12Renderer
{
	class ShaderCompiler
	{
	public:
		ShaderCompiler();
		~ShaderCompiler();

		static inline ShaderCompiler* const GetInstance() { return &s_instance; }

		static bool CompileFromFile(McEnCore::ctstring fileName,const McEnCore::ShaderType type);

	private:
		DISALLOW_COPY_AND_ASSIGN(ShaderCompiler);

	private:
		static ShaderCompiler s_instance;
	};
}