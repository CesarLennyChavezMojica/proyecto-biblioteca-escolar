using System;
using System.Collections.Generic;
using System.Linq;

namespace proyecto_biblioteca_escolar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE BIBLIOTECA ESCOLAR - DÍA 5 ===");

            // 1. Crear un préstamo de prueba (Plazo de 7 días a partir de hoy)
            Prestamo prestamo1 = new Prestamo(101, "978-0132358884", "24737800", DateTime.Now, 7);

            Console.WriteLine("\n--- Estado Inicial del Préstamo ---");
            prestamo1.MostrarInformacion();

            // 2. Simular entrega A TIEMPO (hoy mismo)
            Console.WriteLine("\n--- Prueba 1: Simulación de entrega a tiempo ---");
            prestamo1.RegistrarDevolucion(DateTime.Now);
            prestamo1.MostrarInformacion();

            // 3. Crear otro préstamo para simular ENTREGA CON RETRASO
            Console.WriteLine("\n------------------------------------------------");
            Prestamo prestamo2 = new Prestamo(102, "978-0134494166", "24737800", DateTime.Now.AddDays(-10), 7);

            Console.WriteLine("\n--- Estado Inicial del Préstamo #102 (Hecho hace 10 días con plazo de 7) ---");
            prestamo2.MostrarInformacion();

            Console.WriteLine("\n--- Prueba 2: Simulación de entrega fuera de tiempo ---");
            // Se entrega hoy, pero ya pasaron los días límite
            prestamo2.RegistrarDevolucion(DateTime.Now);
            prestamo2.MostrarInformacion();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}