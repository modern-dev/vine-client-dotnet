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
    [DebuggerDisplay("User {UserName}")]
    public class User : VineItem
    {
        [DataMember]
        [JsonProperty("twitterScreenname")]
        public string TwitterScreenName { get; set; }

        [DataMember]
        [JsonProperty("followerCount")]
        public int FollowerCount { get; set; }

        [DataMember]
        [JsonProperty("loopCount")]
        public long LoopCount { get; set; }

        [DataMember]
        [JsonProperty("twitterVerified")]
        public bool TwitterVerified { get; set; }

        [DataMember]
        [JsonProperty("location")]
        public string Location { get; set; }

        [DataMember]
        [JsonProperty("user")]
        public User UserData { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty("notPorn")]
        public bool NotPorn { get; set; }

        [DataMember]
        [JsonProperty("hideFromPopular")]
        public bool HideFromPopular { get; set; }

        [DataMember]
        [JsonProperty("unflaggable")]
        public bool Unflaggable { get; set; }
    }
}