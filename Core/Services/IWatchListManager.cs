using FinalProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IWatchListManager
    {
        IList<WatchListItem> GetUsersWatchList(string userTc);
        bool AddMovieToWatchList(int movieId, string userTc);
        bool ToggleIsWatched (int id);
        bool DeleteFromWatchList(int id);
    }
}
