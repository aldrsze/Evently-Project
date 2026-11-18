# Evently

Event management system with two apps sharing one MySQL database:

- **Evently.Desktop** – Windows Forms app (.NET 10) for organizers
- **Evently.Web** – ASP.NET Core website for guests and door staff (registration, QR ticket, check-in scan, ratings)

Both use the shared `Evently.Core` library.

## Requirements

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL Server 8+ with `mysql` and `mysqldump` on PATH

## Setup

1. Clone the repo.

2. Create the database and import the tables and demo admin. Run in **Command Prompt** (PowerShell doesn't support `<`):

```cmd
mysql -u root -p -e "CREATE DATABASE IF NOT EXISTS evently_db"
mysql -u root -p evently_db < db\schema.sql
mysql -u root -p < db\seed.sql
```

3. Copy `db.config.example` to `db.config` in the repo root and fill in your MySQL user and password. This file is git-ignored.

4. Run an app:

```bash
dotnet run --project Evently.Desktop
dotnet run --project Evently.Web
```

Default login: `admin` / `admin123` (change it after signing in).

## Notes

- `db.config` is copied next to the exe at build time. After editing it, stop the app and run it again. If the file is missing, the app fails with "db.config not found".
- The website runs at `http://localhost:5000`. To open it from a phone on the same Wi-Fi, use `http://<laptop-ip>:5000` (find the IP with `ipconfig`) and allow the Windows Firewall prompt. It uses plain HTTP because it's only meant for the local network.
- Both apps can run at once and share the same data.
- `db\schema.sql` is edited by hand and holds only `CREATE TABLE` statements. To apply changes, rerun the changed statements, or drop the database and redo step 2.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for the Git workflow.

## Never commit

- `db.config` with real credentials
- Database dumps containing real data (emails, password hashes)