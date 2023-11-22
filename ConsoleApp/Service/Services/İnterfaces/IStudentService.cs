using System;
using Domain.Models;
using Repository.Enums;

namespace Service.Services.İnterfaces
{
	public interface IStudentService
	{
        void Create(Student student);
        void Delete(Student student);
        void Edit(int id, Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> Search(string searchText);
        List<Student> Sort(SortType sort);
    }
}

