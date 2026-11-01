using System;
using System.Collections.Generic;

namespace proyecto_biblioteca_escolar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carga de títulos de prueba (Día 2)
            List<Titulo> biblioteca = new List<Titulo>()
            {
                new Titulo("978-0132358884", "Clean Code", 15, new List<int> { 101, 102, 103 }),
                new Titulo("978-8281633618", "Design Patterns", 22, new List<int> { 281, 282 }),
                new Titulo("978-0321125217", "Domain-Driven Design", 8, new List<int> { 381 }),
                new Titulo("978-0134494166", "Clean Architecture", 30, new List<int> { 481, 482, 483, 484 }),
                new Titulo("978-0596007126", "Head First Design Patterns", 12, new List<int> { 581, 582 }),
                new Titulo("978-0321356688", "Effective Java", 19, new List<int> { 681, 682, 683 }),
                new Titulo("978-1449373328", "Designing Data-Intensive Applications", 25, new List<int> { 781, 782 }),
                new Titulo("978-0135957059", "The Pragmatic Programmer", 40, new List<int> { 801, 802, 803 })
            };

            Console.WriteLine("=== BIBLIOTECA ESCOLAR - CARGA EXITOSA (DÍA 2) ===");
            Console.WriteLine($"Total de títulos registrados: {biblioteca.Count}\n");

            foreach (var t in biblioteca)
            {
                Console.WriteLine($"ISBN: {t.Isbn} | Titulo: {t.Nombre} | Ejemplares: {t.Ejemplares.Count}");
            }

            // Prueba de la nueva clase Prestamo (Día 3)
            Console.WriteLine("\n=== GESTIÓN DE PRÉSTAMOS (DÍA 3) ===");
            Prestamo primerPrestamo = new Prestamo(1, "978-0132358884", "24737800", DateTime.Now, 7);
            primerPrestamo.MostrarInformacion();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}