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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ModernDev.VineClient
{
    internal static class Utils
    {
        internal static string GetQueryString(Dictionary<string, string> queryParams)
            => string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}"));

        internal static void Add(this List<Tuple<string, object, bool>> @this, string str, object obj, bool boolean = false)
        {
            @this.Add(Tuple.Create(str, obj, boolean));
        }
    }
}