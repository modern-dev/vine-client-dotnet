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

using System.Collections.Generic;
using System.Threading.Tasks;
using ModernDev.VineClient.API.Exceptions;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.VineClient.Tests
{
    [TestFixture]
    public class GeneralClientTest
    {
        private VineClient _vineClient;
        private readonly Dictionary<string, string> _emptyDict = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void TestSetup()
        {
            _vineClient = Ex.GetMockedClient("basic");

            _vineClient.InitApiClient();
        }

        [Test]
        public void ParsingJsonResponse()
        {
            Throws<VineClientException>(() => VineClient.DeserializeJsonResponse<int>(null), "Parsing null JSON response.");
            Throws<VineClientException>(() => VineClient.DeserializeJsonResponse<int>("foo bar"), "Parsing invalid JSON response.");

            Response<Empty> resp = null;

            DoesNotThrow(() =>
            {
                resp = VineClient.DeserializeJsonResponse<Empty>(Ex.Responses.GetString("emptyResponse"));
            }, "Parsing JSON response.");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(resp.Data, "resp.Data != null");
        }

        [Test]
        public void PostRequest()
        {
            ThrowsAsync<VineClientException>(async () => await _vineClient.Post(null, null));
            ThrowsAsync<VineClientException>(async () => await _vineClient.Post("some/url", null));

            var respJson = "";

            DoesNotThrowAsync(async () => { respJson = await _vineClient.Post("some/url", _emptyDict); });

            IsNotEmpty(respJson, "respJson");
        }

        [Test]
        public void GetRequest()
        {
            ThrowsAsync<VineClientException>(async () => await _vineClient.Get(null, null));
            ThrowsAsync<VineClientException>(async () => await _vineClient.Get("some/url", null));

            var respJson = "";

            DoesNotThrowAsync(async () => { respJson = await _vineClient.Get("some/url", _emptyDict); });

            IsNotEmpty(respJson, "respJson");
        }

        [Test]
        public void DeleteRequest()
        {
            ThrowsAsync<VineClientException>(async () => await _vineClient.Delete(null));

            var respJson = "";

            DoesNotThrowAsync(async () => { respJson = await _vineClient.Delete("some/url"); });

            IsNotEmpty(respJson, "respJson");
        }

        [Test]
        public async Task Request()
        {
            _vineClient.EnsureResponseSuccess = false;

            DoesNotThrowAsync(async () => await _vineClient.Request<Empty>("some/url"), "Request returns a response.");
            DoesNotThrowAsync(async () => await _vineClient.Request<Empty>("some/url2"), "Request returns an error.");

            _vineClient.EnsureResponseSuccess = true;

            ThrowsAsync<VineClientException>(async () => await _vineClient.Request<Empty>("some/url2"));

            try
            {
                await _vineClient.Request<Empty>("some/url2");
            }
            catch (VineClientException ex)
            {
                IsTrue(ex.Message == "Error 900: That record does not exist.", "ex.Message == 'Error 900: That record does not exist.'");
            }
        }

        [Test]
        public async Task Authenticate()
        {
            var resp = await _vineClient.Authenticate("username", "userpassword");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(_vineClient.Session, "_vineClient.Session != null");
        }

        [Test]
        public async Task Logout()
        {
            var resp = await _vineClient.Logout();

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNull(_vineClient.Session, "_vineClient.Session != null");
        }

        [Test]
        public async Task Signup()
        {
            var resp = await _vineClient.Signup("username", "userpassword", "useremail");

            IsTrue(resp.IsSuccess, "resp.IsSuccess");
            IsNotNull(_vineClient.Session, "_vineClient.Session != null");
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _vineClient?.Dispose();
        }
    }
}
