using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? SupervisorId { get; set; }
        public ResearchFellowModel Supervisor { get; set; }

        public ICollection<SubjectKekJoinModel> Keks { get; set; }

        public ICollection<PekModel> Peks { get; set; }
    }
}
