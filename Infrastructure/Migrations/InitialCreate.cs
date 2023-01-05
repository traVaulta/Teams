namespace Teams.Infrastructure.Migrations
{
    public static class InitialCreate
    {
        public static string Up()
        {
            var migrationsFile = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..\\Infrastructure\\Migrations\\dbmigrations.sql");
            return File.ReadAllText(migrationsFile);
        }

        public static string Down()
        {
            return @"
                drop table [Teams].[dbo].[Message];
                drop table [Teams].[dbo].[ProfileConversationJunction];
                drop table [Teams].[dbo].[Conversation];
                drop table [Teams].[dbo].[Person];
            ";
        }
    }
}
