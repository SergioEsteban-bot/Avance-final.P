﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_Final
{
    internal class Program
    {


        static void Main()
        {
            int opcion = 0;
            int sensor1 = 0, sensor2 = 0, sensor3 = 0, sensor4 = 0;
            while (opcion != 3)
            {
                Console.Clear();
                MostrarMenu();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Elige una opción: ");
                Console.ResetColor();
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Monitorear(ref sensor1, ref sensor2, ref sensor3, ref sensor4);
                }
                else if (opcion == 2)
                {
                    Reiniciar(ref sensor1, ref sensor2, ref sensor3, ref sensor4);
                }
                else if (opcion == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Saliendo del sistema...");
                    Console.WriteLine("Presiona ENTER para terminar.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Opción no válida. Presiona ENTER para intentar de nuevo.");
                    Console.ReadLine();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================");
            Console.WriteLine(" SISTEMA DE MONITOREO  ");
            Console.WriteLine("======================\n");
            Console.WriteLine("1. Monitorear\n");
            Console.WriteLine("2. Reiniciar\n");
            Console.WriteLine("3. Salir\n");
            Console.ResetColor();



        }

        static void Monitorear(ref int s1, ref int s2, ref int s3, ref int s4)
        {
            Random azar = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine("=== ESTADO DE LOS SENSORES ===\n");
                s1 = azar.Next(10, 100);
                s2 = azar.Next(10, 100);
                s3 = azar.Next(10, 100);
                s4 = azar.Next(10, 100);

                MostrarSensor(1, s1);
                MostrarSensor(2, s2);
                MostrarSensor(3, s3);
                MostrarSensor(4, s4);

                if (s1 <= 93 && s2 <= 93 && s3 <= 93 && s4 <= 93)
                {
                    Console.WriteLine("\nNingún sensor activado. Actualizando...");

                }
Thread.Sleep(3000);
            } while (s1 <= 93 && s2 <= 93 && s3 <= 93 && s4 <= 93);

            if (s1 > 93 || s2 > 93 || s3 > 93 || s4 > 93)
            {
                Console.Beep(700, 200);
                Console.Beep(700, 200);
                Console.WriteLine("\n  Atención: Se detectó un sensor activado.");
            }

            Console.WriteLine("\nPresiona ENTER para ver la estructura del piso...");
            Console.ReadLine();

            if (s1 > 93 || s2 > 93 || s3 > 93 || s4 > 93)
            {
                MostrarPlano(s1, s2, s3, s4);
                LlamarBomberos();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No hay sensores activados. Todo está en orden.");
                Console.WriteLine("Presiona ENTER para volver al menú...");
                Console.ReadLine();
            }
        }

        static void MostrarSensor(int numero, int valor)
        {
            Console.Write("Sensor " + numero + ": ");
            if (valor > 93)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(valor + "  <-- ACTIVADO");
                Console.Beep(700, 200);
                Console.Beep(900, 200);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(valor + "  (Normal)");
            }
            Console.ResetColor();
        }

        static void MostrarPlano(int s1, int s2, int s3, int s4)
        {
            Console.Clear();
            Console.WriteLine("=== PLANO DE ÁREAS (ALERTA) ===\n");

           
            Console.WriteLine("    +----------------------------+----------------------------+");
            Console.WriteLine("    |                            |                            |");
            Console.Write("    |  ");
            Console.Write("MÁQUINAS 1 (S2)");
            Console.Write("           |  ");
            Console.Write("ALMACÉN (S4)");
            Console.WriteLine("              |  ");
            Console.WriteLine("    |                                                         |");
            Console.Write("    |  S2: ");
            MostrarColor(s2);
            Console.Write("          |  S4: ");
            MostrarColor(s4);
            Console.WriteLine("          |");
            Console.WriteLine("    |                            |                            |");
            Console.WriteLine("    +-------------   ------------+---------------   ----------+");
            Console.WriteLine("    |                            |                            |");
            Console.Write("    |  ");
            Console.Write("MÁQUINAS 2 (S1)");           
            Console.Write("           |  ");
            Console.Write("OFICINA (S3)");
            Console.WriteLine("              |  ");
            Console.WriteLine("    |                            |                            |");
            Console.Write("    |  S1: ");
            MostrarColor(s1);
            Console.Write("          |  S3:  ");
            MostrarColor(s3);
            Console.WriteLine("         |");
            Console.WriteLine("    |                            |                            |");
            Console.WriteLine("    +----------------------------+---------------   ----------+");


            if (s1 > 93 || s2 > 93 || s3 > 93 || s4 > 93)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep(1000, 300);
                    Console.Beep(1200, 300);
                    Console.Beep(800, 300);
                }
            }

            Console.WriteLine("\nPresiona ENTER para continuar...");
            Console.ReadLine();
        }

        static void MostrarColor(int valor)
        {
            if (valor > 93)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + valor + "]  ACTIVA");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[" + valor + "]  Normal");
            }
            Console.ResetColor();
        }

        static void LlamarBomberos()
        {
            Console.Clear();
            Console.WriteLine("Llamando a los bomberos...");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Llamando...");
                Console.Beep(600, 200);
            }
            Console.WriteLine("Los bomberos fueron notificados.");
            Console.WriteLine("Presiona ENTER para volver al menú...");
            Console.ReadLine();
        }

        static void Reiniciar(ref int s1, ref int s2, ref int s3, ref int s4)
        {
            Console.Clear();
            Console.WriteLine("Reiniciando el sistema...\n");

            s1 = 0;
            s2 = 0;
            s3 = 0;
            s4 = 0;

            Console.WriteLine("Todos los sensores fueron reiniciados.");
            Console.WriteLine("Presiona ENTER para volver al menú...");
            Console.ReadLine();
        }
    }
}



