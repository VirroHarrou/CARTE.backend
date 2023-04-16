using Domain;

namespace Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
