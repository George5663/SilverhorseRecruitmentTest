using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace SilverhorseRecruitmentTest.Authentication
{
    //Inspiration taken from https://dotnetcorecentral.com/blog/authentication-handler-in-asp-net-core/
    public class Authentication : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration config;

        public Authentication(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IConfiguration config) 
            : base(options, logger, encoder, clock)
        {
            this.config = config;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string auth = Request.Headers["Authorization"].ToString();

            if(auth != null && auth.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
            {
                var tokenIn = auth["Bearer ".Length..].Trim();
                var token = config.GetValue<string>("Token");

                //If tokens are the same, allow user to use programs
                if(tokenIn == token)
                {
                    var claims = new List<Claim> { new Claim("name", token) };

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
                else
                {
                    //Returning 501 if token is invalid
                    Response.StatusCode = StatusCodes.Status501NotImplemented;
                    Response.Headers.Add("WWW-Authenticate", "Bearer");
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authentication Token"));

                }
            }
            else
            {
                //Returning 501 if token is missing
                Response.StatusCode = StatusCodes.Status501NotImplemented;
                Response.Headers.Add("WWW-Authenticate", "Bearer");
                return Task.FromResult(AuthenticateResult.Fail("Missing Authentication Token"));
            }
        }
    }
}
