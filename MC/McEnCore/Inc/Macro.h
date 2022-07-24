// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#define SAFE_DELETE(p)       { if (p) { delete (p);     (p)=NULL; } }
#define SAFE_DELETE_ARRAY(p) { if (p) { delete[] (p);   (p)=NULL; } }
#define SAFE_RELEASE(p)      { if (p) { (p)->Release(); (p)=NULL; } }
#define SAFE_ADDREF(p)      { if (p) { (p)->AddRef(); } }
#define ARRAY_SIZE(_arr_) (sizeof(_arr_)/sizeof((_arr_)[0]))


#define DISALLOW_COPY_AND_ASSIGN(TypeName) \
TypeName(const TypeName&); \
void operator=(const TypeName&)

#define REGISTER_OBJECT_RTTI_HEADER(TypeName) \
public: \
virtual McEnCore::ctstring const ClassName() override {return UNIQUE_RTTI.GetClassName();}  \
protected: \
const virtual McEnCore::Rtti& GetRtti() const override {return UNIQUE_RTTI;} \
private: \
static const McEnCore::Rtti UNIQUE_RTTI;

#define REGISTER_OBJECT_RTTI_SOURCE(TypeName,ClassName) \
const McEnCore::Rtti TypeName::UNIQUE_RTTI(_T(ClassName));

#ifdef _DEBUG
#   define CustomOutputDebugString( str, ... ) \
      { \
        TCHAR c[256]; \
        _stprintf_s( c, str, __VA_ARGS__ ); \
        OutputDebugString( c ); \
      }
#else
#    define CustomOutputDebugString( str, ... )
#endif

#define RPROPERTY(...) \