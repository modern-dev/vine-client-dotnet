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
    [DebuggerDisplay("Session {Username} {UserId}")]
    public class Session : IVineModel
    {
        [DataMember]
        [JsonProperty("username")]
        public string Username { get; private set; }

        [DataMember]
        [JsonProperty("avatarUrl")]
        public string Avatar { get; private set; }

        [DataMember]
        [JsonProperty("userId")]
        public long UserId { get; private set; }
        
        [DataMember]
        [JsonProperty("edition")]
        public string Edition { get; private set; }
        
        [DataMember]
        [JsonProperty("key")]
        public string Key { get; private set; }

        [DataMember]
        [JsonProperty("clientFlags")]
        public ClientFlags ClientFlags { get; private set; }
    }
}