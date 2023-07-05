using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi9_Q1
{
    public  class Function
    {
        public static List<Employee> ReadFile(string filename)
        {
            List<Employee> list = new List<Employee>();
            try
            {
                StreamReader reader = new StreamReader(filename);
                string line;
                while((line= reader.ReadLine())!= null)
                {
                    try
                    {
                        string[] arr = line.Split(';');
                        Employee e1 = new Employee();
                        e1.Id = arr[0];
                        e1.Name = arr[1];
                        e1.Dob = DateTime.Parse(arr[2]);
                        e1.Salary = int.Parse(arr[3]);
                        list.Add(e1);
                    }catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                reader.Close();
            }
            catch (FileNotFoundException ex)
            { 
             MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static List<Employee> Remove(List<Employee> list, string id)
        {
            Employee e1 = list.FirstOrDefault(x => x.Id == id);
            list.Remove(e1);
            return list;

        }

        public static void WriteToFile(List<Employee> e1, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);   
            foreach(Employee item in e1)
            {
                writer.WriteLine($"{item.Id};{item.Name};{item.Dob.ToString("dd-MM-yyyy")};{item.Salary}");
            }
            writer.Close(); 
        }
    }
}
