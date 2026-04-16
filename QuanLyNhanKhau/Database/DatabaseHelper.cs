using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanKhau.Database
{
    public static class DatabaseHelper
    {
        private static string connectionString;

        static DatabaseHelper()
        {
            connectionString = GetWorkingConnectionString();
            
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra lại.");
            }
        }

        private static string GetWorkingConnectionString()
        {
            foreach (ConnectionStringSettings connSetting in ConfigurationManager.ConnectionStrings)
            {
                // Bỏ qua connection string mặc định của hệ thống ("LocalSqlServer" v.v.)
                if (connSetting.Name == "LocalSqlServer" || string.IsNullOrEmpty(connSetting.ConnectionString))
                    continue;

                string currentString = connSetting.ConnectionString;

                // Thử kết nối với một timeout ngắn (ví dụ: 2 giây) để không bị treo ứng dụng
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(currentString);
                builder.ConnectTimeout = 2;

                if (TestConnection(builder.ConnectionString))
                {
                    // Trả về chuỗi kết nối gốc (không bị đổi timeout) nếu kết nối thành công
                    return currentString; 
                }
            }
            return null;
        }

        private static bool TestConnection(string connStr)
        {
            try
            {
                using (var testConn = new SqlConnection(connStr))
                {
                    testConn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            return ExecuteQuery(sql, CommandType.Text, parameters);
        }

        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public static object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            return ExecuteScalar(sql, CommandType.Text, parameters);
        }
    }
}