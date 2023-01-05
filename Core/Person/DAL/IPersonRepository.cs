namespace Teams.Core.Person.DAL
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeople();

        Person GetPersonById(int personId);

        void InsertPerson(Person person);

        void DeletePerson(int personId);

        void UpdatePerson(Person person);

        void Save();
    }
}
