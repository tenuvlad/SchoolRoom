using System;


namespace Servicies.Users.Dto
{
    public class UserForDetailed
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBitrh { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string TaughtSubjects { get; set; }
        public string EnrolledSubjects { get; set; }
    }
}
