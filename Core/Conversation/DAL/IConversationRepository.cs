namespace Teams.Core.Conversation.DAL
{
    public interface IConversationRepository : IDisposable
    {
        IEnumerable<Conversation> GetConversations();
        
        Conversation GetConversationById(int converstionId);
        
        void InsertConversation(Conversation conversation);
        
        void DeleteConversation(int converstionId);
        
        void UpdateConversation(Conversation conversation);
        
        void Save();
    }
}
