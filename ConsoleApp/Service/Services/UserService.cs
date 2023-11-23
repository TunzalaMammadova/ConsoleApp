using System;
using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.İnterfaces;
using Service.Services.İnterfaces;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool Login(string email, string password)
        {
            return _userRepository.Login(email,password);
        }

        public void Register(User user)
        {
            _userRepository.Register(user);
        }
    }
}

