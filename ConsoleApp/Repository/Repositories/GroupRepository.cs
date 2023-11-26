using System;
using Domain.Models;
using Repository.Data;
using Repository.Enums;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> Search(string searchText)
        {
            return AppDbContext<Group>.Datas.Where(m => m.Name.ToLower().Trim().Contains(searchText.Trim().ToLower())).ToList();
        }


        public List<Group> Sort(SortType sort)
        {
            switch (sort)
            {
                case SortType.Asc:
                    return AppDbContext<Group>.Datas.OrderBy(m => m.Capacity).ToList();
                case SortType.Desc:
                    return AppDbContext<Group>.Datas.OrderByDescending(m => m.Capacity).ToList();

            }
            return default;
        }
        

        public void Edit(int id, Group group)
        {
            var result  = GetById(id);
            if(result is not null)
            {
                if (!string.IsNullOrWhiteSpace(result.Name))
                    result.Name = group.Name;

                if (group.Capacity is not null)
                    result.Capacity = group.Capacity;
                
            }
    
        }
    }
}




