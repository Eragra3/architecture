using System;
using System.Collections.Generic;
using System.Text;

namespace KekManager.Domain
{
    public class ResearchFellow
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }
    }
}
