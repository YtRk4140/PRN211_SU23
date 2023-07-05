using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    public class Function
    {
        public static List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            string sql = @"select Employee.*, Department.Name as Name1 from Employee, Department 
                            where Employee.Department= Department.Id    ";
            DataTable dt = DAO.GetDataBySql(sql);
            foreach (DataRow item in dt.Rows)
            {
                Employee emp = new Employee();
                emp.Id = int.Parse(item["Id"].ToString());
                emp.Name = item["Name"].ToString();
                emp.Dob = DateTime.Parse(item["Dob"].ToString());
                emp.Sex = item["Sex"].ToString();
                emp.Position = item["Position"].ToString();
                emp.DerName = item["Name1"].ToString();
                list.Add(emp);
            }

            return list;
        }

        public static List<Employee> GetSearch(string text)
        {
            List<Employee> list = new List<Employee>();
            string sql = @"select Employee.*, Department.Name as Name1 from Employee, Department 
                            where Employee.Department= Department.Id   and Employee.Name like '%"+text+"%' ";
            DataTable dt = DAO.GetDataBySql(sql);
            foreach (DataRow item in dt.Rows)
            {
                Employee emp = new Employee();
                emp.Id = int.Parse(item["Id"].ToString());
                emp.Name = item["Name"].ToString();
                emp.Dob = DateTime.Parse(item["Dob"].ToString());
                emp.Sex = item["Sex"].ToString();
                emp.Position = item["Position"].ToString();
                emp.DerName = item["Name1"].ToString();
                list.Add(emp);
            }

            return list;
        }
        public static List<Department> GetDepartment()
        {
            List<Department> list = new List<Department>();
            string sql = @"select * from  Department ";
                            
            DataTable dt = DAO.GetDataBySql(sql);
            foreach (DataRow item in dt.Rows)
            {
                Department de = new Department();
                de.Id = int.Parse(item["Id"].ToString());
                de.Name = item["Name"].ToString();
                list.Add(de);
            }

            return list;
        }
        public static int Delete(int id)
        {
            string sql = "Delete from Employee where Id=@id" ;
            SqlParameter para1 = new SqlParameter("@id", SqlDbType.Int);
            para1.Value = id;
            int rowaffectec= DAO.ExecuteBySql(sql, para1);
            return rowaffectec;
        }

        
        public static int AddEmp(Employee e)
        {
            // gg search sql insert
            string sql = "insert into Employee values (@name, @dob, @sex, @position, @der )";
            SqlParameter para1 = new SqlParameter("@name", SqlDbType.VarChar);
            para1.Value = e.Name;

            SqlParameter para2= new SqlParameter("@dob", SqlDbType.Date);
            para2.Value = e.Dob;

            SqlParameter para3 = new SqlParameter("@sex", SqlDbType.VarChar);
            para3.Value = e.Sex;

            SqlParameter para4 = new SqlParameter("@position", SqlDbType.VarChar);
            para4.Value = e.Position;

            SqlParameter para5 = new SqlParameter("@der", SqlDbType.Int);
            para5.Value = e.DerID;

            int row = DAO.ExecuteBySql(sql, para1, para2, para3, para4, para5);
            return row;
        }

        public static int UpdateEmp(Employee e)
        {
            // gg search sql insert
            string sql = @" update Employee
                            Set Name= @name , Sex= @sex, Dob= @dob, Position= @position, Department= @der
                            where Id= @id
";
            SqlParameter para1 = new SqlParameter("@name", SqlDbType.VarChar);
            para1.Value = e.Name;

            SqlParameter para2 = new SqlParameter("@dob", SqlDbType.Date);
            para2.Value = e.Dob;

            SqlParameter para3 = new SqlParameter("@sex", SqlDbType.VarChar);
            para3.Value = e.Sex;

            SqlParameter para4 = new SqlParameter("@position", SqlDbType.VarChar);
            para4.Value = e.Position;

            SqlParameter para5 = new SqlParameter("@der", SqlDbType.Int);
            para5.Value = e.DerID;
            SqlParameter para6 = new SqlParameter("@id", SqlDbType.Int);
            para6.Value = e.Id;
            int row = DAO.ExecuteBySql(sql, para1, para2, para3, para4, para5,para6);
            return row;
        }
    }
}
