using System;
using Domain.Models;

namespace Service.Services.İnterfaces
{
	public interface IUserService
	{
        bool Login(string email, string password);
        void Register(User user);
    }
}

