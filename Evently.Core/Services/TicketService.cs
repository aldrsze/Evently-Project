using System;
using System.Data;
using Evently.Core.Helpers;
using MySqlConnector;

namespace Evently.Core.Services
{
    public static class TicketService
    {
        public static DataTable GetAttendeesByEvent(int eventId)
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = @"SELECT 
                                a.attendee_id,
                                a.first_name,
                                a.last_name,
                                CONCAT(a.first_name, ' ', a.last_name) AS name,
                                a.birthdate,
                                CASE 
                                    WHEN a.birthdate IS NOT NULL THEN TIMESTAMPDIFF(YEAR, a.birthdate, CURDATE())
                                    ELSE NULL
                                END AS age,
                                a.email
                             FROM tickets t
                             INNER JOIN attendees a ON t.attendee_id = a.attendee_id
                             WHERE t.event_id = @eventId;";

            using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            MySqlDataAdapter adapter = new(cmd);
            DataTable table = new();
            adapter.Fill(table);
            return table;
        }

        public static bool AddAttendee(int eventId, string firstName, string lastName, string email, DateTime birthdate)
        {
            firstName = firstName.Trim();
            lastName = lastName.Trim();
            email = email.Trim();

            using var conn = DatabaseConnection.GetConnection();

            int attendeeId = 0;
            string findQuery = "SELECT attendee_id FROM attendees WHERE email = @email;";
            using (MySqlCommand findCmd = new(findQuery, conn))
            {
                findCmd.Parameters.AddWithValue("@email", email);
                object? result = findCmd.ExecuteScalar();
                if (result != null)
                {
                    attendeeId = Convert.ToInt32(result);
                }
            }

            if (attendeeId == 0)
            {
                string insertAttendeeQuery = @"INSERT INTO attendees(first_name, last_name, email, birthdate)
                                               VALUES (@firstName, @lastName, @email, @birthdate);
                                               SELECT LAST_INSERT_ID();";
                using MySqlCommand insertCmd = new(insertAttendeeQuery, conn);
                insertCmd.Parameters.AddWithValue("@firstName", firstName);
                insertCmd.Parameters.AddWithValue("@lastName", lastName);
                insertCmd.Parameters.AddWithValue("@email", email);
                insertCmd.Parameters.AddWithValue("@birthdate", birthdate);

                try
                {
                    attendeeId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) { return false; }
                    if (ex.Number == 1406) { return false; }
                    throw;
                }
            }

            string insertTicketQuery = @"INSERT INTO tickets(ticket_id, attendee_id, event_id)
                                         VALUES (@ticketId, @attendeeId, @eventId);";
            using MySqlCommand ticketCmd = new(insertTicketQuery, conn);
            ticketCmd.Parameters.AddWithValue("@ticketId", Guid.NewGuid().ToString());
            ticketCmd.Parameters.AddWithValue("@attendeeId", attendeeId);
            ticketCmd.Parameters.AddWithValue("@eventId", eventId);

            try
            {
                return ticketCmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) { return false; }
                throw;
            }
        }

        public static bool DeleteAttendee(int eventId, int attendeeId)
        {
            using var conn = DatabaseConnection.GetConnection();

            string deleteTicketQuery = "DELETE FROM tickets WHERE event_id = @eventId AND attendee_id = @attendeeId;";
            using (MySqlCommand ticketCmd = new(deleteTicketQuery, conn))
            {
                ticketCmd.Parameters.AddWithValue("@eventId", eventId);
                ticketCmd.Parameters.AddWithValue("@attendeeId", attendeeId);
                if (ticketCmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
            }

            // If attendee has no tickets left in any event, remove attendee record
            string countQuery = "SELECT COUNT(*) FROM tickets WHERE attendee_id = @attendeeId;";
            using MySqlCommand countCmd = new(countQuery, conn);
            countCmd.Parameters.AddWithValue("@attendeeId", attendeeId);
            int remaining = Convert.ToInt32(countCmd.ExecuteScalar());
            if (remaining == 0)
            {
                string deleteAttendeeQuery = "DELETE FROM attendees WHERE attendee_id = @attendeeId;";
                using MySqlCommand attendeeCmd = new(deleteAttendeeQuery, conn);
                attendeeCmd.Parameters.AddWithValue("@attendeeId", attendeeId);
                attendeeCmd.ExecuteNonQuery();
            }

            return true;
        }

        public static bool UpdateAttendee(int attendeeId, string firstName, string lastName, string email, DateTime birthdate)
        {
            firstName = firstName.Trim();
            lastName = lastName.Trim();
            email = email.Trim();

            using var conn = DatabaseConnection.GetConnection();

            string checkQuery = "SELECT COUNT(*) FROM attendees WHERE attendee_id = @attendeeId;";
            using (MySqlCommand check = new(checkQuery, conn))
            {
                check.Parameters.AddWithValue("@attendeeId", attendeeId);
                if (Convert.ToInt32(check.ExecuteScalar()) == 0) { return false; }
            }

            string query = @"UPDATE attendees
                             SET first_name = @firstName,
                                 last_name = @lastName,
                                 email = @email,
                                 birthdate = @birthdate
                             WHERE attendee_id = @attendeeId;";

            using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@birthdate", birthdate);
            cmd.Parameters.AddWithValue("@attendeeId", attendeeId);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) { return false; }
                if (ex.Number == 1406) { return false; }
                throw;
            }
        }
    }
}
