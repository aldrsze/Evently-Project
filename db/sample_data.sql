-- Fake rows for testing screens and the dashboard. Not real people.
-- Run after schema.sql and seed.sql. Needs empty tables (see the DELETE block below).
-- Ticket IDs are fake UUIDs, so /Ticket/<id> and /Scan work with the printed codes.

USE evently_db;

-- Uncomment to wipe and re-import. Child tables first, or the foreign keys block it.
DELETE FROM reviews;
DELETE FROM tickets;
DELETE FROM event_organizers;
DELETE FROM organizers;
DELETE FROM attendees;
DELETE FROM events;

INSERT INTO users (username, password, role) VALUES
('staff1', '$2a$11$Zq5hVFTuuSmfdyUiCX9M7.CpLHM7iTkdmGHRGRKlpLYbJU6aZ8LVq', 'STAFF'),
('staff2', '$2a$11$Zq5hVFTuuSmfdyUiCX9M7.CpLHM7iTkdmGHRGRKlpLYbJU6aZ8LVq', 'STAFF');
-- Same BCrypt hash as the admin, so staff1 / admin123 works too.

INSERT INTO events (event_id, name, venue, description, event_date, capacity) VALUES
(1, 'Tech Summit 2026', 'Main Auditorium', 'Talks on AI and web development.', DATE_ADD(NOW(), INTERVAL 3 HOUR), 200),
(2, 'AI Workshop', 'Lab 302', 'Hands-on session, bring a laptop.', DATE_ADD(CURDATE(), INTERVAL 5 DAY), 3),
(3, 'Alumni Homecoming', 'Cafeteria', 'Dinner and program for alumni.', DATE_ADD(CURDATE(), INTERVAL -7 DAY), 100),
(4, 'Freshman Orientation', 'Gymnasium', 'Welcome talk for new students.', DATE_ADD(CURDATE(), INTERVAL 12 DAY), 50);

INSERT INTO attendees (attendee_id, first_name, last_name, email, birthdate) VALUES
(1, 'Maria', 'Santos', 'maria.santos@example.com', '2004-03-12'),
(2, 'Jose', 'Reyes', 'jose.reyes@example.com', '2003-07-25'),
(3, 'Ana', 'Cruz', 'ana.cruz@example.com', NULL),
(4, 'Mark', 'Villanueva', 'mark.villanueva@example.com', '2005-01-30'),
(5, 'Liza', 'Ramos', 'liza.ramos@example.com', '2002-11-05'),
(6, 'Paul', 'Garcia', 'paul.garcia@example.com', '2004-09-18'),
(7, 'Grace', 'Tan', 'grace.tan@example.com', '2001-04-02'),
(8, 'Neil', 'Bautista', 'neil.bautista@example.com', '2003-12-21'),
(9, 'Joy', 'Lim', 'joy.lim@example.com', '2005-06-14'),
(10, 'Carlo', 'Mendoza', 'carlo.mendoza@example.com', '2004-08-09');

INSERT INTO organizers (organizer_id, full_name, email, phone, organization) VALUES
(1, 'Aldrin Jariel', 'aldrin@example.com', '09171234567', 'Student Council'),
(2, 'Nicole Diaz', 'nicole@example.com', NULL, 'IT Society');

INSERT INTO event_organizers (event_id, organizer_id) VALUES
(1, 1),
(1, 2),
(2, 2),
(3, 1),
(4, 1);

-- Event 1 starts in 3 hours: two guests inside, one already left, one not arrived.
INSERT INTO tickets (ticket_id, attendee_id, event_id, ticket_emailed, review_emailed, checked_in_at, checked_out_at) VALUES
('11111111-1111-4111-8111-000000000001', 1, 1, TRUE, FALSE, NOW() - INTERVAL 120 MINUTE, NULL),
('11111111-1111-4111-8111-000000000002', 2, 1, TRUE, FALSE, NOW() - INTERVAL 95 MINUTE, NULL),
('11111111-1111-4111-8111-000000000003', 3, 1, FALSE, FALSE, NOW() - INTERVAL 180 MINUTE, NOW() - INTERVAL 100 MINUTE),
('11111111-1111-4111-8111-000000000004', 4, 1, FALSE, FALSE, NULL, NULL);

-- Event 2 is full at 3 of 3. Ana already has an attendee row, so she is reused.
INSERT INTO tickets (ticket_id, attendee_id, event_id, ticket_emailed, review_emailed, checked_in_at, checked_out_at) VALUES
('22222222-2222-4222-8222-000000000001', 5, 2, TRUE, FALSE, NULL, NULL),
('22222222-2222-4222-8222-000000000002', 6, 2, FALSE, FALSE, NULL, NULL),
('22222222-2222-4222-8222-000000000003', 3, 2, FALSE, FALSE, NULL, NULL);

-- Event 3 already happened: both guests left and rated.
INSERT INTO tickets (ticket_id, attendee_id, event_id, ticket_emailed, review_emailed, checked_in_at, checked_out_at) VALUES
('33333333-3333-4333-8333-000000000001', 7, 3, TRUE, TRUE, NOW() - INTERVAL 7 DAY, NOW() - INTERVAL 7 DAY + INTERVAL 4 HOUR),
('33333333-3333-4333-8333-000000000002', 8, 3, TRUE, TRUE, NOW() - INTERVAL 7 DAY, NOW() - INTERVAL 7 DAY + INTERVAL 3 HOUR);

-- Event 4 is still upcoming: nobody has arrived.
INSERT INTO tickets (ticket_id, attendee_id, event_id, ticket_emailed, review_emailed, checked_in_at, checked_out_at) VALUES
('44444444-4444-4444-8444-000000000001', 9, 4, FALSE, FALSE, NULL, NULL),
('44444444-4444-4444-8444-000000000002', 10, 4, TRUE, FALSE, NULL, NULL);

-- Reviews only exist for guests who checked in.
INSERT INTO reviews (ticket_id, rating, comment, submitted_at) VALUES
('11111111-1111-4111-8111-000000000003', 4, 'Good talks, sound was a bit low.', NOW() - INTERVAL 60 MINUTE),
('33333333-3333-4333-8333-000000000001', 5, 'Great event, see you next year.', NOW() - INTERVAL 6 DAY),
('33333333-3333-4333-8333-000000000002', 3, 'Food ran out early.', NOW() - INTERVAL 6 DAY);
