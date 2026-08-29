namespace SimuladorGestionProcesos.Models;

/// <summary>
/// Representa un proceso del sistema simulado con sus recursos y estado.
/// </summary>
public class Proceso
{
    /// <summary>Identificador único del proceso.</summary>
    public int PID { get; set; }

    /// <summary>Nombre descriptivo del proceso.</summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Memoria RAM requerida en MB.</summary>
    public int MemoriaRequerida { get; set; }

    /// <summary>Duración total de ejecución en segundos.</summary>
    public int Duracion { get; set; }

    /// <summary>Estado actual: Nuevo, En espera, Ejecutando o Finalizado.</summary>
    public string Estado { get; set; } = "Nuevo";

    /// <summary>Segundos restantes antes de finalizar la ejecución.</summary>
    public int TiempoRestante { get; set; }

    /// <summary>
    /// Indica si el proceso ya tiene una tarea de ejecución activa
    /// para evitar iniciarlo dos veces.
    /// </summary>
    public bool EnEjecucionActiva { get; set; }
}
