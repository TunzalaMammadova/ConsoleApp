using System;
using Domain.Models;
using Repository.Data;
using Repository.Enums;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> Search(string searchText)
        {
            return AppDbContext<Student>.Datas.Where(m => m.FullName == searchText).ToList();
        }

        public List<Student> Sort(SortType sort)
        {
            switch (sort)
            {
                case SortType.Asc:
                    return AppDbContext<Student>.Datas.OrderBy(m => m.FullName).ToList();
                case SortType.Desc:
                    return AppDbContext<Student>.Datas.OrderByDescending(m => m.FullName).ToList();

            }

            return null;
        }
    }
}

