using System;
using Domain.Models;
using Repository.Enums;

namespace Repository.Repositories.İnterfaces
{
	public interface IStudentRepository : IBaseRepository<Student>
	{
        List<Student> Search(string searchText);
        List<Student> Sort(SortType sort);
    }
}

