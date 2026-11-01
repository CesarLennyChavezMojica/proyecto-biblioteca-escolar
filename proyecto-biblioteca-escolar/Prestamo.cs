using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_biblioteca_escolar
{
    public class Prestamo
    {
        // Propiedades de la clase Prestamo
        public int IdPrestamo { get; set; }
        public string IsbnLibro { get; set; }
        public string MatriculaAlumno { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Activo { get; set; }

        // Constructor por defecto
        public Prestamo() { }

        // Constructor con parámetros
        public Prestamo(int idPrestamo, string isbnLibro, string matriculaAlumno, DateTime fechaPrestamo, int diasPlazo)
        {
            IdPrestamo = idPrestamo;
            IsbnLibro = isbnLibro;
            MatriculaAlumno = matriculaAlumno;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaPrestamo.AddDays(diasPlazo);
            Activo = true;
        }

        // Método para mostrar los detalles del préstamo en consola
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID Préstamo: {IdPrestamo}");
            Console.WriteLine($"ISBN Libro: {IsbnLibro}");
            Console.WriteLine($"Matrícula Alumno: {MatriculaAlumno}");
            Console.WriteLine($"Fecha de Préstamo: {FechaPrestamo:dd/MM/yyyy}");
            Console.WriteLine($"Fecha de Devolución: {FechaDevolucion:dd/MM/yyyy}");
            Console.WriteLine($"Estado: {(Activo ? "Activo (Pendiente)" : "Devuelto")}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}