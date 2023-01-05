using AutoMapper;
using Teams.Core.Message.DAL;

namespace Teams.Infrastructure.Message.DAL
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private readonly MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Message, Core.Message.Message>();
            cfg.CreateMap<Core.Message.Message, Message>();
        });
        private readonly TeamsDbContext _context;

        private bool _disposed = false;

        public MessageRepository(TeamsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Core.Message.Message> GetMessagesByConversationId(int conversationID)
        {
            var mapper = _mapperConfiguration.CreateMapper();
            return _context.Messages.Select(message => mapper.Map<Core.Message.Message>(message));
        }

        public void InsertMessage(Core.Message.Message message)
        {
            var mapper = _mapperConfiguration.CreateMapper();
            _context.Messages.Add(mapper.Map<Message>(message));
            _context.SaveChanges();
        }

        public void DeleteMessage(int messageID)
        {
            throw new NotImplementedException();
        }

        public void UpdateMessage(Core.Message.Message message)
        {
            throw new NotImplementedException();
        }

        public void Save()
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
