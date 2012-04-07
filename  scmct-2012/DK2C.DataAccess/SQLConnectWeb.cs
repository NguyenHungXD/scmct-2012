namespace DK2C.DataAccess.Web
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web;
    using System.Web.UI;

    public class SQLConnectWeb
    {
        protected static SqlCommand Cmd = null;
        public static SqlConnection Conn = null;
        private static int countBeginTran = 0;
        private static int countCommittran = 0;
        protected static SqlDataAdapter Da;
        public static string Databasename;
        public static bool isConnecting = false;
        protected static bool isRunTransac = false;
        public static string LoginName;
        public static string LoginPassword;
        private static string oldConnectionString = null;
        public static string ServerName;
        protected static SqlTransaction Tran;
        public static Page WebPage = new Page();

        public static bool BeginConnect()
        {
            return NewConnect();
        }

        public static void BeginTran()
        {
        }

        public static void Commit()
        {
        }

        public static DateTime GetSystemDatetime()
        {
            try
            {
                DataTable table = GetTable("SELECT GETDATE()");
                if (table == null)
                {
                    return DateTime.Now;
                }
                return DateTime.Parse(table.Rows[0][0].ToString());
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"d_SystemDate\": " + exception.Message + "');</script>");
                return GetSystemDatetime();
            }
        }

        public static int Exec(string strCommandText)
        {
            string erroMess = null;
            return Exec(strCommandText, 0, ref erroMess);
        }

        public static int Exec(string strCommandText, int timeout)
        {
            string erroMess = null;
            return Exec(strCommandText, timeout, ref erroMess);
        }

        public static int Exec(string strCommandText, int timeOut, ref string ErroMess)
        {
            int num2;
            SqlConnection connection = GetConnection();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(strCommandText, connection);
                if (timeOut < 0)
                {
                    command.CommandTimeout = timeOut;
                }
                int num = command.ExecuteNonQuery();
                connection.Close();
                num2 = num;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"Exec\": " + exception.Message + "');</script>");
                ErroMess = exception.Message;
                num2 = -1;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            return num2;
        }

        public static int Exec(string strCommandText, string[] arrParameterName, object[] arrParameterValue)
        {
            return Exec(strCommandText, arrParameterName, arrParameterValue, 0);
        }

        public static int Exec(string strCommandText, string[] arrParameterName, object[] arrParameterValue, int timeout)
        {
            string erroMess = "";
            return Exec(strCommandText, 0, ref erroMess, arrParameterName, arrParameterValue);
        }

        public static int Exec(string strCommandText, int timeout, ref string ErroMess, string[] arrParameterName, object[] arrParameterValue)
        {
            try
            {
                Conn = new SqlConnection();
                Conn.ConnectionString = GetConnectionString();
                Conn.Open();
                SqlCommand command = new SqlCommand(strCommandText, Conn);
                if (timeout < 0)
                {
                    command.CommandTimeout = timeout;
                }
                Cmd.Parameters.Clear();
                for (int i = 0; i < arrParameterName.Length; i++)
                {
                    Cmd.Parameters.Add(arrParameterName[i], arrParameterValue[i]);
                }
                int num2 = command.ExecuteNonQuery();
                Conn.Close();
                return num2;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"Exec\"" + exception.Message + "');</script>");
                ErroMess = exception.Message;
                return -1;
            }
        }

        public static bool ExecSQL(string strCommandText)
        {
            string erroMess = null;
            return ExecSQL(strCommandText, ref erroMess);
        }

        public static bool ExecSQL(string strCommandText, int timeOut)
        {
            string erroMess = null;
            return (Exec(strCommandText, timeOut, ref erroMess) >= 0);
        }

        public static bool ExecSQL(string strCommandText, ref string ErroMess)
        {
            return (Exec(strCommandText, 0, ref ErroMess) >= 0);
        }

        public static bool ExecSQL(string strCommandText, string[] arrParameterName, object[] arrParameterValue)
        {
            string erroMess = "";
            return (Exec(strCommandText, 0, ref erroMess, arrParameterName, arrParameterValue) >= 1);
        }

        public static bool ExecSQL(string strCommandText, string[] arrParameterName, object[] arrParameterValue, int timeOut)
        {
            string erroMess = "";
            return (Exec(strCommandText, timeOut, ref erroMess, arrParameterName, arrParameterValue) >= 1);
        }

        public static byte[] GetByte(string sqlSelect)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                Conn = new SqlConnection(GetConnectionString());
                Conn.Open();
                command.CommandType = CommandType.Text;
                byte[] buffer = null;
                buffer = (byte[]) Cmd.ExecuteScalar();
                Conn.Close();
                return buffer;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"GetByte\"" + exception.Message + "');</script>");
                return null;
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = GetConnectionString() + "Min Pool Size=5;Max Pool Size=60;Connect Timeout=2;";
                connection.Open();
            }
            catch (Exception)
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                connection.ConnectionString = GetConnectionString() + "Connect Timeout=45;";
                connection.Open();
            }
            return connection;
        }

        public static string GetConnectionString()
        {
            try
            {
                if (WebPage == null)
                {
                    return "";
                }
                string path = WebPage.Server.MapPath("~/App_Data/ServerConfig.txt");
                if (!File.Exists(path))
                {
                    return null;
                }
                string[] strArray = File.ReadAllLines(path);
                if ((strArray == null) || (strArray.Length == 0))
                {
                    return null;
                }
                if (strArray.Length < 2)
                {
                    return null;
                }
                string str2 = strArray[0];
                string str3 = strArray[1];
                string str4 = "";
                if (strArray.Length > 2)
                {
                    str4 = strArray[2];
                }
                string str5 = "";
                string str6 = "";
                if (strArray.Length > 3)
                {
                    str5 = strArray[3];
                    str6 = "Data Source=" + str2 + ";Initial Catalog=" + str3 + ";User ID=" + str4 + "; Password=" + str5 + ";";
                }
                else
                {
                    str6 = "Data Source=" + str2 + ";Initial Catalog=" + str3 + ";Integrated Security=True;";
                }
                if (oldConnectionString == null)
                {
                    oldConnectionString = str6;
                }
                return str6;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"GetConnectionString\"" + exception.Message + "');</script>");
                return "";
            }
        }

        public static DataSet GetDataSet(string strSelect)
        {
            try
            {
                DataSet dataSet = new DataSet();
                new SqlDataAdapter(strSelect, GetConnectionString()).Fill(dataSet);
                return dataSet;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"GetDataSet\" " + exception.Message + "');</script>");
                return null;
            }
        }

        public static DataTable GetTable(string strSelect)
        {
            string erroMess = null;
            return GetTable(strSelect, null, ref erroMess);
        }

        public static DataTable GetTable(string strSelect, ref string ErroMess)
        {
            return GetTable(strSelect, null, ref ErroMess);
        }

        public static DataTable GetTable(string strSelect, string TableName)
        {
            string erroMess = null;
            return GetTable(strSelect, TableName, ref erroMess);
        }

        public static DataTable GetTable(string strSelect, string TableName, ref string ErroMess)
        {
            try
            {
                DataTable dataTable = new DataTable();
                new SqlDataAdapter(strSelect, GetConnectionString()).Fill(dataTable);
                if ((TableName != null) && (TableName != ""))
                {
                    dataTable.TableName = TableName;
                }
                return dataTable;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"GetTable\": " + exception.Message + "');</script>");
                ErroMess = exception.ToString();
                return null;
            }
        }

        protected static void Init()
        {
            try
            {
                if ((Conn != null) && (Conn.State == ConnectionState.Open))
                {
                    Conn.Close();
                }
                Conn = new SqlConnection();
                Cmd = new SqlCommand();
                Da = new SqlDataAdapter();
                Cmd.Connection = Conn;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"Init\": " + exception.Message + "');</script>");
            }
        }

        public static bool IsConnect()
        {
            return NewConnect();
        }

        public static bool NewConnect()
        {
            string connectionString = GetConnectionString();
            Init();
            Conn.ConnectionString = connectionString;
            oldConnectionString = connectionString;
            try
            {
                return true;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"NewConnect\": " + exception.Message + "');</script>");
                return false;
            }
        }

        public static void NewConnect(string sSer, string sDataBaseName, string sLoginName, string sLoginPass)
        {
            try
            {
                if (Conn == null)
                {
                    Init();
                }
                ServerName = sSer.Trim();
                Databasename = sDataBaseName.Trim();
                LoginName = sLoginName.Trim();
                LoginPassword = sLoginPass;
                Conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Databasename + ";User ID=" + LoginName + "; Password=" + LoginPassword + ";Connect Timeout=1";
                if (LoginName == "")
                {
                    Conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Databasename + ";Integrated Security=True;Connect Timeout=1";
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"NewConnect\": " + exception.Message + "');</script>");
            }
        }

        public static void RollBack()
        {
        }

        public static string GetSystemStringDate()
        {
            try
            {
                DataTable table = GetTable("SELECT GETDATE()");
                if (table != null)
                {
                    return DateTime.Parse(table.Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"s_SystemDate\": " + exception.Message + "');</script>");
                return "";
            }
        }

        public static string GetSaveValue(string sValue, string sValueType)
        {
            try
            {
                if (((sValue == null) || (sValue.Trim() == "")) || (sValue.ToUpper() == "NULL"))
                {
                    return "NULL";
                }
                if (((((sValueType.IndexOf("int") != -1) || (sValueType.IndexOf("num") != -1)) || ((sValueType.IndexOf("double") != -1) || (sValueType.IndexOf("float") != -1))) || (sValueType.IndexOf("deci") != -1)) || (sValueType.IndexOf("bit") != -1))
                {
                    return sValue;
                }
                if (sValueType.IndexOf("Date") != -1)
                {
                    return ("'" + sValue + "'");
                }
                return ("N'" + sValue + "'");
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('Error at function \"sGetSaveValue\": " + exception.Message + "');</script>");
                return "";
            }
        }
        #region from database
        public static String ConnectionString = SQLConnectWeb.GetConnectionString();

        public static SqlConnection GetConnections()
        {
            return new SqlConnection(ConnectionString);
        }
        public static DataTable Fill(DataTable table, String sql, params Object[] parameters)
        {
            SqlCommand command = SQLConnectWeb.CreateCommand(sql, parameters);
            new SqlDataAdapter(command).Fill(table);
            command.Connection.Close();

            return table;
        }

        public static SqlCommand CreateCommand(String sql, params Object[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, SQLConnectWeb.GetConnections());

            for (int i = 0; i < parameters.Length; i += 2)
            {
                command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
            }
            return command;
        }
        public static DataTable GetTableParmams(String sql, params Object[] parameters)
        {
            return SQLConnectWeb.Fill(new DataTable(), sql, parameters);
        }
        public static int ExecuteNonQuery(String sql, params Object[] parameters)
        {
            SqlCommand command = SQLConnectWeb.CreateCommand(sql, parameters);

            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();

            return rows;
        }

        public static object ExecuteScalar(String sql, params Object[] parameters)
        {
            SqlCommand command = SQLConnectWeb.CreateCommand(sql, parameters);

            command.Connection.Open();
            object value = command.ExecuteScalar();
            command.Connection.Close();

            return value;
        }

        #endregion
    }
}

