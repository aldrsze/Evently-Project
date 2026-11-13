# Evently

Windows Forms app (.NET 10) for managing events, attendees and tickets. Data is stored in MySQL.

## Requirements

- Windows
- .NET 10 SDK
- MySQL Server 8 or newer, with `mysql` and `mysqldump` on PATH

## Setup on a new machine

1. Clone the repo.

2. Create the database, then its tables:

```
cmd /c "mysql -u root -p -e \"CREATE DATABASE IF NOT EXISTS evently_db\""
cmd /c "mysql -u root -p evently_db < db\schema.sql"
```

`db\schema.sql` is hand-written, so it holds only `CREATE TABLE` statements — no `CREATE DATABASE`, no `USE`, no rows. That is why the database is created first and named on the second line.

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

`db\schema.sql` is the source of truth and is edited by hand. Keep it to `CREATE TABLE` statements only: no real rows, no database commands.

To apply an edit on your machine, run the changed statements in a MySQL client, or drop the database and import the file again following step 2.

## Never commit

- `db.config` with real credentials
- database dumps that include rows (real emails and password hashes)
