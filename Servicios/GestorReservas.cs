using System;
using System.Collections.Generic;
using System.Linq;
using PLANAZO_POO_CSharp.Modelos;

namespace PLANAZO_POO_CSharp.Servicios
{
    public class GestorReservas
    {
        private List<Evento> eventos = new List<Evento>();
        private List<Reserva> reservas = new List<Reserva>();
        private List<Usuario> usuarios = new List<Usuario>();
        private int contadorReservas = 1;

        public GestorReservas()
        {
            usuarios.Add(new Usuario(1, "Andrés Novoa"));
            eventos.Add(new Cine(1, "Inception", DateTime.Now.AddDays(2), 15000, 50));
            eventos.Add(new Cine(2, "Interstellar", DateTime.Now.AddDays(3), 15000, 40));
            eventos.Add(new Concierto(3, "Rock al Parque", DateTime.Now.AddDays(10), 50000, 100));
            eventos.Add(new Concierto(4, "Jazz Night", DateTime.Now.AddDays(5), 40000, 60));
            eventos.Add(new Taller(5, "Taller de C#", DateTime.Now.AddDays(4), 30000, 20));
            eventos.Add(new Taller(6, "Taller de Python", DateTime.Now.AddDays(7), 30000, 25));
            eventos.Add(new EventoDeportivo(7, "Partido de Fútbol", DateTime.Now.AddDays(1), 20000, 200));
        }

        public void MostrarEventos()
        {
            Console.WriteLine("\n--- Eventos Disponibles ---");
            foreach (var e in eventos)
            {
                Console.WriteLine($"{e.Id}. {e.Nombre} ({e.GetType().Name}) - Precio Final: {e.CalcularPrecioFinal():C} - Cupos: {e.CuposDisponibles}/{e.CapacidadMaxima}");
            }
        }

        public void ConsultarEvento(int id)
        {
            var e = eventos.FirstOrDefault(x => x.Id == id);
            if (e == null) throw new KeyNotFoundException("El evento no existe.");
            
            Console.WriteLine($"\nDetalles del evento:\nNombre: {e.Nombre}\nTipo: {e.GetType().Name}\nFecha: {e.Fecha}\nPrecio Base: {e.PrecioBase:C}\nPrecio Final: {e.CalcularPrecioFinal():C}\nCupos: {e.CuposDisponibles}");
        }

        public void ReservarEntradas(int idEvento, int cantidad)
        {
            var evento = eventos.FirstOrDefault(x => x.Id == idEvento);
            if (evento == null) throw new KeyNotFoundException("El evento no existe.");

            evento.DisminuirCupos(cantidad); 
            var nuevaReserva = new Reserva(contadorReservas++, usuarios[0], evento, cantidad);
            reservas.Add(nuevaReserva);
            
            Console.WriteLine($"\nReserva exitosa! ID de Reserva: {nuevaReserva.Id}. Total a pagar: {nuevaReserva.ValorTotal:C}");
        }

        public void VerReservas()
        {
            Console.WriteLine("\n--- Reservas Realizadas ---");
            if (reservas.Count == 0) Console.WriteLine("No hay reservas.");
            foreach (var r in reservas)
            {
                string estado = r.EstadoActiva ? "Activa" : "Cancelada";
                Console.WriteLine($"ID: {r.Id} | Evento: {r.EventoReservado.Nombre} | Entradas: {r.CantidadEntradas} | Total: {r.ValorTotal:C} | Estado: {estado}");
            }
        }

        public void CancelarReserva(int idReserva)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == idReserva);
            if (reserva == null) throw new KeyNotFoundException("La reserva no existe.");
            if (!reserva.EstadoActiva) throw new InvalidOperationException("La reserva ya se encuentra cancelada.");

            reserva.EventoReservado.DevolverCupos(reserva.CantidadEntradas);
            reserva.EstadoActiva = false;
            Console.WriteLine("Reserva cancelada exitosamente. Se han devuelto los cupos al evento.");
        }

        public void MostrarResumen()
        {
            var activas = reservas.Where(r => r.EstadoActiva).ToList();
            Console.WriteLine("\n--- Resumen de Reservas ---");
            Console.WriteLine($"Reservas activas: {activas.Count}");
            Console.WriteLine($"Total entradas reservadas: {activas.Sum(r => r.CantidadEntradas)}");
            Console.WriteLine($"Valor total recaudado: {activas.Sum(r => r.ValorTotal):C}");
        }
    }
}