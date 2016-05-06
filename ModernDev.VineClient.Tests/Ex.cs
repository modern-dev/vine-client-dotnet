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

using System;
using System.Resources;
using RichardSzalay.MockHttp;
using static NUnit.Framework.Assert;

namespace ModernDev.VineClient.Tests
{
    public static class Ex
    {
        private static MockHttpMessageHandler WhenAndRespond(this MockHttpMessageHandler @this, string url, string json)
        {
            @this.When(url).Respond("application/json", json);

            return @this;
        }

        internal static ResourceManager Responses = MockJsonResponses.ResourceManager;

        public static VineClient GetMockedClient(string cat = null)
        {
            var mockHttp = new MockHttpMessageHandler();

            switch (cat)
            {
                case "basic":
                    mockHttp
                        .WhenAndRespond("/users/authenticate", Responses.GetString("authResponse"))
                        .WhenAndRespond("/users", Responses.GetString("authResponse"))
                        .WhenAndRespond("/some/url", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/some/url2", Responses.GetString("responseError"));
                    break;

                case "tags":
                    mockHttp
                        .WhenAndRespond("/tags/trending", Responses.GetString("tagsRecordsList"))
                        .WhenAndRespond("/tags/search/cat", Responses.GetString("tagsRecordsList"));
                    break;

                case "channels":
                    mockHttp.WhenAndRespond("/channels/featured", Responses.GetString("channelRecordsList"));
                    break;

                case "timelines":
                    mockHttp
                        .WhenAndRespond("/timelines/posts/1", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/users/1", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/users/1/likes", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/tags/cat", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/graph", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/popular", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/trending", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/promoted", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/channels/1/popular", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/channels/1/recent", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/venues/1", Responses.GetString("postsRecordsList"))
                        .WhenAndRespond("/timelines/similar/post/1", Responses.GetString("postsRecordsList"));
                    break;

                case "posts":
                    mockHttp
                        .WhenAndRespond("/posts/1/likes", Responses.GetString("likeResponse"))
                        .WhenAndRespond("/posts/1/comments", Responses.GetString("commentResponse"))
                        .WhenAndRespond("/posts/1/comments/1", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/posts/1/repost", Responses.GetString("repostResponse"))
                        .WhenAndRespond("/posts/1/repost/1", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/posts/1/complaints", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/posts", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/posts/1", Responses.GetString("emptyResponse"));
                    break;

                case "users":
                    mockHttp
                        .WhenAndRespond("/users/me", Responses.GetString("userResponse"))
                        .WhenAndRespond("/users/profiles/1", Responses.GetString("userResponse"))
                        .WhenAndRespond("/users/1", Responses.GetString("userResponse"))
                        .WhenAndRespond("/users/1/explicit", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/users/1/blocked/1", Responses.GetString("emptyResponse"))
                        .WhenAndRespond("/users/1/pendingNotificationsCount", Responses.GetString("notificationsCount"))
                        .WhenAndRespond("/users/1/notifications", Responses.GetString("notificationsRecordsList"))
                        .WhenAndRespond("/users/1/followers", Responses.GetString("usersRecordsList"))
                        .WhenAndRespond("/users/1/following", Responses.GetString("usersRecordsList"))
                        .WhenAndRespond("/users/search/virtyaluk", Responses.GetString("usersRecordsList"));
                    break;
            }

            return new VineClient(mockHttp);
        }

        public static void TestTag(Tag tag)
        {
            IsNotNull(tag, "tag != null");
            IsNull(tag.Deleted, "tag.Deleted != null");
            IsTrue(tag.Id == 1301468743066816512, "tag.Id == 1301468743066816512");
            IsTrue(tag.Name == "runningmanchallenge", "tag.Name == 'runningmanchallenge'");
            IsNotNull(tag.Created, "tag.Created != null");
            IsTrue(tag.Created == new DateTime(2016, 1, 20, 5, 42, 22),
                "tag.Created == new DateTime(2016, 1, 20, 5, 42, 22)");
        }

        public static void TestPost(Post post)
        {
            IsNotNull(post, "post != null");
            IsTrue(post.Promoted, "post.Promoted");
            IsFalse(post.Liked, "post.Liked");
            IsNotNull(post.VideoDashUrl, "post.VideoDashUrl");
            IsTrue(post.UserId == 980422881370669056, "post.UserId == 980422881370669056");
            IsNotNull(post.Loops, "post.Loops != null");
            IsTrue(Math.Abs(post.Loops.Count - 57120468.0) < float.Epsilon, "Math.Abs(post.Loops.Count - 57120468.0) < float.Epsilon");
            IsFalse(post.Loops.OnFire, "post.Loops.OnFire");
            IsNotNull(post.Comments, "post.Comments != null");
            IsNotEmpty(post.Comments.Records, "post.Comments.Records");
            TestComment(post.Comments.Records[0]);
            IsEmpty(post.Entities, "post.Entities");
            IsNotNull(post.Reposts, "post.Reposts != null");
            IsNotNull(post.Likes, "post.Likes != null");
            IsNotEmpty(post.Likes.Records, "post.Likes.Records");
            TestLike(post.Likes.Records[0]);
        }

        public static void TestLike(Like like)
        {
            IsNotNull(like, "like != null");
            IsTrue(like.UserName == "JustMiso", "like.UserName == 'JustMiso'");
            IsFalse(like.Verified, "like.Verified");
            IsEmpty(like.VanityUrls, "like.VanityUrls");
            IsTrue(like.UserId == 1338770960601493504, "like.UserId == 1338770960601493504");
        }

        public static void TestComment(Comment comment)
        {
            IsNotNull(comment, "comment != null");
            IsTrue(comment.Text == "song?", "comment.Text == 'song?'");
            IsFalse(comment.Verified, "comment.Verified");
            IsTrue(comment.UserId == 985402855928315904, "comment.UserId == 985402855928315904");
            IsTrue(comment.Created == new DateTime(2016, 5, 2, 3, 19, 2),
                "comment.Created == new DateTime(2016, 5, 2, 3, 19, 2)");
            IsEmpty(comment.Entities, "comment.Entities");
            TestUser(comment.User);
        }

        public static void TestUser(User user)
        {
            IsNotNull(user, "user != null");
            IsFalse(user.Verified, "user.Verified");
            IsTrue(user.UserId == 985402855928315904, "user.UserId == 985402855928315904");
            IsTrue(user.ProfileBackground == "0x7870cc", "user.ProfileBackground == '0x7870cc'");
            IsEmpty(user.VanityUrls, "user.VanityUrls");
        }

        public static void TestUser2(User user)
        {
            IsNotNull(user, "user != null");
            IsTrue(user.TwitterScreenName == "alisonbrie", "user.TwitterScreenName == 'alisonbrie'");
            IsTrue(user.FollowerCount == 109779, "user.FollowerCount == 109779");
            IsTrue(user.Verified, "user.Verified");
            IsTrue(user.UserId == 951265490817449984, "user.UserId == 951265490817449984");
        }
    }
}
