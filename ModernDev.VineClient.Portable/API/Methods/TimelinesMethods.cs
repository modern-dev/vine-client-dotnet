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

namespace ModernDev.VineClient.API.Methods
{
    /// <summary>
    /// A base class for working with timelines.
    /// </summary>
    public sealed class TimelinesMethods : MethodsGroup
    {
        internal TimelinesMethods(VineClient apiClient) : base(apiClient, "timelines")
        {
        }

        /// <summary>
        /// Returns a post by its Id.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetPostById(long postId, int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>($"posts/{postId}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of posts from user by user Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetUserTimeline(long userId, int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>($"users/{userId}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of posts liked by user with specified user Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetUserLikes(long userId, int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>($"users/{userId}/likes", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of posts by specified tag name.
        /// </summary>
        /// <param name="tagName">Tag name.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetTagTimeline(string tagName, int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>($"tags/{tagName}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of posts from the main timeline.
        /// </summary>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetMainTimeline(int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>("graph", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of popular posts.
        /// </summary>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetPopular(int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>("popular", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of trending posts.
        /// </summary>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetTrending(int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>("trending", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of promoted posts.
        /// </summary>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetPromoted(int? size = null, int? page = null,
            string anchor = null)
            => await Request<RecordsList<Post>>("promoted", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of popular posts from a channel.
        /// </summary>
        /// <param name="channelId">Channel Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetChannelPopular(long channelId, int? size = null,
            int? page = null, string anchor = null)
            => await Request<RecordsList<Post>>($"channels/{channelId}/popular", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of recent posts from a channel.
        /// </summary>
        /// <param name="channelId">Channel Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetChannelRecent(long channelId, int? size = null,
            int? page = null, string anchor = null)
            => await Request<RecordsList<Post>>($"channels/{channelId}/recent", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of venues posts.
        /// </summary>
        /// <param name="venueId">Venue Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetVenue(long venueId, int? size = null,
            int? page = null, string anchor = null)
            => await Request<RecordsList<Post>>($"venues/{venueId}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });

        /// <summary>
        /// Returns a list of similar posts by given post Id.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="Post"/> objects.</returns>
        public async Task<Response<RecordsList<Post>>> GetSimilar(long postId, int? size = null,
            int? page = null, string anchor = null)
            => await Request<RecordsList<Post>>($"similar/post/{postId}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });
    }
}