namespace CARTE.backend.Core.Domain.Models
{
    public class BusinessCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public List<string> Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Urls { get; set; }
        public Guid UserId { get; set; }
    }
}
