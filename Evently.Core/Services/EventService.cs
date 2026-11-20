
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
    }
}