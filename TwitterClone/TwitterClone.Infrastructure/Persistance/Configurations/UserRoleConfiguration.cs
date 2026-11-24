using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistance.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(ur => ur.Id);

            builder.HasOne(ur => ur.User).
                WithMany(u => u.UserRoles).
                HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role).
                WithMany(u => u.UserRoles).
                HasForeignKey(ur => ur.RoleId);


        }
    }
}
