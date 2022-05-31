// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace McEdShare.Serialization
{
    public static class Serializer
    {
        public static bool Serialize<T>(T file, string path) where T : SerializableBase
        {
            var att = typeof(T).GetCustomAttribute<SerializeAttribute>();

            switch (att.Type)
            {
                case SerializeAttribute.SerializeType.Json:
                    return JsonSerializer.ToJson(file, path);
            }

            return false;
        }

        public static T Deserialize<T>(string path) where T : SerializableBase
        {
            var att = typeof(T).GetCustomAttribute<SerializeAttribute>();

            switch (att.Type)
            {
                case SerializeAttribute.SerializeType.Json:
                    return JsonSerializer.FromJson<T>(path);
            }

            return null;
        }
    }
}
