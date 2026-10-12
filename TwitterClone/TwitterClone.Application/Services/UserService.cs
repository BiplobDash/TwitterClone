using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
                string.IsNullOrWhiteSpace(createUserDto.LastName) ||
                string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return null;
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser != null)
            {
                return null;
            }

            var createdUser = _userRepository.AddUser(new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
            });

            return new UserDto
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email,
            };

        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public List<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;

            _userRepository.UpdateUser(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}
