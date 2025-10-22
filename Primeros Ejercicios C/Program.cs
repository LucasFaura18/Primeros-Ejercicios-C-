using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primeros_Ejercicios_C
{
    // Clase Cliente Ejercicio 10
    class Cliente
    {
        private string nombre;
        private double cantidadTotal;

        public Cliente(string nombre)
        {
            this.nombre = nombre;
            this.cantidadTotal = 0;
        }

        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                cantidadTotal += cantidad;
            }
        }

        public void Sacar(double cantidad)
        {
            if (cantidad > 0 && cantidad <= cantidadTotal)
            {
                cantidadTotal -= cantidad;
            }
            else
            {
                Console.WriteLine($"{nombre}: No se puede sacar esa cantidad.");
            }
        }

        public double GetCantidadTotal()
        {
            return cantidadTotal;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Cliente: {nombre} | Saldo: {cantidadTotal} $");
        }
    }

    // Clase Banco Ejercicio 10
    class Banco
    {
        private Cliente cliente1;
        private Cliente cliente2;
        private Cliente cliente3;

        public Banco()
        {
            cliente1 = new Cliente("Ana");
            cliente2 = new Cliente("Luis");
            cliente3 = new Cliente("Marta");
        }

        public void Operar()
        {
            cliente1.Ingresar(1000);
            cliente2.Ingresar(500);
            cliente3.Ingresar(1200);
        }

        public void ObtenerEstado()
        {
            double totalBanco = cliente1.GetCantidadTotal() + cliente2.GetCantidadTotal() + cliente3.GetCantidadTotal();

            Console.WriteLine($"\nDinero total en el banco: {totalBanco} $\n");

            cliente1.MostrarInformacion();
            cliente2.MostrarInformacion();
            cliente3.MostrarInformacion();
        }
    }

    internal class Program
    {
        // Funciones usadas en los ejercicios
        static long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        static bool EsPrimo(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static double PotenciaIte(double baseNum, int exponente)
        {
            double resultado = 1;
            for (int i = 1; i <= exponente; i++)
            {
                resultado *= baseNum;
            }
            return resultado;
        }

        static double PotenciaRec(double baseNum, int exponente)
        {
            if (exponente == 0)
                return 1;
            else
                return baseNum * PotenciaRec(baseNum, exponente - 1);
        }

        static bool Login(string usuario, string contraseña)
        {
            return usuario == "usuario2DAM" && contraseña == "pass2DAM";
        }

        static bool EsMultiplo(int n1, int n2)
        {
            if (n2 == 0)
                return false;

            return n1 % n2 == 0;
        }

        static int SumarDigitos(int n)
        {
            int suma = 0;
            while (n > 0)
            {
                suma += n % 10;
                n /= 10;
            }
            return suma;
        }

        static int PosicionMenor(int[] array)
        {
            int posMenor = 0;
            int valorMenor = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < valorMenor)
                {
                    valorMenor = array[i];
                    posMenor = i;
                }
            }
            return posMenor;
        }

        static void Main(string[] args)
        {
            // Ejercicio 1
            Console.WriteLine("\n===== Ejercicio 1 =====");
            Console.WriteLine("Introduce el tamaño del array");
            int tamañoArray = int.Parse(Console.ReadLine());

            int[] numerosE1 = new int[tamañoArray];
            for (int i = 0; i < tamañoArray; i++)
            {
                Console.WriteLine($"Introduce el número {i + 1}");
                numerosE1[i] = int.Parse(Console.ReadLine());
            }

            int sumaE1 = 0;
            for (int i = 0; i < tamañoArray; i++)
            {
                sumaE1 += numerosE1[i];
            }

            Console.WriteLine("La suma de los números introducidos es: " + sumaE1);
            Console.WriteLine("La media de los números introducidos es: " + (sumaE1 / (double)tamañoArray));

            // Ejercicio 2
            Console.WriteLine("\n===== Ejercicio 2 =====");
            Console.WriteLine("Escribe una frase: ");
            string fraseE2 = Console.ReadLine();
            int espaciosE2 = 0;

            foreach (char c in fraseE2)
            {
                if (c == ' ') espaciosE2++;
            }
            Console.WriteLine("El número de espacios en blanco es: " + espaciosE2);

            // Ejercicio 3
            Console.WriteLine("\n===== Ejercicio 3 =====");
            Console.Write("Introduce un número: ");
            int numeroE3 = int.Parse(Console.ReadLine());
            long resultadoE3 = Factorial(numeroE3);
            Console.WriteLine($"El factorial de {numeroE3} es: {resultadoE3}");

            // Ejercicio 4
            Console.WriteLine("\n===== Ejercicio 4 =====");
            Console.Write("Introduce un número: ");
            int numeroE4 = int.Parse(Console.ReadLine());

            if (EsPrimo(numeroE4))
                Console.WriteLine($"{numeroE4} es un número primo.");
            else
                Console.WriteLine($"{numeroE4} NO es un número primo.");

            // Ejercicio 5
            Console.WriteLine("\n===== Ejercicio 5 =====");
            Console.Write("Introduce la base: ");
            double baseE5 = double.Parse(Console.ReadLine());
            Console.Write("Introduce el exponente: ");
            int exponenteE5 = int.Parse(Console.ReadLine());

            double resultadoIteE5 = PotenciaIte(baseE5, exponenteE5);
            double resultadoRecE5 = PotenciaRec(baseE5, exponenteE5);

            Console.WriteLine($"[Iterativo] {baseE5}^{exponenteE5} = {resultadoIteE5}");
            Console.WriteLine($"[Recursivo] {baseE5}^{exponenteE5} = {resultadoRecE5}");

            // Ejercicio 6
            Console.WriteLine("\n===== Ejercicio 6 =====");
            const int maxIntentos = 3;
            int intentos = 0;
            bool accesoConcedido = false;

            while (intentos < maxIntentos && !accesoConcedido)
            {
                Console.Write("Introduce el nombre de usuario: ");
                string usuario = Console.ReadLine();
                Console.Write("Introduce la contraseña: ");
                string contraseña = Console.ReadLine();

                if (Login(usuario, contraseña))
                {
                    accesoConcedido = true;
                    Console.WriteLine("Acceso permitido");
                }
                else
                {
                    intentos++;
                    Console.WriteLine("Usuario o contraseña incorrectos");
                    if (intentos == maxIntentos)
                        Console.WriteLine("Acceso Denegado");

                    if (intentos < maxIntentos)
                        Console.WriteLine($"Te quedan {maxIntentos - intentos} intento(s).");
                }
            }

            // Ejercicio 7
            Console.WriteLine("\n===== Ejercicio 7 =====");
            Console.Write("Introduce el primer número: ");
            int num1E7 = int.Parse(Console.ReadLine());
            Console.Write("Introduce el segundo número: ");
            int num2E7 = int.Parse(Console.ReadLine());

            if (EsMultiplo(num1E7, num2E7))
                Console.WriteLine($"{num1E7} es múltiplo de {num2E7}");
            else if (EsMultiplo(num2E7, num1E7))
                Console.WriteLine($"{num2E7} es múltiplo de {num1E7}");
            else
                Console.WriteLine("Ninguno de los dos números es múltiplo del otro.");

            // Ejercicio 8
            Console.WriteLine("\n===== Ejercicio 8 =====");
            Console.Write("Introduce un número: ");
            int numeroE8 = int.Parse(Console.ReadLine());
            int sumaE8 = SumarDigitos(numeroE8);
            Console.WriteLine($"La suma de los dígitos de {numeroE8} es: {sumaE8}");

            // Ejercicio 9
            Console.WriteLine("\n===== Ejercicio 9 =====");
            int[] numerosE9 = { 12, 5, 8, 3, 19, 7 };
            int posicionMenorE9 = PosicionMenor(numerosE9);
            Console.WriteLine($"El número menor del array es {numerosE9[posicionMenorE9]} y está en la posición {posicionMenorE9}.");

            // Ejercicio 10
            Console.WriteLine("\n===== Ejercicio 10 =====");
            Banco banco = new Banco();
            banco.Operar();
            banco.ObtenerEstado();
        }
    }
}
