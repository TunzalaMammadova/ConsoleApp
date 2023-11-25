using System;
using System.Xml.Linq;
using Domain.Models;
using Repository.Enums;
using Service.Exceptions;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.İnterfaces;

namespace ConsoleApp.Controllers
{
	public class GroupController
	{
		private readonly IGroupService _groupService;

		public GroupController()
		{
			_groupService = new GroupService();
		}

		public void Create()
		{
            Name: ConsoleColor.Cyan.WriteConsole("Please enter groupname:");
			string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Name;
            }

            Cpacity: ConsoleColor.Cyan.WriteConsole("Please enter capacity:");
            string capacityStr = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
            if (isCorrectCapacity is false)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong,please try again");
                goto Cpacity;
            }

            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Cpacity;

            }

            Group group = new()
            {
                Name = name,
                Capacity = capacity
            };
            ConsoleColor.DarkGreen.WriteConsole("Group create successed");

            _groupService.Create(group);
        }


        public void GetAll()
        {
            var response = _groupService.GetAll();

            foreach (var item in response)
            {
                var res = $"Name:{item.Name} ; Capacity:{item.Capacity}";
                ConsoleColor.Cyan.WriteConsole(res);
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
                    ConsoleColor.DarkGreen.WriteConsole("Cannot be empty");
                    goto Delete;
                }
                if (isCorrectId)
                {
                    var result = _groupService.GetById(id);
                    if(result is null)
                    {
                        throw new NotFoundException("Data not found");
                    }
                    _groupService.Delete(result);

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


        public void Sorting()
        {
            ConsoleColor.Cyan.WriteConsole("Please select sort type: 1.Ascending , 2.Descending");
            Sorting: string sortStr = Console.ReadLine();
            int sortType;
            bool isCorrectSortType = int.TryParse(sortStr, out sortType);

            if (isCorrectSortType)
            {
                if((sortType == (int)SortType.Asc || sortType == (int)SortType.Desc))
                {
                    List<Group> result = new();

                    if(sortType == (int)SortType.Asc)
                    {
                        result = _groupService.Sort(SortType.Asc);
                    }
                    else
                    {
                        result = _groupService.Sort(SortType.Desc);
                    }

                    foreach (var item in result)
                    {
                        var res = $"Name:{item.Name} ; Capacity:{item.Capacity}";
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

        public void Edit()
        {
            Id: string idStr = Console.ReadLine();
            try
            {
                ConsoleColor.Cyan.WriteConsole("Please enter group id");
                int id;
                bool isCorrectId = int.TryParse(idStr, out id);
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.DarkGreen.WriteConsole("Cannot be empty");
                    goto Id;
                }
                if (isCorrectId)
                {
                    var result = _groupService.GetById(id);
                    if (result is null)
                    {
                        throw new NotFoundException("Data not found");
                    }

                    ConsoleColor.Cyan.WriteConsole("Add name: ");
                    string name = Console.ReadLine();

                    ConsoleColor.Cyan.WriteConsole("Add capacity: ");
                    Capacity: string capacityStr = Console.ReadLine();

                    int capacity;
                    bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
                    if (!isCorrectCapacity)
                    {
                        ConsoleColor.Red.WriteConsole("Capacity format is wrong");
                        goto Capacity;
                    }
                    _groupService.Edit(id, new Group { Name = name, Capacity = capacity });
                    ConsoleColor.DarkGreen.WriteConsole("Edit Successfull");


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

  