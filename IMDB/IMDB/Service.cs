using IMDB.Domain;
using IMDB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IMDB
{
   public class IMDBService
    {   private readonly ActorRepository _actorRepository;
        private readonly ProducerRepository _producerRepository;
        private readonly MovieRepository _movieRepository;
        public IMDBService()
        {
            _actorRepository = new ActorRepository();
            _producerRepository = new ProducerRepository();
            _movieRepository = new MovieRepository();
        }
        public void AddActor(string name, string dob)
        {
            if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(dob.Trim()))
                throw new Exception("Please enter a valid name or DOB");    
            DateTime date;
            if (DateTime.TryParseExact(dob, "dd-MM-yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out date))
            {
                if (date.Year > DateTime.Now.Year - 10)
                    throw new Exception("The Actor should be atleast 10 years old"); 
                else
                {
                    var person = new Person
                    {
                        Name = name,
                        DOB = date
                    };
                    _actorRepository.Add(person);
                }
            }
            else
                throw new Exception("Enter valid DOB in the DD-MM-YYYY format");
        }

        public void AddProducer(string name, string dob)
        {
            if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(dob.Trim()))
                throw new Exception("Please enter a valid name or DOB");   
            DateTime date;
            if (DateTime.TryParseExact(dob, "dd-MM-yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out date))
            {
                if (date.Year > DateTime.Now.Year - 21)
                    throw new Exception("The Producer should be at least 21 years old");
                else
                {
                    var person = new Person
                    {
                        Name = name,
                        DOB = date
                    };
                    _producerRepository.Add(person);
                }
            }
            else
                throw new Exception("Enter valid DOB in the DD-MM-YYYY format");

        }
        public void AddMovie(string name, int year, string plot, string actorIds, int producerId)
        {
            if (String.IsNullOrEmpty(name.Trim()) || year < 1870 || String.IsNullOrEmpty(plot.Trim()))
                throw new Exception("Enter valid name, year or plot");
            else
            {
                var movie = new Movie
                {
                    Name = name,
                    YearOfRelease = year,
                    Plot = plot,
                    Actors = GetActors(actorIds),
                    Producer = GetProducer(producerId)
                };
                _movieRepository.Add(movie);
            }
        }
       

        public List<Person> GetActors()
        {
           return _actorRepository.Get();
        }
        public List<Person> GetActors(string actorIds)
        {
            var actors = _actorRepository.Get();
            var movieActors = new List<Person>();
            var tokens =actorIds.Split(' ');
            var ids = Array.ConvertAll(tokens, int.Parse);
            if (actors.Count > 0)
            {
                if (ids.Length < 1)
                    throw new Exception("There should be atleast one actor!!");
                else
                {
                    foreach (var id in ids)
                    {
                        if (id > actors.Count)
                            throw new Exception("Choose a valid input");
                        else
                            movieActors.Add(actors[id - 1]);
                    }
                }  
            }
            else
                throw new Exception("Add Actors first!!");
            return movieActors.ToList();
        }
        
        public List<Person> GetProducers()
        {
            return _producerRepository.Get();
        }

        public Person GetProducer(int producerId)
        {
                var producers = _producerRepository.Get();
                return producers[producerId - 1];
        }

        public List<Movie> GetMovies()
        {
           return _movieRepository.Get();
        }
        public List<Movie> ListMovies()
        {
            var movies = GetMovies();
            if (movies.Count < 1)
                throw new Exception("Add Movies First");
            else
                return movies;
        }
        public void DeleteMovie(int movieId)
        {
            _movieRepository.Delete(movieId - 1);
        }

    }
}
