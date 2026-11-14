using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistance;

namespace TwitterClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TwitterCloneDbContext _context;
        public UserRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }


        public User AddUser(User user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(User user)
        {
            var existingUser = _context.Users
                .SingleOrDefault(u => u.Id == user.Id);

            if (existingUser is null)
                return false;

            _context.Users.Remove(existingUser);
            _context.SaveChanges();

            return true;
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u =>
                string.Equals(u.Email, email.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
