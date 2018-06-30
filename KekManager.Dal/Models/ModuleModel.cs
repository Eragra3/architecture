using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data.Models
{
    public class ModuleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CourseArea Area { get; set; }

        public int LearningProgramId { get; set; }
        public LearningProgramModel LearningProgram { get; set; }
    }
}
