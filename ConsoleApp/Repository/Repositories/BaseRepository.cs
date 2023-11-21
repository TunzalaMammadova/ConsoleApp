using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            AppDbContext<T>.Datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext<T>.Datas.Remove(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll() => AppDbContext<T>.Datas.ToList();


        public T GetById(int id) => AppDbContext<T>.Datas.FirstOrDefault(m => m.Id == id);
       

       
    }
}

