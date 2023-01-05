namespace Teams.Core.Person
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }

        public virtual IEnumerable<Conversation.Conversation> Conversations { get; set; }
    }
}
