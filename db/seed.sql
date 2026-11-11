-- Demo data only. Real rows (emails, password hashes) never go in here.
-- Creates the first admin so you can sign in on a fresh database.
-- Login: admin / admin123  -- change it after your first sign in.

USE evently_db;

INSERT INTO users (username, password, role) VALUES
('admin', '$2a$11$Zq5hVFTuuSmfdyUiCX9M7.CpLHM7iTkdmGHRGRKlpLYbJU6aZ8LVq', 'ADMIN');
