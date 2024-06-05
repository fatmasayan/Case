using Case.Data;
using Case.Models;

namespace Case.Repository
{
    public class UserRepository : GenericRepo<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
