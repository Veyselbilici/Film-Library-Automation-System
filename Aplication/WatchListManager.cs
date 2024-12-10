using FinalProject.Core.Domain;
using FinalProject.Core.Services;
using FinalProject.Infstructure.Database.Mssql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Aplication
{
    public class WatchListManager : IWatchListManager
    {
        private readonly FinalProjectDbContext db;

        public WatchListManager(FinalProjectDbContext db)
        {
            this.db = db;
        }

        public bool AddMovieToWatchList(int movieId, string userTc)
        {
            var isAny = db.WatchList.Any(x => x.MovieId == movieId && x.UserId == userTc);

            if (isAny)
                return true;

            var addItem = new WatchListItem();
            addItem.MovieId = movieId;
            addItem.UserId = userTc;
            db.WatchList.Add(addItem);
            db.SaveChanges();

            return true;
        }

        public bool DeleteFromWatchList(int id)
        {
            var removeItem = db.WatchList.First(x => x.Id == id);
            db.WatchList.Remove(removeItem);
            db.SaveChanges();
            return true;
        }

        public IList<WatchListItem> GetUsersWatchList(string userTc)
        {
            return db.WatchList.Include(x=>x.Movie).Where(x => x.UserId == userTc).ToList();
           
        }

        public bool ToggleIsWatched(int id)
        {
            var toggleItem = db.WatchList.First(x => x.Id == id);
            toggleItem.IsWatched = !toggleItem.IsWatched;
            return true;
        }
    }
}
