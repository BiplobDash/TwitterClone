using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Constants;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistance.SeedData
{
        public static class SeedData
        {
            // Role IDs
            private static readonly Guid AdminRoleId =
                Guid.Parse("11111111-1111-1111-1111-111111111111");

            private static readonly Guid ModeratorRoleId =
                Guid.Parse("22222222-2222-2222-2222-222222222222");
        
            private static readonly Guid UserRoleId =
                Guid.Parse("33333333-3333-3333-3333-333333333333");


            // Permission IDs
            private static readonly Guid UsersReadPermissionId =
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            private static readonly Guid UsersDeletePermissionId =
                Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            private static readonly Guid RolesManagePermissionId =
                Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");


            // Roles
            public static Role[] Roles()
            {
                return new Role[]
                {
                new Role(AdminRoleId)
                {
                    Name = RoleNames.Admin,
                },

                new Role(ModeratorRoleId)
                {
                    Name = RoleNames.Moderator,
                },

                new Role(UserRoleId)
                {
                    Name = RoleNames.User,
                }
                };
            }


            // Permissions
            public static Permission[] Permissions()
            {
                return new Permission[]
                {
                new Permission(UsersReadPermissionId)
                {
                    Name = PermissionNames.UsersRead,
                },

                new Permission(UsersDeletePermissionId)
                {
                    Name = PermissionNames.UsersDelete,
                },

                new Permission(RolesManagePermissionId)
                {
                    Name = PermissionNames.RolesManage,
                }
                };
            }


            // Role-Permission Mapping
            public static RolePermission[] RolePermissions()
            {
                return new RolePermission[]
                {
                // Admin - All Permissions

                new RolePermission(Guid.Parse(
                    "10000000-0000-0000-0000-000000000001"))
                {
                    RoleId = AdminRoleId,
                    PermissionId = UsersReadPermissionId,
                },

                new RolePermission(Guid.Parse(
                    "10000000-0000-0000-0000-000000000002"))
                {
                    RoleId = AdminRoleId,
                    PermissionId = UsersDeletePermissionId,
                },

                new RolePermission(Guid.Parse(
                    "10000000-0000-0000-0000-000000000003"))
                {
                    RoleId = AdminRoleId,
                    PermissionId = RolesManagePermissionId,
                },


                // Moderator - Read and Delete Users

                new RolePermission(Guid.Parse(
                    "20000000-0000-0000-0000-000000000001"))
                {
                    RoleId = ModeratorRoleId,
                    PermissionId = UsersReadPermissionId,
                },

                new RolePermission(Guid.Parse(
                    "20000000-0000-0000-0000-000000000002"))
                {
                    RoleId = ModeratorRoleId,
                    PermissionId = UsersDeletePermissionId,
                }
                };
            }
        }

    //public static class SeedData
    //{

    //    public static Role[] Roles()
    //    {
    //        return new Role[] {
    //            new Role(Guid.NewGuid())
    //            {
    //                Name = RoleNames.Admin,
    //            },
    //            new Role(Guid.NewGuid())
    //            {
    //                Name = RoleNames.Moderator,
    //            },
    //            new Role(Guid.NewGuid())
    //            {
    //                Name = RoleNames.User,
    //            }
    //        };
    //    }

    //    public static Permission[] Permissions()
    //    {
    //        return new Permission[] {
    //            new Permission(Guid.NewGuid())
    //            {
    //                Name = PermissionNames.UsersRead,
    //            },
    //            new Permission(Guid.NewGuid())
    //            {
    //                Name = PermissionNames.UsersDelete,
    //            },
    //            new Permission(Guid.NewGuid())
    //            {
    //                Name = PermissionNames.RolesManage,
    //            }
    //        };
    //    }


    //    public static RolePermission[] RolePermissions()
    //    {
    //        return new RolePermission[] {
    //            // Admin Everything
    //            new RolePermission(Guid.NewGuid())
    //            {
    //                RoleId = Guid.NewGuid(),
    //                PermissionId = Guid.NewGuid(),
    //            },
    //           new RolePermission(Guid.NewGuid())
    //            {
    //                RoleId = Guid.NewGuid(),
    //                PermissionId = Guid.NewGuid(),
    //            },
    //            new RolePermission(Guid.NewGuid())
    //            {
    //                RoleId = Guid.NewGuid(),
    //                PermissionId = Guid.NewGuid(),
    //            },

    //            // Moderator read and delete users
    //            new RolePermission(Guid.NewGuid())
    //            {
    //                RoleId = Guid.NewGuid(),
    //                PermissionId = Guid.NewGuid(),
    //            },
    //            new RolePermission(Guid.NewGuid())
    //            {
    //                RoleId = Guid.NewGuid(),
    //                PermissionId = Guid.NewGuid(),
    //            },
    //        };
    //    }

    //}
}
