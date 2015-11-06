/**
 * This file\code is part of VineClient project.
 *
 * VineClient - is an unofficial C# library for the Vine.
 * https://github.com/modern-dev/vine-client-dotnet
 *
 * Copyright (c) 2016 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModernDev.VineClient
{
    internal class PrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            if (!prop.Writable)
            {
                var property = member as PropertyInfo;

                if (property != null)
                {
                    var hasPrivateSetter = property.SetMethod != null;
                    prop.Writable = hasPrivateSetter;
                }
            }

            return prop;
        }
    }
}