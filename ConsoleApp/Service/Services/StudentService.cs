using System;
using Domain.Models;
using Repository.Enums;
using Repository.Repositories;
using Repository.Repositories.İnterfaces;
using Service.Services.İnterfaces;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void Create(Student student)
        {
            _studentRepository.Create(student);
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void Edit(int id, Student student)
        {
            _studentRepository.Edit(id, student);
        }

        public List<Student> GetAll() => _studentRepository.GetAll();


        public Student GetById(int id) => _studentRepository.GetById(id);


        public List<Student> Search(string searchText) => _studentRepository.Search(searchText);


        public List<Student> Sort(SortType sort) => _studentRepository.Sort(sort);
    }
    
}
