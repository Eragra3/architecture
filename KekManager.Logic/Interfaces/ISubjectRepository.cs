using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekManager.Logic.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IList<Subject>> GetAll();

        Task<Subject> GetById(int id);

        Task<Subject> Update(Subject param);
    }
}
