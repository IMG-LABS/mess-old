using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace MessLibrary
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
    /// This Class consists all user related functions.
    /// 
    /// </summary>
    
    public class users
    {
        public string message;
        public string post;
        private static string GetMD5Hash(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();

        }

        public users(string username, string password)
        {
            username = GetMD5Hash(username);
            password = GetMD5Hash(password);
            connect con = new connect("main");
            string query = "SELECT passhash, post FROM users WHERE userhash='" + username + "'";
            MySqlDataReader dr = con.reader(query);
            if (dr.Read())
            {
                message = "read";
                if (password == dr[0].ToString())
                {
                    message = "sucess";
                    post = dr[1].ToString();
                    con.closeConnection();
                    
                }
                else
                {
                    message = "no-match";
                }
            }
            else
            {
                message = "error";
            }
            con.closeConnection();
        }
    }
}
