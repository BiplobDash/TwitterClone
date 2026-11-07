using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public bool VerifyPassword(string password, string passwordHash)
        {
            // verify password logic
            return true;
        }
    }
}
