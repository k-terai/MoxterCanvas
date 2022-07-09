// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace McEdShare.CoreSystem
{
    internal static class AssemblyUtility
    {
        public static List<Type> GetMatchAttributeTypesFromExecutingAssembly<T>()
           where T : Attribute
        {
            var asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes().Where(t => t.GetCustomAttribute<T>() != null).ToList();
        }

        public static T CreateInstance<T>(string fullName) where T : class
        {
            var asm = Assembly.GetExecutingAssembly();
            return asm.CreateInstance(fullName) as T;
        }
    }
}
