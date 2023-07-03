using System;

namespace Store
{
    public abstract class Person : saveInterface
    {
        public string Name {get; protected set;}
        public string CPF {get; protected set;}

        protected Person(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
        }

        static void collectData(Store store)
        {

        }
        public void saveData(Store store)
        {
            
        }
    }
}