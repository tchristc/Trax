# Trax.Database

Standalone console app for deploying and managing the Supabase PostgreSQL schema via EF Core migrations.

## Prerequisites

- .NET 10 SDK
- EF Core CLI: `dotnet tool install --global dotnet-ef`

## Configuration

Fill in your Supabase connection details in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=db.YOUR_PROJECT_REF.supabase.co;Port=5432;Database=trax;Username=postgres;Password=YOUR_DB_PASSWORD;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

> **Tip:** Use `dotnet user-secrets` to avoid committing credentials.

## Common Commands

| Task | Command (run from `Trax.Database/`) |
|------|--------------------------------------|
| Add a migration | `dotnet ef migrations add <Name> --project ../Trax.Infrastructure` |
| Apply migrations + seed | `dotnet run` |
| Apply migrations only | `dotnet ef database update` |
| Generate SQL script | `dotnet ef migrations script --output schema.sql` |
| List migrations | `dotnet ef migrations list` |
