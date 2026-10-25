using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public abstract class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioBase { get; set; }
        public int CapacidadMaxima { get; set; }
        public int CuposDisponibles { get; protected set; }

        protected Evento(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima)
        {
            Id = id;
            Nombre = nombre;
            Fecha = fecha;
            PrecioBase = precioBase;
            CapacidadMaxima = capacidadMaxima;
            CuposDisponibles = capacidadMaxima;
        }

        public abstract decimal CalcularPrecioFinal();

        public void DisminuirCupos(int cantidad)
        {
            if (cantidad > CuposDisponibles)
                throw new InvalidOperationException("No hay suficientes cupos disponibles.");
            CuposDisponibles -= cantidad;
        }

        public void DevolverCupos(int cantidad)
        {
            CuposDisponibles += cantidad;
        }
    }
}