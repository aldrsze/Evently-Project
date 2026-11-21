# Product Requirements Document (PRD)

## 1. Project Overview

**Project Name:**
Evently

**Team Members & Roles:**

| Name | Role |
| --- | --- |
| Aldrin Jariel | Full-Stack Developer, Database Designer |
| Raxell Alshane Minaves | Researcher & Documentation |
| Ron Paulo Angeles | Researcher & Documentation |
| George Alcantara | Frontend Designer |
| Neciforo Ezekeil Feliciano | Researcher & Documentation |
| Ashley Nicole Alima | Researcher & Documentation |
| Elliya Fernandez | Researcher & Documentation |
| Hanna Raiza Mukaddis | Frontend Designer |

**Summary:**
Evently is two apps on one MySQL database. **Evently.Web** is a small ASP.NET Core website that guests open on their phone: they register themselves for an event, get their QR ticket on screen, show it at the door, and fill in the rating form after the event. **Evently.Desktop** is a Windows Forms app for the organizers: users and events, manual or CSV attendee entry, ticket emails, a live dashboard, and an attendance CSV export. Both apps call the same shared library (**Evently.Core**), so capacity, duplicate, ticket, and check-in rules are written once and enforced everywhere. Admin login uses a username and password (hashed). At the door, staff scan the QR ticket with a phone camera through the web page. The same ticket is scanned again on the way out, so the system knows who is inside the venue right now. After the event, the admin emails a link to the site's own rating form, and the guest's rating and comment are saved straight into the database — no Google Forms, no CSV import. A live dashboard shows how many people are inside, how many have arrived, and the average rating, with charts. Data is stored in MySQL with a normalized schema (attendees and reviews are separate tables, and events can have organizers).

---

## 2. Problem Statement

**What problem are you solving?**
Many school and organization events still use paper attendance sheets. This causes long lines at the entrance, mistakes when checking people in, no way to tell if the venue is over capacity, and people using fake or copied tickets. Paper sheets also cannot tell organizers how many people are inside right now, or what guests thought of the event.

**Who has this problem?**
Event organizers, student volunteers, and the people attending campus or organization events.

**Why does it matter?**
Checking people in by hand is slow and creates bottlenecks at the door. Organizers have no easy way to see, in real time, how many people are in the venue. Feedback is usually collected late, or never.

---

## 3. Goals & Objectives

**Project Goals:**

* Split the system into a website (guests and staff) and a desktop app (organizers), sharing one library and one database.
* Let guests register themselves on the website with their name and email, from a phone, without installing anything.
* Give the system its own basic login (username and password), so only authorized people can use the admin and staff screens.
* Let administrators create events with a maximum guest limit.
* Support three ways to register attendees: guest self-registration on the website, manual entry in the desktop app, and CSV import in the desktop app.
* Generate a unique QR ticket for each attendee and show it on the website right after registration.
* Check guests in (and out) by scanning the QR ticket with a phone camera on the website.
* Show a live count of guests who are currently inside the venue.
* Collect 1 to 5 ratings and comments on the website's own rating page, only from guests who checked in.
* Show a simple dashboard with charts and export attendance as CSV.
* Keep the schema normalized: users, events, attendees, organizers, event_organizers, tickets, and reviews.
* Show good use of Object-Oriented Programming (OOP) by separating forms/pages, services, and helpers into organized parts.

**Success Criteria:**

* An administrator can create an event in under 2 minutes, and a guest can register for it on their phone in under 1 minute.
* A QR ticket exists for every registered attendee, including self-registered ones, and is visible on their ticket page.
* A phone scan on the website checks a ticket in and updates the count in about 1 second.
* The system always blocks: (1) using the same ticket to check in twice, (2) registering more attendees than the event's guest limit, from any of the three entry points, and (3) the same email registering twice for one event.
* A CSV of up to 100 attendees can be imported in one step, with a summary (imported / skipped).
* An admin can email the rating link to every checked-in guest in one click.
* A guest's rating is saved only if their ticket was checked in and has no review yet, and the site refuses a second submission for the same ticket.
* The dashboard refreshes by itself every 5 seconds without freezing the app.
* Passwords are never stored in plain text, and no admin screen, staff scan page, or review form can be used without the right access.

**Out of Scope:**

* Google Forms, Google Sheets, Google sign-in, and any Google API. The rating form lives on the Evently website.
* Paid tickets or payment services.
* SMS, push notifications, and scheduled or reminder emails.
* Badge printing and PDF exports.
* Native iOS or Android apps (the website is the mobile experience).
* Linux or macOS support (Windows Forms is Windows-only).
* Internet hosting, a domain name, and HTTPS certificates. The site runs on the organizer's laptop over the local Wi-Fi.
* Multi-computer database syncing beyond the shared MySQL server.
* Forgot-password emails, two-factor authentication, and detailed permission editors.
* Automated unit or integration tests.

---

## 4. Target Users / Personas

| Persona | Description | Needs |
| --- | --- | --- |
| Event Attendee | A student or guest going to an event | A page on their phone to register, their QR ticket, a quick entry at the door, and a short rating form after the event. |
| Event Administrator | The organizer running the event | A desktop login, an easy screen to create events, a way to add walk-ins (manual or CSV), ticket emails, a rating request email, a dashboard, and an attendance export. |
| Staff | Staff member or volunteer checking people in at the door | Their own login, a scan page on their phone, and clear pass or fail messages. |

---

## 5. Features & Requirements

### 5.1 Core Features (Must-Have)

Status reflects what is in the repository today, which is still the single-project desktop app. The split in section 6 is step 0 of the build progress table.

**Where:** `Desktop` = Windows Forms app, `Web` = ASP.NET Core site, `Core` = shared library used by both.

| # | Feature | Description | Where | Priority | Status |
| --- | --- | --- | --- | --- | --- |
| 1 | Login & Roles | Users sign in with a username and password (hashed). Two roles: Administrator (desktop plus website) and Staff (website scan page only). The desktop app refuses Staff. A demo administrator is created by `db/seed.sql` (`admin` / `admin123`). | Desktop, Web | High | Desktop login done. Web staff login not started. |
| 2 | User Accounts | Administrators can add, edit, deactivate, and reactivate staff or admin accounts. Usernames are unique, passwords need at least 8 characters, the last active admin and your own account are protected, and you cannot change your own role. | Desktop | Medium | Done. |
| 3 | Event Management | Admin can create, edit, and delete events with a name, venue, date and time, description, review link text, and maximum guest limit. | Desktop | High | Screen built. Save, edit, and delete are not wired. |
| 4 | Guest Self-Registration | A guest opens the site on their phone, picks an open event, types first name, last name, email, and birthdate, and is registered. A full event is refused, and a known email is reused without creating a second attendee row. | Web | High | Not started. |
| 5 | Manual Registration | Admin registers a walk-in by typing first name, last name, email, and birthdate into the desktop app, for the selected event. | Desktop | High | Done (full CRUD wired). |
| 6 | CSV Import | Admin imports `first_name`, `last_name`, `email`, `birthdate` rows from a CSV file into a selected event, with duplicate handling, capacity enforcement, and a result summary. | Desktop, Core | High | Button only. |
| 7 | QR Ticket Creation | The system generates a unique UUID for each ticket and builds a QR image from it. | Core | High | Done (`QrCodeService`). |
| 8 | Ticket Page | Right after registering, the guest sees their QR ticket, event name, venue, and date on the website, and can open the same page again later from a saved link. | Web | High | Not started. |
| 9 | Email Tickets | Admin clicks "Send Tickets" and the desktop app emails the QR image to every attendee who has not been emailed yet. | Desktop, Core | High | Done (`EmailService` + Send Tickets). |
| 10 | Phone Scan Check-In | Staff open the scan page on their phone, sign in, allow the camera, and scan tickets. This is the only scanner in the system. There is no event picker: the ticket already knows its event. The page shows a full-width green or red result with the guest's name and that event's inside count. | Web | High | Not started. |
| 11 | Check-Out (Unique Feature) | Scanning a checked-in ticket again checks the guest out, so the system always knows who is inside the venue right now. | Web, Core | High | Not written. |
| 12 | Ticket Checking Rules | The system rejects fake codes, blocks repeat check-ins, and blocks scans for tickets that are already checked out. | Core | High | Not written. |
| 13 | Rating Request Email | Admin clicks "Send Review Request" on the desktop app, and every checked-in guest gets an email with their personal rating link. | Desktop, Core | High | Screen built. Email and "already sent" tracking not implemented. |
| 14 | Rating Form | The guest opens the link on their phone, picks 1 to 5, optionally writes a comment, and submits. The review is saved only for a checked-in ticket that has no review yet. | Web | High | Not started. |
| 15 | Live Dashboard | A screen with an event selector, metrics, a doughnut chart, a check-ins-over-time chart, and a recent check-ins list (section 5.4). | Desktop | High | Layout, charts, and 5-second timer done with sample data. Real queries not written. |
| 16 | Attendance Export (CSV) | Admin can export an event's attendee list (first name, last name, birthdate, email, check-in time, check-out time, rating, comment) as a CSV file. | Desktop, Core | High | Button only. |
| 17 | Event Organizers | The schema stores organizers and links them to events through `event_organizers`, so one event can list several organizer contacts. | Core | Medium | Schema only. No screens or services yet. |

### 5.2 Nice-to-Have Features (Stretch Goals)

| # | Feature | Description |
| --- | --- | --- |
| 1 | Sound Alerts | Play one sound for a good scan and a different sound for a rejected scan, in the browser. |
| 2 | Badge Printing | Print a simple badge (name and QR code) using `PrintDocument`. |
| 3 | Announcement Email | Send one email message to all attendees of an event. |
| 4 | Dashboard Display Mode | A full-screen, large-type dashboard for a projector. |
| 5 | Registration Poster QR | The desktop app generates a QR that opens the web registration page for one event, ready to print on a poster. |
| 6 | Add to Calendar | The ticket page offers an `.ics` download for the event date. |

### 5.3 User Stories

* As an **Administrator**, I want to sign in with a username and password, so only authorized people can use the system.
* As an **Administrator**, I want to add staff accounts, so volunteers can scan tickets without seeing admin screens.
* As an **Administrator**, I want to create an event with a maximum number of guests, so the event is never over capacity.
* As an **Attendee**, I want to register on the website from my phone, so I don't need to install an app or ask someone to add me.
* As an **Attendee**, I want to see my QR ticket right after registering, so I can save it or show it at the door.
* As an **Administrator**, I want to add a walk-in by typing them in the desktop app, so late arrivals are not left out.
* As an **Administrator**, I want to import an attendee list from a CSV file, so I can register many people at once.
* As an **Administrator**, I want to send QR tickets to all attendees with one button click, so I don't have to email each person.
* As an **Administrator**, I want to see a live dashboard, so I know how many people are inside and how the event is going.
* As an **Administrator**, I want to export attendance as a CSV, so I can report on turnout.
* As a **Staff** member, I want to scan tickets with my phone, so I don't need a laptop at the door.
* As a **Staff** member, I want clear "valid" and "invalid" messages, so I know right away whether to let someone in.
* As an **Administrator**, I want to email a rating link only to the guests who attended, so I get feedback from real attendees.
* As an **Attendee**, I want to rate the event on a short page, so I can tell the organizers what I thought without leaving the site.

### 5.4 Live Dashboard: Data to Present

The dashboard has an **event selector**, a "Last Updated" stamp, and a timer that fires every 5 seconds. It shows:

| Data | Description |
| --- | --- |
| Registered / capacity | Count and total, e.g., "Registered: 150 of 200 (75%)," with a progress bar. |
| Currently inside | Checked in minus checked out. |
| Checked in | Number of guests who have arrived, with turnout percentage of registered guests. |
| Not yet arrived | Registered guests who have not checked in. |
| Average rating | Mean rating of the event (e.g., "4.3 / 5.0") and the number of reviews. |
| Response rate | Reviews divided by guests checked in (%). |
| Rating requests sent | Count versus guests checked in. |
| Tickets emailed | Count of tickets sent versus registered guests. |
| Recent check-ins | The latest guests with their check-in or check-out time. |
| Attendance chart | Doughnut chart splitting guests into inside, checked out, and not arrived. |
| Check-ins over time | Line chart of total check-ins across time slots. |

Until the services exist, these values are sample data held in memory, and the timer simulates gate scans so the charts can be viewed.

**Role visibility:** The dashboard is desktop-only, so only Administrators see it. Staff have no desktop login; their only screen is `/Scan` on the website.

---

## 6. System Design Overview

**Target layout: one solution, three projects, one database.**

| Project | Type | Framework | Job |
| --- | --- | --- | --- |
| `Evently.Core` | Class library | `net9.0` | Services and helpers: SQL, rules, QR images, email, CSV. No Windows Forms, no ASP.NET. Referenced by both apps. |
| `Evently.Desktop` | WinExe | `net9.0-windows`, WinForms | Admin screens, dashboard, export. No scanner; scanning is on the website. |
| `Evently.Web` | Web app | `net9.0`, ASP.NET Core Razor Pages | Guest registration, ticket page, phone scan page, staff login, rating form. |

**Tech Stack:**

| Layer | Technology |
| --- | --- |
| Desktop App | Windows Forms on .NET 9 (`net9.0-windows`), C#, WinForms Designer |
| Website | ASP.NET Core Razor Pages on .NET 9 (`net9.0`), plain HTML/CSS, one small JS file |
| Database | MySQL 8.x, accessed with `MySqlConnector` 2.6.2 and plain SQL |
| Authentication | Desktop: local accounts in MySQL, `Session` in memory. Web: same accounts, cookie sign-in. Passwords hashed with `BCrypt.Net-Next` 4.2.0. |
| Charts | `WinForms.DataVisualization` 1.10.2 (doughnut and spline charts on the desktop dashboard) |
| Configuration | One `db.config` in the repo root with four plain `key=value` lines (`Server`, `Database`, `User`, `Password`). `Evently.Core` reads it, and both apps copy it next to their output at build time. |
| Hosting | Desktop and website run on the organizer's Windows laptop with MySQL installed locally. Phones connect to the website over the same Wi-Fi using the laptop's IP address. |

**Libraries:**

| Feature | Package | Project |
| --- | --- | --- |
| CSV import and export | `CsvHelper` | Core |
| QR generation | `QRCoder` | Core |
| Email | `MailKit` (SMTP using a Gmail address and an app password read from configuration) | Core |
| Phone camera QR reading | `html5-qrcode` (JavaScript file in `wwwroot`, loaded with a `<script>` tag) | Web |

**High-Level Architecture:**

```
  PHONE (same Wi-Fi)                         WINDOWS LAPTOP
  ┌──────────────────────┐            ┌───────────────────────────────┐
  │ Evently.Web          │            │ Evently.Desktop               │
  │  /Register  register │            │  Users, Events, Attendees     │
  │  /Ticket    show QR  │            │  Dashboard, Export            │
  │  /Scan      staff    │            │  Reviews list                 │
  │  /Review    rate     │            │                               │
  └──────────┬───────────┘            └───────────────┬───────────────┘
             │            ┌──────────────────────┐    │
             └───────────>│ Evently.Core         │<───┘
                          │  Services + Helpers  │
                          │  rules, SQL, QR,     │
                          │  email, CSV          │
                          └──────────┬───────────┘
                                     │ SQL
                             ┌───────▼────────┐
                             │ MySQL (7 tables)│
                             └────────────────┘
```

1. **`Evently.Core`**: static service classes holding both the SQL and the business rules (login, users, events, registration and capacity, CSV, QR codes, email, check-in, reviews, dashboard numbers) plus `DatabaseConnection`, `PasswordHelper`, and `CsvHelper`-based readers. Both apps call the same methods, so a rule cannot drift between the phone and the desktop.
2. **`Evently.Desktop`**: Forms that call Core directly and bind `DataTable` results to grids. There is no Models folder and no repository layer. It also keeps `Session` (who signed in for this run), because the website has its own cookie session.
3. **`Evently.Web`**: Razor Pages, one page per job. No JavaScript framework. Pages call Core directly, the same way forms do. The only real client script is the QR scanner on `/Scan`.

**Why the site must be reached by IP:** `localhost` on a phone means the phone itself. The laptop runs the site on port 5000, and phones use `http://192.168.1.x:5000`. The address is set in `Evently.Web/Properties/launchSettings.json` (`"applicationUrl": "http://0.0.0.0:5000"`) so the app listens on all network cards, and Windows Firewall must allow it once. This is a local-network setup only; nothing is published to the internet.

**Database Models (7 tables):**

* **User**: `user_id`, `username`, `password` (BCrypt hash), `role` (ADMIN or STAFF), `is_active`.
* **Event**: `event_id`, `name`, `venue`, `description`, `event_date`, `capacity`.
* **Attendee**: `attendee_id`, `first_name`, `last_name`, `email` (unique across the whole app), `birthdate` (optional date of birth).
* **Organizer**: `organizer_id`, `full_name`, `email` (unique), `phone`, `organization`.
* **EventOrganizer**: `event_id` + `organizer_id` (one row per organizer of an event).
* **Ticket**: `ticket_id` (UUID used as the QR code), `attendee_id`, `event_id`, `ticket_emailed` (yes/no), `review_emailed` (yes/no), `checked_in_at` (empty until checked in), `checked_out_at` (empty until checked out).
* **Review**: `ticket_id` (one review per ticket), `rating` (1 to 5), `comment` (optional), `submitted_at` (when the guest submitted the web form).

**SQL Schema (`db/schema.sql`), four changes from today:**

* `events.review_form_url` is dropped. The rating page is part of Evently, so there is no link to paste.
* `tickets.review_emailed` is added, so "Send Review Request" can email only the guests who have not been asked yet.
* `reviews.submitted_at` is added for the dashboard's "latest reviews".
* `attendees.full_name` is split into `first_name` and `last_name`, and `birthdate` is added, so the door screen and the emails can greet by first name and organizers can see ages.

```sql
CREATE TABLE users (
    user_id       INT AUTO_INCREMENT PRIMARY KEY,
    username      VARCHAR(50)  NOT NULL UNIQUE,
    password      VARCHAR(100) NOT NULL,
    role          ENUM('ADMIN','STAFF') NOT NULL,
    is_active     BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE events (
    event_id        INT AUTO_INCREMENT PRIMARY KEY,
    name            VARCHAR(100) NOT NULL,
    venue           VARCHAR(100),
    description     TEXT,
    event_date      DATETIME NOT NULL,
    capacity        INT NOT NULL CHECK (capacity > 0)
);

CREATE TABLE attendees (
    attendee_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name  VARCHAR(50) NOT NULL,
    last_name   VARCHAR(50) NOT NULL,
    email       VARCHAR(100) NOT NULL UNIQUE,
    birthdate   DATE NULL
);

CREATE TABLE organizers (
    organizer_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name    VARCHAR(100) NOT NULL,
    email        VARCHAR(100) NOT NULL UNIQUE,
    phone        VARCHAR(30) NULL,
    organization VARCHAR(150) NULL
);

CREATE TABLE event_organizers (
    event_id     INT NOT NULL,
    organizer_id INT NOT NULL,
    PRIMARY KEY (event_id, organizer_id),
    FOREIGN KEY (event_id) REFERENCES events(event_id) ON DELETE CASCADE,
    FOREIGN KEY (organizer_id) REFERENCES organizers(organizer_id) ON DELETE CASCADE
);

CREATE TABLE tickets (
    ticket_id      CHAR(36) PRIMARY KEY,
    attendee_id    INT NOT NULL,
    event_id       INT NOT NULL,
    ticket_emailed BOOLEAN NOT NULL DEFAULT FALSE,
    review_emailed BOOLEAN NOT NULL DEFAULT FALSE,
    checked_in_at  DATETIME NULL,
    checked_out_at DATETIME NULL,
    UNIQUE (event_id, attendee_id),
    FOREIGN KEY (event_id) REFERENCES events(event_id) ON DELETE CASCADE,
    FOREIGN KEY (attendee_id) REFERENCES attendees(attendee_id) ON DELETE CASCADE
);

CREATE TABLE reviews (
    ticket_id    CHAR(36) PRIMARY KEY,
    rating       TINYINT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    comment      VARCHAR(500) NULL,
    submitted_at DATETIME NOT NULL,
    FOREIGN KEY (ticket_id) REFERENCES tickets(ticket_id) ON DELETE CASCADE
);
```

`db/schema.sql` holds only `CREATE TABLE` statements. `db/seed.sql` adds the demo admin (`admin` / `admin123`, change it after first sign-in) and nothing else. `setup.md` explains creating `evently_db`, importing both files, copying `db.config.example` to `db.config`, and starting both projects.

**Rules the database enforces:**

* `username` is unique.
* `attendees.email` is unique across the app, so a person is stored once and is reused for other events. A ticket is unique on (`event_id`, `attendee_id`), so nobody is registered twice for one event, even if they submit the web form twice.
* `rating` is required and must be between 1 and 5; the review's `ticket_id` is the primary key, so a ticket can have only one review.
* Deleting an event deletes its tickets (cascade), and deleting a ticket deletes its review. Deleting an attendee or organizer also removes its links.

**Design Notes & Constraints:**

* **One rule location:** capacity, duplicate email, and ticket-state checks live in `Evently.Core` only. The web page, the desktop form, and the CSV importer all call the same method, so they cannot disagree.
* **Passwords:** Minimum length of 8 (`UserService.MinPasswordLength`), hashed with BCrypt, never logged or saved as plain text.
* **Session:** Desktop: after a successful login, `Session.SignIn` stores the username and role for the rest of the run, and the main window can only be closed with Log out. Web: `AddAuthentication` with a cookie; `/Scan` requires the STAFF or ADMIN role, `/Register`, `/Ticket`, and `/Review` are public.
* **Registration flow (shared):** Look up the email in `attendees`. If it exists, reuse that row; otherwise insert the attendee. Then insert a ticket for the event. Both steps run in one transaction with the capacity check, so two phones registering the last slot at the same moment cannot both succeed.
* **Self-registration page:** `/Register` lists only events that have not happened yet and are not full. A direct link `/Register?eventId=3` opens the form for one event, which is what a poster QR points to. The page asks for first name, last name, email, and birthdate; no account, no password.
* **Ticket page:** `/Ticket/{ticket_id}` shows the QR image, the event name, venue, and date. The UUID in the URL is the ticket, so the link works while the site runs. Guests are told to screenshot it.
* **Ticket states (worked out from columns, not stored):**
  * `checked_in_at` empty: **Registered** (not arrived).
  * `checked_in_at` set and `checked_out_at` empty: **Inside**.
  * Both set: **Left**.
* **Scan logic (website):** (1) Look up the scanned UUID. If not found, show "Invalid Ticket." (2) If `checked_in_at` is empty, set it and show "Welcome, [name]." (3) If checked in but not checked out, save `checked_out_at` and show "Goodbye, [name]." (4) If already checked out, show "Ticket already used." The method returns the result, the guest name, the event name, and that event's inside count, so the web page needs no other call.
* **Phone scan page:** `/Scan` shows the camera feed in a square viewport, decodes with `html5-qrcode`, and posts the code to the same page handler. There is no event selector, because the ticket UUID already points at one event; the scan returns the result plus that event's inside count in one call. The result replaces the buttons at the top in large type (green welcome, amber goodbye, red invalid) and is read aloud by the staff member, not announced by audio. The same code is ignored for 3 seconds so one ticket in front of the camera is not scanned repeatedly.
* **Scan concurrency:** the check-in and check-out updates are single `UPDATE ... WHERE` statements with the old state in the `WHERE` clause, so two phones scanning the same ticket at once cannot both win.
* **Email:** "Send Tickets" only sends to tickets where `ticket_emailed` is false, so clicking it again retries only the failures. "Send Review Request" only sends to checked-in tickets where `review_emailed` is false and no review exists. Each summary shows sent and failed counts.
* **Rating link:** the email contains `/Review/{ticket_id}`. The page refuses a ticket that is not checked in and a ticket that already has a review, so no email typing is needed and nobody can rate as someone else. This removes the old Google Forms weakness.
* **Rating form:** one radio group (1 to 5), one optional comment box (max 500 characters), one Submit button, and a thank-you state afterwards.
* **CSV:** attendee import (`first_name`, `last_name`, `email`, `birthdate`) and attendance export stay on the desktop. Review CSV import is removed because reviews now arrive on the site. Names are stored split, so displays and emails join them as `first_name + ' ' + last_name` and greet by first name; the CSV header change means old import files with `full_name` must be updated.
* **Dashboard:** Uses a `System.Windows.Forms.Timer` at 5000 ms with simple `COUNT` and `AVG` queries, one event at a time. It does not push updates to the web; each web scan answers with the scanned ticket's event name and inside count, so staff see the number move without picking anything.
* **UI shell (desktop):** `MainForm` is a sidebar plus a content panel; each menu button swaps a child form into the panel (`TopLevel = false`, `Dock = Fill`). Login `Hide()`s itself and opens `MainForm` as a modal dialog, then shows itself again after logout.
* **UI (web):** mobile-first, single column, big tap targets, Segoe UI with system fallbacks, and the same blue-and-slate palette as the desktop app. Pages must be readable in daylight at a door: large result text and no hover-only actions.
* **Not stored on purpose:** Failed or duplicate scan attempts and import summaries are shown on screen but not saved.

**Known Gaps (code and doc not aligned yet):**

* The repository is still one project; the Core / Desktop / Web split has not been done.
* Role-based access: the desktop app still opens for any signed-in user; it must refuse Staff, who belong on the web scan page.
* Organizers and `event_organizers` have no screen or service.
* The dashboard shows sample events instead of database rows.
* Services for events, tickets, CSV, QR, email, reviews, and dashboard are empty files; `Forms/*Form.cs` handlers are TODO stubs.
* Service files use the namespace `_` (`using _.Services`), which should become `Evently.Core.Services` during the split.

**Project Structure (target):**

```
evently-project/
├── Evently.sln
├── PRD.md
├── README.md
├── setup.md
├── db.config                      (git-ignored, copied to both apps at build)
├── db.config.example
├── db/
│   ├── schema.sql                 (7 tables, CREATE TABLE only)
│   └── seed.sql                   (demo admin)
│
├── Evently.Core/
│   ├── Evently.Core.csproj
│   ├── Helpers/
│   │   ├── DatabaseConnection.cs  (db.config reader, GetConnection)
│   │   └── PasswordHelper.cs      (BCrypt hash and verify)
│   └── Services/
│       ├── AuthService.cs         (written: verify login, read role)
│       ├── UserService.cs         (written: list, add, edit, activate)
│       ├── EventService.cs        (empty)
│       ├── TicketService.cs       (empty: registration, capacity, check-in/out)
│       ├── CsvService.cs          (empty: attendee import, export)
│       ├── QrCodeService.cs       (empty)
│       ├── EmailService.cs        (empty: ticket and rating emails)
│       ├── ReviewService.cs       (empty: save review, average)
│       └── DashboardService.cs    (empty)
│
├── Evently.Desktop/
│   ├── Evently.Desktop.csproj
│   ├── Program.cs                 (opens LoginForm)
│   ├── Helpers/Session.cs
│   └── Forms/
│       ├── LoginForm.cs / .Designer.cs
│       ├── MainForm.cs / .Designer.cs / .resx
│       ├── UserListForm.cs / .Designer.cs
│       ├── UserEditForm.cs / .Designer.cs
│       ├── EventListForm.cs / .Designer.cs
│       ├── AttendeesForm.cs / .Designer.cs
│       ├── ReviewsForm.cs / .Designer.cs
│       ├── OrganizersForm.cs / .Designer.cs
│       └── DashboardForm.cs / .Designer.cs / .resx
│
└── Evently.Web/
    ├── Evently.Web.csproj
    ├── Program.cs
    ├── Properties/launchSettings.json
    ├── wwwroot/
    │   ├── css/site.css
    │   ├── js/site.js
    │   └── lib/html5-qrcode.min.js
    └── Pages/
        ├── Index.cshtml           (upcoming events + registration entry)
        ├── Register.cshtml
        ├── Ticket.cshtml
        ├── Review.cshtml
        ├── Login.cshtml           (staff)
        ├── Logout.cshtml
        ├── Scan.cshtml
        ├── Error.cshtml
        └── Shared/_Layout.cshtml
```

**Build Progress & Next Steps (in order):**

| # | Area | State | Next work |
| --- | --- | --- | --- |
| 0 | Solution split | Not started | Move the current project to `Evently.Desktop/`, add `Evently.Core` as a class library, move `Helpers` and `Services` into Core, fix the `Forms\*Form.cs` path and `db.config` copy, confirm the desktop app still builds and logs in. One commit. |
| 1 | Web project | Done | `Evently.Web` (Razor Pages) builds, references Core, listens on `0.0.0.0:5000`, and serves a placeholder home page on the LAN. Template Bootstrap/jQuery removed on purpose; pages get added as their services land. |
| 2 | Schema changes | Not started | Edit `db/schema.sql`: drop `events.review_form_url`, add `tickets.review_emailed` and `reviews.submitted_at`, split `attendees.full_name` into `first_name` and `last_name`, add `attendees.birthdate`. Apply by hand to the running database. |
| 3 | Events | Screen only | `EventService` create/edit/delete + desktop grid binding, plus the upcoming-events query for the web home page. |
| 4 | Registration | Screen only | `TicketService` register (transaction + capacity + duplicate email), used by `/Register`, the desktop walk-in form, and the CSV importer. |
| 5 | QR tickets | Not started | `QrCodeService` (Core, returns PNG bytes), `/Ticket` page, `EmailService` + "Send Tickets" with a sent/failed summary. |
| 6 | Check-in / check-out | Not started | `TicketService` scan rules with the 3-second cooldown, `/Scan` page with `html5-qrcode`, result plus that event's inside count in one call. |
| 7 | Reviews | Screen only | `/Review` page, `ReviewService.Save` with the checked-in and one-per-ticket checks, "Send Review Request" email using `review_emailed`. |
| 8 | Dashboard | Mock data | Replace sample data with `DashboardService` queries, including average rating and response rate. |
| 9 | Organizers | Schema only | Decide whether screens are needed; otherwise document as schema-only. |
| 10 | Cleanup | Not started | Delete the root `Evently.csproj` and stale build folders once both apps build from the solution. |

---

## 7. User Flow

**1. Signing In (All Users)**
* **Administrators** open the desktop app and see the Login screen. A correct password opens the main menu.
* **Staff** open the site on their phone, go to `/Login`, and sign in with the same accounts. They land on `/Scan`.
* At present the desktop app opens for any signed-in user; the plan is to refuse Staff there, since their screen is `/Scan` on the website.

**2. Managing Users (Admin, Desktop)**
* In "Manage Users," the admin sees all accounts with role and status.
* They can add a user (username, password, role), edit a user (rename, change role, reset password), and deactivate or reactivate a user.
* The app refuses to deactivate the signed-in account, to remove the last active admin, or to change your own role.

**3. Creating an Event (Admin, Desktop)**
* The admin clicks "Create" on the Events screen.
* They enter the name, venue, description, date and time, and maximum number of guests (e.g., 200), then save.

**4. Registering Attendees**
* **Self-registration (guest, phone):** The guest opens the site link (or the poster QR for one event), picks the event, types first name, last name, email, and birthdate, and taps Register. If the event is full or their email is already registered for that event, the page says so in plain words and nothing is saved.
* **Walk-in (admin, desktop):** The admin opens "Attendees," selects the event, types first name, last name, email, and birthdate, and clicks "Add."
* **CSV (admin, desktop):** The admin clicks "Import CSV" and chooses a file with `first_name`, `last_name`, `email`, and `birthdate` columns. The app imports valid rows until the event is full and shows a summary: "48 imported, 3 duplicates skipped, 2 invalid, 0 over capacity."

**5. Tickets**
* After a successful registration, the website goes straight to `/Ticket/{ticket_id}`: the QR image, the event details, and a note to screenshot it. The guest can open the same page again from a saved link.
* The admin can select the event on the desktop and click "Send Tickets." For each ticket not yet emailed, the app generates the QR image, emails it with the event details, and marks it as emailed. Summary: "12 tickets sent, 3 failed." Clicking again retries only the failed ones.

**6. Checking In (Staff)**
* Staff open `/Scan` on their phone and allow the camera. No event is selected; the page reads the ticket and names the event itself. The guest holds up their QR (from their phone screen or a printout).
* The ticket is read and looked up:
  * **Valid, first scan:** Marks it checked in and shows "Welcome, [name]." The "inside" count goes up by 1.
  * **Invalid code:** Shows "Invalid Ticket."

**7. Checking Out (Staff)**
* When the guest leaves, they show the same QR code to the camera.
* The app recognizes the ticket as already checked in, saves the check-out time, and shows "Goodbye, [name]." The "inside" count goes down by 1.
* If the ticket is scanned a third time, the app shows "Ticket already used."

**8. Collecting Reviews (Admin, Attendee)**
* After the event, the admin opens the "Reviews" screen on the desktop and clicks "Send Review Request." The app emails every checked-in guest who has not been asked yet a link to their own rating page, and shows a summary: "30 sent, 2 failed."
* The guest opens `/Review/{ticket_id}` on their phone, taps a rating from 1 to 5, optionally writes a comment, and submits.
* The site saves the review immediately and shows a thank-you page. A ticket that was not checked in, or that already has a review, gets a clear refusal page instead. No CSV download or import is needed.
* The admin sees the reviews arrive on the desktop Reviews screen and on the dashboard.

**9. Watching the Dashboard (Admin, Desktop)**
* The admin opens the Live Dashboard and picks an event.
* The dashboard refreshes every 5 seconds and shows the data in section 5.4, including the charts and the live average rating.

**10. Exporting Attendance (Admin, Desktop)**
* On the "Attendees" screen, the admin selects an event and clicks "Export CSV."
* The app saves a file with each attendee's first name, last name, birthdate, email, check-in time, check-out time, rating, and comment.

---

## 8. Evaluation / Testing Plan

* **Split Tests:**
  * Confirm `Evently.Desktop` builds and logs in after `Helpers` and `Services` move to `Evently.Core`.
  * Confirm `Evently.Web` starts on `http://0.0.0.0:5000` and a phone on the same Wi-Fi can load the home page by the laptop's IP.
  * Confirm `db.config` is read by both apps and no connection string is duplicated in code.

* **Login Tests:**
  * Sign in with the correct password on the desktop, and confirm a wrong password and a deactivated user are rejected.
  * Sign in on `/Login` as Staff, and confirm `/Scan` opens while `/Login` as a deactivated user is refused.
  * Confirm `/Scan` redirects to `/Login` when signed out.
  * Check the database to confirm passwords are stored as BCrypt hashes in `users.password`.
  * Confirm the last active admin cannot be deactivated, demoted, or edited away.

* **Registration Tests:**
  * Register on a phone for an open event and confirm a ticket and an attendee row appear.
  * Register the same email twice for the same event and confirm the site refuses the second and creates no duplicate ticket.
  * Register the same email for a second event and confirm the attendee row is reused.
  * Fill an event with self-registrations and confirm the form refuses the next one and the event drops off the home page list.
  * Register a walk-in in the desktop app and a CSV batch into the same event, and confirm all three paths respect one shared capacity limit.
  * Try two browsers submitting the last slot at once and confirm only one ticket is created.
  * Register with the birthdate left empty and confirm it saves as NULL, then register with a birthdate and confirm the date is stored unchanged.

* **Database Tests (MySQL):**
  * Add, read, update, and delete users, events, attendees, organizers, and tickets using the service classes.
  * Confirm no tickets are created once the event reaches its capacity (web, manual, CSV).
  * Confirm a rating outside 1 to 5 is rejected.
  * Confirm a ticket cannot receive a second review.
  * Confirm deleting an event removes its tickets and their reviews.

* **CSV Tests:**
  * Import a valid file, a file with missing columns, invalid emails, duplicate emails, and a file with more rows than the remaining capacity. Confirm the summary is accurate.
  * Export attendance and confirm it opens correctly in Excel (test names with accents and commas).

* **Email Tests:**
  * Send tickets to your own test emails and confirm the QR image arrives and the link matches the ticket page.
  * Send the rating request and confirm only checked-in guests who were not asked before receive it.
  * Enter a wrong SMTP password, click a send button, and confirm failures are counted. Fix it and confirm only the unsent tickets are retried.

* **Rating Tests:**
  * Open a rating link from a checked-in guest, submit 5 with a comment, and confirm it saves and the dashboard average moves.
  * Open a rating link for a ticket that never checked in and confirm the page refuses.
  * Submit twice for the same ticket and confirm the second is refused.
  * Edit the URL to a random UUID and confirm a "not found" page.
  * Submit a comment with accents and commas and confirm it is stored unchanged.
  * Submit the form with no rating picked and confirm a validation message appears.

* **QR Scanning Tests:**
  * Scan a QR from a phone screen and from a paper printout, at 10 cm to 50 cm.
  * Scan a random QR code not made by the app, and confirm "Invalid Ticket."
  * Scan tickets from two different events on the same phone and confirm each result names the right event with that event's inside count.
  * Scan the same ticket three times and confirm it checks in, checks out, then is rejected.
  * Hold one ticket in front of the camera for 10 seconds and confirm only one scan is recorded.
  * Scan the same ticket from two phones at once and confirm only one check-in is recorded.

* **Dashboard Tests:**
  * Compare each number on the dashboard against a direct SQL query.
  * Check a guest in on the web and confirm the desktop dashboard updates within 5 seconds.
  * Confirm the app does not freeze while the dashboard refreshes.

* **Full Run-Through Test:**
  * Log in as the admin and add one staff account.
  * Create a test event with a limit of 10 guests.
  * Register 4 guests from phones on the LAN, add 3 walk-ins on the desktop, and import 3 through CSV.
  * Try to register an 11th person from the phone and confirm it is blocked.
  * Open the ticket page on a phone and confirm the QR is readable.
  * Send QR tickets by email.
  * Log in as staff on a phone, check in all 10 guests, and confirm the count shows "10 inside."
  * Check out 8 guests and confirm the dashboard shows "2 inside."
  * Send the rating request, submit 8 ratings from the phones (plus one attempt for a guest who never checked in), and confirm 8 reviews are saved and the dashboard shows the correct average.
  * Export the attendance CSV and confirm it lists all 10 guests with their times, ratings, and comments.

---

## 9. References / Appendix

* ASP.NET Core Razor Pages: [https://learn.microsoft.com/en-us/aspnet/core/razor-pages/](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/)
* Windows Forms Docs: [https://learn.microsoft.com/en-us/dotnet/desktop/winforms/](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
* .NET 9 Downloads: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
* MySQL Reference Manual: [https://dev.mysql.com/doc/](https://dev.mysql.com/doc/)
* MySqlConnector: [https://mysqlconnector.net/](https://mysqlconnector.net/)
* BCrypt.Net-Next (password hashing): [https://github.com/BcryptNet/bcrypt.net](https://github.com/BcryptNet/bcrypt.net)
* WinForms DataVisualization (charts): [https://github.com/dotnet/winforms-datavisualization](https://github.com/dotnet/winforms-datavisualization)
* html5-qrcode (phone camera scanning): [https://github.com/mebjas/html5-qrcode](https://github.com/mebjas/html5-qrcode)
* html5-qrcode (phone camera scanning): [https://github.com/mebjas/html5-qrcode](https://github.com/mebjas/html5-qrcode)
* QRCoder (makes QR codes): [https://github.com/codebude/QRCoder](https://github.com/codebude/QRCoder)
* MailKit (SMTP email): [https://github.com/jstedfast/MailKit](https://github.com/jstedfast/MailKit)
* CsvHelper (CSV import and export): [https://joshclose.github.io/CsvHelper/](https://joshclose.github.io/CsvHelper/)
