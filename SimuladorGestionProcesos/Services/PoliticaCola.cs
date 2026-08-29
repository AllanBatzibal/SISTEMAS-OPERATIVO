namespace SimuladorGestionProcesos.Services;

/// <summary>
/// Define cómo se admiten procesos desde la cola de espera cuando hay memoria disponible.
/// </summary>
public enum PoliticaCola
{
    /// <summary>
    /// Solo evalúa al proceso al frente de la cola. Si no cabe en RAM, detiene la revisión
    /// aunque procesos posteriores sí quepan (bloqueo de cabeza de línea / head-of-line blocking).
    /// </summary>
    FifoEstricta,

    /// <summary>
    /// Recorre toda la cola y admite a cada proceso que quepa en el momento en que se evalúa,
    /// sin detenerse en el primero que no cabe. Reduce el bloqueo de cabeza de línea.
    /// </summary>
    RecorrerTodaLaCola
}
