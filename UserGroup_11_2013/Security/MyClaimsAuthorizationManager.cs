using System.Linq;
using System.Security.Claims;
using Thinktecture.IdentityModel.Extensions;

namespace UserGroup.Security
{
    public class MyClaimsAuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var action = context.Action.First().Value;
            var resource = context.Resource.First().Value;
            if (resource == "home/about")
            {
                return context.Principal.HasClaim(ClaimTypes.Gender, "male");
            }
            if (resource == "home/contact")
            {
                return !context.Principal.HasClaim(ClaimTypes.Gender, "male");
            }

            return false;
        }
    }
}