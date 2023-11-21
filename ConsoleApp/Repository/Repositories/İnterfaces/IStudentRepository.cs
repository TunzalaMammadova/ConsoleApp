using System;
using Domain.Models;
using Repository.Enums;

namespace Repository.Repositories.İnterfaces
{
	public interface IStudentRepository : IBaseRepository<Student>
	{
        public List<Student> Search(string searchText);
        public List<Student> Sort(SortType sort);
    }
}

