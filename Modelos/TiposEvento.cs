using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Cine : Evento
    {
        public Cine(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima) 
            : base(id, nombre, fecha, precioBase, capacidadMaxima) { }
            
        public override decimal CalcularPrecioFinal() => PrecioBase;
    }

    public class Concierto : Evento
    {
        public Concierto(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima) 
            : base(id, nombre, fecha, precioBase, capacidadMaxima) { }
            
        public override decimal CalcularPrecioFinal() => PrecioBase * 1.15m;
    }

    public class Taller : Evento
    {
        public Taller(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima) 
            : base(id, nombre, fecha, precioBase, capacidadMaxima) { }
            
        public override decimal CalcularPrecioFinal() => PrecioBase * 0.90m;
    }

    public class EventoDeportivo : Evento
    {
        public EventoDeportivo(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima) 
            : base(id, nombre, fecha, precioBase, capacidadMaxima) { }
            
        public override decimal CalcularPrecioFinal() => PrecioBase * 1.05m;
    }
}