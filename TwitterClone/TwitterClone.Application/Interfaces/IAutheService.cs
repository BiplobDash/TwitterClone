using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IAutheService
    {
        AuthResponseDto? Login(LoginDto loginDto);
    }
}
