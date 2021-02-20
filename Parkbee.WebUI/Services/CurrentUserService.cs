using Microsoft.AspNetCore.Http;
using Parkbee.Application.Common.Interfaces;
using System.Security.Claims;

namespace Parkbee.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
