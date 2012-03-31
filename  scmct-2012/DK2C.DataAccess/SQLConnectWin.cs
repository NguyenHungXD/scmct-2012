namespace DK2C.DataAccess.Win
{
    using Microsoft.Win32;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public class SQLConnectWin
    {
        protected static SqlCommand Cmd = null;
        protected static SqlConnection Conn = null;
        private static int countBeginTran = 0;
        private static int countCommittran = 0;
        protected static SqlDataAdapter Da;
        public static string Databasename;
        public static bool IsConnectByMdfFile = false;
        public static bool isConnecting = false;
        protected static bool isRunTransac = false;
        public static string LoginName;
        public static string LoginPassword;
        public static string MdfFileName = null;
        public static string ProductName;
        public static string ServerName;
        protected static SqlTransaction Tran;

        public static bool BackupDB(bool IsDefaultFileName, ref string OutputFile)
        {
            OutputFile = "Kh\x00f4ng th\x00e0nh c\x00f4ng";
            if (IsDefaultFileName)
            {
                DataTable table = GetTable("select physical_name  from sys.database_files");
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return false;
                }
                string str = table.Rows[0][0].ToString();
                int length = str.LastIndexOf(@"\");
                if (length == -1)
                {
                    return false;
                }
                str = str.Substring(0, length);
                table = GetTable("select name from sysobjects where name like 'BackupDB' and type='p'");
                if (table == null)
                {
                    return false;
                }
                if (table.Rows.Count == 0)
                {
                    string strCommandText = " Create Procedure BackupDB(@Path as nvarchar(500))\r\n as\r\n begin\r\n declare @DBName as nvarchar(100),\r\n \t\t@FileName as nvarchar(100),\r\n \t\t@MediaName as nvarchar(500),\r\n \t\t@Disk as nvarchar(500),\r\n \t\t@Name as nvarchar(100),\r\n \t\t@Date as datetime,\r\n \t\t@Day as nvarchar(2),\r\n \t\t@Month as nvarchar(2) \r\n \t\tset @Date=(select getdate())\r\n \t\tset @Day=convert(nvarchar(2),day(@Date))\r\n \t\tset @Month=convert(nvarchar(2),month(@Date))\r\n \t\tif(len(@Day)=1) set @Day='0'+@Day\r\n \t\tif(len(@Month)=1) set @Month='0'+@Month\r\n \t\tset @DBName=DB_Name()\r\n \t\tset @FileName=@DBName +convert(nvarchar(4),year(@Date))+ @Month+@day+'.bak'\r\n set @MediaName=replace(@Path,':\\','_')\r\n set @Disk=@Path +'\\'+ @FileName\r\n set @Name='Full Backup of '+@DBName\r\n \t\tBACKUP DATABASE @DBName\r\n \t\tTO DISK =@Disk\r\n \t\t   WITH FORMAT,\r\n \t\t\t  MEDIANAME = @MediaName,\r\n \t\t\t  NAME = @Name\r\n end\r\n ";
                    if (!ExecSQL(strCommandText))
                    {
                        return false;
                    }
                }
                bool flag2 = ExecSQL("EXEC BackupDB  '" + str + "'");
                if (flag2)
                {
                    OutputFile = str + @"\" + Databasename + d_SystemDate().ToString("yyyyMMdd") + ".bak";
                }
                return flag2;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string selectedPath = dialog.SelectedPath;
            DateTime time = d_SystemDate();
            string databasename = Databasename;
            string str5 = databasename + time.ToString("yyyyMMdd") + ".bak";
            string str6 = selectedPath.Replace(@":\", "_").Replace(@"\", "_");
            string str7 = selectedPath + @"\" + databasename;
            string str8 = "Full Backup of " + databasename;
            bool flag3 = ExecSQL("  BACKUP DATABASE " + databasename + "\r\n TO DISK ='" + str7 + "'\r\n    WITH FORMAT,\r\n \t  MEDIANAME = '" + str6 + "',\r\n \t  NAME = '" + str8 + "'");
            if (flag3)
            {
                OutputFile = selectedPath + @"\" + Databasename + d_SystemDate().ToString("yyyyMMdd") + ".bak";
            }
            return flag3;
        }

        public static bool BeginConnect()
        {
            if (Conn == null)
            {
                Init();
            }
            if (ServerName == null)
            {
                return false;
            }
            if ((Conn != null) && (Conn.State == ConnectionState.Open))
            {
                Conn.Close();
            }
            if (IsConnectByMdfFile)
            {
                Conn.ConnectionString = "Data Source=" + ServerName + ";AttachDbFilename=" + MdfFileName + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            }
            else
            {
                Conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Databasename + ";User ID=" + LoginName + "; Password=" + LoginPassword + ";Connect Timeout=1";
                if (LoginName == "")
                {
                    Conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Databasename + ";Integrated Security=True;Connect Timeout=1";
                }
            }
            try
            {
                Conn.Open();
                WriteKeys();
                Conn.Close();
                isConnecting = true;
                return true;
            }
            catch (Exception)
            {
                isConnecting = false;
                return false;
            }
        }

        public static void BeginTran()
        {
            countBeginTran++;
            if (!isRunTransac && IsConnect())
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                Tran = Conn.BeginTransaction();
                Cmd.Transaction = Tran;
                isRunTransac = true;
            }
        }

        public static void ClearInitSetting()
        {
            ConnectSetting.Default.ServerName = null;
            ConnectSetting.Default.Databasename = null;
            ConnectSetting.Default.LoginName = null;
            ConnectSetting.Default.LoginPassword = null;
            ConnectSetting.Default.Save();
        }

        public static void Commit()
        {
            countCommittran++;
            if ((countCommittran == countBeginTran) && isRunTransac)
            {
                try
                {
                    Tran.Commit();
                    countBeginTran = 0;
                    countCommittran = 0;
                }
                catch (Exception)
                {
                }
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                isRunTransac = false;
            }
        }

        public static bool ConnectByMdfFile(string mdffilename)
        {
            if (Conn == null)
            {
                Init();
            }
            string sSer = Dns.GetHostName() + @"\SQLEXPRESS";
            ServerName = sSer.Trim();
            return ConnectByMdfFile(sSer, mdffilename);
        }

        public static bool ConnectByMdfFile(string sSer, string mdffilename)
        {
            if (Conn == null)
            {
                Init();
            }
            ServerName = sSer.Trim();
            MdfFileName = mdffilename;
            IsConnectByMdfFile = true;
            WriteKeys();
            Conn.ConnectionString = Conn.ConnectionString = "Data Source=" + sSer + ";AttachDbFilename=" + mdffilename + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            try
            {
                Conn.Open();
                Conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DateTime d_SystemDate()
        {
            DataTable table = GetTable("SELECT GETDATE()");
            if (table == null)
            {
                return DateTime.Now;
            }
            return DateTime.Parse(table.Rows[0][0].ToString());
        }

        private static bool DeleteRegistry(string ins_keyName)
        {
            try
            {
                RegistryKey key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\" + ProductName);
                if (key2 != null)
                {
                    key2.DeleteValue(ins_keyName);
                }
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return false;
            }
        }

        public static int Exec(string strCommandText)
        {
            int num = -1;
            try
            {
                if (!IsConnect())
                {
                    return -1;
                }
                Cmd.CommandText = strCommandText;
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.Clear();
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                num = Cmd.ExecuteNonQuery();
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            if (!((Conn.State != ConnectionState.Open) || isRunTransac))
            {
                Conn.Close();
            }
            return num;
        }

        public static int Exec(string strCommandText, int timeout)
        {
            int num = -1;
            try
            {
                if (!IsConnect())
                {
                    return -1;
                }
                Cmd.CommandText = strCommandText;
                Cmd.CommandTimeout = timeout;
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.Clear();
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                num = Cmd.ExecuteNonQuery();
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
            }
            if (!((Conn.State != ConnectionState.Open) || isRunTransac))
            {
                Conn.Close();
            }
            return num;
        }

        public static int Exec(string strCommandText, string[] arrParameterName, object[] arrParameterValue)
        {
            int num = -1;
            try
            {
                if (!IsConnect())
                {
                    return -1;
                }
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                Cmd.CommandText = strCommandText;
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.Clear();
                for (int i = 0; i < arrParameterName.Length; i++)
                {
                    Cmd.Parameters.Add(arrParameterName[i], arrParameterValue[i]);
                }
                num = Cmd.ExecuteNonQuery();
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
            }
            if (!((Conn.State != ConnectionState.Open) || isRunTransac))
            {
                Conn.Close();
            }
            return num;
        }

        public static int Exec(string strCommandText, string[] arrParameterName, object[] arrParameterValue, int timeout)
        {
            int num = -1;
            try
            {
                if (!IsConnect())
                {
                    return -1;
                }
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                Cmd.CommandText = strCommandText;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandTimeout = timeout;
                Cmd.Parameters.Clear();
                for (int i = 0; i < arrParameterName.Length; i++)
                {
                    Cmd.Parameters.Add(arrParameterName[i], arrParameterValue[i]);
                }
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                num = Cmd.ExecuteNonQuery();
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
            }
            if (!((Conn.State != ConnectionState.Open) || isRunTransac))
            {
                Conn.Close();
            }
            return num;
        }

        public static bool ExecSQL(string strCommandText)
        {
            bool flag = false;
            try
            {
                if (!IsConnect())
                {
                    return false;
                }
                Cmd.CommandText = strCommandText;
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.Clear();
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                Cmd.ExecuteNonQuery();
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            if (!((Conn.State != ConnectionState.Open) || isRunTransac))
            {
                Conn.Close();
            }
            return flag;
        }

        public static bool ExecSQL(string strCommandText, int timeOut)
        {
            return (Exec(strCommandText, timeOut) >= 1);
        }

        public static bool ExecSQL(string strCommandText, string[] arrParameterName, object[] arrParameterValue)
        {
            return (Exec(strCommandText, arrParameterName, arrParameterValue) >= 1);
        }

        public static bool ExecSQL(string strCommandText, string[] arrParameterName, object[] arrParameterValue, int timeOut)
        {
            return (Exec(strCommandText, arrParameterName, arrParameterValue, timeOut) >= 1);
        }

        public static Bitmap getBitmap(string sqlSelect, string sFileFilter)
        {
            return getBitmap(sqlSelect, sFileFilter, false);
        }

        public static Bitmap getBitmap(string sqlSelect, string sFileFilter, bool IsFileName)
        {
            try
            {
                StreamReader reader = new StreamReader(sGetFileName_ImageField(sqlSelect, sFileFilter, IsFileName));
                BinaryReader reader2 = new BinaryReader(reader.BaseStream, Encoding.Default);
                Bitmap bitmap = (Bitmap) Image.FromStream(reader2.BaseStream);
                reader2.Close();
                reader2.Close();
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] GetByte(string sqlSelect)
        {
            if (!IsConnect())
            {
                return null;
            }
            byte[] buffer = null;
            try
            {
                if (!((Conn.State != ConnectionState.Closed) || isRunTransac))
                {
                    Conn.Open();
                }
                Cmd.CommandText = sqlSelect;
                buffer = (byte[]) Cmd.ExecuteScalar();
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                return null;
            }
            return buffer;
        }

        public static DataSet GetDataSet(string strSelect)
        {
            if (!IsConnect())
            {
                return null;
            }
            DataSet dataSet = new DataSet();
            try
            {
                strSelect = strSelect.Replace("= NULL", " IS NULL");
                strSelect = strSelect.Replace("=NULL", " IS NULL");
                Cmd.CommandText = strSelect;
                Da.SelectCommand = Cmd;
                Da.Fill(dataSet);
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                return null;
            }
            return dataSet;
        }

        public static Image getImage(string sqlSelect, string sFileFilter)
        {
            return getImage(sqlSelect, sFileFilter, false);
        }

        public static Image getImage(string sqlSelect, string sFileFilter, bool IsFileName)
        {
            try
            {
                StreamReader reader = new StreamReader(sGetFileName_ImageField(sqlSelect, sFileFilter, IsFileName));
                BinaryReader reader2 = new BinaryReader(reader.BaseStream, Encoding.Default);
                Image image = Image.FromStream(reader2.BaseStream);
                reader2.Close();
                return image;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetTable(string strSelect)
        {
            if (!IsConnect())
            {
                return null;
            }
            DataTable dataTable = new DataTable();
            try
            {
                Cmd.CommandText = strSelect;
                Da.SelectCommand = Cmd;
                Da.Fill(dataTable);
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                return null;
            }
            return dataTable;
        }

        public static DataTable GetTable(string strSelect, string TableName)
        {
            if (!IsConnect())
            {
                return null;
            }
            DataTable dataTable = new DataTable();
            try
            {
                Cmd.CommandText = strSelect;
                Da.SelectCommand = Cmd;
                Da.Fill(dataTable);
                dataTable.TableName = TableName;
                if (!((Conn.State != ConnectionState.Open) || isRunTransac))
                {
                    Conn.Close();
                }
            }
            catch (Exception)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                return null;
            }
            return dataTable;
        }

        protected static void Init()
        {
            Conn = new SqlConnection();
            Cmd = new SqlCommand();
            Da = new SqlDataAdapter();
            Cmd.Connection = Conn;
        }

        public static bool IsConnect()
        {
            if ((((Conn == null) || (Conn.ConnectionString == null)) || (Cmd == null)) || (Conn.ConnectionString == ""))
            {
                ReadKeys();
                if (((((ServerName == null) || (Databasename == null)) || ((LoginName == null) || (LoginPassword == null))) || (ServerName == "")) || (Databasename == ""))
                {
                    Init();
                    return NewConnect();
                }
                bool flag = BeginConnect();
                if (!flag)
                {
                    return NewConnect();
                }
                return flag;
            }
            return true;
        }

        public static bool NewConnect()
        {
            frmLoginServer server = new frmLoginServer();
            ReadKeys();
            if (ServerName != null)
            {
                server.txtServer.Text = ServerName;
            }
            if (Databasename != null)
            {
                server.txtDatabase.Text = Databasename;
            }
            if (LoginName != null)
            {
                server.txtLoginname.Text = LoginName;
            }
            if (LoginPassword != null)
            {
                server.txtPas.Text = LoginPassword;
            }
            server.ShowDialog();
            return frmLoginServer.isConnect;
        }

        public static void NewConnect(string sSer, string sDataBaseName, string sLoginName, string sLoginPass)
        {
            if (Conn == null)
            {
                Init();
            }
            ServerName = sSer.Trim();
            Databasename = sDataBaseName.Trim();
            LoginName = sLoginName.Trim();
            LoginPassword = sLoginPass;
            WriteKeys();
            Conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Databasename + ";User ID=" + LoginName + "; Password=" + LoginPassword + ";Connect Timeout=1";
            if (LoginName == "")
            {
                Conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Databasename + ";Integrated Security=True;Connect Timeout=1";
            }
        }

        protected static void ReadKeys()
        {
            if ((ServerName == null) || (ServerName == ""))
            {
                ServerName = ConnectSetting.Default.ServerName;
            }
            if ((Databasename == null) || (Databasename == ""))
            {
                Databasename = ConnectSetting.Default.Databasename;
            }
            if ((LoginName == null) || (LoginName == ""))
            {
                LoginName = ConnectSetting.Default.LoginName;
            }
            if ((LoginPassword == null) || (LoginPassword == ""))
            {
                LoginPassword = ConnectSetting.Default.LoginPassword;
            }
        }

        private static string ReadRegistry(string ins_keyName)
        {
            RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + ProductName);
            if (key2 == null)
            {
                return null;
            }
            try
            {
                return (string) key2.GetValue(ins_keyName.ToUpper());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return null;
            }
        }

        public static bool RestoreDB(string BackupFile, string DBName, string SavePath)
        {
            string str = DBName;
            string str2 = DBName + "_log";
            return RestoreDB(BackupFile, DBName, SavePath, str, str2);
        }

        public static bool RestoreDB(string BackupFile, string DBName, string SavePath, string LogicalName_mdf, string LogicalName_ldf)
        {
            return ExecSQL("RESTORE DATABASE " + DBName + "\r\nFROM DISK = '" + BackupFile + "'\r\nWITH  Move '" + LogicalName_mdf + "' To  '" + SavePath + @"\" + DBName + ".mdf',\r\n Move '" + LogicalName_ldf + "' To '" + SavePath + @"\" + DBName + "_log.ldf'\r\n");
        }

        public static void RollBack()
        {
            if (isRunTransac)
            {
                try
                {
                    Tran.Rollback();
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                    isRunTransac = false;
                    countBeginTran = 0;
                    countCommittran = 0;
                }
                catch (Exception)
                {
                }
            }
        }

        public static string s_SystemDate()
        {
            DataTable table = GetTable("SELECT GETDATE()");
            if (table != null)
            {
                return DateTime.Parse(table.Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string sGetFileName_ImageField(string sqlSelect, string sfileFilter)
        {
            return sGetFileName_ImageField(sqlSelect, sfileFilter, false);
        }

        public static string sGetFileName_ImageField(string sqlSelect, string sfileFilter, bool IsFileName)
        {
            byte[] @byte = GetByte(sqlSelect);
            if (@byte == null)
            {
                return null;
            }
            string path = "";
            if (!IsFileName)
            {
                path = Application.StartupPath + @"\hsOpenImageFile." + sfileFilter;
            }
            else
            {
                path = sfileFilter;
            }
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            FileStream stream = new FileStream(path, FileMode.CreateNew);
            stream.Write(@byte, 0, @byte.Length);
            stream.Close();
            return path;
        }

        public static void ViewSQLHelpInterface()
        {
            new frmExecSQL().ShowDialog();
        }

        protected static void WriteKeys()
        {
            ConnectSetting.Default.ServerName = ServerName;
            ConnectSetting.Default.Databasename = Databasename;
            ConnectSetting.Default.LoginName = LoginName;
            ConnectSetting.Default.LoginPassword = LoginPassword;
            ConnectSetting.Default.Save();
        }

        private static bool WriteRegistry(string ins_keyName, string ins_keyValue)
        {
            try
            {
                Registry.LocalMachine.CreateSubKey(@"SOFTWARE\" + ProductName).SetValue(ins_keyName.ToUpper(), ins_keyValue);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return false;
            }
        }
    }
}

