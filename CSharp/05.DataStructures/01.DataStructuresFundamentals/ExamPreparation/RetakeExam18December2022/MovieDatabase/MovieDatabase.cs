using System;
using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        public void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Actor actor)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            throw new NotImplementedException();
        }
    }
}
