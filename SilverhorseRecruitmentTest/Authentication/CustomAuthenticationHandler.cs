using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace SilverhorseRecruitmentTest.Authentication
{
    //Inspiration taken from https://dotnetcorecentral.com/blog/authentication-handler-in-asp-net-core/
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration config;

        public CustomAuthenticationHandler(
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
            var auth = Request.Headers["Authorization"].ToString();

            if(auth != null && auth.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
            {
                var baseToken = config.GetValue<string>("Token");
                var token = auth.Substring("Bearer ".Length).Trim();

                //If tokens are the same, allow user to use programs
                if (token == baseToken)
                {
                    var claims = new List<Claim> { new Claim("name", token), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Bearer");
                    var principal = new ClaimsPrincipal(identity);
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
