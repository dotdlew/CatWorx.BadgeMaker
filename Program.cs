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
                Console.WriteLine("Enter first name: (leave empty to exit): ");
                // Get a name from the console and assign it to a variable
                string firstName = Console.ReadLine();
                // break if the user hits ENTER without typing a name
                if (firstName == "")
                {
                    break;
                }
                // get each value from user
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine());
                Console.Write("Enter Photo URL:");
                string photoUrl = Console.ReadLine();
                // create new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                // add currentEmployee
                employees.Add(currentEmployee);
            }
            return employees;
        }
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                // each item in employees is now an Employee instance
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
            }
        }
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}