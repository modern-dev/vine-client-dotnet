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

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.VineClient
{
    public class Response<T> : IVineModel where T : IVineModel
    {
        [DataMember]
        [JsonProperty("code")]
        public string Code { get; set; }

        [DataMember]
        [JsonProperty("data")]
        public T Data { get; set; }

        [DataMember]
        [JsonProperty("success")]
        public bool Success { get; set; }

        [DataMember]
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}