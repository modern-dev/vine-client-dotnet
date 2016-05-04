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
    public class ChannelsMethodsTest
    {
        private VineClient _vineClient;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _vineClient = Ex.GetMockedClient("channels");
        }

        [Test]
        public async Task GetFeatured()
        {
            var resp = await _vineClient.Channels.GetFeatured();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            IsNotNull(resp.Data.Records[0], "resp.Data.Records[0] != null");
            IsTrue(resp.Data.Records[0].FeaturedChannelId == 1337983201704087552, "resp.Data.Records[0].FeaturedChannelId == 1337983201704087552");
            IsTrue(resp.Data.Records[0].ShowRecent, "resp.Data.Records[0].ShowRecent");
            IsTrue(resp.Data.Records[0].FontColor == "ffffff", "resp.Data.Records[0].FontColor == 'ffffff'");
            IsNull(resp.Data.Records[0].Description, "resp.Data.Records[0].Description != null");
            IsTrue(resp.Data.Records[0].Priority == 301, "resp.Data.Records[0].Priority == 301");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _vineClient?.Dispose();
        }
    }
}
