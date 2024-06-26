﻿using Domain.Groups;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.Groups
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly ApplicationContext _applicationContext;

        internal GroupRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(Group entity)
        {
            await _applicationContext.Groups.AddAsync(entity);
        }

        public async Task<Group> Get(GroupId groupId)
        {
            return await _applicationContext.Groups.FindAsync(groupId);
        }

        public async Task<List<Group>> GetAll()
        {
            return await _applicationContext.Groups.ToListAsync();
        }

        public void Update(Group entity)
        {
            _applicationContext.Groups.Update(entity);
        }
    }
}
