using Case.Data;
using Case.Models;

namespace Case.Repository
{
    public class AuthTokenRepository : GenericRepo<AuthToken>, IAuthTokenRepository
    {
        public AuthTokenRepository(DataContext context) : base(context)
        {
        }
    }
}
