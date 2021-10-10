using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Common.DataAccess
{
    public static class DataAccessHelper
    {
        public enum Mode
        {
            Dev,
            Test,
            Live
        }
        public static string ConnectionString
        {
            get
            { return $"Data Source=;Integrated Security=true;"; }
        }

        public static Databases Database { get; set; }

        public static void Execute(string command, Databases db, SqlParameter[] parameters)
        {

        }

        public static List<T> ExecuteList<T>(string command, Databases db, SqlParameter[] parameters)
        {
            return null;
        }

        public static T ExecuteSingle<T>(string command, Databases db, SqlParameter[] parameters)
        {
            return null;
        }

        public static int ExecuteId<T>(string command, Databases db, SqlParameter[] parameters)
        {
            return 0;
        }
        
    }
}