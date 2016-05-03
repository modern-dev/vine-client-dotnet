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
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.VineClient
{
    [DataContract]
    [DebuggerDisplay("Entity {Title}")]
    public class Entity : IVineModel
    {
        [DataMember]
        [JsonProperty("link")]
        public string Link { get; set; }

        [DataMember]
        [JsonProperty("range")]
        public List<int> Range { get; set; }

        [DataMember]
        [JsonProperty("type")]
        public string Type { get; set; }

        [DataMember]
        [JsonProperty("id")]
        public long Id { get; set; }

        [DataMember]
        [JsonProperty("title")]
        public string Title { get; set; } 
    }
}