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
            return AppDbContext<Student>.Datas.Where(m => m.FullName.ToLower().Trim().Contains(searchText.Trim().ToLower())).ToList();
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

            return default;
        }

        public void Edit(int id, Student student)
        {
            var result = GetById(id);
            if (result is not null)
            {
                if (!string.IsNullOrWhiteSpace(result.FullName))
                    result.FullName = student.FullName;

                if (!string.IsNullOrWhiteSpace(result.Address))
                    result.Address = student.Address;

                if (!string.IsNullOrWhiteSpace(result.Phone))
                    result.Phone = student.Phone;

                if (student.Age is not null)
                    result.Age = student.Age;

                if (student.Group is not null)
                    result.Group = student.Group;
            }


        }
    }
}

