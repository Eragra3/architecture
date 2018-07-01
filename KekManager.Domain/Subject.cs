using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Domain
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? SupervisorId { get; set; }
        public ResearchFellow Supervisor { get; set; }

        public ICollection<Kek> Keks { get; set; }

        public ICollection<Pek> Peks { get; set; }
    }
}
