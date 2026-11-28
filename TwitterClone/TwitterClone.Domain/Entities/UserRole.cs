using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public UserRole(Guid id) : base(id)
        {

        }

        public Guid UserId {  get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
