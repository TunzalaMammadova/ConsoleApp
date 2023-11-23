using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool Login(string email, string password)
        {
            return AppDbContext<User>.Datas.Exists(m => m.Email == email && m.Password == password);
        }
        

        public void Register(User user)
        {
            var res = AppDbContext<User>.Datas;
        }
    }
}

