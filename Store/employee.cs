using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class Employee : Person
    {   
        public string Role {get; set;}

        public Employee(string name, string cpf, string role) :base(name,cpf)
        {
            Name = name;
            CPF = cpf;
            Role = role;
        }

        public static void collectData(Store store)
        {   
            try
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Funcionário:");

                Console.Write("Nome: ");
                string employeeName = store.NullString(Console.ReadLine());

                Console.Write("CPF: ");
                string employeeCPF = store.NullString(Console.ReadLine());

                Console.Write("Função: ");
                string employeeRole = store.NullString(Console.ReadLine());

                Employee newEmployee = new Employee(employeeName, employeeCPF, employeeRole);
                store.employees.Add(newEmployee);

                Employee.saveData(store);
            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect employee data: {e}");
            }

        }

        public static new void saveData(Store store)
        {
            File.WriteAllText("json/employees.json", JsonConvert.SerializeObject(store.employees));
        }

        public static void listData(Store store)
        {
            var table = new ConsoleTable("Nome","CPF","Cargo"); 
            Console.Clear();
            store.employees.ForEach(employee => {
                table.AddRow(employee.Name, employee.CPF, employee.Role);
            });
            table.Write();
            Console.ReadLine();
        }

    }
}