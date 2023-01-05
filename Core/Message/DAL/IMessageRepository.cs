namespace Teams.Core.Message.DAL
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<Message> GetMessagesByConversationId(int conversationId);

        void InsertMessage(Message message);

        void DeleteMessage(int messageId);
        
        void UpdateMessage(Message message);

        void Save();
    }
}
