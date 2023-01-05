namespace Teams.Core.Message
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Person.Person Author { get; set; }

        public Conversation.Conversation Conversation { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }
    }
}
