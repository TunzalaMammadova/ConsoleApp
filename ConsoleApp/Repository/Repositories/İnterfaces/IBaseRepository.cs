using System;
using Domain.Models;

namespace Repository.Repositories.İnterfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		void Create(T entity);
		void Delete(T entity);
		void Edit(int id,T entity);
		T GetById(int id);
        List<T> GetAll();
    }
}

