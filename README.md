# PLANAZO - Gestión de Eventos y Reservas

Aplicación de consola en C# y .NET para la gestión de eventos, reservas y control de aforos, desarrollada aplicando principios de Programación Orientada a Objetos (POO).

## Instrucciones de ejecución
1. Asegúrate de tener el SDK de .NET 8 instalado.
2. Abre la terminal en la raíz de este proyecto.
3. Ejecuta el comando:
   `dotnet run`

## Conceptos de POO Implementados
* **Abstracción:** Se implementó una clase base abstracta `Evento` para unificar propiedades.
* **Encapsulamiento:** La propiedad `CuposDisponibles` cuenta con un `protected set`, evitando modificaciones fuera de la lógica permitida.
* **Herencia:** Clases especializadas como `Cine`, `Concierto` y `Taller` derivan de `Evento`.
* **Polimorfismo:** Cada tipo de evento sobrescribe el método `CalcularPrecioFinal()` según sus propias reglas de negocio.
* **Colecciones:** Uso de `List<T>` en `GestorReservas` para almacenar las entidades.
* **Excepciones:** Bloques `try-catch` y lanzamiento de excepciones para prevenir reservas negativas o sobrecupo.

## Retos Adicionales Implementados
1. **Nuevo tipo de evento:** Se agregó la clase `EventoDeportivo`.
2. **Gestión de usuarios:** Se implementó la clase `Usuario`.
3. **Diagrama UML:** Las capturas y diagrama se encuentran en la carpeta `Capturas`.

## Pregunta de Sustentación
**¿Por qué utilizaste una clase abstracta Evento en lugar de crear clases completamente independientes para Cine, Concierto y Taller?**
Utilizar una clase abstracta `Evento` previene la duplicación de código. Además, aprovecha el polimorfismo, permitiendo que una sola lista (`List<Evento>`) pueda almacenar cualquier tipo de evento y llamar al método `CalcularPrecioFinal()` delegando a cada clase su comportamiento. Cuando se requiere un nuevo tipo de evento (como el `EventoDeportivo` del reto 1), solo se necesita crear una clase nueva que herede de `Evento` sin modificar la lógica principal, cumpliendo con el principio Abierto/Cerrado.
