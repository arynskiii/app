namespace Roadmap.Persistance;

public class DbInitializer
{
    public static void Initialize(RoadmapDbContext context)
    {
        context.Database.EnsureCreated();
    }
}