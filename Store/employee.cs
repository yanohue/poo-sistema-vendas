using System;
using Newtonsoft.Json;
using ConsoleTables;

namespace Store
{
    public class Employee : Person,IDataControl
    {   
        public int ID {get; set;}
        public string Role {get; set;}

        public Employee(int id, string name, string cpf, string role) :base(name,cpf)
        {
            ID = id;
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

                Employee newEmployee = new Employee(store.employees.Count + 1, employeeName, employeeCPF, employeeRole);
                store.employees.Add(newEmployee);

                JsonFileUtils.writeToJson(store.employees, "json/employees.json");
            }
            catch(Exception e)
            {
                throw new ArgumentException($"[Error] Collect employee data: {e}");
            }

        }

        public static void listData(Store store)
        {
            Console.WriteLine("== FUNCIONÁRIOS DISPONÍVEIS ==");
            var table = new ConsoleTable("ID","Nome","CPF","Cargo"); 
            store.employees.ForEach(employee => {
                table.AddRow(employee.ID, employee.Name, employee.CPF, employee.Role);
            });
            table.Write();
        }

        public static Employee findByID(Store store)
        {
            Console.Clear();

            Employee.listData(store);
            Console.WriteLine("Selecione funcionário pela ID: ");
            int.TryParse(Console.ReadLine(), out int employeeID);
            Employee matchedEmployee = store.employees.Find(e => e.ID == employeeID);

            return matchedEmployee;
        }
    }
}