using System;
using System.Linq;

namespace Person
{
    public class Persona
    {
        public Persona(string nombre, string id)
        {
            this.Nombre = nombre;
            this.Id = id;
        }
        private string id;
        public string Id { 
            get{
                return this.id;
                }
        set{
        
            string Ci = numero(value);
            if (validarFormatoCI(Ci))
            {
                this.id = value;
            }
            else{
                this.id = "";
            }
        }
        }

        public string Nombre { get; set; } 

        public string numero(string ci)
        {
            string nueva= ci.Replace(".","").Replace("-","");
            return nueva;
        }
        public void IntroduceYourself()
        {
            Console.WriteLine("Se llama: "+this.Nombre+", y su cedula es: "+this.Id+".");
        
        }
        public bool validarFormatoCI(string ci)
        {

            long verificadorFormato;

            //Validar largo
            if (ci.Length == 8 && long.TryParse(ci, out verificadorFormato))
            {
                var vectorStrCI = ci.ToCharArray();
                var vectorCI = vectorStrCI.Select(c => int.Parse(c.ToString())).ToArray();
                var vectorReferencia = "2987634".ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

                var verificadorIngresado = vectorCI[7];

                //Calcular número verificador
                int numeroVerificadorRaw = 0;

                for (int i = 0; i < vectorReferencia.Length; i++)
                {
                    numeroVerificadorRaw = numeroVerificadorRaw + (vectorCI[i] * vectorReferencia[i]);
                }

                int verificadorCalculado = 10 - (numeroVerificadorRaw % 10);

                if(verificadorCalculado != verificadorIngresado)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Persona john = new Persona("John Doe", "1.234.567-8");
            Persona jane = new Persona("Jane Doe", "4.870.499-7");
            Persona Adrian = new Persona("Adrian Tesore","4.870.499-7");
            john.IntroduceYourself();
            jane.IntroduceYourself();
            Adrian.IntroduceYourself();

        }
    }
}