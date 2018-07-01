using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KekManager.Api.Interfaces
{
    public class AddLearningProgramParam
    {
        [Required]
        public string Name { get; set; }

        public string Specialization { get; set; }

        [Range(0, int.MaxValue)]
        public int NumberOfSemesters { get; set; }

        [EnumDataType(typeof(Level))]
        public Level Level { get; set; }

        [EnumDataType(typeof(Mode))]
        public Mode Mode { get; set; }

        [Range(0, int.MaxValue)]
        public int CnpsHours { get; set; }
    }
}
