using System;
using System.Xml.Linq;
using Domain.Models;
using Repository.Enums;
using Service.Exceptions;
using Service.Helpers.Constants;
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
            Name: ConsoleColor.DarkCyan.WriteConsole(GroupNotification.EnterGroupname);
			string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                goto Name;
            }

            Cpacity: ConsoleColor.DarkCyan.WriteConsole(GroupNotification.EnterCapacity);
            string capacityStr = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
            if (isCorrectCapacity is false)
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.FormatWrongMessage);
                goto Cpacity;
            }

            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                goto Cpacity;

            }

            Group group = new()
            {
                Name = name,
                Capacity = capacity
            };
            ConsoleColor.DarkGreen.WriteConsole(GroupNotification.GroupCreateSuccess);

            _groupService.Create(group);
        }


        public void GetAll()
        {
            var response = _groupService.GetAll();

            foreach (var item in response)
            {
                var res = $"Name:{item.Name} ; Capacity:{item.Capacity}";
                ConsoleColor.DarkCyan.WriteConsole(res);
            }
        }


        public void Delete()
        {
            Delete: ConsoleColor.DarkCyan.WriteConsole(GroupNotification.EnterGroupId);
            Id: string IdStr = Console.ReadLine();
            try
            {
                int id;
                bool isCorrectId = int.TryParse(IdStr, out id);
                if (string.IsNullOrWhiteSpace(IdStr))
                {
                    ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                    goto Delete;
                }
                if (isCorrectId)
                {
                    var result = _groupService.GetById(id);
                    if(result is null)
                    {
                        throw new NotFoundException(GroupNotification.DataNotFound);
                    }
                    _groupService.Delete(result);

                    ConsoleColor.DarkGreen.WriteConsole(GroupNotification.SuccessDelete);
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


        public void Sorting()
        {
            ConsoleColor.DarkCyan.WriteConsole(GroupNotification.SelectSortType);
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
                        ConsoleColor.DarkCyan.WriteConsole(res);
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(GroupNotification.WrongSortType);
                    goto Sorting;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.FormatWrongSortType);
                goto Sorting;
            }

        }


        public void Edit()
        {
            Id: string idStr = Console.ReadLine();
            try
            {
                ConsoleColor.Cyan.WriteConsole(GroupNotification.EnterGroupId);
                int id;
                bool isCorrectId = int.TryParse(idStr, out id);
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                    goto Id;
                }
                if (isCorrectId)
                {
                    var result = _groupService.GetById(id);
                    if (result is null)
                    {
                        throw new NotFoundException(GroupNotification.DataNotFound);
                    }

                    ConsoleColor.Cyan.WriteConsole(GroupNotification.EnterGroupname);
                    string name = Console.ReadLine();

                    ConsoleColor.Cyan.WriteConsole(GroupNotification.EnterCapacity);
                    Capacity: string capacityStr = Console.ReadLine();

                    int capacity;
                    bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
                    if (!isCorrectCapacity)
                    {
                        ConsoleColor.Red.WriteConsole(GroupNotification.CapacityFormatWrongMessage);
                        goto Capacity;
                    }
                    _groupService.Edit(id, new Group { Name = name, Capacity = capacity });
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


        public void GetById()
        {
            Id: ConsoleColor.DarkCyan.WriteConsole(GroupNotification.EnterGroupId);
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                goto Id;
            }
            if (isCorrectId)
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.IdFormatWrongMessage);
                goto Id;
            }

            Group group = _groupService.GetById(id);
            if(group is null)
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.GroupNotFound);
                goto Id;

            }
        }


        public void Search()
        {
            Text: ConsoleColor.DarkGreen.WriteConsole(GroupNotification.EnterSearchText);
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole(GroupNotification.InputEmptyMessage);
                goto Text;
            }

            var response = _groupService.Search(text);
            var result = _groupService.GetAll();
            foreach (var item in result)
            {
                var res = $" Name - {item.Name} ; Capacity - {item.Capacity}";
                ConsoleColor.DarkCyan.WriteConsole(res);

            }


        }
    }
}

  