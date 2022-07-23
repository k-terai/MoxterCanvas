// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#define WIN32_LEAN_AND_MEAN             // Windows ヘッダーからほとんど使用されていない部分を除外する
// Windows ヘッダー ファイル
#include"Platform.h"

#ifdef MCEDENGINE_EXPORTS
#define MCEDENGINE_API __declspec(dllexport)
#else
#define MCEDENGINE_API __declspec(dllimport)
#endif

using namespace McEnCore;

EXTERN_C MCEDENGINE_API bool8 McEdStartup();

EXTERN_C MCEDENGINE_API bool8 McEdShutdown();

EXTERN_C MCEDENGINE_API bool8 McEdInitialize();

EXTERN_C MCEDENGINE_API void McEdUpdate();
