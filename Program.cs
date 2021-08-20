using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            // employees = PeopleFetcher.GetEmployees();
            employees = PeopleFetcher.GetFromApi();

            Util.MakeCSV(employees);
            Util.MakeBadges(employees);
        }
    }
}