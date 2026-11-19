using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        private PasswordHasher<UserDto> _passwordHasher = new PasswordHasher<UserDto>();
        public string Hash(UserDto user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(UserDto user, string password, string passwordHash)
        {
            // verify password logic
            var result = _passwordHasher.VerifyHashedPassword(user, passwordHash, password);
            if (result == PasswordVerificationResult.Success) {
                return true;
            }
            return false;
        }
    }
}
