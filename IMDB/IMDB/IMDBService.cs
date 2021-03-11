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
                throw new ArgumentNullException("Please enter a valid name or DOB");
            DateTime date;
            if (DateTime.TryParse(dob, out date))
            {
                if (date.Year < 2010)
                {
                    throw new ArgumentOutOfRangeException("YOB Cant be greater than current year ");
                }
            }
            else
            {
                throw new ArgumentException("enter valid DOB");
            }
            var person = new Person(name, dob);
            _actorRepository.Add(person);
        }

        public void AddProducer(string name, string dob)
        {
            if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(dob.Trim()))
                throw new ArgumentNullException("Please enter a valid name or DOB");
            DateTime date;
            if (DateTime.TryParse(dob, out date))
            {
                if (date.Year.CompareTo(DateTime.Today.Year) > 0)
                {
                    throw new ArgumentOutOfRangeException("YOB Cant be greater than current year ");
                }
            }
            else
            {
                throw new ArgumentException("enter valid DOB");
            }
            var person = new Person(name, dob);
            _producerRepository.Add(person);
        }
        public void AddMovie(string name, int year, string plot)
        {
            if (String.IsNullOrEmpty(name.Trim()) || year < 1870 || String.IsNullOrEmpty(plot.Trim()))
                throw new ArgumentException(" Enter valid name, year or plot");
            else
            {
                var movie = new Movie(name, year, plot);
                ChooseActors(movie);
                ChooseProducer(movie);
                _movieRepository.Add(movie);
            }
        }
        public void ChooseActors(Movie movie)
        {
            var actors = _actorRepository.Get();
            Console.WriteLine("Choose actors" );
            for( var i = 0; i < actors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actors[i].Name}");
            }

            string[] tokens = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(tokens, int.Parse);
            if (nums.Length < 1)
                throw new ArgumentOutOfRangeException("There should be atleast one actor!");
            foreach(var num in nums)
            {
                
                movie.Actors.Add(actors[num - 1]);
            }
        }
        public void ChooseProducer(Movie movie)
        {
            var producers = _producerRepository.Get();
            for (var i = 0; i < producers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {producers[i].Name}\n");
            }

            string[] tokens = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(tokens, int.Parse);
            if (nums.Length > 1)
                throw new ArgumentOutOfRangeException("There can be atmost one producer!");
           
           else 
                movie.Producer = producers[nums[0] - 1];

           
            
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
                    Console.Write(movieActor.Name + ","); 

                }
                Console.WriteLine("Producers - " + movies[i].Producer.Name);
                Console.WriteLine("\n");
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
