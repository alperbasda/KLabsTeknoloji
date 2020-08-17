using System.Collections.Generic;
using System.Security.Claims;
using KLabs.Entities.Concrete;

namespace KLabs.WebUI.Helpers.ClaimHelper
{
    public static class ClaimHelper
    {
        public static Claim[] ClaimFromUser(User user, List<string> roles)
        {
            return new[] {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, string.Join(',' ,roles))
            };
        }
    }
}