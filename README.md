# Evently

Event management system with two apps sharing one MySQL database:

- **Evently.Desktop** – Windows Forms app (.NET 10) for organizers
- **Evently.Web** – ASP.NET Core website for guests and door staff (registration, QR ticket, check-in scan, ratings)

Both use the shared `Evently.Core` library.

## Requirements

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL Server 8+

## Setup

See [setup.md](setup.md) for the database, `db.config`, and how to run both apps.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for the Git workflow.

## Never commit

- `db.config` with real credentials
- Database dumps containing real data (emails, password hashes)