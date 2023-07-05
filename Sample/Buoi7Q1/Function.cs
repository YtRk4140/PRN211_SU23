using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi7Q1
{
    public class Function
    {
        public static List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            string sql = @"Select Employee.* , Department.Name as Name1
                            from Employee join Department on Employee.Department = Department.Id";
            DataTable dt = DAO.GetDataBySql(sql);
            foreach (DataRow item in dt.Rows)
            {
                Employee e1 = new Employee();
                e1.Id = int.Parse(item["Id"].ToString());
                e1.Name = item["Name"].ToString();
                e1.Dob = DateTime.Parse(item["Dob"].ToString());
                e1.Sex = item["Sex"].ToString();
                e1.Position = item["Position"].ToString();
                e1.Department = int.Parse(item["Department"].ToString());
                e1.DepartmentName = item["Name1"].ToString();
                list.Add(e1);
            }
            return list;
        }

        public static List<Employee> Search( string name, string sex, string position)
        {
            List<Employee> list = new List<Employee>();
            string sql = @"Select Employee.* , Department.Name as Name1
                            from Employee ,Department
                            where Employee.Department= Department.Id";

            if(name != string.Empty)
            {
                sql = sql + " and Employee.Name like '%" + name+"%'";
            }
            if(sex != "")
            {
                sql += " and Employee.Sex='" + sex + "'"; 
            }
            if(position != "All position")
            {
                sql += " and Employee.Position='" + position + "'";
            }

            DataTable dt = DAO.GetDataBySql(sql);
            foreach (DataRow item in dt.Rows)
            {
                Employee e1 = new Employee();
                e1.Id = int.Parse(item["Id"].ToString());
                e1.Name = item["Name"].ToString();
                e1.Dob = DateTime.Parse(item["Dob"].ToString());
                e1.Sex = item["Sex"].ToString();
                e1.Position = item["Position"].ToString();
                e1.Department = int.Parse(item["Department"].ToString());
                e1.DepartmentName = item["Name1"].ToString();
                list.Add(e1);
            }
            return list;
        }
    }
}
