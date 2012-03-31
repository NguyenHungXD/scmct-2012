﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace chiase
{
    public static class Database
    {
        public static String ConnectionString = "Data Source=mayso5;Initial Catalog=SCMCT;User ID=sa; Password=123;Connect Timeout=1";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static DataTable Fill(DataTable table, String sql, params Object[] parameters)
        {
            SqlCommand command = Database.CreateCommand(sql, parameters);
            new SqlDataAdapter(command).Fill(table);
            command.Connection.Close();

            return table;
        }

        public static DataTable GetData(String sql, params Object[] parameters)
        {
            return Database.Fill(new DataTable(), sql, parameters);
        }

        public static int ExecuteNonQuery(String sql, params Object[] parameters)
        {
            SqlCommand command = Database.CreateCommand(sql, parameters);

            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();

            return rows;
        }

        public static object ExecuteScalar(String sql, params Object[] parameters)
        {
            SqlCommand command = Database.CreateCommand(sql, parameters);

            command.Connection.Open();
            object value = command.ExecuteScalar();
            command.Connection.Close();

            return value;
        }

        public static SqlCommand CreateCommand(String sql, params Object[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, Database.GetConnection());
            for (int i = 0; i < parameters.Length; i += 2)
            {
                command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
            }
            return command;
        }
    }
}