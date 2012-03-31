namespace DK2C.GeneralDOOjects
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed class ConnectSetting : ApplicationSettingsBase
    {
        private static ConnectSetting defaultInstance = ((ConnectSetting)SettingsBase.Synchronized(new ConnectSetting()));

        [DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
        public string ArrDatabaseName
        {
            get
            {
                return (string)this["ArrDatabaseName"];
            }
            set
            {
                this["ArrDatabaseName"] = value;
            }
        }

        [DebuggerNonUserCode, UserScopedSetting, DefaultSettingValue("")]
        public string ArrServerName
        {
            get
            {
                return (string)this["ArrServerName"];
            }
            set
            {
                this["ArrServerName"] = value;
            }
        }

        [DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
        public string Databasename
        {
            get
            {
                return (string)this["Databasename"];
            }
            set
            {
                this["Databasename"] = value;
            }
        }

        public static ConnectSetting Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [DefaultSettingValue(""), DebuggerNonUserCode, UserScopedSetting]
        public string LoginName
        {
            get
            {
                return (string)this["LoginName"];
            }
            set
            {
                this["LoginName"] = value;
            }
        }

        [DefaultSettingValue(""), DebuggerNonUserCode, UserScopedSetting]
        public string LoginPassword
        {
            get
            {
                return (string)this["LoginPassword"];
            }
            set
            {
                this["LoginPassword"] = value;
            }
        }

       
        [DefaultSettingValue(""), DebuggerNonUserCode, UserScopedSetting]
        public string ServerName
        {
            get
            {
                return (string)this["ServerName"];
            }
            set
            {
                this["ServerName"] = value;
            }
        }
        [DefaultSettingValue(""), DebuggerNonUserCode, UserScopedSetting]
        public string PrefixNameSpace
        {
            get
            {
                return (string)this["PrefixNameSpace"];
            }
            set
            {
                this["PrefixNameSpace"] = value;
            }
        }
        [DefaultSettingValue(""), DebuggerNonUserCode, UserScopedSetting]
        public string SelectedPath
        {
            get
            {
                return (string)this["SelectedPath"];
            }
            set
            {
                this["SelectedPath"] = value;
            }
        }
    }
}

