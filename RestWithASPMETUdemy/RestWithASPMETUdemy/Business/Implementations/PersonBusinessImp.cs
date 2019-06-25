using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPMETUdemy.Model;
using RestWithASPMETUdemy.Model.Context;
using RestWithASPMETUdemy.Service.Implementations;

namespace RestWithASPMETUdemy.Business.Implementations
{
    
    public class PersonBusinessImp : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImp(IPersonRepository repository)
        {
            _repository = repository;
        }
            
        public Person Create(Person person)
        {
            _repository.Create(person);
            return person;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return  _repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }


        public void Delete(long id)
        {
             _repository.Delete(id);
        }

    }
}
