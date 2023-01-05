using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teams.Core.Conversation.DAL;

namespace Teams.Infrastructure.Conversation.DAL
{
    public class ConversationRepository : IConversationRepository, IDisposable
    {
        private readonly MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Conversation, Core.Conversation.Conversation>();
            cfg.CreateMap<Core.Conversation.Conversation, Conversation>();
            cfg.CreateMap<Person.Person, Core.Person.Person>();
        });
        private readonly TeamsDbContext _context;

        private bool _disposed = false;

        public ConversationRepository(TeamsDbContext context)
        {
            _context = context;
        }

        public Core.Conversation.Conversation GetConversationById(int converstionID)
        {
            var mapper = _mapperConfiguration.CreateMapper();
            var entity = _context.Conversations
                .Where(conversation => conversation.Id == converstionID)
                .Include(conversation => conversation.Participants)
                .Include(conversation => conversation.Messages);
            return mapper.Map<Core.Conversation.Conversation>(entity);
        }

        public IEnumerable<Core.Conversation.Conversation> GetConversations()
        {
            throw new NotImplementedException();
        }

        public void InsertConversation(Core.Conversation.Conversation conversation)
        {
            var mapper = _mapperConfiguration.CreateMapper();
            //var entity = mapper.Map<Conversation>(conversation);
            var entity = new Conversation {
                Id = conversation.Id,
                Title = conversation.Title
            };
            var result = _context.Conversations.Add(entity);

            PersonConversationJunction[] junctions = new PersonConversationJunction[conversation.Participants.Count()];
            int i = 0;
            foreach (var person in conversation.Participants)
            {
                junctions[i] = new PersonConversationJunction()
                {
                    ConversationId = result.Entity.Id,
                    PersonId = person.Id
                };
                ++i;
            }
            _context.PersonConversationJunctions.AddRange(junctions);

            _context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateConversation(Core.Conversation.Conversation conversation)
        {
            throw new NotImplementedException();
        }

        public void DeleteConversation(int converstionID)
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
