using System;
using System.Collections.Generic;
using System.Linq;

namespace proyecto_biblioteca_escolar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carga inicial de títulos de prueba (Días 2 y 3)
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

            Console.WriteLine("=== SISTEMA DE BIBLIOTECA ESCOLAR - DÍA 4 ===");
            Console.WriteLine($"Total de libros registrados: {biblioteca.Count}\n");

            // --- PRUEBAS DE BÚSQUEDA (DÍA 4) ---
            Console.WriteLine("--- 1. Búsqueda por ISBN ('978-0132358884') ---");
            BuscarPorIsbn(biblioteca, "978-0132358884");

            Console.WriteLine("\n--- 2. Búsqueda por ISBN (Inexistente '000-0000000000') ---");
            BuscarPorIsbn(biblioteca, "000-0000000000");

            Console.WriteLine("\n--- 3. Búsqueda por Título (Coincidencia 'Clean') ---");
            BuscarPorTitulo(biblioteca, "Clean");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método para buscar un libro por su ISBN exacto
        public static void BuscarPorIsbn(List<Titulo> lista, string isbn)
        {
            var libro = lista.FirstOrDefault(t => t.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));

            if (libro != null)
            {
                Console.WriteLine($"[ENCONTRADO] ISBN: {libro.Isbn} | Título: {libro.Nombre}");
                Console.WriteLine($"   Ejemplares disponibles ({libro.Ejemplares.Count}): {string.Join(", ", libro.Ejemplares)}");
            }
            else
            {
                Console.WriteLine($"[NO ENCONTRADO] No se encontró ningún libro con el ISBN: {isbn}");
            }
        }

        // Método para buscar libros cuyo título contenga la palabra clave
        public static void BuscarPorTitulo(List<Titulo> lista, string criterio)
        {
            var resultados = lista.Where(t => t.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count > 0)
            {
                Console.WriteLine($"Se encontraron {resultados.Count} resultado(s) para '{criterio}':");
                foreach (var libro in resultados)
                {
                    Console.WriteLine($" - [{libro.Isbn}] {libro.Nombre} | Ejemplares: {libro.Ejemplares.Count}");
                }
            }
            else
            {
                Console.WriteLine($"[NO ENCONTRADO] No se encontraron libros que contengan: '{criterio}'");
            }
        }
    }
}