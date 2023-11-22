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
            _groupRepository.Create(group);
        }

        public void Delete(Group group)
        {
            _groupRepository.Delete(group);
        }

        public void Edit(int id, Group group)
        {
            _groupRepository.Edit(id,group);
        }

        public List<Group> GetAll() => _groupRepository.GetAll();


        public Group GetById(int id) => _groupRepository.GetById(id);


        public List<Group> Search(string searchText) => _groupRepository.Search(searchText);
        

        public List<Group> Sort(SortType sort) => _groupRepository.Sort(sort);
        
    }
}

