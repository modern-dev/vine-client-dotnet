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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.VineClient
{
    [DataContract]
    [DebuggerDisplay("VineItem {UserName}")]
    public abstract class VineItem : IVineModel
    {
        [DataMember]
        [JsonProperty("username")]
        public string UserName { get; set; }

        [DataMember]
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [DataMember]
        [JsonProperty("vanityUrls")]
        public List<string> VanityUrls { get; set; }

        [DataMember]
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [DataMember]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [DataMember]
        [JsonProperty("entities")]
        public List<Entity> Entities { get; set; }

        [DataMember]
        [JsonProperty("profileBackground")]
        public string ProfileBackground { get; set; }

        [DataMember]
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [DataMember]
        [JsonProperty("private")]
        public bool Private { get; set; }
    }
}