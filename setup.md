# Project Setup

How to get **Evently** running on your machine. Do this once, after cloning (see `CONTRIBUTING.md` for the Git workflow).

## What you need

- Windows
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server 8+](https://dev.mysql.com/downloads/mysql/) with `mysql` available in your terminal (on PATH)
- An editor: Visual Studio 2022 or VS Code

Check that everything is installed:

```bash
dotnet --version
mysql --version
git --version
```

## Setup steps

### 1. Clone and switch to your branch

```bash
git clone https://github.com/aldrsze/evently-project.git
cd evently-project
git checkout yourname
```

If you haven't made your branch yet, see `CONTRIBUTING.md`.

### 2. Create the database

Run these in **Command Prompt** (not PowerShell, it can't do `<`):

```cmd
mysql -u root -p -e "CREATE DATABASE IF NOT EXISTS evently_db"
mysql -u root -p evently_db < db\schema.sql
mysql -u root -p < db\seed.sql
```

Enter your MySQL password when asked. `seed.sql` already starts with `USE evently_db;`, so it needs no database argument. It adds the demo admin account.

**Login:** `admin` / `admin123`

### 3. Create your config file

Copy `db.config.example` to `db.config` in the repo root, then open it and fill in your own MySQL username and password.

- `db.config` is git-ignored, so your password never gets pushed.
- It must be in the repo root (next to `Evently.sln`). Both apps use this one file.
- Each build copies it next to the app, so after editing it, stop the app and run it again.

### 4. Run the apps

Desktop app (organizers):

```bash
dotnet run --project Evently.Desktop
```

Website (guests and door staff):

```bash
dotnet run --project Evently.Web
```

Then open `http://localhost:5000`.

Both can run at the same time since they share one database.

To build everything: `dotnet build Evently.sln`

## Project structure

| Folder | What it is |
|---|---|
| `Evently.Core` | Shared library (database access, logic) |
| `Evently.Desktop` | Windows Forms desktop app |
| `Evently.Web` | ASP.NET Core website |
| `db` | `schema.sql` (tables) and `seed.sql` (demo admin) |

## Troubleshooting

| Problem | Fix |
|---|---|
| App can't connect to the database | Check `db.config` (repo root) has the right user and password, then rebuild and rerun |
| `mysql` is not recognized | Add MySQL's `bin` folder to your PATH, then reopen the terminal |
| `dotnet` is not recognized | Install the .NET 9 SDK and reopen the terminal |
| Can't log in | Make sure you ran `db\seed.sql`, then use `admin` / `admin123` |
| Phone can't open the website | Same Wi-Fi as the laptop, use `http://<laptop-ip>:5000`, allow the Windows Firewall prompt |

## Never commit

- `db.config` with real credentials
- Database dumps that contain real data (emails, password hashes)

## Changing the database

`db\schema.sql` is edited by hand and holds only `CREATE TABLE` statements. If you change it, tell the team so everyone re-imports it on their machine.
