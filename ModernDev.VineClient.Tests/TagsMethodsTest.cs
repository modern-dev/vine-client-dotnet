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
    public class TagsMethodsTest
    {
        private VineClient _vineClient;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _vineClient = Ex.GetMockedClient("tags");
        }

        [Test]
        public async Task GetTrending()
        {
            var resp = await _vineClient.Tags.GetTrending();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            Ex.TestTag(resp.Data.Records[0]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _vineClient.Tags.Search("cat");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            Ex.TestTag(resp.Data.Records[0]);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _vineClient?.Dispose();
        }
    }
}
