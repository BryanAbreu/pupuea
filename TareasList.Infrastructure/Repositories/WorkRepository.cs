﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareasList.Core.Entities;
using TareasList.Core.Interfaces;
using TareasList.Infrastructure.Data;

namespace WorksList.Core.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly WorkListContext _context;

        public WorkRepository(WorkListContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Work>> GetWorks()
        {
            var List = await _context.Works.AsNoTracking().ToListAsync();
            return List;
        }

        public async Task<Work> GetWork(int id)
        {
            var Task = await _context.Works.FirstOrDefaultAsync(x => x.WorkID == id);
            return Task;
        }

        public async Task InsertWork(Work work)
        {
             _context.Works.Add(work);
            await _context.SaveChangesAsync();
            
        }
    }
}
