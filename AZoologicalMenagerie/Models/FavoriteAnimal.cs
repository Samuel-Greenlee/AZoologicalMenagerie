using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZoologicalMenagerie.Models
{
    public class FavoriteAnimal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Animal { get; set; }
        public string Reason { get; set; }
    }
}
