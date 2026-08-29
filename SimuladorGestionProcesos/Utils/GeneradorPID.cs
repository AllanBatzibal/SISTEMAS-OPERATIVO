namespace SimuladorGestionProcesos.Utils;

/// <summary>
/// Genera identificadores de proceso (PID) únicos e incrementales.
/// </summary>
public class GeneradorPID
{
    private int _contador;
    private readonly object _bloqueo = new();

    /// <summary>
    /// Obtiene el siguiente PID disponible de forma segura ante accesos concurrentes.
    /// </summary>
    public int ObtenerSiguientePID()
    {
        lock (_bloqueo)
        {
            _contador++;
            return _contador;
        }
    }
}
