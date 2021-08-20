using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
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
                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine();
                // create new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                // add currentEmployee
                employees.Add(currentEmployee);
            }
            return employees;
        }
        public static List<Employee> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                foreach (JToken token in json.SelectToken("results"))
                {
                    // parse JSON data
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first").ToString(),
                        token.SelectToken("name.last").ToString(),
                        Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                        token.SelectToken("picture.large").ToString()
                    );
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}