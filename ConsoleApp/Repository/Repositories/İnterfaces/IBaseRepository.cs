using System;
using Domain.Models;

namespace Repository.Repositories.İnterfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		void Create(T entity);
		void Delete(T entity);
		void Edit(T entity);
		T Search(string text);
		T GetById(int id);
        List<T> GetAll();
    }
}

