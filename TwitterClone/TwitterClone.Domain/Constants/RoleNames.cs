using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Constants
{
    public class RoleNames
    {
        public const string ClaimType = "Role";
        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public const string User = "User";
    }

    public static class PermissionNames
    {
        public const string ClaimType = "permission";
        public const string UsersRead = "users.read";
        public const string UsersDelete = "users.delete";
        public const string RolesManage = "roles.manage";

        public static readonly string[] All = { UsersRead, UsersDelete, RolesManage };
    }
}
