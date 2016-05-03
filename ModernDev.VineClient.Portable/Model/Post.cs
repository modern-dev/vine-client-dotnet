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
    [DebuggerDisplay("Post {Description}")]
    public class Post : VineItem
    {
        [DataMember]
        [JsonProperty("promoted")]
        public bool Promoted { get; set; }

        [DataMember]
        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [DataMember]
        [JsonProperty("videoDashUrl")]
        public string VideoDashUrl { get; set; }

        [DataMember]
        [JsonProperty("foursquareVenueId")]
        public string FoursquareVenueId { get; set; }

        [DataMember]
        [JsonProperty("videoWebmUrl")]
        public string VideoWebmUrl { get; set; }

        [DataMember]
        [JsonProperty("loops")]
        public Loops Loops { get; set; }

        [DataMember]
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [DataMember]
        [JsonProperty("explicitContent")]
        public bool ExplicitContent { get; set; }

        [DataMember]
        [JsonProperty("blocked")]
        public bool Blocked { get; set; }

        [DataMember]
        [JsonProperty("comments")]
        public RecordsList<Comment> Comments { get; set; }

        [DataMember]
        [JsonProperty("videoLowURL")]
        public string VideoLowUrl { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }
        // tags

        [DataMember]
        [JsonProperty("permalinkUrl")]
        public string PermalinkUrl { get; set; }

        [DataMember]
        [JsonProperty("hasRemixes")]
        public bool HasRemixes { get;set; }

        [DataMember]
        [JsonProperty("postId")]
        public long PostId { get; set; }

        [DataMember]
        [JsonProperty("videoUrl")]
        public string VideoUrl { get; set; }

        [DataMember]
        [JsonProperty("followRequested")]
        public bool FollowRequested { get; set; }

        [DataMember]
        [JsonProperty("hasSimilarPosts")]
        public bool HasSimilarPosts { get; set; }

        [DataMember]
        [JsonProperty("shareUrl")]
        public string ShareUrl { get; set; }

        [DataMember]
        [JsonProperty("myRepostId")]
        public long MyRepostId { get; set; }

        [DataMember]
        [JsonProperty("following")]
        public bool Following { get; set; }

        [DataMember]
        [JsonProperty("reposts")]
        public RecordsList<Repost> Reposts { get; set; }

        [DataMember]
        [JsonProperty("likes")]
        public RecordsList<Like> Likes { get; set; }
    }
}