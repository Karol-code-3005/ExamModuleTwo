using CCPolandAPI.DAL.Data;
using CCPolandAPI.Models.EntityModels;
using CCPolandAPI.Services.ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CCPolandAPI.Services.AuthenticationHandler
{
    public class UserAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly CCPolandDbContext _context;

        public UserAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                         ILoggerFactory logger,
                                         UrlEncoder encoder,
                                         ISystemClock clock,
                                         CCPolandDbContext context) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header was not found");
            }

            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);

            string[] userCredentials = Encoding.UTF8.GetString(bytes).Split(":");

            string login = userCredentials[0];
            string password = userCredentials[1];


            User user = _context.Users.Include(x =>x.Role).Where(x=>x.Login == login).SingleOrDefault(x =>x.Password ==password);

            if(user == null)
            {
                throw new NotFoundException("user not found");
            }

            var claims = new[] { new Claim(ClaimTypes.Role, user.Role.Name) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
