# Evently

Evently has two apps on one MySQL database: a Windows Forms desktop app (.NET 10) for organizers, and an ASP.NET Core website for guests and door staff. Both talk to the same database through a shared `Evently.Core` library.

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

3. Create your own config file. Copy `db.config.example` to `db.config` in the repo root and fill in your MySQL user and password.

`db.config` is git-ignored, so each machine keeps its own credentials. The desktop and web projects both copy that one file next to their exe on build, so it stays the only place the database settings live.

Do this before the first build. If `db.config` is missing the build cannot copy it, and at run time the app throws "db.config not found next to the app." There are no built-in defaults to fall back on.

4. Build and run:

```
dotnet run --project Evently.Desktop
```

`dotnet run` restores packages and builds for you, so no separate `dotnet build` is needed. Build everything with `dotnet build Evently.sln`.

Because `db.config` is copied at build time, a later edit to it only takes effect after the next build. Stop the app, run `dotnet run` again, and it copies the new values.

## Running the website

The website is the guest side: registration, the QR ticket, the staff scan page, and the rating form. It uses the same `db.config`, so there is nothing extra to set up.

```
dotnet run --project Evently.Web
```

It listens on port 5000 on all network cards, so the laptop opens `http://localhost:5000` and a phone on the same Wi-Fi opens `http://<laptop-ip>:5000` (run `ipconfig` and use the IPv4 address of the Wi-Fi adapter). The first request from the phone triggers a Windows Firewall prompt; allow access on private networks.

HTTP is used on the local network on purpose. HTTPS would need a certificate the phone trusts, and the site is never published to the internet.

Both apps can run at the same time. They share one MySQL database, so a check-in from the phone shows up on the desktop dashboard.

## Updating the schema

`db\schema.sql` is the source of truth and is edited by hand. Keep it to `CREATE TABLE` statements only: no real rows, no database commands.

To apply an edit on your machine, run the changed statements in a MySQL client, or drop the database and import the file again following step 2.

## Never commit

- `db.config` with real credentials
- database dumps that include rows (real emails and password hashes)
