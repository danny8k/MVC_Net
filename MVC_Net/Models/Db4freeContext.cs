using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MVC_Net.Models
{
    public class Db4freeContext
    {
        public string ConnectionString { get; set; }

        public Db4freeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            id = reader.GetInt32("id"),
                            username = reader.IsDBNull(reader.GetOrdinal("username")) ? "N/A" : reader.GetString("username"),
                            password = reader.IsDBNull(reader.GetOrdinal("password")) ? "N/A" : reader.GetString("password"),
                            fname = reader.IsDBNull(reader.GetOrdinal("fname")) ? "N/A" : reader.GetString("fname"),
                            lname = reader.IsDBNull(reader.GetOrdinal("lname")) ? "N/A" : reader.GetString("lname"),
                            email = reader.IsDBNull(reader.GetOrdinal("email")) ? "N/A" : reader.GetString("email"),

                        });
                    }
                }
            }

            return list;
        }
    }
}
