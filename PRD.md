# Product Requirements Document (PRD)

## 1. Project Overview

**Project Name:**
Evently

**Team Members & Roles:**

| Name | Role |
| --- | --- |
| Aldrin Jariel | Full-Stack Developer, Database Designer |
| Raxell Alshane Minaves | Frontend Designer |
| Ron Paulo Angeles | Frontend Designer & Documentation |

**Summary:**
Evently is a Windows desktop app for managing event registration and check-in. Users sign in with a username and password. Administrators create events with a guest limit, register attendees (one by one or from a CSV file), and email each attendee a QR ticket. At the door, staff scan the QR ticket with a webcam to check guests in. The same QR ticket is scanned again on the way out, so the app knows who is inside the venue right now. After the event, the admin emails a link to a rating form (a Google Form the admin makes by hand) to the guests who actually attended. The admin downloads the form's responses as a CSV and imports them, and Evently saves a rating only for guests who checked in. A live dashboard shows how many people are inside, how many have arrived, and the average rating, with charts. Attendance can be exported as CSV. Data is stored in a MySQL database with a normalized schema (attendees and reviews are separate tables, and events can have organizers).

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

* Give the system its own basic login (username and password), so only authorized people can use it.
* Let administrators create events with a maximum guest limit.
* Support two ways to register attendees: manual entry and CSV import.
* Generate a unique QR ticket for each attendee and email it.
* Check guests in (and out) by scanning the QR ticket with a webcam.
* Show a live count of guests who are currently inside the venue.
* Collect 1 to 5 ratings and comments only from guests who attended, using a Google Form link sent by email and a CSV import.
* Show a simple dashboard with charts and export attendance as CSV.
* Keep the schema normalized: users, events, attendees, organizers, event_organizers, tickets, and reviews.
* Show good use of Object-Oriented Programming (OOP) by separating forms, services, and helpers into organized parts.

**Success Criteria:**

* An administrator can create an event and register an attendee in under 2 minutes.
* A QR ticket is created for every registered attendee, and the email is sent when the admin clicks "Send Tickets."
* The webcam scanner checks a ticket and updates the on-screen count in about 1 second.
* The system always blocks: (1) using the same ticket to check in twice, and (2) registering more attendees than the event's guest limit, whether by manual entry or CSV.
* A CSV of up to 100 attendees can be imported in one step, with a summary (imported / skipped).
* An admin can email the review form link to every checked-in guest in one click.
* A CSV of up to 100 review responses can be imported in one step, with a summary (saved / skipped), and a rating is saved only for a checked-in guest, once per guest.
* The dashboard refreshes by itself every 5 seconds without freezing the app.
* Passwords are never stored in plain text, and no screen other than Login can be opened without signing in.

**Out of Scope:**

* Any Google API or automatic syncing with Google Forms (the admin creates the rating form by hand and moves the data with CSV files).
* Google sign-in.
* Paid tickets or payment services.
* SMS, push notifications, and scheduled or reminder emails.
* Badge printing and PDF exports.
* Native iOS or Android apps.
* Linux or macOS support (Windows Forms is Windows-only).
* Multi-computer live syncing.
* Forgot-password emails, two-factor authentication, and detailed permission editors.
* Automated unit or integration tests.

---

## 4. Target Users / Personas

| Persona | Description | Needs |
| --- | --- | --- |
| Event Attendee | A student or guest going to an event | A QR ticket sent to their email, a quick entry at the door, and a short rating form sent to their email after the event. |
| Event Administrator | The organizer running the event | A login, an easy screen to create events, a way to add attendees (manual or CSV), ticket emails, a review request email, a review CSV import, a dashboard, and an attendance export. |
| Staff | Staff member or volunteer checking people in at the door | Their own login limited to the scanner screen, a hands-free webcam scan, and clear pass or fail messages. |

---

## 5. Features & Requirements

### 5.1 Core Features (Must-Have)

Status reflects what is in the repository today.

| # | Feature | Description | Priority | Status |
| --- | --- | --- | --- | --- |
| 1 | Login & Roles | Users sign in with a username and password (hashed). There are two roles: Administrator (full access) and Staff (scanner screen only). A demo administrator is created by `db/seed.sql` (`admin` / `admin123`). | High | Login done. Hiding admin screens from Staff is not done. |
| 2 | User Accounts | Administrators can add, edit, deactivate, and reactivate staff or admin accounts. Usernames are unique, passwords need at least 8 characters, the last active admin and your own account are protected, and you cannot change your own role. | Medium | Done. |
| 3 | Event Management | Admin can create, edit, and delete events with a name, venue, date and time, description, and maximum guest limit. | High | Screen built. Save, edit, and delete are not wired. |
| 4 | Attendee Registration | Admin can register an attendee by typing their full name and email into the app. Attendees are stored once and shared across events; a known email is reused and only a new ticket is created. A full event is refused. | High | Screen built. Logic not written. |
| 5 | CSV Import | Admin can import a list of attendees (`full_name`, `email`) from a CSV file into a selected event, with duplicate handling, capacity enforcement, and a result summary. | High | Button only. |
| 6 | QR Ticket Creation | The system generates a unique UUID for each ticket and creates a QR image from it. | High | Service file empty. |
| 7 | Email Tickets | Admin clicks "Send Tickets" and the app emails the QR image to every attendee who has not been emailed yet. | High | Service file empty. |
| 8 | Webcam Check-In | The desktop app uses a webcam to read QR tickets. A valid first scan marks the guest as checked in. | High | Screen built. Scanner not written. |
| 9 | Check-Out (Unique Feature) | Scanning a checked-in ticket again checks the guest out, so the app always knows who is inside the venue right now. | High | Not written. |
| 10 | Ticket Checking Rules | The system rejects fake codes, blocks repeat check-ins, and blocks scans for tickets that are already checked out. | High | Not written. |
| 11 | Review Request Email | The admin pastes the link of a Google Form (made by hand) into the event, then clicks "Send Review Request." The app emails the link to checked-in guests. | High | Screen built. Email and "already sent" tracking not implemented. |
| 12 | Review CSV Import | The admin downloads the form's responses as a CSV and imports them. The app matches each row to a ticket by email and saves a review row only if that guest checked in and has no review yet. A summary is shown. | High | Button only. |
| 13 | Live Dashboard | A screen with an event selector, metrics, a doughnut chart, a check-ins-over-time chart, and a recent check-ins list (section 5.4). | High | Layout, charts, and 5-second timer done with sample data. Real queries not written. |
| 14 | Attendance Export (CSV) | Admin can export an event's attendee list (name, email, check-in time, check-out time, rating, comment) as a CSV file. | High | Button only. |
| 15 | Event Organizers | The schema stores organizers and links them to events through `event_organizers`, so one event can list several organizer contacts. | Medium | Schema only. No screens or services yet. |

### 5.2 Nice-to-Have Features (Stretch Goals)

| # | Feature | Description |
| --- | --- | --- |
| 1 | Sound Alerts | Play one sound for a good scan and a different sound for a rejected scan. |
| 2 | Badge Printing | Print a simple badge (name and QR code) using `PrintDocument`. |
| 3 | Announcement Email | Send one email message to all attendees of an event. |
| 4 | Dashboard Display Mode | A full-screen, large-type dashboard for a projector. |
| 5 | Registration Form Import | Import registrations from a Google Form CSV (the admin picks which columns are the name and email). |

### 5.3 User Stories

* As an **Administrator**, I want to sign in with a username and password, so only authorized people can use the system.
* As an **Administrator**, I want to add staff accounts, so volunteers can scan tickets without seeing admin screens.
* As an **Administrator**, I want to create an event with a maximum number of guests, so the event is never over capacity.
* As an **Administrator**, I want to register attendees by typing them in, so I can add walk-ins quickly.
* As an **Administrator**, I want to import an attendee list from a CSV file, so I can register many people at once.
* As an **Administrator**, I want to send QR tickets to all attendees with one button click, so I don't have to email each person.
* As an **Administrator**, I want to see a live dashboard, so I know how many people are inside and how the event is going.
* As an **Administrator**, I want to export attendance as a CSV, so I can report on turnout.
* As an **Attendee**, I want to receive my QR code by email, so I can use it to enter the event.
* As an **Administrator**, I want to email a rating form only to the guests who attended, so I get feedback from real attendees.
* As an **Administrator**, I want to import the form's responses from a CSV, so I can see the average rating without any complicated setup.
* As an **Attendee**, I want to receive a short rating form by email after the event, so I can tell the organizers what I thought.
* As a **Staff** member, I want to scan tickets with my laptop's webcam, so I don't have to search for names by hand.
* As a **Staff** member, I want clear "valid" and "invalid" messages, so I know right away whether to let someone in.

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
| Review requests sent | Count versus guests checked in. |
| Tickets emailed | Count of tickets sent versus registered guests. |
| Recent check-ins | The latest guests with their check-in or check-out time. |
| Attendance chart | Doughnut chart splitting guests into inside, checked out, and not arrived. |
| Check-ins over time | Line chart of total check-ins across time slots. |

Until the services exist, these values are sample data held in memory, and the timer simulates gate scans so the charts can be viewed.

**Role visibility:** Administrators see the whole dashboard. Staff should see only the check-in screen with its live count; this restriction is not implemented yet.

---

## 6. System Design Overview

**Tech Stack (packages currently in `Evently.csproj`):**

| Layer | Technology |
| --- | --- |
| Desktop App | Windows Forms on .NET 10 (`net10.0-windows`), C#, WinForms Designer |
| Database | MySQL 8.x, accessed with `MySqlConnector` 2.6.2 and plain SQL |
| Authentication | Local username/password accounts stored in MySQL. Passwords are hashed with `BCrypt.Net-Next` 4.2.0. |
| Charts | `WinForms.DataVisualization` 1.10.2 (doughnut and spline charts on the dashboard) |
| Configuration | `db.config` in the project root: four plain `key=value` lines (`Server`, `Database`, `User`, `Password`), copied next to the exe at build time and git-ignored |
| Hosting | Runs on one Windows computer with MySQL installed locally |

**Libraries still to add when their features are built:**

| Feature | Package |
| --- | --- |
| CSV import and export | `CsvHelper` |
| QR generation | `QRCoder` |
| QR reading | `ZXing.Net` |
| Webcam | `AForge.NET` (`AForge.Video.DirectShow`) |
| Email | `MailKit` (SMTP using a Gmail address and an app password read from configuration) |

**High-Level Architecture:**
The project is a single Windows Forms desktop application connected to a MySQL database and, later, an SMTP server for email:

1. **`Evently`**: A single Windows Forms desktop application containing:
   * **Forms**: Windows Forms screens that call static service methods directly.
   * **Services**: Static classes that hold both the SQL and the business rules (login, users, registration and capacity, CSV, QR codes, email, check-in, dashboard numbers). `AuthService` and `UserService` are written; the rest are empty files.
   * **Helpers**: `DatabaseConnection` (builds the connection string and opens connections), `PasswordHelper` (BCrypt hash and verify), and `Session` (who is signed in for the current run).
   * There is no separate Models folder and no repository layer; grids bind straight to `DataTable` results.

```
 [Login: username + password]
              │
              ▼
      ┌───────────────┐
 [CSV file] ─ import ─>│    Evently    │── export ──> [CSV report]
      │  Windows      │
 [Manual entry] ──────>│  Forms App    │        ┌──────────────┐
      │               │───────>│ MySQL        │
      │  Services     │  SQL   │ Database     │
      │  Dashboard <──┼─ timer─┤ (7 tables)   │
      └───────┬───────┘        └──────────────┘
              │ SMTP
              ▼
   [Attendee's Email: QR ticket]

 [Webcam] ──> QR scan ──> Check-in (1st scan) / Check-out (2nd scan)

 After the event:
 [Review Google Form (made by hand)] <── link emailed to checked-in guests
 [Form responses CSV (downloaded by admin)] ── import ──> reviews saved
```

**Database Models (7 tables):**

* **User**: `user_id`, `username`, `password` (BCrypt hash), `role` (ADMIN or STAFF), `is_active`.
* **Event**: `event_id`, `name`, `venue`, `description`, `event_date`, `capacity`, `review_form_url` (empty until the admin pastes the Google Form link).
* **Attendee**: `attendee_id`, `full_name`, `email` (unique across the whole app).
* **Organizer**: `organizer_id`, `full_name`, `email` (unique), `phone`, `organization`.
* **EventOrganizer**: `event_id` + `organizer_id` (one row per organizer of an event).
* **Ticket**: `ticket_id` (UUID used as the QR code), `attendee_id`, `event_id`, `ticket_emailed` (yes/no), `checked_in_at` (empty until checked in), `checked_out_at` (empty until checked out).
* **Review**: `ticket_id` (one review per ticket), `rating` (1 to 5), `comment` (optional).

**SQL Schema (`db/schema.sql`):**

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
    capacity        INT NOT NULL CHECK (capacity > 0),
    review_form_url VARCHAR(255) NULL
);

CREATE TABLE attendees (
    attendee_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name   VARCHAR(100) NOT NULL,
    email       VARCHAR(100) NOT NULL UNIQUE
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
    checked_in_at  DATETIME NULL,
    checked_out_at DATETIME NULL,
    UNIQUE (event_id, attendee_id),
    FOREIGN KEY (event_id) REFERENCES events(event_id) ON DELETE CASCADE,
    FOREIGN KEY (attendee_id) REFERENCES attendees(attendee_id) ON DELETE CASCADE
);

CREATE TABLE reviews (
    ticket_id CHAR(36) PRIMARY KEY,
    rating    TINYINT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    comment   VARCHAR(500) NULL,
    FOREIGN KEY (ticket_id) REFERENCES tickets(ticket_id) ON DELETE CASCADE
);
```

`db/schema.sql` holds only `CREATE TABLE` statements. `db/seed.sql` adds the demo admin (`admin` / `admin123`, change it after first sign-in) and nothing else. The README explains creating `evently_db`, importing both files, and copying `db.config.example` to `db.config`.

**Rules the database enforces:**

* `username` is unique.
* `attendees.email` is unique across the app, so a person is stored once and is reused for other events. A ticket is unique on (`event_id`, `attendee_id`), so nobody is registered twice for one event.
* `rating` is required and must be between 1 and 5; the review's `ticket_id` is the primary key, so a ticket can have only one review.
* Deleting an event deletes its tickets (cascade), and deleting a ticket deletes its review. Deleting an attendee or organizer also removes its links.

**Design Notes & Constraints:**

* **Passwords:** Minimum length of 8 (`UserService.MinPasswordLength`), hashed with BCrypt, never logged or saved as plain text. The hashed value is stored in the `password` column.
* **Session:** After a successful login, `Session.SignIn` stores the username and role for the rest of the run. Logging out clears them. The main window can only be closed with Log out.
* **Capacity rule:** Before inserting a ticket, the app counts the event's tickets and refuses the insert when the count equals `capacity`. This is used for manual entry and CSV import.
* **Registration flow:** Look up the email in `attendees`. If it exists, reuse that row; otherwise insert the attendee. Then insert a ticket for the selected event.
* **Ticket states (worked out from columns, not stored):**
  * `checked_in_at` empty: **Registered** (not arrived).
  * `checked_in_at` set and `checked_out_at` empty: **Inside**.
  * Both set: **Left**.
* **Scan logic:** (1) Look up the scanned UUID. If not found, show "Invalid Ticket." (2) If `checked_in_at` is empty, set it to the current time and show "Welcome, [name]." (3) If checked in but not checked out, save `checked_out_at` and show "Goodbye, [name]." (4) If already checked out, show "Ticket already used."
* **Review request:** The admin creates the rating form in Google Forms by hand (a 1 to 5 scale question, an optional comment question, and a required email question), then pastes its link into the event. "Send Review Request" emails the link only to tickets where `checked_in_at` is set. There is no `review_emailed` column yet, so retry-only-the-unsent behaviour is not possible until one is added.
* **Review import:** The admin downloads the responses as a CSV from Google Forms (Responses tab, three-dot menu, "Download responses") and imports it on the Reviews screen. For each row, the app finds the ticket of the selected event whose email matches and inserts a `reviews` row only if the ticket has `checked_in_at` set and has no review yet. Other rows are skipped and counted (not registered, not checked in, already rated, invalid rating). The screen currently has no column-mapping controls; the importer expects email, rating, and comment headers.
* **Known limit:** The form asks for an email instead of requiring Google sign-in, so someone who knows another guest's email could submit a rating for them. This is accepted for a school project.
* **Scan cooldown:** The scanner ignores the same QR code for 3 seconds so one ticket held in front of the camera is not scanned many times.
* **Email:** "Send Tickets" only sends to tickets where `ticket_emailed` is false, so clicking it again retries only the ones that failed. The summary shows sent and failed counts.
* **Dashboard:** Uses a `System.Windows.Forms.Timer` at 5000 ms. Real numbers will come from simple `COUNT` and `AVG` queries, one event at a time. The timer currently redraws sample data.
* **UI shell:** `MainForm` is a sidebar plus a content panel; each menu button swaps a child form into the panel (`TopLevel = false`, `Dock = Fill`). Login `Hide()`s itself and opens `MainForm` as a modal dialog, then shows itself again after logout.
* **Styling:** Segoe UI 10/11/18 pt, a blue-and-slate palette, and a brand side panel on the login screen.
* **Not stored on purpose:** Failed or duplicate scan attempts and import summaries are shown on screen but not saved.

**Known Gaps (code and doc not aligned yet):**

* Role-based access: Staff can currently see every sidebar button and lands on the Events screen, not the Check-In screen.
* Organizers and `event_organizers` have no screen or service.
* The dashboard shows sample events instead of database rows.
* Review request sending cannot tell who was already emailed.
* Services for events, tickets, CSV, QR, email, and dashboard are empty files; `Forms/*Form.cs` handlers are TODO stubs.
* Service files use the namespace `_` (`using _.Services`), which should be renamed to `Evently.Services`.

**Project Structure:**

```
evently/
├── Evently.sln
├── Evently.csproj
├── Program.cs                    (opens LoginForm)
├── db.config.example
├── README.md
│
├── db/
│   ├── schema.sql                (7 tables, CREATE TABLE only)
│   └── seed.sql                  (demo admin)
│
├── Helpers/
│   ├── DatabaseConnection.cs     (db.config reader, GetConnection)
│   ├── PasswordHelper.cs         (BCrypt hash and verify)
│   └── Session.cs                (signed-in username and role)
│
├── Services/
│   ├── AuthService.cs            (written: verify login, read role)
│   ├── UserService.cs            (written: list, add, edit, activate)
│   ├── EventService.cs           (empty)
│   ├── TicketService.cs          (empty: registration, capacity, check-in/out)
│   ├── CsvService.cs             (empty: attendee import, review import, export)
│   ├── QrCodeService.cs          (empty)
│   ├── EmailService.cs           (empty: ticket and review emails)
│   └── DashboardService.cs       (empty)
│
├── Forms/
│   ├── LoginForm.cs / .Designer.cs
│   ├── MainForm.cs / .Designer.cs / .resx
│   ├── UserListForm.cs / .Designer.cs
│   ├── UserEditForm.cs / .Designer.cs
│   ├── EventListForm.cs / .Designer.cs
│   ├── AttendeesForm.cs / .Designer.cs
│   ├── ReviewsForm.cs / .Designer.cs
│   ├── CheckInForm.cs / .Designer.cs
│   └── DashboardForm.cs / .Designer.cs / .resx
```

**Build Progress & Next Steps:**

| Area | State | Next work |
| --- | --- | --- |
| Database schema, seed, README, config | Done | Keep `db/schema.sql` as the source of truth; apply changes by hand |
| Project setup, .NET 10, packages | Done | Add CSV, QR, webcam, and email packages per feature |
| Login, session, password hashing | Done | Show login errors on the form; enforce role-based screens |
| User management | Done | Optional cleanup: rename namespace `_` |
| All screen layouts and styling | Done | Polish after real data is bound |
| Events | Screen only | `EventService` create/edit/delete + list binding |
| Attendees | Screen only | `TicketService` registration, capacity rule, grid binding |
| CSV import/export | Not started | `CsvService` with duplicate, invalid, and over-capacity counts |
| QR tickets and email | Not started | `QrCodeService` + `EmailService` + sent/failed summary |
| Check-in / check-out scanner | Not started | Webcam loop, ZXing decode, 3-second cooldown, live inside count |
| Reviews | Screen only | Save URL, send request, review CSV import into `reviews` |
| Dashboard | Mock data | Replace sample data with `DashboardService` queries; refresh after scans |
| Organizers | Schema only | Decide whether screens are needed; otherwise document as schema-only |

---

## 7. User Flow

**1. Signing In (All Users)**
* Users open the app and see the Login screen. They enter a username and password.
* A correct password opens the main menu. At present both roles see the same sidebar; the plan is for Staff to land on the Check-In screen with only that button visible.

**2. Managing Users (Admin)**
* In "Manage Users," the admin sees all accounts with role and status.
* They can add a user (username, password, role), edit a user (rename, change role, reset password), and deactivate or reactivate a user.
* The app refuses to deactivate the signed-in account, to remove the last active admin, or to change your own role.

**3. Creating an Event (Admin)**
* The admin clicks "Create" on the Events screen.
* They enter the name, venue, description, date and time, and maximum number of guests (e.g., 200), then save.

**4. Registering Attendees (Admin)**
* **Manual:** The admin opens "Attendees," selects an event, types the full name and email, and clicks "Add." If the email is new it becomes an attendee row, and a ticket with a unique UUID is created when the event is not full.
* **CSV:** The admin clicks "Import CSV" and chooses a file with `full_name` and `email` columns. The app imports valid rows until the event is full and shows a summary: "48 imported, 3 duplicates skipped, 2 invalid, 0 over capacity."

**5. Sending QR Tickets (Admin)**
* The admin selects an event and clicks "Send Tickets."
* For each ticket not yet emailed, the app generates a QR image from the UUID, emails it with the event details, and marks it as emailed.
* The app shows a summary: "12 tickets sent, 3 failed." Clicking the button again retries only the failed ones.

**6. Checking In (Staff)**
* Staff open the Check-In Scanner and select the event.
* The guest shows their QR code (from their phone or a printout) to the webcam.
* The app reads the QR code and looks up the ticket:
  * **Valid, first scan:** Marks it checked in, shows "Welcome, [name]," and adds 1 to the live count (e.g., "48 inside").
  * **Invalid code:** Shows "Invalid Ticket."

**7. Checking Out (Staff)**
* When the guest leaves, they show the same QR code to the webcam.
* The app recognizes the ticket as already checked in, saves the check-out time, and shows "Goodbye, [name]." The "inside" count goes down by 1.
* If the ticket is scanned a third time, the app shows "Ticket already used."

**8. Collecting Reviews (Admin, Attendee)**
* After the event, the admin creates a rating form in Google Forms by hand (1 to 5 rating, optional comment, and the guest's email) and pastes its link into the event on the "Collect Reviews" screen.
* The admin clicks "Send Review Request." The app emails the link to every checked-in guest and shows a summary: "30 sent, 2 failed."
* The guest opens the link on their phone, picks a rating, optionally writes a comment, enters the email they registered with, and submits.
* When enough responses are in, the admin downloads the responses as a CSV from Google Forms, then clicks "Import Reviews CSV" in Evently and chooses the file.
* The app saves a review only for a checked-in guest with no review yet, and shows a summary: "14 saved, 2 skipped (not checked in), 1 skipped (already rated), 1 skipped (email not found)."

**9. Watching the Dashboard (Admin)**
* The admin opens the Live Dashboard and picks an event.
* The dashboard refreshes every 5 seconds and shows the data in section 5.4, including the charts and the average rating once reviews are imported.

**10. Exporting Attendance (Admin)**
* On the "Attendees" screen, the admin selects an event and clicks "Export CSV."
* The app saves a file with each attendee's name, email, check-in time, check-out time, rating, and comment.

---

## 8. Evaluation / Testing Plan

* **Login Tests:**
  * Sign in with the correct password, and confirm a wrong password and a deactivated user are rejected.
  * Confirm a staff user sees only the Check-In screen.
  * Check the database to confirm passwords are stored as BCrypt hashes in `users.password`.
  * Confirm the last active admin cannot be deactivated, demoted, or edited away.

* **Database Tests (MySQL):**
  * Add, read, update, and delete users, events, attendees, organizers, and tickets using the service classes.
  * Confirm the same attendee email is stored once and reused for a second event.
  * Confirm the same attendee cannot get two tickets for one event.
  * Confirm no tickets are created once the event reaches its capacity (manual and CSV).
  * Confirm a rating outside 1 to 5 is rejected.
  * Confirm a ticket cannot receive a second review.
  * Confirm deleting an event removes its tickets and their reviews.

* **CSV Tests:**
  * Import a valid file, a file with missing columns, invalid emails, duplicate emails, and a file with more rows than the remaining capacity. Confirm the summary is accurate.
  * Export attendance and confirm it opens correctly in Excel (test names with accents and commas).

* **Email Tests:**
  * Send tickets to your own test emails and confirm the QR image arrives.
  * Enter a wrong SMTP password, click "Send Tickets," and confirm failures are counted. Fix it and confirm only the unsent tickets are retried.

* **Review Tests:**
  * Make a test Google Form (rating, comment, email), paste its link into an event, and click "Send Review Request." Confirm only checked-in guests receive the email.
  * Submit responses from a checked-in email, an email that never checked in, an email that is not registered, and a second response from the checked-in email. Download the CSV and import it. Confirm only the first is saved and the summary counts the others correctly.
  * Import the same CSV twice and confirm no guest gets a second review (the `reviews` primary key blocks it).
  * Import a CSV with a rating outside 1 to 5 and confirm that row is skipped.
  * Confirm the average rating and response rate on the dashboard match a direct SQL query.
  * Confirm comments with accents and commas import correctly.

* **QR Scanning Tests:**
  * Scan a QR code from a phone screen and from a paper printout, at different distances (10 cm to 50 cm).
  * Scan a random QR code not made by the app, and confirm "Invalid Ticket" is shown.
  * Scan the same ticket three times and confirm it checks in, checks out, then is rejected.

* **Dashboard Tests:**
  * Compare each number on the dashboard against a direct SQL query.
  * Check in a guest and confirm the dashboard updates within 5 seconds.
  * Confirm the app does not freeze while the dashboard refreshes.

* **Full Run-Through Test:**
  * Log in as the admin and add one staff account.
  * Create a test event with a limit of 10 guests.
  * Register 7 people manually and import 3 through CSV.
  * Try to register an 11th person and confirm it is blocked.
  * Send QR tickets by email.
  * Log in as staff, check in all 10 guests with the webcam, and confirm the count shows "10 inside."
  * Check out 8 guests and confirm the dashboard shows "2 inside."
  * Send the review request, submit 8 ratings in the Google Form (plus one from an unregistered email), download the CSV, import it, and confirm 8 reviews are saved and the dashboard shows the correct average.
  * Export the attendance CSV and confirm it lists all 10 guests with their times, ratings, and comments.

---

## 9. References / Appendix

* Windows Forms Docs: [https://learn.microsoft.com/en-us/dotnet/desktop/winforms/](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
* .NET 10 Downloads: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
* MySQL Reference Manual: [https://dev.mysql.com/doc/](https://dev.mysql.com/doc/)
* MySqlConnector: [https://mysqlconnector.net/](https://mysqlconnector.net/)
* BCrypt.Net-Next (password hashing): [https://github.com/BcryptNet/bcrypt.net](https://github.com/BcryptNet/bcrypt.net)
* WinForms DataVisualization (charts): [https://github.com/dotnet/winforms-datavisualization](https://github.com/dotnet/winforms-datavisualization)
* ZXing.Net (reads QR codes): [https://github.com/micjahn/ZXing.Net](https://github.com/micjahn/ZXing.Net)
* AForge.NET (webcam access): [http://www.aforgenet.com/framework/](http://www.aforgenet.com/framework/)
* QRCoder (makes QR codes): [https://github.com/codebude/QRCoder](https://github.com/codebude/QRCoder)
* MailKit (SMTP email): [https://github.com/jstedfast/MailKit](https://github.com/jstedfast/MailKit)
* CsvHelper (CSV import/export): [https://joshclose.github.io/CsvHelper/](https://joshclose.github.io/CsvHelper/)
