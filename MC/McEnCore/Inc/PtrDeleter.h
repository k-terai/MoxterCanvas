// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#include<unknwn.h>

namespace McEnCore
{
	struct Release_Deleter
	{
		void operator() (IUnknown* ptr) { if (ptr) ptr->Release(); }
	};
}

