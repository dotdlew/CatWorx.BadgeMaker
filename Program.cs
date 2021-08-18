using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static List<Employee> GetEmployees()
        {
            // return a List of Employee
            List<Employee> employees = new List<Employee>();
            // collect user values until the value is an empty string
            while (true)
            {
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                // Get a name from the console and assign it to a variable
                string input = Console.ReadLine();
                // break if the user hits ENTER without typing a name
                if (input == "")
                {
                    break;
                }
                // create new Employee instance
                Employee currentEmployee = new Employee(input, "Lewis");
                // add currentEmployee
                employees.Add(currentEmployee);
            }
            return employees;
        }

        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                // each item in employees is now an Employee instance
                Console.WriteLine(employees[i].GetName());
            }
        }
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}