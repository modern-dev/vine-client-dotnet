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
    [DebuggerDisplay("Notification {Body}")]
    public class Notification : VineItem
    {
        [DataMember]
        [JsonProperty("body")]
        public string Body { get; set; }

        [DataMember]
        [JsonProperty("displayUserId")]
        public long DisplayUserId { get; set; }

        [DataMember]
        [JsonProperty("followRequested")]
        public bool FollowRequested { get; set; }

        [DataMember]
        [JsonProperty("following")]
        public bool Following { get; set; }

        [DataMember]
        [JsonProperty("notificationTypeId")]
        public int NotificationTypeId { get; set; }

        [DataMember]
        [JsonProperty("recipientUserId")]
        public long RecipientUserId { get; set; }

        [DataMember]
        [JsonProperty("notificationId")]
        public long NotificationId { get; set; }

        [DataMember]
        [JsonProperty("displayAvatarUrl")]
        public string DisplayAvatarUrl { get; set; }
    }
}