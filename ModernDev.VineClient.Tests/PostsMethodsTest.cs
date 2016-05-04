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
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.VineClient.Tests
{
    [TestFixture]
    public class PostsMethodsTest
    {
        private VineClient _vineClient;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _vineClient = Ex.GetMockedClient("posts");
        }

        [Test]
        public async Task LikePost()
        {
            var resp = await _vineClient.Posts.LikePost(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            Ex.TestLike(resp.Data);
        }

        [Test]
        public async Task DeleteLike()
        {
            var resp = await _vineClient.Posts.DeleteLike(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task CreateComment()
        {
            var resp = await _vineClient.Posts.CreateComment(1, "text");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            Ex.TestComment(resp.Data);
        }

        [Test]
        public async Task DeleteComment()
        {
            var resp = await _vineClient.Posts.DeleteComment(1, 1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Revine()
        {
            var resp = await _vineClient.Posts.Revine(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsTrue(resp.Data.RepostId == 1297595204597354496, "resp.Data.RepostId == 1297595204597354496");
        }

        [Test]
        public async Task Unrevine()
        {
            var resp = await _vineClient.Posts.Unrevine(1, 1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Report()
        {
            var resp = await _vineClient.Posts.Report(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Post()
        {
            var resp = await _vineClient.Posts.Post("url", "url", "desc");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Delete()
        {
            var resp = await _vineClient.Posts.Delete(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _vineClient?.Dispose();
        }
    }
}
