using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        public (string, DateOnly) GetToken(UserDto user)
        {
            // business logic to return token with expiry time.
            return (string.Empty, DateOnly.MinValue);
        }
    }
}
