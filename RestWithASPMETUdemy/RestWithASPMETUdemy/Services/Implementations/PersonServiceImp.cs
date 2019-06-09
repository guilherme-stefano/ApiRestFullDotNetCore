using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPMETUdemy.Model;
using RestWithASPMETUdemy.Model.Context;

namespace RestWithASPMETUdemy.Services.Implementations
{
    
    public class PersonServiceImp : IPersonService
    {
        private MySQLContext _context;
        private volatile int count;

        public PersonServiceImp(MySQLContext context)
        {
            _context = context;
        }
            
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return  _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public bool Exist(long? id)
        {
            if(id != null)
            return _context.Persons.Any(p => p.Id.Equals(id));

            return false;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if(result != null)_context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            return Interlocked.Increment(ref count);
        }
    }
}
