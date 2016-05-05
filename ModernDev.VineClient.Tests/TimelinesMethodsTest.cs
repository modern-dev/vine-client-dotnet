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
    public class TimelinesMethodsTest
    {
        private VineClient _vineClient;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _vineClient = Ex.GetMockedClient("timelines");
        }

        [Test]
        public async Task GetById()
        {
            var resp = await _vineClient.Timelines.GetPostById(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            Ex.TestPost(resp.Data.Records[0]);
        }
        
        [Test]
        public async Task GetUserTimeline()
        {
            var resp = await _vineClient.Timelines.GetUserTimeline(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetUserLikes()
        {
            var resp = await _vineClient.Timelines.GetUserLikes(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetTagTimeline()
        {
            var resp = await _vineClient.Timelines.GetTagTimeline("cat");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetMainTimeline()
        {
            var resp = await _vineClient.Timelines.GetMainTimeline();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetPopular()
        {
            var resp = await _vineClient.Timelines.GetPopular();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetTrending()
        {
            var resp = await _vineClient.Timelines.GetTrending();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetPromoted()
        {
            var resp = await _vineClient.Timelines.GetPromoted();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetChannelPopular()
        {
            var resp = await _vineClient.Timelines.GetChannelPopular(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetChannelRecent()
        {
            var resp = await _vineClient.Timelines.GetChannelRecent(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetVanue()
        {
            var resp = await _vineClient.Timelines.GetVenue(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetSimilar()
        {
            var resp = await _vineClient.Timelines.GetSimilar(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _vineClient?.Dispose();
        }
    }
}
