using FinalProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IReviewManager
    {
        IList<Review> GetMoviesReviews(int movieId); 
        bool UpdateReview(Review Review);
        bool DeleteReview(Review Review);
        bool CreateReview(Review Review);

    }
}
