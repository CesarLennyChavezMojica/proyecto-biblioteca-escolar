using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Carga de los 8 títulos de prueba con cantidades irregulares de ejemplares
        List<Titulo> biblioteca = new List<Titulo>()
        {
            new Titulo("978-0132350884", "Clean Code", 15, new List<int> { 101, 102, 103 }),
            new Titulo("978-0201633610", "Design Patterns", 22, new List<int> { 201, 202 }),
            new Titulo("978-0321125217", "Domain-Driven Design", 8, new List<int> { 301 }),
            new Titulo("978-0134494166", "Clean Architecture", 30, new List<int> { 401, 402, 403, 404 }),
            new Titulo("978-0596007126", "Head First Design Patterns", 12, new List<int> { 501, 502 }),
            new Titulo("978-0321356680", "Effective Java", 19, new List<int> { 601, 602, 603 }),
            new Titulo("978-1449373328", "Designing Data-Intensive Applications", 25, new List<int> { 701, 702 }),
            new Titulo("978-0135957059", "The Pragmatic Programmer", 40, new List<int> { 801, 802, 803 })
        };

        Console.WriteLine("=== BIBLIOTECA ESCOLAR - CARGA EXITOSA (DÍA 2) ===");
        Console.WriteLine($"Total de títulos registrados: {biblioteca.Count}\n");

        foreach (var t in biblioteca)
        {
            Console.WriteLine($"ISBN: {t.Isbn} | Título: {t.Nombre} | Préstamos: {t.PrestamosHistoricos} | Ejemplares: {t.Ejemplares.Count}");
        }

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}