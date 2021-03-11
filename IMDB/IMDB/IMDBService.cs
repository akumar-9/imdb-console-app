using IMDB.Domain;
using IMDB.Repository.Repositories;
using System;
using System.Linq;

namespace IMDB
{
    class IMDBService
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
            if (DateTime.TryParse(dob, out date))
            {
                if (date.Year > 2010)
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
            if (DateTime.TryParse(dob, out date))
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
        public void AddMovie(string name, int year, string plot)
        {
            if (String.IsNullOrEmpty(name.Trim()) || year < 1870 || String.IsNullOrEmpty(plot.Trim()))
            {
                Console.WriteLine(" Enter valid name, year or plot");
                return;
            }
               
            else
            {
                var movie = new Movie(name, year, plot);
                if (ChooseActors(movie))
                    if(ChooseProducer(movie))
                    _movieRepository.Add(movie);
            }
        }
        public bool ChooseActors(Movie movie)
        {
            var actors = _actorRepository.Get();
            if (actors.Count > 0)
            {
                Console.WriteLine("Choose actors ...");
                for (var i = 0; i < actors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {actors[i].Name}");
                }

                var tokens = Console.ReadLine().Split(' ');
                var nums = Array.ConvertAll(tokens, int.Parse);
                if (nums.Length < 1)
                {
                    Console.WriteLine("There should be atleast one actor!!");
                    return false;
                }

                else
                {
                    foreach (var num in nums)
                    {   if ( num > actors.Count)
                        {
                            Console.WriteLine("choose a valid input);
                            return false;
                        }
                        if (Convert.ToDateTime(actors[num - 1].DOB).Year < movie.YearOfRelease)
                            movie.Actors.Add(actors[num - 1]);
                        else
                        {
                            Console.WriteLine("Actor is not born yet!!");
                            return false;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Add Actors First!!");
                return false;
            }
            return true;
        }
        public bool ChooseProducer(Movie movie)
        {
            var producers = _producerRepository.Get();
            if (producers.Count > 0)

            {
                Console.WriteLine("Choose ONLY 1 producer ...");
                for (var i = 0; i < producers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {producers[i].Name}\n");
                }

                var choice = Convert.ToInt32(Console.ReadLine()[0]);
                if ( choice > producers.Count)
                {
                    Console.WriteLine("Choose a valid input");
                    return false;
                }

                if (Convert.ToDateTime(producers[choice - 1].DOB).Year < movie.YearOfRelease)
                    movie.Producer = producers[choice - 1];
                else
                {
                    Console.WriteLine("Producer is not born yet!!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Add Producers !!");
                return false;
            }
            return true;
        }
        public void ListMovies()
        {
            var movies = _movieRepository.Get();

            for (var i = 0; i < movies.Count; i++)
            {
                Console.WriteLine(i+1);
                Console.WriteLine($"{movies[i].Name} ({movies[i].YearOfRelease})");
                Console.WriteLine($"Plot - {movies[i].Plot}");
                Console.Write("Actors - ");
                foreach(var movieActor in movies[i].Actors)
                {
                    Console.Write(movieActor.Name + "  "); 

                }

                Console.WriteLine("\nProducers - " + movies[i].Producer.Name + " \n\n");
            }
        }
        public void DeleteMovie()
        {
            Console.WriteLine("Choose the movie to delete");
            ListMovies();
            _movieRepository.Delete(Convert.ToInt32(Console.ReadLine()) - 1);
        }
    }
}
