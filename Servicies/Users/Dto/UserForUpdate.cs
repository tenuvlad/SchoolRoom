using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Users.Dto
{
    public class UserForUpdate
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
