using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Domain
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
