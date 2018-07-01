using KekManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekManager.Data.Models
{
    public class PekModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [EnumDataType(typeof(EkLevel))]
        public EkLevel Level { get; set; }

        [EnumDataType(typeof(EkType))]
        public EkType Type { get; set; }

        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; }

        public int KekId { get; set; }
        public KekModel Kek { get; set; }
    }
}
