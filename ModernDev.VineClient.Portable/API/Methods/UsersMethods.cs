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
    /// A base class for working with users.
    /// </summary>
    public sealed class UsersMethods : MethodsGroup
    {
        internal UsersMethods(VineClient apiClient) : base(apiClient, "users")
        {
        }

        /// <summary>
        /// Returns detailed information on the current user.
        /// </summary>
        /// <returns>Returns an <see cref="User"/> object.</returns>
        public async Task<Response<User>> GetMe() => await Request<User>("me");

        /// <summary>
        /// Returns detailed information on the user with specified Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns an <see cref="User"/> object.</returns>
        public async Task<Response<User>> GetUserById(long userId) => await Request<User>($"profiles/{userId}");

        /// <summary>
        /// Allows to edit the current account info.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="description">Account description.</param>
        /// <param name="location">Location.</param>
        /// <param name="locale">Locale.</param>
        /// <param name="privateProfile">Whether the profile is private.</param>
        /// <param name="phoneNumber">Phone number.</param>
        /// <returns>Returns an <see cref="User"/> object.</returns>
        public async Task<Response<User>> UpdateProfile(long userId, string description = null, string location = null,
            string locale = null, bool privateProfile = false, string phoneNumber = null)
            => await Request<User>($"{userId}", "post", new MethodParams
            {
                {"description", description},
                {"location", location},
                {"locale", locale},
                {"private", privateProfile},
                {"phoneNumber", phoneNumber}
            });

        /// <summary>
        /// Sets explicit profile to true.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> SetExplicit(long userId)
            => await Request<Empty>($"{userId}/explicit", "post");

        /// <summary>
        /// Sets explicit profile to false.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> UnsetExplicit(long userId)
            => await Request<Empty>($"{userId}/explicit", "delete");

        /// <summary>
        /// Follows the user with given Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Follow(int userId) => await Request<Empty>($"{userId}/followers", "post");

        /// <summary>
        /// Unfollows the user with given Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Unollow(int userId) => await Request<Empty>($"{userId}/followers", "delete");

        /// <summary>
        /// Blocks the user with given Id.
        /// </summary>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Block(long fromUserId, long toUserId)
            => await Request<Empty>($"{fromUserId}/blocked/{toUserId}", "post");

        /// <summary>
        /// Unblocks the user with given Id.
        /// </summary>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Unlock(long fromUserId, long toUserId)
            => await Request<Empty>($"{fromUserId}/blocked/{toUserId}", "delete");

        /// <summary>
        /// Returns the number of pending notifications.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns the number of pending notifications.</returns>
        public async Task<Response<int>> GetPendingNotificationsCount(long userId)
            => await Request<int>($"{userId}/pendingNotificationsCount");

        /// <summary>
        /// Returns a list of notifications.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns a list of <see cref="Notification"/> objects.</returns>
        public async Task<Response<RecordsList<Notification>>> GetNotifications(long userId)
            => await Request<RecordsList<Notification>>($"{userId}/notifications");

        /// <summary>
        /// Returns a list of followers of the user with given Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns a list of <see cref="User"/> objects.</returns>
        public async Task<Response<RecordsList<User>>> GetFollowers(long userId)
            => await Request<RecordsList<User>>($"{userId}/followers");

        /// <summary>
        /// Returns a list of users following by the user with given Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Returns a list of <see cref="User"/> objects.</returns>
        public async Task<Response<RecordsList<User>>> GetFollowing(long userId)
            => await Request<RecordsList<User>>($"{userId}/following");

        /// <summary>
        /// Returns a list of users matching the search criteria.
        /// </summary>
        /// <param name="query">Search query string.</param>
        /// <param name="size">Number of tags per page to return.</param>
        /// <param name="page">Page number.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>Returns a list of <see cref="User"/> objects.</returns>
        public async Task<Response<RecordsList<User>>> Search(string query, int? size = null, int? page = null,
            string anchor = null) => await Request<RecordsList<User>>($"search/{query}", methodParams: new MethodParams
            {
                {"size", size},
                {"page", page},
                {"anchor", anchor}
            });
    }
}