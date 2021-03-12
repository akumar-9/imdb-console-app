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
                showMenu = MainMenu(imdbService);
        }
        static bool MainMenu(IMDBService imdbService)
        {
           // Console.Clear();
            Console.WriteLine( "Choose an option");
            Console.WriteLine("1) List Movies \n2)Add Movie \n3)Add Actor \n4)Add Producer \n5)Delete Movie \n6)Exit");
            Console.WriteLine(" What do you want to do?");

            switch (Console.ReadLine())
            {
                case "1":
                    imdbService.ListMovies();
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
                    imdbService.DisplayPersons(imdbService.GetActors());
                    string actorIds = Console.ReadLine();
                    
                    
                    Console.WriteLine("Choose Producers...");
                    imdbService.DisplayPersons(imdbService.GetProducers());
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
                    imdbService.DeleteMovie();
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        } 
        
    }
}
