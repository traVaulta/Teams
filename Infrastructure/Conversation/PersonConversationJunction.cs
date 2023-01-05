using System.ComponentModel.DataAnnotations.Schema;

namespace Teams.Infrastructure.Conversation
{
    public class PersonConversationJunction
    {
        [ForeignKey("FK_PersonConversationJunction_Person")]
        public int PersonId { get; set; }

        [ForeignKey("FK_PersonConversationJunction_Conversation")]
        public int ConversationId { get; set; }
    }
}
