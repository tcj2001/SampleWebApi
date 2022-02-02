﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class SampleRepository : GenericRepository<Sample>, ISampleRepository
    {
        public SampleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        //public async Task<IEnumerable<Sample>> GetSampleByName(string name)
        //{
        //    return await _context.Set<Sample>().Where(x => x.Name == name).ToListAsync();
        //}
    }
}
