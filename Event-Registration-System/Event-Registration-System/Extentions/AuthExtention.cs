using System.Security.Claims;

namespace Event_Registration_System.Extentions
{
    public static class AuthExtension
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var userIdStr = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(userIdStr, out int userId))
                return userId;

            return null;
        }
    }
}
