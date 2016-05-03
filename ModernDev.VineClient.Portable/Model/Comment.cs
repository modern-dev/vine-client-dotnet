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
    [DebuggerDisplay("Comment {Text}")]
    [DataContract]
    public class Comment : VineItem
    {
        [DataMember]
        [JsonProperty("comment")]
        public string Text { get; set; }

        [DataMember]
        [JsonProperty("user")]
        public User User { get; set; }

        [DataMember]
        [JsonProperty("commentId")]
        public long CommentId { get; set; }

        [DataMember]
        [JsonProperty("postId")]
        public long PostId { get; set; }
    }
}