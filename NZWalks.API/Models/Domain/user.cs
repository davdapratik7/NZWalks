namespace NZWalks.API.Models.Domain
{
    public class user
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
    }
}
