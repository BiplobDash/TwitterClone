using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(UserDto user, string password);
        bool VerifyPassword(UserDto user, string password, string passwordHash);
    }
}
