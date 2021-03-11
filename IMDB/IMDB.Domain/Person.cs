using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Domain
{
    public class Person
    {
        public Person(string name, string dob)
        {
            Name = name;
            DOB = dob;
        }

        public string Name { get; set; }
        public string DOB { get; set; }
    }
}
