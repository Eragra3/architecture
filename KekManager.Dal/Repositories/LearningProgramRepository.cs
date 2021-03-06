﻿using AutoMapper;
using KekManager.Data.Contexts;
using KekManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KekManager.Logic.Interfaces;
using KekManager.Data.Models;

namespace KekManager.Data.Repositories
{
    public class LearningProgramRepository : ILearningProgramRepository
    {
        protected readonly IMainDbContext _context;
        protected readonly IMapper _mapper;

        public LearningProgramRepository(IMainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LearningProgram> Add(LearningProgram param)
        {
            var entity = _mapper.Map<LearningProgramModel>(param);
            var result = await _context.LearningProgram.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<LearningProgram>(result.Entity);
        }

        public async Task<IList<LearningProgram>> GetAll()
        {
            return await _context
                .LearningProgram
                .Include(x => x.Modules)
                .Select(e => _mapper.Map<LearningProgram>(e))
                .ToListAsync();
        }
    }
}
