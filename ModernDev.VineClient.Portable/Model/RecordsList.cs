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
    [DebuggerDisplay("RecordsList")]
    public class RecordsList<T> : IVineModel where T : IVineModel
    {
        [DataMember]
        [JsonProperty("count")]
        public int Count { get; set; }

        [DataMember]
        [JsonProperty("anchorStr")]
        public string AnchorString { get; set; }

        [DataMember]
        [JsonProperty("records")]
        public List<T> Records { get; set; }

        [DataMember]
        [JsonProperty("previousPage")]
        public string PreviousPage { get; set; }

        [DataMember]
        [JsonProperty("backAnchor")]
        public string BackAnchor { get; set; }

        [DataMember]
        [JsonProperty("anchor")]
        public string Anchor { get; set; }

        [DataMember]
        [JsonProperty("nextPage")]
        public string NextPage { get; set; }

        [DataMember]
        [JsonProperty("size")]
        public int Size { get; set; }

        [DataMember]
        [JsonProperty("channel")]
        public Channel Channel { get; set; }
    }
}