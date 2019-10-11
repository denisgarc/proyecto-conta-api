using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SeedSolution.Business.Interfaces;
using SeedSolution.Entity.SecurityAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SeedSolution.WebApi.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                ISecurityAccesBL userService = StructureMap.ObjectFactory.GetInstance<ISecurityAccesBL>();
                SysUser user = userService.GetUserByCredentials(username, password);
                if (userService.Status())
                {                    
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserID", user.Id.ToString()),                        
                        new Claim("ExpirationDate",user.RenewalPassDate.ToString())                        
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() {  }));
                }
                else
                {
                    context.SetError("500", userService.Message());                   
                }
            });
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}