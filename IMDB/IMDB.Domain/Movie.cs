using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Domain
{
   public class Movie
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }

        public List<Person> Actors { get; set; }

        public Person Producer { get; set; }

        public Movie()
        {
            Actors = new List<Person>();
        }
       //public Movie(string name, int year, string plot, List<Person> actors, Person producer) : this()
       // {

       //     Name = name;
       //     YearOfRelease = year;
       //     Plot = plot;
       //     Actors = actors;
       //     Producer = producer;
       // }

        
    }
}
