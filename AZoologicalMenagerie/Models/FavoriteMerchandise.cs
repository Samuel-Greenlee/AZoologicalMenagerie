using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZoologicalMenagerie.Models
{
    public class FavoriteMerchandise
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Item { get; set; }
        public string ReasonBought { get; set; }
    }
}
