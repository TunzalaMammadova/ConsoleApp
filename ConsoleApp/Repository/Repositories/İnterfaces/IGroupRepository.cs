using System;
using Domain.Models;
using Repository.Enums;

namespace Repository.Repositories.İnterfaces
{
	public interface IGroupRepository : IBaseRepository<Group>
	{
        public List<Group> Search(string searchText);
        public List<Group> Sort(SortType sort);
    }
}

