using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class User
    {
        public User()
        {
            Administrator = new HashSet<Administrator>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Administrator> Administrator { get; set; }
    }
}
