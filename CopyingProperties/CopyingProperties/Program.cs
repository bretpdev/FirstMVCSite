using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CopyingProperties
{
    public class Program
    {
        static List<Person> People = new List<Person>();
        static List<Company> Companies = new List<Company>();
        static List<Employee> Employees = new List<Employee>();

        public enum Sex
        {
            M,
            F,
            O
        }

        public enum JobType
        {
            Software,
            Groceries
        }

        public static void Main(string[] args)
        {
            LoadPerson();
            LoadCompany();
            CopyPeople();
            WriteOutPeople();

            ReadKey();
        }

        private static void LoadPerson()
        {
            People.Add(new Person("John", "Smith", Sex.M, 25, 74250, JobType.Software));
            People.Add(new Person("Jacob", "Johnson", Sex.M, 19, 26500, JobType.Groceries));
            People.Add(new Person("Erin", "Porter", Sex.F, 32, 48000, JobType.Software));
            People.Add(new Person("Paul", "Revere", Sex.M, 56, 110986, JobType.Groceries));
            People.Add(new Person("Jessica", "Johnson", Sex.F, 48, 164535, JobType.Groceries));
            People.Add(new Person("Jordan", "Allred", Sex.M, 27, 73238, JobType.Software));
            People.Add(new Person("Randy", "Butterfield", Sex.O, 45, 54893, JobType.Groceries));
            People.Add(new Person("Evan", "Kindred", Sex.M, 35, 64000, JobType.Groceries));
        }

        private static void LoadCompany()
        {
            Companies.Add(new Company("Google", "456 Main St", "Salt Lake City", "UT", "12345", JobType.Software));
            Companies.Add(new Company("Harmons", "1450 E 200 S", "Salt Lake City", "UT", "54321", JobType.Groceries));
        }

        private static void CopyPeople()
        {
            int g = 0;
            int s = 0;
            foreach (var person in People)
            {
                Employee e = new Employee();

                PropertyCopier<Person, Employee>.Copy(person, e);
                if (person.Job == JobType.Groceries)
                {
                    e.EmployeeNumber = ++g;
                    Company company = Companies.Where(p => p.Job == JobType.Groceries).SingleOrDefault();
                    company.Employees.Add(e);
                }
                else
                {
                    e.EmployeeNumber = ++s;
                    Company company = Companies.Where(p => p.Job == JobType.Software).SingleOrDefault();
                    company.Employees.Add(e);
                }
            }
        }

        private static void WriteOutPeople()
        {
            WriteLine("All People");
            foreach (Person p in People)
                WriteLine($"Name: {p.FirstName} {p.LastName}, Gender: {p.Gender}, Age: {p.Age}, Salary: ${p.Salary:0,00}");

            WriteLine("");

            WriteLine("Companies");
            foreach (var company in Companies)
                foreach (var employee in company.Employees)
                    WriteLine($"Company: {company.CompanyName}, Employee: {employee.EmployeeNumber}, {employee.FirstName} {employee.LastName}");
        }
    }
}