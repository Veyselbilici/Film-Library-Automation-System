using FinalProject.Core.Domain;
using FinalProject.Core.Services;
using FinalProject.Infstructure.Database.Mssql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Aplication
{
    public class ReviewManager : IReviewManager
    {
        private readonly FinalProjectDbContext db;
        public ReviewManager(FinalProjectDbContext db)
        {
            this.db = db;
        }

        public bool CreateReview(Review Review)
        {
            db.Reviews.Add(Review);
            var movie = db.Movies.First(x => x.ID == Review.ID);

            movie.ReviewPoint = ((movie.ReviewPoint * movie.ReviewCount) + Review.ReviewPoint) / movie.ReviewCount + 1;

            movie.ReviewCount += 1;
            db.SaveChanges();
            return true;
        }

        public bool DeleteReview(Review Review)
        {
            var removeItem = db.Reviews.Where(x => x.ID == Review.ID).First();

            db.Remove(removeItem);
            db.SaveChanges();
            return true;
        }

        public IList<Review> GetMoviesReviews(int movieId)
        {
            return db.Reviews.Where(x => x.Movie.ID == movieId).ToList();
        }

        public bool UpdateReview(Review Review)
        {
            throw new NotImplementedException();
        }
    }
}
