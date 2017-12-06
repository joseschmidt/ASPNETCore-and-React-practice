using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCore_React.Domain.Models;
using ASPNETCore_React.Domain.Database;
using System.Linq;

namespace ASPNETCore_React.Domain.Repositories
{
    public class UserRepository
    {
        private DomainContext _context;

        public UserRepository(DomainContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public User Add(User user)
        {
            var result = _context.Users.Add(user);
            return result.Entity;
        }

        public List<User> List(string name = null)
        {
            var result = _context.Users.AsQueryable();

            //Filters
            if (name != null)
                result = result.Where(u => u.Name.Contains(name));


            return result.ToList();
        }

        public User Modify(User user)
        {
            var result = _context.Users.Update(user);
            return result.Entity;
        }

        public bool Delete(User user)
        {
            var result = _context.Users.Remove(user);
            return result.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
