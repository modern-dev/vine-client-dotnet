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
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.VineClient
{
    [DataContract]
    [DebuggerDisplay("Tag {Name}")]
    public class Tag : IVineModel
    {
        [DataMember]
        [JsonProperty("tagId")]
        public long Id { get; set; }

        [DataMember]
        [JsonProperty("tag")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("postCount")]
        public int PostCount { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        [DataMember]
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}