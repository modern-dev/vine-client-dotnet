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
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ModernDev.VineClient.API;
using ModernDev.VineClient.API.Exceptions;
using ModernDev.VineClient.API.Methods;
using Newtonsoft.Json;
using static ModernDev.VineClient.Utils;

namespace ModernDev.VineClient
{
    /// <summary>
    /// Provides a base class for working with vine.co API.
    /// </summary>
    public class VineClient : IDisposable
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VineClient"/> class.
        /// </summary>
        public VineClient()
        {
            Users = new UsersMethods(this);
            Posts = new PostsMethods(this);
            Tags = new TagsMethods(this);
            Timelines = new TimelinesMethods(this);
            Channels = new ChannelsMethods(this);
        }

        internal VineClient(HttpMessageHandler httpMessageHandler) : this()
        {
            _httpMessageHandler = httpMessageHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        ~VineClient()
        {
            Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The current API session.
        /// </summary>
        public Session Session { get; private set; }

        /// <summary>
        /// Throws an exception if the <see cref="Response{T}.IsSuccess"/> property for the <see cref="VineClient"/> response is false.
        /// </summary>
        public bool EnsureResponseSuccess { get; set; }

        /// <summary>
        /// Methods for working with users.
        /// </summary>
        public UsersMethods Users { get; private set; }

        /// <summary>
        /// Methods for working with posts.
        /// </summary>
        public PostsMethods Posts { get; private set; }

        /// <summary>
        /// Methods for working with tags.
        /// </summary>
        public TagsMethods Tags { get; private set; }

        /// <summary>
        /// Methods for working with timelines.
        /// </summary>
        public TimelinesMethods Timelines { get; private set; }

        /// <summary>
        /// Methods for working with timelines.
        /// </summary>
        public ChannelsMethods Channels { get; private set; }

        #endregion

        #region Fields

        private HttpClient _apiClient;
        private readonly Uri _baseApiUri = new Uri("https://api.vineapp.com/");
        private readonly Uri _baseMediaUrl = new Uri("http://media.vineapp.com/");
        private readonly HttpMessageHandler _httpMessageHandler;
        private const string UserAgent = "com.vine.iphone/1.0.3 (unknown, iPhone OS 6.0.1, iPhone, Scale/2.000000)";
        private bool _disposed;
        private const string AcceptLanguage =
            "en, sv, fr, de, ja, nl, it, es, pt, pt-PT, da, fi, nb, ko, zh-Hans, zh-Hant, ru, pl, tr, uk, ar, hr, cs, el, he, ro, sk, th, id, ms, en-GB, ca, hu, vi, en-us;q=0.8";

        #endregion

        #region Public methods

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="VineClient"/>.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _apiClient?.Dispose();
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance of <see cref="VineClient"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="username">User's name.</param>
        /// <param name="password">User's password (minimum of 6 characters).</param>
        /// <param name="email">Users's email.</param>
        /// <returns>Returns the current API session object in case of success sign up.</returns>
        public async Task<Response<Session>> Signup(string username, string password, string email)
        {
            var result = await Request<Session>("users", "post", new MethodParams
            {
                {"username", username, true},
                {"password", password, true},
                {"email", email, true},
                {"authenticate", true}
            });

            if (result.IsSuccess)
            {
                Session = result.Data;
                _apiClient.DefaultRequestHeaders.Add("vine-session-id", Session.Key);
            }

            return result;
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="deviceToken">Optional device token.</param>
        /// <returns>Returns the current API session object in case of success authentication.</returns>
        public async Task<Response<Session>> Authenticate(string username, string password, string deviceToken = null)
        {
            var result = await Request<Session>("users/authenticate", "post", new MethodParams
            {
                {"username", username, true},
                {"password", password, true},
                {"deviceToken", deviceToken}
            });

            if (result.IsSuccess)
            {
                Session = result.Data;
                _apiClient.DefaultRequestHeaders.Add("vine-session-id", Session.Key);
            }

            return result;
        }

        /// <summary>
        /// Closes the current API session.
        /// </summary>
        /// <returns>Returns an empty response.</returns>
        public async Task<Response<Empty>> Logout()
        {
            var resp = await Request<Empty>("users/authenticate", "delete");

            if (resp.IsSuccess)
            {
                Session = null;
            }

            return resp;
        }

        /// <summary>
        /// Performs an asynchronous API call to the specific method with a given parameters.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Response{T}.Data"/> property.</typeparam>
        /// <param name="endpoint">Method endpoint.</param>
        /// <param name="reqType">Request type. Can be either Post, Get or Delete.</param>
        /// <param name="reqParams">Request parameters.</param>
        /// <returns>Returns the result of API call.</returns>
        public async Task<Response<T>> Request<T>(string endpoint, string reqType = "get",
            MethodParams reqParams = null)
        {
            var mn = reqType.ToLowerInvariant();

            if (_apiClient == null)
            {
                InitApiClient();
            }

            var reqData = reqParams?.GetParams() ?? new Dictionary<string, string>();
            var json = mn == "get"
                ? await Get(endpoint, reqData)
                : mn == "post"
                    ? await Post(endpoint, reqData)
                    : await Delete(endpoint);

            return await Task.Run(() =>
            {
                var resp = DeserializeJsonResponse<T>(json);

                if (EnsureResponseSuccess && !resp.IsSuccess)
                {
                    throw new VineClientException($"Error {resp.Code}: {resp.Error}");
                }

                return resp;
            });
        }

        #endregion

        #region Non-public methods

        internal void InitApiClient()
        {
            _apiClient = _httpMessageHandler != null
                ? new HttpClient(_httpMessageHandler)
                : new HttpClient();

            _apiClient.BaseAddress = _baseApiUri;
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Accept-Language", AcceptLanguage);
            _apiClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }

        internal static Response<T> DeserializeJsonResponse<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Response<T>>(json, new JsonSerializerSettings
                {
                    ContractResolver = new PrivateResolver()
                });
            }
            catch (Exception ex)
            {
                throw new VineClientException("An exception has occurred while parsing request response", ex);
            }
        }

        internal async Task<string> Post(string url, Dictionary<string, string> reqParams)
        {
            try
            {
                var response = await _apiClient.PostAsync(url, new FormUrlEncodedContent(reqParams));

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new VineClientException("An exception has occurred while processing the POST request.", ex);
            }
        }

        internal async Task<string> Get(string url, Dictionary<string, string> queryParams)
        {
            try
            {
                var response = await _apiClient.GetAsync($"{url}?{GetQueryString(queryParams)}");

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new VineClientException("An exception has occurred while processing the GET request.", ex);
            }
        }

        internal async Task<string> Delete(string url)
        {
            try
            {
                var response = await _apiClient.DeleteAsync(url);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new VineClientException("An exception has occurred while processing the DELETE request.", ex);
            }
        }

        #endregion
    }
}
