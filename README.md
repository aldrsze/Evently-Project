# Evently

Windows Forms app (.NET 9) for managing events, attendees and tickets. Data is stored in MySQL.

## Requirements

- Windows
- .NET 9 SDK
- MySQL Server 8 or newer, with `mysql` and `mysqldump` on PATH

## Setup on a new machine

1. Clone the repo.

2. Create the database and its tables:

```
cmd /c "mysql -u root -p < db\schema.sql"
```

Then add the demo admin, or you will have no account to sign in with:

```
cmd /c "mysql -u root -p < db\seed.sql"
```

Both lines use `cmd /c` because PowerShell cannot do `<` redirection.

Login is `admin` / `admin123`. Change it after your first sign in.

3. Create your own config file. Copy `db.config.example` to `db.config` and fill in your MySQL user and password.

`db.config` is git-ignored, so each machine keeps its own credentials. The project copies it next to the exe on build, so keep it in the project root.

Do this before the first run. If `db.config` is missing, the app starts anyway and falls back to the built-in defaults (empty password), which usually just fails to connect.

4. Build and run:

```
dotnet run
```

`dotnet run` restores packages and builds for you, so no separate `dotnet build` is needed.

Because `db.config` is copied at build time, a later edit to it only takes effect after the next build. Stop the app, run `dotnet run` again, and it copies the new values.

## Updating the schema

After you change tables, re-export the structure. `db\schema.sql` holds only `CREATE TABLE` statements, never real rows.

```
cmd /c "mysqldump -u root -p --no-data --set-gtid-purged=OFF --databases evently_db > db\schema.sql"
```

Run it from `cmd` or through `cmd /c` like above. PowerShell's `>` writes UTF-16, and the MySQL client will not import that.

`--no-data` keeps every row out. `--databases` adds `CREATE DATABASE IF NOT EXISTS` and `USE`, so the dump restores on a machine that has no database yet.

## Never commit

- `db.config` with real credentials
- database dumps that include rows (real emails and password hashes)
