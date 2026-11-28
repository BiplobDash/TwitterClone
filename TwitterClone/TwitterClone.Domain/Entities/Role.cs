using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role(Guid id) : base(id)
        {

        }

        public required string Name { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
