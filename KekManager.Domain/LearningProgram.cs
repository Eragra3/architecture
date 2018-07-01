using System;
using System.Collections.Generic;

namespace KekManager.Domain
{
    public class LearningProgram
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public int NumberOfSemesters { get; set; }

        public Level Level { get; set; }

        public Mode Mode { get; set; }

        public IList<Module> Modules { get; set; }

        public int CnpsHours { get; set; }

        public ICollection<Kek> Keks { get; set; }
    }
}
