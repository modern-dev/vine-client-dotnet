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
    /// A base class for working with posts.
    /// </summary>
    public sealed class PostsMethods : MethodsGroup
    {
        internal PostsMethods(VineClient apiClient) : base(apiClient, "posts")
        {
        }

        /// <summary>
        /// Adds the post to the <c>Likes</c> list of the current user.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Returns a <see cref="Like"/> object.</returns>
        public async Task<Response<Like>> LikePost(long postId) => await Request<Like>($"{postId}/likes", "post");

        /// <summary>
        /// Deletes the post from the <c>Likes</c> list of the current user.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> DeleteLike(long postId)
            => await Request<Empty>($"{postId}/likes", "delete");

        /// <summary>
        /// Adds a comment to a post.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <param name="comment">Comment text.</param>
        /// <param name="entities">Entities.</param>
        /// <returns>Returns a <see cref="Comment"/> object.</returns>
        public async Task<Response<Comment>> CreateComment(long postId, string comment, string entities = null)
            => await Request<Comment>($"{postId}/comments", "post", new MethodParams
            {
                {"comment", comment, true},
                {"entities", entities}
            });

        /// <summary>
        /// Deletes a comment on a post.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <param name="commentId">Comment Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> DeleteComment(long postId, long commentId)
            => await Request<Empty>($"{postId}/comments/{commentId}", "delete");

        /// <summary>
        /// Revines a post.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <returns>Returns a <see cref="Repost"/> object.</returns>
        public async Task<Response<Repost>> Revine(long postId) => await Request<Repost>($"{postId}/repost", "post");

        /// <summary>
        /// Unrevines a post.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <param name="revineId">Revine Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Unrevine(long postId, long revineId)
            => await Request<Empty>($"{postId}/repost/{revineId}", "delete");

        /// <summary>
        /// Reports (submits a complaint about) a post.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Report(long postId) => await Request<Empty>($"{postId}/complaints", "post");

        /// <summary>
        /// Adds a new post.
        /// </summary>
        /// <param name="videoUrl">Uploaded video URL.</param>
        /// <param name="thumbnailUrl">Uploaded thumbnail URL.</param>
        /// <param name="description">Vine description.</param>
        /// <param name="entities">Entities.</param>
        /// <param name="forsquareVenueId">Forsquare venue Id.</param>
        /// <param name="venueName">Venue name.</param>
        /// <param name="channelId">Channel Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Post(string videoUrl, string thumbnailUrl, string description,
            string entities = null, long? forsquareVenueId = null, string venueName = null, long? channelId = null)
            => await Request<Empty>("", "post", new MethodParams
            {
                {"videoUrl", videoUrl, true},
                {"thumbnailUrl", thumbnailUrl, true},
                {"description", description, true},
                {"entities", entities},
                {"forsquareVenueId", forsquareVenueId},
                {"venueName", venueName},
                {"channelId", channelId}
            });

        /// <summary>
        /// Deletes a post by given post Id.
        /// </summary>
        /// <param name="postId">Post Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Delete(long postId) => await Request<Empty>($"{postId}", "delete");
    }
}