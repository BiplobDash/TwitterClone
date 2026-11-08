using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(string password, string passwordHash);
    }
}
