using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Domain
{
    public class Kek
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EkLevel Level { get; set; }

        public EkType Type { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Pek> Peks { get; set; }

        public int LearningProgramId { get; set; }
        public LearningProgram LearningProgram { get; set; }
    }
}
