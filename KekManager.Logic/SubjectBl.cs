using KekManager.Logic.Interfaces;
using System;
using KekManager.Api.Interfaces;
using KekManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace KekManager.Logic
{
    public class SubjectBl : ISubjectBl
    {
        protected readonly ISubjectRepository _repository;
        protected readonly IMapper _mapper;

        public SubjectBl(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Subject> SetSupervisor(int subjectId, int? supervisorId)
        {
            var subject = await _repository.GetById(subjectId);
            subject.SupervisorId = supervisorId;
            subject.Supervisor = null;

            var updatedEntity = await _repository.Update(subject);

            return updatedEntity;
        }

        public async Task<IList<Subject>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
