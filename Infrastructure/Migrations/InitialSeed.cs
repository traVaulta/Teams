namespace Teams.Infrastructure.Migrations
{
    public static class InitialSeed
    {
        public static string Up()
        {
            var migrationsFile = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..\\Infrastructure\\Migrations\\dbseed.sql");
            return File.ReadAllText(migrationsFile);
        }

        public static string Down()
        {
            return "truncate table [Teams].[dbo].[Profile];";
        }
    }
}
