using System;
using Domain.Models;
using Repository.Enums;

namespace Repository.Repositories.İnterfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		void Create(T entity);
		void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}

