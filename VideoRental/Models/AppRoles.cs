using System.Security.Claims;

namespace WebMvcPruebaMosh.Models
{
    public static class AppRoles
    {
        public const string CanManageMovies = "CanManageMovies";


        public static IEnumerable<string> Roles(this ClaimsIdentity identity)
        {
            return identity.Claims
                           .Where(c => c.Type == ClaimTypes.Role)
                           .Select(c => c.Value)
                           .ToList();
        }


    }
}
