using System;
using System.Collections.Generic;


namespace FirstMVCSite.Models
{
    public static partial class DataAccessHelper
    {
        public class ModeNotSetException : Exception { public ModeNotSetException(string message) : base(message) { } }
        public class RegionNotSetException : Exception { public RegionNotSetException(string message) : base(message) { } }
        private static Region? currentRegion = null;
        public static bool RegionSet { get { return currentRegion.Value; } }
        public static Region CurrentRegion
        {
            get
            {
                if (!currentRegion.HasValue)
                    throw new RegionNotSetException("Data access region must be set before it can be used.");
                return currentRegion.Value;
            }
            set
            {
                currentRegion = value;
                //EnterpriseFileSystem.Invalidate();
            }
        }
        private static Mode? currentMode = null;
        public static bool ModeSet { get { return currentMode.HasValue; } }
        public static Mode CurrentMode
        {
            get
            {
                if (!currentMode.HasValue)
                    throw new ModeNotSetException("Data access mode must be set before it can be used.");
                return currentMode.Value;
            }
            set
            {
                currentMode = value;
            }
        }

        public static bool TestMode
        {
            get
            {
                return ((CurrentMode == Mode.Test) || (currentMode == Mode.Dev));
            }
        }
        public enum Region
        {
            None
        }
        public enum Mode
        {
            Live,
            Test,
            Dev,
            Local
        }

        public enum Database
        {
            Local = 0,
            Logs = 1
        }

        private class DatabaseInfo
        {
            public Dictionary<Mode, string> Servers = new Dictionary<Mode, string>();
            public string ConnectionString {get;set;}
            public DatabaseInfo(string connectionString, params object[] servers)
            {
                ConnectionString = connectionString;
                foreach (KeyValuePair<Mode, string> server in servers)
                    Servers.Add(server.Key, server.Value);
            }

            public string GetConnectionString(Mode mode)
            {
                return string.Format(ConnectionString, Servers[mode]);
            }

            public string GetConnectionString(Mode mode, string username, string password)
            {
                return string.Format(ConnectionString, Servers[mode], username, password);
            }
        }
        private static Dictionary<Database, DatabaseInfo> databases = new Dictionary<Database, DatabaseInfo>();
        static DataAccessHelper()
        {
            databases[Database.Local] = new DatabaseInfo("Data Source={0};Initial Catalog=;Integrated Security=SSPI;MultipleActiveREsultSets=True;Connection Timeout=100",
                Mode.Local, @"(localdb)");
        }

        public static string GetConnectionString(Database db)
        {
            return GetConnectionString(db, CurrentMode);
        }
        public static string GetConnectionString(Database db, Mode mode)
        {
            return databases[db].GetConnectionString(mode);
        }
        public static DataContext

    }
}
