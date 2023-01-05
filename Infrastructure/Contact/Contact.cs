using System.ComponentModel.DataAnnotations;

namespace Teams.Infrastructure.Contact
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string? LinkedInProfile { get; set; }

        //public virtual Person.Person Person { get; set; }
    }
}