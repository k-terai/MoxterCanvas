// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "D3D12Manager.h"

using namespace std;
using namespace McEngine;

D3D12Manager D3D12Manager::s_instance;

McEngine::D3D12Manager::D3D12Manager()
{

}

McEngine::D3D12Manager::~D3D12Manager()
{
	m_device.reset();
}

bool McEngine::D3D12Manager::Initialize()
{
	D3D_FEATURE_LEVEL levels[] =
	{
		D3D_FEATURE_LEVEL_12_1,
		D3D_FEATURE_LEVEL_12_0
	};

	ID3D12Device8* device = nullptr;

	for (auto lv : levels)
	{
		if (D3D12CreateDevice(nullptr, lv, IID_PPV_ARGS(&device)) == S_OK) 
		{
			break;
		}
	}

	if (device == nullptr) 
	{
		return false;
	}

	m_device.reset(device);
	return true;
}
