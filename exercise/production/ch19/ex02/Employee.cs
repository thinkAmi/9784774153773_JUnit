using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch19.ex02
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public static List<Employee> Load(System.IO.StreamReader stream)
        {
            List<Employee> list = new List<Employee>();

            try
            {
                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();

                    string[] values = line.Split(',');
                    Employee employee = new Employee();
                    employee.FirstName = values[0];
                    employee.LastName = values[1];
                    employee.Email = values[2];

                    list.Add(employee);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                stream.Close();
            }

            return list;
        }
    }
}
