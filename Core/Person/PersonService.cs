using AutoMapper;
using Teams.Core.Person.DAL;

namespace Teams.Core.Person
{
    public class PersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Person? GetById(int personId)
        {
            return personRepository.GetPersonById(personId);
        }
    }
}
