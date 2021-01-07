using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LinQ1.task
{
    class TaskJan2
    {
        public string connectionString;
        public TaskJan2()
        {
            connectionString = "Data Source=SQL-TRAINERS;Initial Catalog=spali;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        }

        //Department table
        public IList<Department> GetDeptDetails()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = "select * from Department ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                        ad.Fill(dataTable);
                    }
                }
            }
            IList<Department> department = new List<Department>();
            foreach (DataRow row in dataTable.Rows)
            {
                var department1 = new Department()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    Loc =row["salary"].ToString()
                };
                department.Add(department1);
            }
            return department;
        }

        // Employee table
        public IList<Employee34> GetEmpDetails()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = "select * from Employee34 ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(command))
                    {
                        ad.Fill(dataTable);
                    }
                }
            }
            IList<Employee34> employee34 = new List<Employee34>();
            foreach (DataRow row in dataTable.Rows)
            {
                var employee3 = new Employee34()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    EmpName = row["EmpName"].ToString(),
                    Salary = decimal.Parse(row["salary"].ToString()),
                    DeptId=int.Parse(row["DeptId"].ToString())
                };
                employee34.Add(employee3);
            }
            return employee34;
        }
    }
}
