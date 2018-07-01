using AutoMapper;
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
    public class ResearchFellowRepository : IResearchFellowRepository
    {
        protected readonly IMainDbContext _context;
        protected readonly IMapper _mapper;

        public ResearchFellowRepository(IMainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ResearchFellow>> GetAll()
        {
            return await _context
                .ResearchFellow
                .Select(e => _mapper.Map<ResearchFellow>(e))
                .ToListAsync();
        }
    }
}
