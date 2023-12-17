using System;
using System.Collections.Generic;

namespace IMDB
{
    class Program
    {
        static void Main(string[] args)
        {

            var imdbService = new IMDBService();
            var showMenu = true;
            while (showMenu)
            {
                try
                {
                    showMenu = MainMenu(imdbService);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("****** SORRY, " + ex.Message + "!! ******");
                }
            }
              
        }
        static bool MainMenu(IMDBService imdbService)
        {
           // Console.Clear();
            Console.WriteLine("\n\n============   Choose an option   ===========");
            Console.WriteLine("1) List Movies \n2)Add Movie \n3)Add Actor \n4)Add Producer \n5)Delete Movie \n6)Exit");
            Console.WriteLine("\nWhat do you want to do?");

            switch (Console.ReadLine())
            {
                case "1":
                    
                    var movies = imdbService.ListMovies();
                    for (var i = 0; i < movies.Count; i++)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine(i + 1);
                        Console.WriteLine($"{movies[i].Name} ({movies[i].YearOfRelease})");
                        Console.WriteLine($"Plot - {movies[i].Plot}");
                        Console.Write("Actors - ");
                        foreach (var movieActor in movies[i].Actors)
                            Console.Write(movieActor.Name + "  ");
                        Console.WriteLine("\nProducers - " + movies[i].Producer.Name + " \n\n");
                    }
                    return true;
                case "2":
                    var actorsCount = imdbService.GetActors().Count;
                    var producersCount = imdbService.GetProducers().Count;
                    if (actorsCount < 1)
                    {
                        Console.WriteLine("Add Actors into the list first!!");
                        return true;
                    }
                    if (producersCount < 1)
                    {
                        Console.WriteLine("Add Producers into the list first!!");
                        return true;
                    }
                    Console.Write("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Year of Release:");
                    int yor = Convert.ToInt32( Console.ReadLine());
                    Console.WriteLine("Plot:");
                    string plot = Console.ReadLine();
                   
                    
                    Console.WriteLine("Choose Actors...");
                   var actorsList = imdbService.GetActors();
                    for (var i = 0; i < actorsList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {actorsList[i].Name}");
                    }
                    string actorIds = Console.ReadLine();
                    
                    
                    Console.WriteLine("Choose Producers...");
                 var producersList = imdbService.GetProducers();
                 
                    for (var i = 0; i < producersList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {producersList[i].Name}");
                    }
                    int producerId = Convert.ToInt32(Console.ReadLine());
                    imdbService.AddMovie(name,yor,plot,actorIds,producerId);
                    return true;
                case "3":
                    Console.Write("Name:");
                    string actorname = Console.ReadLine();
                    Console.WriteLine("Date of Birth(dd-mm-yyyy):");
                    string dob = Console.ReadLine();
                    imdbService.AddActor(actorname, dob);
                    return true;
                case "4":
                    Console.Write("Name:");
                    string producername = Console.ReadLine();
                    Console.WriteLine("Date of Birth(dd-mm-yyyy):");
                    string pdob = Console.ReadLine();
                    imdbService.AddProducer(producername, pdob);
                    return true;
                case "5":
                    var moviesPresent = imdbService.ListMovies();
                    for (var i = 0; i < moviesPresent.Count; i++)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine(i + 1);
                        Console.WriteLine($"{moviesPresent[i].Name} ({moviesPresent[i].YearOfRelease})");
                        Console.WriteLine($"Plot - {moviesPresent[i].Plot}");
                        Console.Write("Actors - ");
                        foreach (var movieActor in moviesPresent[i].Actors)
                            Console.Write(movieActor.Name + "  ");
                        Console.WriteLine("\nProducers - " + moviesPresent[i].Producer.Name + " \n\n");
                    }
                    Console.WriteLine("Choose the movie to delete from the above list...");
                    int movieId = Convert.ToInt32(Console.ReadLine());
                    if(movieId < moviesPresent.Count && moviesPresent.Count > 0)
                        imdbService.DeleteMovie(movieId);
                    else
                        throw new Exception("Invalid input");
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        } 
        
    }
}
