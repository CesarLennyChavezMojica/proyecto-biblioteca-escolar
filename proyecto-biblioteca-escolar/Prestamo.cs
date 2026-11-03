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

        // Método para mostrar la información del préstamo
        public void MostrarInformacion()
        {
            string estadoStr = Activo ? "ACTIVO" : "DEVUELTO";
            Console.WriteLine($"[Préstamo #{IdPrestamo}] ISBN: {IsbnLibro} | Alumno: {MatriculaAlumno} | Estado: {estadoStr}");
            Console.WriteLine($"   Fecha Préstamo: {FechaPrestamo:dd/MM/yyyy} | Límite Devolución: {FechaDevolucion:dd/MM/yyyy}");
        }

        // Método del Día 5: Registrar la devolución del libro
        public void RegistrarDevolucion(DateTime fechaEntregaReal)
        {
            if (!Activo)
            {
                Console.WriteLine($"⚠️ El préstamo #{IdPrestamo} ya se encuentra devuelto.");
                return;
            }

            Activo = false;
            Console.WriteLine($"\n✅ Devolución registrada con éxito para el préstamo #{IdPrestamo}.");

            // Evaluación de reglas de negocio (Devolución a tiempo vs Retraso)
            if (fechaEntregaReal <= FechaDevolucion)
            {
                Console.WriteLine("🎉 Entrega a tiempo. ¡Sin penalización!");
            }
            else
            {
                TimeSpan retraso = fechaEntregaReal - FechaDevolucion;
                int diasRetraso = retraso.Days;
                Console.WriteLine($"⚠️ Entrega con retraso de {diasRetraso} día(s). Se aplica registro de mora.");
            }
        }
    }
}