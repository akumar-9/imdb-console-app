using IMDB.Domain;
using IMDB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.Repository.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        readonly private List<Person> _producers;

        public ProducerRepository()
        {
            _producers = new List<Person>();
           // Console.WriteLine();
        }
        public void Add(Person person)
        {
            _producers.Add(person);
        }

        public List<Person> Get()
        {
            return _producers.ToList();
        }
    }
}
