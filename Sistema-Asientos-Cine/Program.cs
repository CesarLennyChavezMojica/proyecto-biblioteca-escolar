using System;

class Program
{
    static void Main(string[] args)
    {
        int filas = 5;
        int columnas = 5;
        char[,] matriz = new char[filas, columnas];
        int filaUser, colUser;

        // Inicializar asientos con 'L' (Libre)
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = 'L';
            }
        }

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE ASIENTOS DE CINE ===");
            Console.WriteLine("1. Mostrar mapa");
            Console.WriteLine("2. Reservar asiento");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n--- PANTALLA ---");
                    for (int i = 0; i < filas; i++)
                    {
                        Console.Write($"Fila {i}: ");
                        for (int j = 0; j < columnas; j++)
                        {
                            Console.Write($"{matriz[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("\n--- RESERVAR ASIENTO ---");
                    Console.Write("Ingrese el numero de fila (0-4): ");
                    filaUser = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el numero de columna (0-4): ");
                    colUser = int.Parse(Console.ReadLine());

                    if (filaUser >= 0 && filaUser < filas && colUser >= 0 && colUser < columnas)
                    {
                        if (matriz[filaUser, colUser] == 'L')
                        {
                            matriz[filaUser, colUser] = 'X';
                            Console.WriteLine("\n[Mensaje]: ¡Exito! Asiento reservado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("\n[Aviso]: El asiento seleccionado ya se encuentra ocupado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n[Error]: Las coordenadas ingresadas estan fuera de rango.");
                    }
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "6":
                    salir = true;
                    break;
            }
        }
    }
}