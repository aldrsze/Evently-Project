
using System.Data;
using Evently.Core.Helpers;
using MySqlConnector;

namespace Evently.Core.Services
{
    public static class EventService
    {

        public static DataTable GetEvent()
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM events;";
            MySqlDataAdapter adapter = new(query, conn);
            DataTable table = new();
            adapter.Fill(table);
            return table;
        }

        public static bool AddEvent(string name, string venue, string description, DateTime date, int capacity)
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = @"INSERT INTO events(name, venue, description, event_date, capacity)
                             VALUES
                             (@name, @venue, @description, @event_date, @capacity)";
            using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@venue", venue);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@event_date", date);
            cmd.Parameters.AddWithValue("@capacity", capacity);

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                // 3819 = a CHECK rule refused the row, here capacity > 0
                if (ex.Number == 3819) { return false; } 
                // 1406 = a string is longer than its column, e.g. name over 100 chars
                if (ex.Number == 1406) { return false; }

                // anything else is not the user's fault: wrong db.config, MySQL down
                // rethrow so the form shows the real message instead of a guess
                throw;
            }

        }

        public static bool UpdateEvent(int eventId, string name, string venue, string description, DateTime date, int capacity)
        {
            using var conn = DatabaseConnection.GetConnection();

            // 0 changed rows can mean "nothing to change", so check the row exists first
            string checkQuery = "SELECT COUNT(*) FROM events WHERE event_id = @eventId";
            using MySqlCommand check = new(checkQuery, conn);
            check.Parameters.AddWithValue("@eventId", eventId);
            if (Convert.ToInt32(check.ExecuteScalar()) == 0) { return false; } // deleted meanwhile

            string query = @"UPDATE events
                             SET name = @name,
                                 venue = @venue,
                                 description = @description,
                                 event_date = @event_date,
                                 capacity = @capacity
                             WHERE event_id = @eventId";

            using MySqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@venue", venue);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@event_date", date);
            cmd.Parameters.AddWithValue("@capacity", capacity);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            try
            {
                cmd.ExecuteNonQuery();
                return true; // the row exists, and an identical save is still a success
            }
            catch (MySqlException ex)
            {
                // 3819 = CHECK failed, so capacity was 0 or less
                if (ex.Number == 3819) { return false; }
                // 1406 = a string is longer than its column
                if (ex.Number == 1406) { return false; }
                throw;
            }
        }
    }
}