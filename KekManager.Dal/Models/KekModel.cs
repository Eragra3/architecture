using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekManager.Data.Models
{
    public class KekModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [EnumDataType(typeof(EkLevel))]
        public EkLevel Level { get; set; }

        [EnumDataType(typeof(EkType))]
        public EkType Type { get; set; }

        public ICollection<SubjectKekJoinModel> Subjects { get; set; }

        public ICollection<PekModel> Peks { get; set; }

        public int LearningProgramId { get; set; }
        public LearningProgramModel LearningProgram { get; set; }
    }
}
