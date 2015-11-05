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

using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.VineClient
{
    [DataContract]
    [DebuggerDisplay("Response")]
    public class Response<T>
    {
        public Response(string code, T data, bool success, string error)
        {
            Code = code;
            Data = data;
            Success = success;
            Error = error;
        }

        [DataMember]
        [JsonProperty("code")]
        public string Code { get; private set; }

        [DataMember]
        [JsonProperty("data")]
        public T Data { get; private set; }

        [DataMember]
        [JsonProperty("success")]
        public bool Success { get; private set; }

        [DataMember]
        [JsonProperty("error")]
        public string Error { get; private set; }
    }
}