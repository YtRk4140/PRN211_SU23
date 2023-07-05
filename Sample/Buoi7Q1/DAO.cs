using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi7Q1
{
    public class DAO
    {
        /// <summary>
        /// ket noi voi database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connect = config.GetConnectionString("Test");
            return new SqlConnection(connect);
        }
        /// <summary>
        /// dung de tra ve du lieu dung cau lenh select
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            //   de truy suat dy lieu
            //SqlDataAdapter là một lớp đại diện cho một tập hợp các lệnh SQL và kết nối cơ sở dữ liệu. Nó được sử dụng để điền DataSet hoặc DataTable và cập nhật nguồn dữ liệu.
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        ///  thuc hien cau lenh insert , update, delete trong sql 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteBySql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            command.Connection.Open();
            // thuc hien cau truy van
            int count = command.ExecuteNonQuery();
            command.Connection.Close();
            return count;
        }
    }
}
