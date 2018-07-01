using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Domain
{
    public class Pek
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EkLevel Level { get; set; }

        public EkType Type { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int KekId { get; set; }
        public Kek Kek { get; set; }
    }
}
