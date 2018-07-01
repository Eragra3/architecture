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
    public class SubjectRepository : ISubjectRepository
    {
        protected readonly IMainDbContext _context;
        protected readonly IMapper _mapper;

        public SubjectRepository(IMainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Subject> GetById(int id)
        {
            var entity = await _context
                .Subject
                .AsNoTracking()
                .Include(x => x.Supervisor)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Subject>(entity);
        }

        public async Task<Subject> Update(Subject param)
        {
            var tracker = _context
                .Subject
                .Update(_mapper.Map<SubjectModel>(param));

            await _context.SaveChangesAsync();

            var entity = await _context
                .Subject
                .Include(x => x.Supervisor)
                .FirstOrDefaultAsync(x => x.Id == tracker.Entity.Id);

            return _mapper.Map<Subject>(entity);
        }

        public async Task<IList<Subject>> GetAll()
        {
            return await _context
                .Subject
                .Include(x => x.Supervisor)
                .Select(e => _mapper.Map<Subject>(e))
                .ToListAsync();
        }
    }
}
