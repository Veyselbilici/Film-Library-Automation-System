using FinalProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.ViewModals
{
    public class StatisticsViewModal
    {
        public Movie MostRatedFilm { get; set; }
        public Movie BestRatedMovie { get; set; }
        public Genre MostRatedGenre { get; set; }
        public Genre BestRatedGenre { get; set; }
        public Director MostRatedDirector { get; set; }
        public Director BestRatedDirector { get; set; }
    }
}
