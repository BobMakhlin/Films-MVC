## How to setup

1.  Set connection strings inside of `appsettings.json`
2.  Run migrations:

*   `dotnet ef database update --project=src/Films.DAL.MsSqlServer --startup-project=src/Films.WebUI --context=FilmsDbContext`

*   `dotnet ef database update --project=src/Films.WebUI --context=ApplicationDbContext`
