namespace CARTE.backend.Core.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<BusinessCard> Cards { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public UserPreferences UserPreferences { get; set; }
    }
}
