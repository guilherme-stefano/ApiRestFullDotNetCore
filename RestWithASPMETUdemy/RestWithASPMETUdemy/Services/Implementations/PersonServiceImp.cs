﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPMETUdemy.Model;

namespace RestWithASPMETUdemy.Services.Implementations
{
    
    public class PersonServiceImp : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public List<Person> FindAll(Person person)
        {
            List<Person> persons = new List<Person>();

            for(int i=0; i< 10; i++)
            {
                persons.Add(this.MockPerson(i));
            }

            return persons;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia - Minas Gerais - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person " + i,
                LastName = "Costa " + i,
                Address = "Uberlandia - " + i,
                Gender = "Male " + i,
            };
        }

        public long IncrementAndGet()
        {
            return Interlocked.Increment(ref count)
        }
    }
}