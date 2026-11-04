using System;
using System.Collections.Generic;
using System.Linq;

namespace proyecto_biblioteca_escolar
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Inicializar listas principales del sistema
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

            List<Prestamo> listaPrestamos = new List<Prestamo>();
            int contadorIdPrestamo = 1;

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("       SISTEMA DE BIBLIOTECA ESCOLAR (CELE)       ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Buscar libros (por ISBN o Título)");
                Console.WriteLine("2. Registrar nuevo préstamo");
                Console.WriteLine("3. Registrar devolución de préstamo");
                Console.WriteLine("4. Ver todos los préstamos registrados");
                Console.WriteLine("5. Salir");
                Console.WriteLine("==================================================");
                Console.Write("Selecciona una opción (1-5): ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("=== BÚSQUEDA DE LIBROS ===");
                        Console.WriteLine("1. Buscar por ISBN exacto");
                        Console.WriteLine("2. Buscar por coincidencia de Título");
                        Console.Write("Elige método de búsqueda: ");
                        string tipoBusqueda = Console.ReadLine();

                        if (tipoBusqueda == "1")
                        {
                            Console.Write("Introduce el ISBN a buscar: ");
                            string isbnBuscado = Console.ReadLine();
                            BuscarPorIsbn(biblioteca, isbnBuscado);
                        }
                        else if (tipoBusqueda == "2")
                        {
                            Console.Write("Introduce la palabra clave del título: ");
                            string tituloBuscado = Console.ReadLine();
                            BuscarPorTitulo(biblioteca, tituloBuscado);
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Opción no válida.");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("=== REGISTRAR NUEVO PRÉSTAMO ===");
                        Console.Write("Introduce el ISBN del libro: ");
                        string isbnPrestamo = Console.ReadLine();

                        var libroEncontrado = biblioteca.FirstOrDefault(t => t.Isbn.Equals(isbnPrestamo, StringComparison.OrdinalIgnoreCase));

                        if (libroEncontrado != null)
                        {
                            Console.Write("Introduce la matrícula del alumno (ej. 24737800): ");
                            string matricula = Console.ReadLine();

                            Console.Write("Introduce los días de plazo para la entrega: ");
                            if (int.TryParse(Console.ReadLine(), out int diasPlazo))
                            {
                                Prestamo nuevoPrestamo = new Prestamo(contadorIdPrestamo++, isbnPrestamo, matricula, DateTime.Now, diasPlazo);
                                listaPrestamos.Add(nuevoPrestamo);
                                Console.WriteLine($"\n✅ Préstamo #{nuevoPrestamo.IdPrestamo} registrado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("⚠️ Plazo en días no válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("❌ No se encontró ningún libro con ese ISBN en la biblioteca.");
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("=== REGISTRAR DEVOLUCIÓN ===");
                        if (listaPrestamos.Count == 0)
                        {
                            Console.WriteLine("No hay préstamos registrados en el sistema.");
                        }
                        else
                        {
                            Console.WriteLine("Préstamos actuales:");
                            foreach (var p in listaPrestamos)
                            {
                                p.MostrarInformacion();
                                Console.WriteLine("--------------------------------------------------");
                            }

                            Console.Write("Introduce el ID del préstamo a devolver: ");
                            if (int.TryParse(Console.ReadLine(), out int idBuscado))
                            {
                                var prestamoObj = listaPrestamos.FirstOrDefault(p => p.IdPrestamo == idBuscado);
                                if (prestamoObj != null)
                                {
                                    // Simulamos la devolución en el día actual (puedes cambiarlo si deseas probar retrasos)
                                    prestamoObj.RegistrarDevolucion(DateTime.Now);
                                }
                                else
                                {
                                    Console.WriteLine("❌ No se encontró un préstamo con ese ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("⚠️ ID ingresado no válido.");
                            }
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("=== LISTADO DE PRÉSTAMOS ===");
                        if (listaPrestamos.Count == 0)
                        {
                            Console.WriteLine("Aún no se han registrado préstamos.");
                        }
                        else
                        {
                            foreach (var p in listaPrestamos)
                            {
                                p.MostrarInformacion();
                                Console.WriteLine("--------------------------------------------------");
                            }
                        }
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por usar el Sistema de Biblioteca Escolar! Saliendo...");
                        break;

                    default:
                        Console.WriteLine("\n⚠️ Opción no válida. Intenta de nuevo.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // Métodos de búsqueda (Día 4)
        public static void BuscarPorIsbn(List<Titulo> lista, string isbn)
        {
            var libro = lista.FirstOrDefault(t => t.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));

            if (libro != null)
            {
                Console.WriteLine($"\n[ENCONTRADO] ISBN: {libro.Isbn} | Título: {libro.Nombre}");
                Console.WriteLine($"   Ejemplares disponibles ({libro.Ejemplares.Count}): {string.Join(", ", libro.Ejemplares)}");
            }
            else
            {
                Console.WriteLine($"\n[NO ENCONTRADO] No se encontró ningún libro con el ISBN: {isbn}");
            }
        }

        public static void BuscarPorTitulo(List<Titulo> lista, string criterio)
        {
            var resultados = lista.Where(t => t.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count > 0)
            {
                Console.WriteLine($"\nSe encontraron {resultados.Count} resultado(s) para '{criterio}':");
                foreach (var libro in resultados)
                {
                    Console.WriteLine($" - [{libro.Isbn}] {libro.Nombre} | Ejemplares: {libro.Ejemplares.Count}");
                }
            }
            else
            {
                Console.WriteLine($"\n[NO ENCONTRADO] No se encontraron libros que contengan: '{criterio}'");
            }
        }
    }
}