using System.Globalization;
using System.Linq;
using Course.Entities;

namespace Aulas
{
    class Aulas
    {
        static void Main(string[] args)
        {

            // Read file and create list of employees
            List<Employee> employees = new List<Employee>();
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        string email = line[1];
                        double salary = double.Parse(line[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("File error: " + e.Message);
            }

            // Alphabetically show employees email above given salary
            Console.WriteLine();
            Console.Write("Informe valor do salário para pesquisa: ");
            double empSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            var empEmails = employees.Where(e => e.Salary >= empSalary).OrderBy(e => e.Email).Select(e => e.Email);
            foreach (string email in empEmails)
            {
                Console.WriteLine(email);
            }

            // Show sum of salary of employees that start name start with letter 'M'
            Console.WriteLine();
            var salaries = employees.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Sum();
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + salaries);
        }
    }
}
