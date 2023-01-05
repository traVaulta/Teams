using AutoMapper;
using Teams.Core.Person.DAL;

namespace Teams.Infrastructure.Person.DAL
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private readonly MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Person, Core.Person.Person>();
            cfg.CreateMap<Core.Person.Person, Person>();
        });
        private readonly TeamsDbContext _context;

        private bool _disposed = false;

        public PersonRepository(TeamsDbContext context)
        {
            _context = context;
        }

        public Core.Person.Person GetPersonById(int personID)
        {
            var mapper = _mapperConfiguration.CreateMapper();
            var entity = _context.People.SingleOrDefault(person => person.Id == personID);
            return mapper.Map<Core.Person.Person>(entity);
        }

        public IEnumerable<Core.Person.Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public void InsertPerson(Core.Person.Person Person)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Core.Person.Person Person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int personID)
        {
            throw new NotImplementedException();
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
