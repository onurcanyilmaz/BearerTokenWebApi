using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BearerTokenExample
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName.Equals("onurcan", StringComparison.OrdinalIgnoreCase) && context.Password == "yilmaz")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("name", context.UserName));
                identity.AddClaim(new Claim("pass", context.Password));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Oturum Hatası", "Kullanıcı adı ve şifre hatalıdır");
            }
        }
    }
}