using Microsoft.EntityFrameworkCore;

namespace Teams.Infrastructure
{
    public class TeamsDbContext : DbContext
    {

        public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options) { }

        public DbSet<Contact.Contact> Contacts { get; set; }
        public DbSet<Person.Person> People { get; set; }
        public DbSet<Conversation.Conversation> Conversations { get; set; }
        public DbSet<Conversation.PersonConversationJunction> PersonConversationJunctions { get; set; }
        public DbSet<Message.Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact.Contact>().ToTable("Contact");
            modelBuilder.Entity<Person.Person>().ToTable("Person");
            modelBuilder.Entity<Message.Message>().ToTable("Message");
            modelBuilder.Entity<Conversation.PersonConversationJunction>().ToTable("PersonConversationJunction")
                .HasKey(pcj => new { pcj.PersonId, pcj.ConversationId });
            modelBuilder.Entity<Conversation.Conversation>().ToTable("Conversation");
        }
    }
}
