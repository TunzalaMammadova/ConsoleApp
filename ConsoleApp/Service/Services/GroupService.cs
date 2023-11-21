using System;
using Domain.Models;
using Repository.Enums;
using Repository.Repositories;
using Repository.Repositories.İnterfaces;
using Service.Services.İnterfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public void Create(Group group)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group group)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Group group)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public List<Group> Sort(SortType sort)
        {
            throw new NotImplementedException();
        }
    }
}

