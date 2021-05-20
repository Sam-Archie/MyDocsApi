using Microsoft.AspNetCore.Identity;
using MyDocs.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Domain.Entities
{
    public class User : IdentityUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName}, {LastName}";
            }
        }
        public List<Forum> UserForums { get; set; } = new List<Forum>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
