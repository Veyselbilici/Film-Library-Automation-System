using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Domain
{
    public class Review
    {
        public int ID { get; set; }
        public decimal ReviewPoint { get; set; }
        public string ReviewMessage { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
