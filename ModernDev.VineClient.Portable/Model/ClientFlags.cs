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
    [DebuggerDisplay("ClientFlags")]
    public class ClientFlags : IVineModel
    {
        [DataMember]
        [JsonProperty("findPeopleTabs")]
        public List<string> FindPeopleTabs { get; private set; }

        [DataMember]
        [JsonProperty("shouldRenux")]
        public bool ShouldRenux { get; private set; }

        [DataMember]
        [JsonProperty("nuxHideFriendsFinder")]
        public bool NuxHideFriendsFinder { get; private set; }

        [DataMember]
        [JsonProperty("useHeartIcons")]
        public bool UseHeartIcons { get; private set; }

        [DataMember]
        [JsonProperty("followSuggestionsSelectAll")]
        public bool FollowSuggestionsSelectAll { get; private set; }

        [DataMember]
        [JsonProperty("followSuggestions")]
        public bool FollowSuggestions { get; private set; }

        [DataMember]
        [JsonProperty("pinchZoomEnabled")]
        public bool PinchZoomEnabled { get; private set; }

        [DataMember]
        [JsonProperty("audioNumChannels")]
        public int? AudioNumChannels { get; private set; }

        [DataMember]
        [JsonProperty("audioRemix")]
        public bool AudioRemix { get; private set; }

        [DataMember]
        [JsonProperty("profile_sorting")]
        public bool ProfileSorting { get; private set; }

        [DataMember]
        [JsonProperty("similarPosts")]
        public bool SimilarPosts { get; private set; }

        [DataMember]
        [JsonProperty("scribeEnabled")]
        public bool ScribeEnabled { get; private set; }

        [DataMember]
        [JsonProperty("disableContactsTwitterPrompt")]
        public bool DisableContactsTwitterPrompt { get; private set; }

        [DataMember]
        [JsonProperty("useDigitsForPhoneVerification")]
        public bool UseDigitsForPhoneVerification { get; private set; }

        [DataMember]
        [JsonProperty("nuxHideChannelPicker")]
        public bool NuxHideChannelPicker { get; private set; }

        [DataMember]
        [JsonProperty("welcomeFeedExitUrl")]
        public string WelcomeFeedExitUrl { get; private set; }

        [DataMember]
        [JsonProperty("show_custom_rating_view")]
        public bool ShowCustomRatingView { get; private set; }

        [DataMember]
        [JsonProperty("nuxShowWelcomeFeed")]
        public bool NuxShowWelcomeFeed { get; private set; }

        [DataMember]
        [JsonProperty("audioUploadBitrate")]
        public int? AudioUploadBitrate { get; private set; }

        [DataMember]
        [JsonProperty("wideFoVEnabled")]
        public bool WideFoVEnabled { get; private set; }

        [DataMember]
        [JsonProperty("channelsSelectAll")]
        public bool ChannelsSelectAll { get; private set; }

        [DataMember]
        [JsonProperty("showDeleteCommentsInComplaints")]
        public bool ShowDeleteCommentsInComplaints { get; private set; }

        [DataMember]
        [JsonProperty("maxContentCacheSize")]
        public int? MaxContentCacheSize { get; private set; }

        [DataMember]
        [JsonProperty("sectionedSearch")]
        public bool SectionedSearch { get; private set; }

        [DataMember]
        [JsonProperty("disableMuteSwitchOnVolumeChanged")]
        public bool DisableMuteSwitchOnVolumeChanged { get; private set; }

        [DataMember]
        [JsonProperty("canViewPostSources")]
        public bool CanViewPostSources { get; private set; }
    }
}