using System;
using System.Collections.Generic;

public class Titulo
{
    public string Isbn { get; set; }
    public string Nombre { get; set; }
    public int PrestamosHistoricos { get; set; }
    public List<int> Ejemplares { get; set; }

    public Titulo(string isbn, string nombre, int prestamosHistoricos, List<int> ejemplares)
    {
        Isbn = isbn;
        Nombre = nombre;
        PrestamosHistoricos = prestamosHistoricos;
        Ejemplares = ejemplares;
    }
}
