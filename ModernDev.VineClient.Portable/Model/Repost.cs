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
    [DebuggerDisplay("Repost {UserName}")]
    public class Repost : Post
    {
        [DataMember]
        [JsonProperty("repostId")]
        public long RepostId { get; set; }
    }
}