using System;
using System.Xml.Linq;
using Domain.Models;
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
            Name:ConsoleColor.Cyan.WriteConsole("Please enter groupname:");
			string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Cannot be empty, please try again");
                goto Name;
            }

            Cpacity:ConsoleColor.Cyan.WriteConsole("Please enter capacity:");
            string capacity = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(capacity))
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
            ConsoleColor.Cyan.WriteConsole("Please enter group id");
            Id: string IdStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(IdStr, out id);

            if (isCorrectId)
            {
                var result = _groupService.GetById(id);
                _groupService.Delete(result);
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please try again");
                goto Id;
            }

            
        }

        
	}
}

  