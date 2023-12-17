using IMDB.Domain;
using IMDB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.Repository.Repositories
{
    public class ActorRepository : IActorRepository
    { private List<Person> _actors;
        public ActorRepository()
        {
            _actors = new List<Person>();
        }

        public void Add(Person person)
        {
            _actors.Add(person);
        }

        public List<Person> Get()
        {
            return _actors.ToList();
        }
    }
}
