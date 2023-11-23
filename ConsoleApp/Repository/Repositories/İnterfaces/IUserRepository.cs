using System;
using Domain.Models;

namespace Repository.Repositories.İnterfaces
{
	public interface IUserRepository
	{
        bool Login(string email, string password);
        void Register(User user);
    }
}

