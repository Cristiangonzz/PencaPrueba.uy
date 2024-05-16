
using Microsoft.AspNetCore.Identity;

namespace WordPenca.Business.Repository.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
