using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekManager.Data.Models
{
    public class LearningProgramModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specialization { get; set; }

        public int NumberOfSemesters { get; set; }

        public Level Level { get; set; }

        public Mode Mode { get; set; }

        public ICollection<ModuleModel> Modules { get; set; }

        public int CnpsHours { get; set; }
    }
}
