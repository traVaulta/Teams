using Teams.Core.Message.DAL;

namespace Teams.Core.Message
{
    public class MessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetByConversationId(int conversationId)
        {
            return messageRepository.GetMessagesByConversationId(conversationId);
        }

        public void Send(Message message)
        {
            messageRepository.InsertMessage(message);
        }
    }
}
