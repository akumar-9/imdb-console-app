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
            {
                Console.WriteLine("Please enter a valid name or DOB");
                return;
            }
            
            DateTime date;
            if (DateTime.TryParseExact(dob, "dd-MM-yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out date))
            {
               
                if (date.Year > DateTime.Now.Year - 10)
                {
                    Console.WriteLine("The Actor should be 10 years atleast ");
                    return;
                }
            }
            else
            {
                
                Console.WriteLine("enter valid DOB");
                return;
            }
            var person = new Person(name, dob);
            _actorRepository.Add(person);
        }

        public void AddProducer(string name, string dob)
        {
            if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(dob.Trim()))
            {
                 Console.WriteLine("Please enter a valid name or DOB");
                return;
            }
            DateTime date;
            if (DateTime.TryParseExact(dob, "dd-MM-yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out date))
            {
                if (date.Year.CompareTo(DateTime.Today.Year) > 0)
                {
                    Console.WriteLine("YOB Cant be greater than current year ");
                    return;
                }
            }
            else
            {
                Console.WriteLine("enter valid DOB");
                return;
            }
            var person = new Person(name, dob);
            _producerRepository.Add(person);
        }
        public void AddMovie(string name, int year, string plot, string actorIds, int producerId)
        {
            if (String.IsNullOrEmpty(name.Trim()) || year < 1870 || String.IsNullOrEmpty(plot.Trim()))
            {
                Console.WriteLine(" Enter valid name, year or plot");
                return;
            }
               
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
                {
                    Console.WriteLine("There should be atleast one actor!!");
                }
                else
                {
                    foreach (var id in ids)
                    {
                        if (id > actors.Count)
                        {
                            Console.WriteLine("choose a valid input");
                        }

                        movieActors.Add(actors[id - 1]);

                    }
                }  
            }
            else
            {
                Console.WriteLine("Add Actors first!!");
            }
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
        public void ListMovies()
        {
            var movies = GetMovies();
            if(movies.Count < 1)
            {
                Console.WriteLine("Add Movies First");
                return;
            }
            else
            for (var i = 0; i < movies.Count; i++)
            {
                Console.WriteLine(i+1);
                Console.WriteLine($"{movies[i].Name} ({movies[i].YearOfRelease})");
                Console.WriteLine($"Plot - {movies[i].Plot}");
                Console.Write("Actors - ");
                foreach(var movieActor in movies[i].Actors)
                    Console.Write(movieActor.Name + "  "); 
                Console.WriteLine("\nProducers - " + movies[i].Producer.Name + " \n\n");
            }
        }
        public void DeleteMovie()
        {
            Console.WriteLine("Choose the movie to delete");
            
            ListMovies();
            _movieRepository.Delete(Convert.ToInt32(Console.ReadLine()) - 1);
        }

        public void DisplayPersons(List<Person> personsList)
        {

           for (var i = 0; i < personsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personsList[i].Name}");
            }
        }
    }
}
