using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promedios
{

    public class Alumno
    {
        public string NombreAlumno { get; set; }
        public string NumeroCuenta { get; set; }
    }

    public interface IAsignatura
    {
        int CalcularNotaFinal();
        int CalcularNotaFinal(int nota1, int nota2, int nota3);
        string MensajeNotaFinal(double notaFinal);
        void Imprimir();
    }

    public class Asignatura : Alumno, IAsignatura
    {
        public int N1 { get; set; }
        public int N2 { get; set; }
        public int N3 { get; set; }
        public string NombreAsignatura { get; set; }
        public string Horario { get; set; }
        public string NombreDocente { get; set; }

        public int CalcularNotaFinal()
        {
            return (N1 + N2 + N3) / 3;
        }

        public int CalcularNotaFinal(int nota1, int nota2, int nota3)
        {
            return (nota1 + nota2 + nota3) / 3;
        }

        public string MensajeNotaFinal(double notaFinal)
        {
            if (notaFinal >= 0 && notaFinal <= 59)
            {
                return "Reprobado";
            }
            else if (notaFinal >= 60 && notaFinal <= 79)
            {
                return "Bueno";
            }
            else if (notaFinal >= 80 && notaFinal <= 89)
            {
                return "Muy Bueno";
            }
            else if (notaFinal >= 90 && notaFinal <= 100)
            {
                return "Sobresaliente";
            }
            else
            {
                return "Nota inválida";
            }
        }

        public void Imprimir()
        {
            double notaFinal = CalcularNotaFinal();
            Console.WriteLine("Datos del alumno:");
            Console.WriteLine("Nombre: " + NombreAlumno);
            Console.WriteLine("Número de cuenta: " + NumeroCuenta);
            Console.WriteLine("Datos de la asignatura:");
            Console.WriteLine("Nombre: " + NombreAsignatura);
            Console.WriteLine("Horario: " + Horario);
            Console.WriteLine("Nombre del docente: " + NombreDocente);
            Console.WriteLine("Nota final: " + notaFinal);
            Console.WriteLine("Mensaje de la nota final: " + MensajeNotaFinal(notaFinal));

            double notaFinalParametros = CalcularNotaFinal(N1, N2, N3);
            Console.WriteLine("Nota final con parámetros: " + notaFinalParametros);
            Console.WriteLine("Mensaje de la nota final con parámetros: " + MensajeNotaFinal(notaFinalParametros));
            Console.ReadKey();
        }
    }

    class Program
    {
        public static bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        static void Main(string[] args)
        {
            try
            {
                Asignatura asignatura = new Asignatura();

                Console.WriteLine("Ingrese los datos del alumno:");
                Console.Write("Nombre del alumno: ");
                asignatura.NombreAlumno = Console.ReadLine();
                Console.Write("Número de cuenta: ");
                asignatura.NumeroCuenta = Console.ReadLine();

                Console.WriteLine("Ingrese los datos de la asignatura:");
                Console.Write("Nombre de la asignatura: ");
                asignatura.NombreAsignatura = Console.ReadLine();
                Console.Write("Horario: ");
                asignatura.Horario = Console.ReadLine();
                Console.Write("Nombre del docente: ");
                asignatura.NombreDocente = Console.ReadLine();

                Console.WriteLine("Ingrese las notas de los parciales:");

                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("Nota del primer parcial: ");
                    string inputN1 = Console.ReadLine();

                    if (IsNumeric(inputN1))
                    {
                        asignatura.N1 = int.Parse(inputN1);
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese valres numericos ");
                    }
                }

                validInput = false;

                while (!validInput)
                {
                    Console.Write("Nota del segundo parcial: ");
                    string inputN2 = Console.ReadLine();

                    if (IsNumeric(inputN2))
                    {
                        asignatura.N2 = int.Parse(inputN2);
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese valores numericos ");
                    }
                }

                validInput = false;

                while (!validInput)
                {
                    Console.Write("Nota del tercer parcial: ");
                    string inputN3 = Console.ReadLine();

                    if (IsNumeric(inputN3))
                    {
                        asignatura.N3 = int.Parse(inputN3);
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese valores numericos ");
                    }
                }

                asignatura.Imprimir();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}
