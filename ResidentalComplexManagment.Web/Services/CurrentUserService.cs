using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Core.Interface;
using System.Security.Claims;

namespace ResidentalComplexManagment.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ClaimsPrincipal User;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            User = _httpContextAccessor.HttpContext?.User;
        }

        public string UserId => User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string UserRole => User?.FindFirstValue(ClaimTypes.Role);

        public string GetNonAdminUserId => IsAdminRole? string.Empty : User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public bool IsAdminRole => (bool)(User?.IsInRole("Admin"));

    }
}
