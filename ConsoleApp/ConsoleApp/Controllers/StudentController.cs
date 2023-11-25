using System;
using System.Net;
using Domain.Models;
using Repository.Enums;
using Service.Exceptions;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.İnterfaces;

namespace ConsoleApp.Controllers
{
	public class StudentController
	{
        private readonly IStudentService _studentervice;

        public StudentController()
        {
            _studentervice = new StudentService();
        }

        public void Create()
        {
            Fullname: ConsoleColor.Cyan.WriteConsole("Please enter Fullname:");
            string fullname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullname))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Fullname;
            }

            Address: ConsoleColor.Cyan.WriteConsole("Please enter address:");
            string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Address;
            }

            Phone: ConsoleColor.Cyan.WriteConsole("Please enter phone:");
            string phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Phone;
            }

            Age: ConsoleColor.Cyan.WriteConsole("Please enter capacity:");
            string ageStr = Console.ReadLine();
            int age;
            bool isCorrectAge = int.TryParse(ageStr, out age);
            if (isCorrectAge is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Age;
            }

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Age;

            }


            Group: ConsoleColor.Cyan.WriteConsole("Please enter group Id:");
            string groupStr = Console.ReadLine();
            int id;
            bool isCorrectFormat = int.TryParse(groupStr, out id);
            if (isCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Group;
            }
            var res = _studentervice.GetById(id);
            if (res is null)
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Group;

            }
            
            Student student = new()
            {
                FullName = fullname,
                Address = address,
                Age = age,
                Phone = phone,
            };
            ConsoleColor.DarkGreen.WriteConsole("Student create successed");

            _studentervice.Create(student);
        }


        public void GetAll()
        {
            var response = _studentervice.GetAll();

            foreach (var item in response)
            {
                var res = $"Fullname:{item.FullName} ; Age:{item.Age} ; Address:{item.Address} ; Phone:{item.Phone}";
                ConsoleColor.Cyan.WriteConsole(res);
            }
        }

        public void Search()
        {
            Text: ConsoleColor.DarkGreen.WriteConsole("Please enter search text");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Text;
            }

            var response = _studentervice.Search(text);

        }


        public void Sorting()
        {
            ConsoleColor.Cyan.WriteConsole("Please select sort type: 1.Ascending , 2.Descending");
            Sorting: string sortStr = Console.ReadLine();
            int sortType;
            bool isCorrectSortType = int.TryParse(sortStr, out sortType);

            if (isCorrectSortType)
            {
                if ((sortType == (int)SortType.Asc || sortType == (int)SortType.Desc))
                {
                    List<Student> result = new();

                    if (sortType == (int)SortType.Asc)
                    {
                        result = _studentervice.Sort(SortType.Asc);
                    }
                    else
                    {
                        result = _studentervice.Sort(SortType.Desc);
                    }

                    foreach (var item in result)
                    {
                        var res = $"Name:{item.FullName} ; Age:{item.Age} ; Phone:{item.Phone} ; Addres:{item.Address}";
                        ConsoleColor.Cyan.WriteConsole(res);
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Sortype is wrong, please try again");
                    goto Sorting;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Sortype format is wrong, please try again");
                goto Sorting;
            }

        }

        public void GetById()
        {
            Id: ConsoleColor.Cyan.WriteConsole("Please enter id for group");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty");
                goto Id;
            }
            if (isCorrectId)
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong");
                goto Id;
            }

            Student student = _studentervice.GetById(id);
            if (student is null)
            {
                ConsoleColor.Red.WriteConsole("Group not found");
                goto Id;

            }
        }

        public void Delete()
        {
        Id: string IdStr = Console.ReadLine();
            try
            {
            Delete: ConsoleColor.Cyan.WriteConsole("Please enter group id");
                int id;
                bool isCorrectId = int.TryParse(IdStr, out id);
                if (string.IsNullOrWhiteSpace(IdStr))
                {
                    ConsoleColor.Red.WriteConsole("Cannot be empty");
                    goto Delete;
                }
                if (isCorrectId)
                {
                    var result = _studentervice.GetById(id);
                    if (result is null)
                    {
                        throw new NotFoundException("Data not found");
                    }
                    _studentervice.Delete(result);

                    ConsoleColor.DarkGreen.WriteConsole("Deletion was successful");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Id format is wrong, please try again");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Id;
            }

        }
    }
}

