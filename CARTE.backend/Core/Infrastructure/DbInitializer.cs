using CARTE.backend.Core.Domain;

namespace CARTE.backend.Core.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
