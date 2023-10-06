using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<string, Actor> actors = new Dictionary<string, Actor>();
        private HashSet<Movie> movies = new HashSet<Movie>();

        public void AddActor(Actor actor)
        {
            actors.Add(actor.Id, actor);
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!actors.ContainsKey(actor.Id))
            {
                throw new ArgumentException();
            }

            movies.Add(movie);
            actors[actor.Id].Movies.Add(movie);
        }

        public bool Contains(Actor actor)
        {
            return actors.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return actors.Values
                .OrderByDescending(a => a.Movies.Max(m => m.Budget))
                .ThenByDescending(a => a.Movies.Count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return movies
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return movies
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return actors.Values
                .Where(a => a.Movies.Count == 0);
        }
    }
}
