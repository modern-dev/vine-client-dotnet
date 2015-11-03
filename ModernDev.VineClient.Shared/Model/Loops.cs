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
    [DebuggerDisplay("Loops")]
    public class Loops : IVineModel
    {
        [DataMember]
        [JsonProperty("count")]
        public double Count { get; set; }

        [DataMember]
        [JsonProperty("velocity")]
        public double Velocity { get; set; }

        [DataMember]
        [JsonProperty("onFire")]
        public bool OnFire { get; set; }
    }
}
