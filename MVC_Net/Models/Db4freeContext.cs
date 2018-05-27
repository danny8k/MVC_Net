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

        public void AddUser(User user)
        {

            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand storedProcedure = new MySqlCommand("AddUser", conn);
                storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;
                storedProcedure.Parameters.Add(new MySqlParameter("username_input", user.username));
                storedProcedure.Parameters.Add(new MySqlParameter("password_input", user.password));
                storedProcedure.Parameters.Add(new MySqlParameter("fname_input", user.fname));
                storedProcedure.Parameters.Add(new MySqlParameter("lname_input", user.lname));
                storedProcedure.Parameters.Add(new MySqlParameter("email_input", user.email));

                storedProcedure.Connection.Open();

                var result = storedProcedure.ExecuteNonQuery();

                storedProcedure.Connection.Close();
            }

        }

        public void DeleteUser(int userId)
        {

            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand storedProcedure = new MySqlCommand("DeleteUser", conn);
                storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;
                storedProcedure.Parameters.Add(new MySqlParameter("username_id", userId));


                storedProcedure.Connection.Open();

                var result = storedProcedure.ExecuteNonQuery();

                storedProcedure.Connection.Close();
            }

        }
    }
}
