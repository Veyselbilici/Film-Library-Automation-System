using FinalProject.Core.Domain;
using FinalProject.Core.Services;
using FinalProject.Core.ViewModals;
using FinalProject.Infstructure.Database.Mssql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Aplication
{
    public class MovieManager : IMovieManager
    {
        private readonly FinalProjectDbContext db;

        public MovieManager(FinalProjectDbContext db)
        {
            this.db = db;
        }

        public StatisticsViewModal GetStatistics()
        {
            var statistics = new StatisticsViewModal();

            // Get the Best Rated Movie based on ReviewPoint
            statistics.BestRatedMovie = db.Movies.OrderByDescending(x => x.ReviewPoint).First();

            // Get the Most Rated Film based on ReviewCount
            statistics.MostRatedFilm = db.Movies.OrderByDescending(x => x.ReviewCount).First();

            // Get the Most Rated Director based on the sum of ReviewPoints of their movies
            statistics.MostRatedDirector = db.Directors
                .OrderByDescending(d => d.Movies.Sum(m => m.ReviewPoint))
                .First();

            // Get the Best Rated Director based on the average ReviewPoint of their movies
            statistics.BestRatedDirector = db.Directors
                .OrderByDescending(d => d.Movies.Average(m => m.ReviewPoint))
                .First();

            // Get the Most Rated Genre based on the sum of ReviewPoints of movies in that genre
            statistics.MostRatedGenre = db.Genres
                .OrderByDescending(g => g.Movies.Sum(m => m.ReviewPoint))
                .First();

            // Get the Best Rated Genre based on the average ReviewPoint of movies in that genre
            statistics.BestRatedGenre = db.Genres
                .OrderByDescending(g => g.Movies.Average(m => m.ReviewPoint))
                .First();

            return statistics;
        }

        public bool AddActorToMovie(int actorId, int movieId)
        {
            var movie = db.Movies.Include(x => x.Actors).First(x => x.ID == movieId);
            movie.Actors.Add(db.Actors.First(x => x.ID == actorId));
            db.SaveChanges();
            return true;
        }

        public bool CreateActor(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
            return true;
        }

        public bool CreateDirector(Director Director)
        {
            db.Directors.Add(Director);
            db.SaveChanges();
            return true;
        }

        public bool CreateGenre(Genre Genre)
        {
            db.Genres.Add(Genre);
            db.SaveChanges();
            return true;
        }

        public bool CreateMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return true;
        }

        public bool DeleteActor(int actorId)
        {
            var actor = db.Actors.First(x => x.ID == actorId);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return true;
        }

        public bool DeleteDirector(int DirectorId)
        {
            var director = db.Directors.First(x => x.ID == DirectorId);
            db.Directors.Remove(director);
            db.SaveChanges();
            return true;
        }

        public bool DeleteGenre(int GenreId)
        {
            var genre = db.Genres.First(x => x.ID == GenreId);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return true;
        }

        public bool DeleteMovie(int movieId)
        {
            var movie = db.Movies.First(x => x.ID == movieId);
            db.Remove(movie);
            db.SaveChanges();
            return true;
        }

        public Actor GetActorById(int id)
        {
            return db.Actors.AsNoTracking().First(x => x.ID == id);
        }

        public IList<Movie> GetAddedMoviesAfterDate(DateTime date)
        {
            return db.Movies.Include(x=>x.Genre).Include(x=>x.Director).AsNoTracking().Where(x=>x.AddedDate > date).ToList(); 
        }

        public IList<Actor> GetAllActors()
        {
            return db.Actors.ToList();
        }

        public IList<Director> GetAllDirectors()
        {
            return db.Directors.ToList();
        }

        public IList<Genre> GetAllGenres()
        {
            return db.Genres.ToList();
        }

        public IList<Movie> GetAllMovies()
        {
            return db.Movies.Include(x => x.Genre).Include(x => x.Director).ToList();
        }

        public Director GetDirectorById(int id)
        {
            return db.Directors.First(x => x.ID == id);
        }

        public Genre GetGenreById(int id)
        {
            return db.Genres.First(x => x.ID == id);
        }

        public Movie GetMovieById(int id)
        {
            return db.Movies.Include(x => x.Actors).Include(x => x.Genre).Include(x => x.Director).First(x => x.ID == id);
        }

        public IList<Movie> SearchMovies(string search)
        
        {
            search = search.ToLower();
            return db.Movies.Include(x => x.Genre).Include(x => x.Actors).Include(x => x.Director).Where(x => x.Actors.Any(y => y.Name.ToLower().Contains(search)) || x.Director.Name.ToLower().Contains(search) || x.Name.ToLower().Contains(search) ||x.Genre.Name.ToLower().Contains(search)).ToList();
        }

        public bool UpdateActor(Actor actor)
        {
            var u_actor = db.Actors.First(x => x.ID == actor.ID);
            u_actor.Name = actor.Name;
            db.SaveChanges();
            return true;
        }

        public bool UpdateDirector(Director Director)
        {
         
            var u_actor = db.Directors.First(x => x.ID == Director.ID);
            u_actor.Name = Director.Name;
            db.SaveChanges();
            return true;   
        }

        public bool UpdateGenre(Genre Genre)
        {
            var genre = db.Genres.First(x => x.ID == Genre.ID);
            genre.Name = Genre.Name;

            db.SaveChanges();
            return true;
        }

        public bool UpdateMovie(Movie movie)
        {
            var u_movie = db.Movies.First(x => x.ID == movie.ID);
            u_movie.Name = movie.Name;
            u_movie.Director = movie.Director;
            u_movie.ReleaseDate = movie.ReleaseDate;
            db.SaveChanges();
            return true;
        }
    }
}
