using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ModernDev.VineClient
{
    public partial class VineClient : IDisposable
    {
        #region Constructor

        public VineClient()
        {
            _apiClient = new HttpClient();
        }

        ~VineClient()
        {
            
        }

        #endregion

        #region Fields

        private HttpClient _apiClient;

        #endregion

        public void Dispose()
        {
            _apiClient?.Dispose();
        }
    }
}
