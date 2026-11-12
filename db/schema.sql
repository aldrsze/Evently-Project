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

-- Default admin account (change the password after first login)
-- INSERT INTO users (username, password, role) VALUES ('admin', '<bcrypt hash>', 'ADMIN');
