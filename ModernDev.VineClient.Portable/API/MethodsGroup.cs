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

using System.Threading.Tasks;

namespace ModernDev.VineClient
{
    public class MethodsGroup
    {
        private readonly VineClient _apiClient;
        private readonly string _methodsGroup;

        internal MethodsGroup(VineClient apiClient, string methodsGroup)
        {
            _apiClient = apiClient;
            _methodsGroup = methodsGroup;
        }

        internal async Task<Response<T>> Request<T>(string methodName, string reqType = "get",
            MethodParams methodParams = null)
            => await _apiClient.Request<T>($"{_methodsGroup}/{methodName}", reqType, methodParams);
    }
}