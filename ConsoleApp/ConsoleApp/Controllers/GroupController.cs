using System;
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


	}
}

  