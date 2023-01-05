using Teams.Core.Conversation.DAL;
using Teams.Core.Message;
using Teams.Core.Person;

namespace Teams.Core.Conversation
{
    public class ConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly PersonService _personService;
        private readonly MessageService _messageService;

        public ConversationService(
            IConversationRepository conversationRepository,
            MessageService messageService,
            PersonService personService)
        {
            _conversationRepository = conversationRepository;
            _personService = personService;
            _messageService = messageService;

            CreateDefault();
        }

        public Conversation Get(int conversationId)
        {
            var conversation = _conversationRepository.GetConversationById(conversationId);

            if (conversation != null && conversation.Messages.Count() == 0)
            {
                conversation.Messages = _messageService.GetByConversationId(conversationId);
            }
            
            return conversation;
        }

        public void Create(ConversationStartDTO request)
        {
            IEnumerable<int> participantIds = request.ParticipantIds;
            
            Conversation conversation = new Conversation();
            foreach(int id in participantIds)
            {
                var person = _personService.GetById(id);
                conversation.Participants.Append(person);
            }
            
            _conversationRepository.InsertConversation(conversation);
        }

        private void CreateDefault()
        {
            var initial = new Conversation();
            initial.Title = "Test";
            initial.Participants = new List<Person.Person>
            {
                new Person.Person
                { Id = 1 },
                new Person.Person
                { Id = 2 }
            };
            _conversationRepository.InsertConversation(initial);
        }
    }
}
