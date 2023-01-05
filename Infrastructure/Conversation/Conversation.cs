using System.ComponentModel.DataAnnotations;

namespace Teams.Infrastructure.Conversation
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Person.Person> Participants { get; set; }
        public virtual ICollection<Message.Message> Messages { get; set; }
    }
}