using FinalProject.Core.Domain;
using FinalProject.Core.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IMovieManager
    {
        StatisticsViewModal GetStatistics();
        IList<Movie> GetAllMovies();
        IList<Movie> SearchMovies(string search);
        Movie GetMovieById(int id);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(int movieId);
        bool CreateMovie(Movie movie);
        IList<Movie> GetAddedMoviesAfterDate(DateTime date);

        IList<Actor> GetAllActors();
        Actor GetActorById(int id);
        bool UpdateActor(Actor actor);
        bool DeleteActor(int actorId);
        bool CreateActor(Actor actor);
        bool AddActorToMovie(int actorId, int movieId);


        IList<Director> GetAllDirectors();
        Director GetDirectorById(int id);
        bool UpdateDirector(Director Director);
        bool DeleteDirector(int directorId);
        bool CreateDirector(Director Director);

        IList<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        bool UpdateGenre(Genre Genre);
        bool DeleteGenre(int genreId);
        bool CreateGenre(Genre Genre);
    }
}
