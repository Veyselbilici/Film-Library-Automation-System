using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Domain
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReviewCount { get; set; }
        public decimal ReviewPoint { get; set; }
        public DateTime AddedDate { get; set; }
        public Genre Genre { get; set; }
        public List<Actor> Actors { get; set; }
        public Director Director { get; set; }


    }
}
