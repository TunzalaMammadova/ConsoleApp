using System;
using Domain.Models;
using Repository.Enums;

namespace Service.Services.İnterfaces
{
	public interface IGroupService
	{
        void Create(Group group);
        void Delete(Group group);
        void Edit(int id, Group group);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> Search(string searchText);
        List<Group> Sort(SortType sort);
    }
}

