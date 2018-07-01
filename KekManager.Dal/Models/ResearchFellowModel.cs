using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekManager.Data.Models
{
    public class ResearchFellowModel
    {
        public int Id { get; set; }

        // SecurityUser - coming from separate app
        public int? UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Title { get; set; }
    }
}
