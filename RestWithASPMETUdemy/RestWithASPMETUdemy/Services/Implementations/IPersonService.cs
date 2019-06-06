using RestWithASPMETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPMETUdemy.Services.Implementations
{
    interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
