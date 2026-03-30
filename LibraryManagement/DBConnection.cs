using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagement
{
    /// <summary>
    /// Centralized database connection manager.
    /// Reads connection string from App.config.
    /// </summary>
    public static class DBConnection
    {
        private static string _connectionString;

        /// <summary>
        /// Gets the connection string from App.config.
        /// Falls back to default if not configured.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    // Try to read from App.config
                    var appSettings = ConfigurationManager.ConnectionStrings["LibraryDB"];
                    if (appSettings != null)
                    {
                        _connectionString = appSettings.ConnectionString;
                    }
                    else
                    {
                        // Default connection string - UPDATE THESE VALUES FOR YOUR SERVER
                        // Format: Server=your_server;Database=LibraryDB;User Id=your_username;Password=your_password;
                        _connectionString = @"Server=localhost;Database=LibraryDB;User Id=sa;Password=your_password_here;Connect Timeout=30;";
                    }
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// Creates and opens a new database connection.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
