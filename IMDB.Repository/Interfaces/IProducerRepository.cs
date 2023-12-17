using IMDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Repository.Interfaces
{
    public interface IProducerRepository
    {
        void Add(Person person);
        List<Person> Get();
    }
}
