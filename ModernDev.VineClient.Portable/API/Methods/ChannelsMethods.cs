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

using System.Threading.Tasks;

namespace ModernDev.VineClient
{
    public sealed class ChannelsMethods : MethodsGroup
    {
        internal ChannelsMethods(VineClient apiClient) : base(apiClient, "channels")
        {
        }

        /// <summary>
        /// Returns a list of featured channels.
        /// </summary>
        /// <returns>Returns a list of <see cref="Channel"/> objects.</returns>
        public async Task<Response<RecordsList<Channel>>> GetFeatured()
            => await Request<RecordsList<Channel>>("featured");
    }
}