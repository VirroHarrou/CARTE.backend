namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<BusinessCard> Cards { get; set; }
        public Location Location { get; set; }
    }
}
