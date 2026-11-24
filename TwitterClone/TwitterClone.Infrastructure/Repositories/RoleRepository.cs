using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistance;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TwitterCloneDbContext _context;
        public RoleRepository(TwitterCloneDbContext context) 
        {
            _context = context;
        }
        public void AddRolePermission(RolePermission rolePermissions)
        {
            _context.RolePermissions.Add(rolePermissions);
            _context.SaveChanges();
        }

        public Role? GetRoleByName(string name)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == name);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
