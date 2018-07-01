using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Data.Models
{
    public class SubjectKekJoinModel
    {
        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; }

        public int KekId { get; set; }
        public KekModel Kek { get; set; }
    }
}
