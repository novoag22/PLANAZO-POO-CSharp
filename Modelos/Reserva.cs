using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Reserva
    {
        public int Id { get; set; }
        public Usuario Persona { get; set; }
        public Evento EventoReservado { get; set; }
        public int CantidadEntradas { get; set; }
        public decimal ValorTotal { get; set; }
        public bool EstadoActiva { get; set; }

        public Reserva(int id, Usuario persona, Evento evento, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad de entradas debe ser mayor a cero.");

            Id = id;
            Persona = persona;
            EventoReservado = evento;
            CantidadEntradas = cantidad;
            ValorTotal = evento.CalcularPrecioFinal() * cantidad;
            EstadoActiva = true;
        }
    }
}