using System;
using System.Net;
using Domain.Models;
using Repository.Enums;
using Service.Exceptions;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.İnterfaces;

namespace ConsoleApp.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _studentervice;
        private readonly IGroupService _groupService;

        public StudentController()
        {
            _studentervice = new StudentService();
            _groupService = new GroupService();
        }

        public void Create()
        {
            Fullname: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterFullname);
            string fullname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullname))
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                goto Fullname;
            }

            Address: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterAddress);
            string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                goto Address;
            }

            Phone: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterPhone);
            string phone = Console.ReadLine();
            int phonestr;
            bool isCorrectPhone = int.TryParse(phone, out phonestr);
            if (isCorrectPhone is false)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.FormatWrongMessage);
                goto Phone;
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                goto Phone;
            }

            Age: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterAge);
            string ageStr = Console.ReadLine();
            int age;
            bool isCorrectAge = int.TryParse(ageStr, out age);
            if (isCorrectAge is false)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.FormatWrongMessage);
                goto Age;
            }

            if (age <= 14 || age > 100)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InCorrectAgeMessage);
                goto Age;
            }

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                goto Age;
            }


            Group: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterGroupIdForStudent);
            string groupStr = Console.ReadLine();
            int id;
            bool isCorrectFormat = int.TryParse(groupStr, out id);
            if (isCorrectFormat is false)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.FormatWrongMessage);
                goto Group;
            }
            var res = _groupService.GetById(id);
            if (res is null)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                goto Group;

            }


            Student student = new()
            {
                FullName = fullname,
                Address = address,
                Age = age,
                Phone = phone,
                Group = res
            };
            ConsoleColor.DarkGreen.WriteConsole(StudentNotification.CreateSuccess);

            _studentervice.Create(student);
        }


        public void GetAll()
        {
            var response = _studentervice.GetAll();

            foreach (var item in response)
            {
                var res = $"Fullname:{item.FullName} ; Age:{item.Age} ; Address:{item.Address} ; Phone:{item.Phone} - Group: {item.Group.Name}";
                ConsoleColor.Cyan.WriteConsole(res);
            }
        }


        public void Search()
        {
            Text: ConsoleColor.DarkGreen.WriteConsole(StudentNotification.EnterSearchText);
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
            }

            var response = _studentervice.Search(text);
            foreach (var item in response)
            {
                var res = $"Fullname:{item.FullName} ; Age:{item.Age} ; Address:{item.Address} ; Phone:{item.Phone} - Group: {item.Group.Name}";
                ConsoleColor.DarkCyan.WriteConsole(res);

            }
        }


        public void Sorting()
        {
            ConsoleColor.Cyan.WriteConsole(StudentNotification.SelectSortType);
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
                        var res = $"Fullname:{item.FullName} ; Age:{item.Age} ; Address:{item.Address} ; Phone:{item.Phone} - Group: {item.Group.Name}";
                        ConsoleColor.Cyan.WriteConsole(res);
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(StudentNotification.WrongSortType);
                    goto Sorting;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.FormatWrongSortType);
                goto Sorting;
            }

        }


        public void GetById()
        {
            Id: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterStudentId);
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                goto Id;
            }
            if (!isCorrectId)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.IdFormatWrongMessage);
                goto Id;
            }

            Student student = _studentervice.GetById(id);
            if (student is null)
            {
                ConsoleColor.Red.WriteConsole(StudentNotification.StudentNotFound);
                goto Id;

            }
            var res = $"Fullname:{student.FullName} ; Age:{student.Age} ; Address:{student.Address} ; Phone:{student.Phone} - Group: {student.Group.Name}";
            ConsoleColor.DarkCyan.WriteConsole(res);
        }


        public void Delete()
        {
            Delete: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterStudentId);
            Id: string IdStr = Console.ReadLine();
            try
            {
                int id;
                bool isCorrectId = int.TryParse(IdStr, out id);
                if (string.IsNullOrWhiteSpace(IdStr))
                {
                    ConsoleColor.Red.WriteConsole(StudentNotification.InputEmptyMessage);
                    goto Delete;
                }
                if (isCorrectId)
                {
                    var result = _studentervice.GetById(id);
                    if (result is null)
                    {
                        throw new NotFoundException(StudentNotification.DataNotFound);
                    }
                    _studentervice.Delete(result);

                    ConsoleColor.DarkGreen.WriteConsole(StudentNotification.EditSuccess);
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(StudentNotification.IdFormatWrongMessage);
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Id;
            }
        }


        public void Edit()
        {
            ConsoleColor.Cyan.WriteConsole(GroupNotification.EnterGroupId);
            Id: string idStr = Console.ReadLine();
            try
            {
                int id;
                bool isCorrectId = int.TryParse(idStr, out id);
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                    goto Id;
                }
                if (isCorrectId)
                {
                    var result = _studentervice.GetById(id);
                    if (result is null)
                    {
                        throw new NotFoundException(StudentNotification.DataNotFound);
                    }

                    ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterFullname);
                    string fullname = Console.ReadLine();

                    ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterAddress);
                    string address = Console.ReadLine();


                    Age: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterAge);
                    string ageStr = Console.ReadLine();
                    int age;
                    bool isCorrectAge = int.TryParse(ageStr ,out age);

                    if (string.IsNullOrWhiteSpace(ageStr))
                    {
                        age = (int)result.Age;
                        
                    }

                    if (age <= 14 || age > 100)
                    {
                        ConsoleColor.Red.WriteConsole(StudentNotification.InCorrectAgeMessage);
                        goto Age;
                    }

                    ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterPhone);
                    Phone: string phone = Console.ReadLine();
                    int phonestr;
                    bool isCorrectPhone = int.TryParse(phone, out phonestr);
                    if (isCorrectPhone is true)
                    {
                        goto GroupName;
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole(StudentNotification.FormatWrongMessage);
                        goto Phone;
                    }

                    GroupName: ConsoleColor.Cyan.WriteConsole(StudentNotification.EnterGroupName);
                    string groupname = Console.ReadLine();


                    _studentervice.Edit(id, new Student { FullName = fullname, Address = address, Phone = phone, Age = age, Group = new Group { Name = groupname } });
                    ConsoleColor.DarkGreen.WriteConsole(GroupNotification.EditSuccess);


                }
                else
                {
                    ConsoleColor.Red.WriteConsole(GroupNotification.IdFormatWrongMessage);
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

