using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace App
{
    public class Caixa
    {
        public List<Cliente> clientes = new List<Cliente>();
        public void pagar()
        {   
            
        }
        public void carregarDados()
        {
            if(File.Exists("clientes.json"))
            {
                clientes = JsonSerializer.Deserialize<List<Cliente>>(File.ReadAllText("clientes.json"));
            }
        }
        public void salvarDados()
        {   
            File.WriteAllText("clientes.json", JsonSerializer.Serialize(clientes));
        }
    }
}