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
    public class UsersMethodsTest
    {
        private VineClient _vineClient;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _vineClient = Ex.GetMockedClient("users");
        }

        [Test]
        public async Task GetMe()
        {
            var resp = await _vineClient.Users.GetMe();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            Ex.TestUser(resp.Data);
        }

        [Test]
        public async Task GetUserById()
        {
            var resp = await _vineClient.Users.GetUserById(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            Ex.TestUser(resp.Data);
        }

        [Test]
        public async Task UpdateProfile()
        {
            var resp = await _vineClient.Users.UpdateProfile(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            Ex.TestUser(resp.Data);
        }

        [Test]
        public async Task SetExplicit()
        {
            var resp = await _vineClient.Users.SetExplicit(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task UnsetExplicit()
        {
            var resp = await _vineClient.Users.UnsetExplicit(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Follow()
        {
            var resp = await _vineClient.Users.Follow(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Unfollow()
        {
            var resp = await _vineClient.Users.Unollow(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Block()
        {
            var resp = await _vineClient.Users.Block(1, 1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task Unblock()
        {
            var resp = await _vineClient.Users.Unlock(1, 1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
        }

        [Test]
        public async Task GetPendingNotificationsCount()
        {
            var resp = await _vineClient.Users.GetPendingNotificationsCount(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsTrue(resp.Data == 2, "resp.Data == 2");
        }

        [Test]
        public async Task GetNotifications()
        {
            var resp = await _vineClient.Users.GetNotifications(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            IsNotNull(resp.Data.Records[0], "resp.Data.Records[0] != null");
            IsTrue(resp.Data.Records[0].Body == "Scuuuuh is now following you", "resp.Data.Records[0].Body == 'Scuuuuh is now following you'");
            IsTrue(resp.Data.Records[0].NotificationId == 1339157125557506048, "resp.Data.Records[0].NotificationId == 1339157125557506048");
            IsTrue(resp.Data.Records[0].NotificationTypeId == 1, "resp.Data.Records[0].NotificationTypeId == 1");
            IsFalse(resp.Data.Records[0].Following, "resp.Data.Records[0].Following");
        }

        [Test]
        public async Task GetFollowers()
        {
            var resp = await _vineClient.Users.GetFollowers(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            Ex.TestUser2(resp.Data.Records[0]);
        }

        [Test]
        public async Task GetFollowing()
        {
            var resp = await _vineClient.Users.GetFollowing(1);

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            Ex.TestUser2(resp.Data.Records[0]);
        }

        [Test]
        public async Task Search()
        {
            var resp = await _vineClient.Users.Search("virtyaluk");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Records, "resp.Data.Records");
            Ex.TestUser2(resp.Data.Records[0]);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _vineClient?.Dispose();
        }
    }
}
