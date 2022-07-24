// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#define WIN32_LEAN_AND_MEAN             // Windows ヘッダーからほとんど使用されていない部分を除外する

#if _WIN32 | _WIN64
#include<Windows.h> //Windows only
#endif

#include<tchar.h>
#include<string>
#include<memory>
#include<vector>

namespace McEnCore
{
	//http://marupeke296.com/TIPS_No14_tstring.html
	typedef std::basic_string<TCHAR> tstring;

	//Pointer string.
	typedef LPTSTR ptstring;

	//Const string.
	typedef LPCTSTR ctstring;

	//Engine runtime guid.
	typedef std::uint32_t UniqueID;
	const UniqueID INVALID_UNIQUEID = 0;

	typedef bool bool8;
	typedef BYTE byte;
	typedef float float32;
	typedef double double64;
	typedef unsigned char uint8;
	typedef unsigned __int32 uint32;
	typedef unsigned __int64 uint64;
	typedef __int32 int32;
	typedef __int64 int64;
	typedef HWND whandle;
	typedef WPARAM wparam;
	typedef LPARAM lparam;
	typedef LARGE_INTEGER longlong64;
}