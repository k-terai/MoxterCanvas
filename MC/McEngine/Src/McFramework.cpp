// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "McFramework.h"

#include"D3D12Manager.h"

using namespace std;
using namespace McEngine;

McFramework McFramework::s_instance;

bool McEngine::McFramework::Startup()
{
    D3D12Manager::GetInstance()->Initialize();
    return true;
}

bool McEngine::McFramework::Shutdown()
{
    return true;
}
