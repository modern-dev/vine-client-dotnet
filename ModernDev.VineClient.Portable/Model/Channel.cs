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
    [DebuggerDisplay("Channel")]
    public class Channel : IVineModel
    {
        [DataMember]
        [JsonProperty("featuredChannelId")]
        public long FeaturedChannelId { get; set; }

        [DataMember]
        [JsonProperty("channelId")]
        public long ChannelId { get; set; }

        [DataMember]
        [JsonProperty("showRecent")]
        public bool ShowRecent { get; set; }

        [DataMember]
        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [DataMember]
        [JsonProperty("fontColor")]
        public string FontColor { get; set; }

        [DataMember]
        [JsonProperty("event")]
        public bool Event { get; set; }

        [DataMember]
        [JsonProperty("exploreName")]
        public string ExploreName { get; set; }

        [DataMember]
        [JsonProperty("exploreIconFullUrl")]
        public string ExploreIconFullUrl { get; set; }

        [DataMember]
        [JsonProperty("backgroundImageUrl")]
        public string BackgroundImageUrl { get; set; }

        [DataMember]
        [JsonProperty("vanityUrl")]
        public string VanityUrl { get; set; }

        [DataMember]
        [JsonProperty("priority")]
        public int Priority { get; set; }

        [DataMember]
        [JsonProperty("exploreRetinaIconFullUrl")]
        public string ExploreRetinaIconFullUrl { get; set; }

        [DataMember]
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [DataMember]
        [JsonProperty("channel")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty("iconFullUrl")]
        public string IconFullUrl { get; set; }

        [DataMember]
        [JsonProperty("editionCode")]
        public string EditionCode { get; set; }

        [DataMember]
        [JsonProperty("retinaIconFullUrl")]
        public string RetinaIconFullUrl { get; set; }

        [DataMember]
        [JsonProperty("exploreRetinaIconUrl")]
        public string ExploreRetinaIconUrl { get; set; }

        [DataMember]
        [JsonProperty("retinaIconUrl")]
        public string RetinaIconUrl { get; set; }

        [DataMember]
        [JsonProperty("splashTimelineId")]
        public long SplashTimelineId { get; set; }

        [DataMember]
        [JsonProperty("secondaryColor")]
        public string SecondaryColor { get; set; }

        [DataMember]
        [JsonProperty("exploreIconUrl")]
        public string ExploreIconUrl { get; set; }
    }
}
