﻿using System.ComponentModel.DataAnnotations;

namespace Teams.Infrastructure.Person
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Conversation.Conversation> Conversations { get; set; }
    }
}