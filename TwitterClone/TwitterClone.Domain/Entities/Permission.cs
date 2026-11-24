using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public Permission(Guid id) : base(id)
        {

        }
        public required string Name { get; set; }
        public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
