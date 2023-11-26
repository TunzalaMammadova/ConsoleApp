using System;
using Domain.Models;
using Repository.Enums;

namespace Repository.Repositories.İnterfaces
{
	public interface IGroupRepository : IBaseRepository<Group>
	{
        List<Group> Search(string searchText);
        List<Group> Sort(SortType sort);
        void Edit(int id, Group entity);
    }
}

