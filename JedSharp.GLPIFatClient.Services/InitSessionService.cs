using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JedSharp.GLPIFatClient.Services
{
    public class InitSessionService
    {
        private class GLPISession
        {
            public String session_token { get; set; }
        }

        private String _sessionToken;

        private String _glpiUrl;
        public String GLPIUrl
        {
            get { return _glpiUrl; }
            set
            {
                _glpiUrl = value;
                Session.GLPIUrl = value;
            }
        }

        private String _appToken;
        public String AppToken {
        get { return _appToken; }
        set
            {
                _appToken = value;
                Session.AppToken = value;
            }
        }

        public String UserToken { get; set; }

        public InitSessionService(String glpiUrl, String appToken, String userToken)
        {
            GLPIUrl = glpiUrl;
            AppToken = appToken;
            UserToken = userToken;
            Session.GLPIUrl = glpiUrl;
            Session.AppToken = appToken;
        }

        public async Task<String> Connect()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format("{0}/apirest.php/", GLPIUrl));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", String.Format("user_token {0}", UserToken));
            client.DefaultRequestHeaders.Add("App-Token", AppToken);
            HttpResponseMessage response = await client.GetAsync("initSession");
            if (response.IsSuccessStatusCode)
            {
                GLPISession session = await response.Content.ReadAsAsync<GLPISession>();
                Session.SessionToken = session.session_token;
                return session.session_token;
            }
            else
            {
                Session.SessionToken = String.Empty;
                return String.Empty;
            }
        }
    }
}
