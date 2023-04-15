namespace Infrastructure.Card.Queries.GetBusinessCardDetail
{
    public class BusinessCardVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<string> Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Urls { get; set; }
        public UserPreferences UserPreferences { get; set; }
    }
}
