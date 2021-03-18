using IMDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Repository.Interfaces
{
    public interface IActorRepository
    {
        void Add(Person person);
        List<Person> Get();
    }
}
