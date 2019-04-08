using JedSharp.GLPIFatClient.Services;
using System;
using System.Threading.Tasks;

namespace JedSharp.GLPIFatClient.Controller
{
    public class LoginController
    {
        private String _sessionToken;

        public String GLPIUrl { get; set; }

        public String AppToken { get; set; }

        public String UserToken { get; set; }

        public String SessionToken
        {
            get => _sessionToken;
        }

        public LoginController(String glpiUrl, String appToken, String userToken)
        {
            GLPIUrl = glpiUrl;
            AppToken = appToken;
            UserToken = userToken;
        }

        public async Task<bool> InitSession()
        {
            InitSessionService initSessionService = new InitSessionService(GLPIUrl, AppToken, UserToken);
            _sessionToken = await initSessionService.Connect();
            if (!String.IsNullOrWhiteSpace(_sessionToken))
                return true;
            else
                return false;
        }
    }
}
