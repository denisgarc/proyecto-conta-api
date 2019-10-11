using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SeedSolution.WebApi.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedSolution.WebApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}