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
    /// <summary>
    /// A base class for working with tags.
    /// </summary>
    public sealed class TagsMethods : MethodsGroup
    {
        internal TagsMethods(VineClient apiClient) : base(apiClient, "tags")
        {
        }

        /// <summary>
        /// Gets a list of trending tags.
        /// </summary>
        /// <returns>Returns a list of <see cref="Tag"/> objects.</returns>
        public async Task<Response<RecordsList<Tag>>> GetTrending() => await Request<RecordsList<Tag>>("trending");

        /// <summary>
        /// Returns a list of tags matching the search criteria.
        /// </summary>
        /// <param name="query">Search query string.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Tag"/> objects.</returns>
        public async Task<Response<RecordsList<Tag>>> Search(string query, int? size = null, int? page = null,
            int? anchor = null)
            => await Request<RecordsList<Tag>>($"search/{query}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });
    }
}