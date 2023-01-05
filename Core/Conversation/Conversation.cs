namespace Teams.Core.Conversation
{
    public class Conversation
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public IEnumerable<Person.Person> Participants { get; set; }

        public IEnumerable<Message.Message> Messages { get; set; }

        public Conversation(int id = 0)
        {
            Id = id;
            Participants = new List<Person.Person>();
            Messages = new List<Message.Message>();
        }
    }
}
