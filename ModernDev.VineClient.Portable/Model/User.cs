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
    [DebuggerDisplay("User {UserName}")]
    public class User
    {
        [DataMember]
        [JsonProperty("username")]
        public string UserName { get; set; }

        [DataMember]
        [JsonProperty("twitterScreenname")]
        public string TwitterScreenName { get; set; }

        [DataMember]
        [JsonProperty("followerCount")]
        public int FollowerCount { get; set; }

        [DataMember]
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [DataMember]
        [JsonProperty("vanityUrls")]
        public List<string> VanityUrls { get; set; }

        [DataMember]
        [JsonProperty("loopCount")]
        public long LoopCount { get; set; }

        [DataMember]
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [DataMember]
        [JsonProperty("twitterVerified")]
        public bool TwitterVerified { get; set; }

        [DataMember]
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [DataMember]
        [JsonProperty("profileBackground")]
        public string ProfileBackground { get; set; }

        [DataMember]
        [JsonProperty("location")]
        public string Location { get; set; }

        [DataMember]
        [JsonProperty("user")]
        public UserSettings UserSettings { get; set; }
    }
}