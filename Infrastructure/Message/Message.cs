using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teams.Infrastructure.Message
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }

        [Required]
        [ForeignKey("FK_Message_Profile")]
        public int CreatedBy { get; set; }

        [Required]
        [ForeignKey("FK_Message_Conversation")]
        public int ConversationId { get; set; }

        public virtual Person.Person Author { get; set; }

        public virtual Conversation.Conversation Conversation { get; set; }
    }
}
