using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Mess
{
    /*
     * 
     *  Created By -- Vam$hedhar Reddy C
     *  All Rights Reserved
     *  Product of IMG Labs IIT Roorkee, Saharanpur Campus
     *  
     * */

    /// <summary>
    /// 
    /// Class consists of all ADO.NET functions currently for using a MySQL database
    /// Incase in future if it comes to change database host from MySQL to anything, changing ADO.NET functions here is just enough for the whole project.
    /// 
    /// </summary>
    public class connect
    {
        public string message;
        private MySqlConnection connection;
        public connect(string database)
        {
            connection = new MySqlConnection("Server=127.0.0.1; Database=mess_" + database + " ;Uid=root;Pwd=;");
            connection.Open();
        }

        public void nonQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }

        public MySqlDataReader reader(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                message = "Sucess";
                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                message = e.Message;
                return null;
            }
        }

        public MySqlDataAdapter dataAdapter(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                message = "sucess";
                return new MySqlDataAdapter(command);
            }
            catch (Exception e)
            {
                message = e.Message;
                return null;
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
