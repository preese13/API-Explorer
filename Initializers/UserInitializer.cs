using mockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mockAPI
{
    public class UserIntitializer
    {
        private UserContext _context;

        public UserIntitializer(UserContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {

            if (!_context.Users.Any())
            {
                _context.AddRange(Users);
                await _context.SaveChangesAsync();
            }
        }

        List<User> Users = new List<User>
        {
            new User()
            {
                Email = "guest@example.com",
                Password = "ReIiHShm9rSkAhQHne9M9A==",
            }
        };
    }
}