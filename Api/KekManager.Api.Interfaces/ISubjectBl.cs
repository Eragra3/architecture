using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekManager.Api.Interfaces
{
    public interface ISubjectBl
    {
        Task<IList<Subject>> GetAll();

        Task<Subject> SetSupervisor(int subjectId, int? supervisorId);
    }
}
