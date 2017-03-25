using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data;
using System.Linq;

namespace HungryUp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            this._context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return GetByEmail(user.Email);
        }
        
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
