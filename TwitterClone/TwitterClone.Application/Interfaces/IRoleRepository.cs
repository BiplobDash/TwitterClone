using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRoleRepository
    {
        Role? GetRoleByName (string name);
        List<Role> GetRoles ();
        void AddRolePermission(RolePermission rolePermissions);
    }
}
