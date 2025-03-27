using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Employee_Management_System.Models;

namespace EmployeeManagement.Models
{
    public class EmployeeDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // Get all employees
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = (int)rdr["EmployeeID"],
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Department = rdr["Department"].ToString(),
                        Salary = (decimal)rdr["Salary"]
                    };

                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }

        // Add new employee
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees VALUES (@FirstName, @LastName, @Email, @Department, @Salary)", con);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get employee by ID
        public Employee GetEmployeeByID(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", con);
                cmd.Parameters.AddWithValue("@EmployeeID", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    employee.EmployeeID = (int)rdr["EmployeeID"];
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Email = rdr["Email"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = (decimal)rdr["Salary"];
                }
            }
            return employee;
        }

        // Update employee
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE Employees SET 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    Department = @Department, 
                    Salary = @Salary 
                    WHERE EmployeeID = @EmployeeID", con);

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete employee
        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", con);
                cmd.Parameters.AddWithValue("@EmployeeID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
