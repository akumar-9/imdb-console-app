using IMDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Repository.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        List<Movie> Get();

        void Delete(int index);
    }
}
