using IMDB.Domain;
using IMDB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.Repository.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        readonly private List<Movie> _movieList;

        /// <summary> To initialize the movieList </summary>
        public MovieRepository()
        {
            _movieList = new List<Movie>();
        }
        public void Add(Movie movie)
        {
            _movieList.Add(movie);
        }

        public void Delete(int index)
        {
            _movieList.RemoveAt(index);
        }

        public List<Movie> Get()
        {
            return _movieList.ToList();
        }
    }
}
