using System;
using PLANAZO_POO_CSharp.Servicios;

namespace PLANAZO_POO_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorReservas gestor = new GestorReservas();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("        PLANAZO - EVENTOS       ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Ver eventos disponibles");
                Console.WriteLine("2. Consultar evento");
                Console.WriteLine("3. Reservar entradas");
                Console.WriteLine("4. Ver reservas realizadas");
                Console.WriteLine("5. Cancelar una reserva");
                Console.WriteLine("6. Ver resumen de reservas");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                try
                {
                    string opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            gestor.MostrarEventos();
                            break;
                        case "2":
                            Console.Write("Ingrese el ID del evento: ");
                            gestor.ConsultarEvento(int.Parse(Console.ReadLine()));
                            break;
                        case "3":
                            Console.Write("Ingrese el ID del evento: ");
                            int idEvento = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese la cantidad de entradas: ");
                            int cantidad = int.Parse(Console.ReadLine());
                            gestor.ReservarEntradas(idEvento, cantidad);
                            break;
                        case "4":
                            gestor.VerReservas();
                            break;
                        case "5":
                            Console.Write("Ingrese el ID de la reserva a cancelar: ");
                            gestor.CancelarReserva(int.Parse(Console.ReadLine()));
                            break;
                        case "6":
                            gestor.MostrarResumen();
                            break;
                        case "0":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
            }
        }
    }
}