using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Domain
{
    public class WatchListItem 
    {
        public int Id { get; set; } 
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public bool IsWatched { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }

}
