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
    [DebuggerDisplay("Like {UserName}")]
    [DataContract]
    public class Like : VineItem
    {
        [DataMember]
        [JsonProperty("user")]
        public User User { get; set; }

        [DataMember]
        [JsonProperty("likeId")]
        public long LikeId { get; set; }
    }
}