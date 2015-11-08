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

using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ModernDev.VineClient
{
    internal static class Utils
    {
        internal static Dictionary<string, string> NormalizeRequestParams(Dictionary<string, object> reqParams)
            => reqParams.Where(kvp => kvp.Value != null).ToDictionary(kvp => kvp.Key, kvp => ObjToStr(kvp.Value));

        internal static string GetQueryString(Dictionary<string, string> queryParams)
            => string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}"));

        internal static string ObjToStr(object obj)
        {
            if (obj is bool)
            {
                return (bool)obj ? "1" : "0";
            }

            return obj.ToString();
        }
    }
}