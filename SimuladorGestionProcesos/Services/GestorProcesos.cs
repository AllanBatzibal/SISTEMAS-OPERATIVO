using SimuladorGestionProcesos.Models;
using SimuladorGestionProcesos.Utils;

namespace SimuladorGestionProcesos.Services;

/// <summary>
/// Administra la memoria RAM, los procesos en ejecución, la cola de espera
/// y la liberación automática de recursos del simulador.
/// </summary>
public class GestorProcesos
{
    public const int MEMORIA_TOTAL = 1024;

    private int _memoriaUtilizada;
    private int _totalProcesosCreados;
    private int _picoMemoriaUsadaMb;
    private readonly object _bloqueo = new();
    private readonly GeneradorPID _generadorPid = new();

    public List<Proceso> ProcesosEjecucion { get; } = new();
    public Queue<Proceso> ColaEspera { get; } = new();
    public List<Proceso> ProcesosFinalizados { get; } = new();

    /// <summary>
    /// Se dispara cuando cambia el estado de memoria o de algún proceso.
    /// </summary>
    public event Action? SimulacionActualizada;

    public int MemoriaUtilizada
    {
        get
        {
            lock (_bloqueo)
            {
                return _memoriaUtilizada;
            }
        }
    }

    public int MemoriaDisponible => MEMORIA_TOTAL - MemoriaUtilizada;

    /// <summary>Total de procesos creados desde el inicio o último reinicio.</summary>
    public int TotalProcesosCreados
    {
        get
        {
            lock (_bloqueo)
            {
                return _totalProcesosCreados;
            }
        }
    }

    /// <summary>Cantidad de procesos que han finalizado correctamente.</summary>
    public int TotalProcesosFinalizados
    {
        get
        {
            lock (_bloqueo)
            {
                return ProcesosFinalizados.Count;
            }
        }
    }

    /// <summary>
    /// Promedio de segundos entre la creación y el inicio de ejecución
    /// para los procesos que ya comenzaron a ejecutarse.
    /// </summary>
    public double TiempoEsperaPromedioSegundos
    {
        get
        {
            lock (_bloqueo)
            {
                return CalcularTiempoEsperaPromedioInterno();
            }
        }
    }

    /// <summary>Máximo histórico de memoria RAM utilizada en MB.</summary>
    public int PicoMemoriaUsadaMb
    {
        get
        {
            lock (_bloqueo)
            {
                return _picoMemoriaUsadaMb;
            }
        }
    }

    /// <summary>
    /// Crea un proceso, valida los datos y lo envía a ejecución o a la cola FIFO.
    /// </summary>
    public (bool Exito, string? Error, Proceso? Proceso) AgregarProceso(string nombre, int memoria, int duracion)
    {
        string? errorValidacion = ValidarDatos(memoria, duracion);
        if (errorValidacion is not null)
        {
            return (false, errorValidacion, null);
        }

        int pid = _generadorPid.ObtenerSiguientePID();
        string nombreFinal = string.IsNullOrWhiteSpace(nombre)
            ? $"Proceso_{pid}"
            : nombre.Trim();

        var proceso = new Proceso
        {
            PID = pid,
            Nombre = nombreFinal,
            MemoriaRequerida = memoria,
            Duracion = duracion,
            TiempoRestante = duracion,
            Estado = "Nuevo",
            HoraCreacion = DateTime.Now
        };

        lock (_bloqueo)
        {
            _totalProcesosCreados++;

            // Verifica si existe memoria RAM suficiente para iniciar la ejecución del proceso.
            if (ObtenerMemoriaDisponibleInterna() >= proceso.MemoriaRequerida)
            {
                IniciarProcesoInterno(proceso);
            }
            else
            {
                proceso.Estado = "En espera";
                ColaEspera.Enqueue(proceso);
            }
        }

        NotificarActualizacion();
        return (true, null, proceso);
    }

    /// <summary>
    /// Intenta iniciar un proceso reservando memoria e iniciando su ejecución asíncrona.
    /// </summary>
    public void IniciarProceso(Proceso proceso)
    {
        lock (_bloqueo)
        {
            IniciarProcesoInterno(proceso);
        }

        NotificarActualizacion();
    }

    /// <summary>
    /// Simula la ejecución del proceso decrementando el tiempo restante cada segundo.
    /// </summary>
    public async Task EjecutarProcesoAsync(Proceso proceso)
    {
        try
        {
            while (proceso.TiempoRestante > 0 && proceso.Estado == "Ejecutando")
            {
                await Task.Delay(1000).ConfigureAwait(false);

                lock (_bloqueo)
                {
                    if (proceso.Estado != "Ejecutando" || proceso.TiempoRestante <= 0)
                    {
                        break;
                    }

                    proceso.TiempoRestante--;
                }

                NotificarActualizacion();
            }

            lock (_bloqueo)
            {
                if (proceso.Estado == "Ejecutando" && proceso.TiempoRestante <= 0)
                {
                    FinalizarProcesoInterno(proceso);
                }
            }

            NotificarActualizacion();
        }
        finally
        {
            lock (_bloqueo)
            {
                proceso.EnEjecucionActiva = false;
            }
        }
    }

    /// <summary>
    /// Marca un proceso como finalizado, libera memoria y revisa la cola de espera.
    /// </summary>
    public void FinalizarProceso(Proceso proceso)
    {
        lock (_bloqueo)
        {
            FinalizarProcesoInterno(proceso);
        }

        NotificarActualizacion();
    }

    /// <summary>
    /// Libera la memoria RAM ocupada por un proceso finalizado.
    /// </summary>
    public void LiberarMemoria(Proceso proceso)
    {
        lock (_bloqueo)
        {
            LiberarMemoriaInterna(proceso);
        }
    }

    /// <summary>
    /// Revisa la cola FIFO e intenta ejecutar procesos cuando hay memoria disponible.
    /// </summary>
    public void RevisarColaEspera()
    {
        lock (_bloqueo)
        {
            RevisarColaEsperaInterna();
        }

        NotificarActualizacion();
    }

    /// <summary>
    /// Obtiene la memoria RAM disponible en MB.
    /// </summary>
    public int ObtenerMemoriaDisponible()
    {
        lock (_bloqueo)
        {
            return ObtenerMemoriaDisponibleInterna();
        }
    }

    /// <summary>
    /// Obtiene una copia segura de los procesos en ejecución para lectura en la interfaz.
    /// </summary>
    public List<Proceso> ObtenerProcesosEnEjecucion()
    {
        lock (_bloqueo)
        {
            return ProcesosEjecucion.ToList();
        }
    }

    /// <summary>
    /// Obtiene una copia segura de la cola de espera para lectura en la interfaz.
    /// </summary>
    public List<Proceso> ObtenerColaEspera()
    {
        lock (_bloqueo)
        {
            return ColaEspera.ToList();
        }
    }

    /// <summary>
    /// Obtiene una copia segura de los procesos finalizados para lectura en la interfaz.
    /// </summary>
    public List<Proceso> ObtenerProcesosFinalizados()
    {
        lock (_bloqueo)
        {
            return ProcesosFinalizados.ToList();
        }
    }

    /// <summary>
    /// Cancela manualmente un proceso en ejecución o en la cola de espera.
    /// </summary>
    public bool CancelarProceso(Proceso proceso)
    {
        bool cancelado;

        lock (_bloqueo)
        {
            if (ProcesosEjecucion.Contains(proceso))
            {
                CancelarProcesoEnEjecucionInterno(proceso);
                cancelado = true;
            }
            else if (ColaEspera.Contains(proceso))
            {
                CancelarProcesoEnColaInterno(proceso);
                cancelado = true;
            }
            else
            {
                cancelado = false;
            }
        }

        if (cancelado)
        {
            NotificarActualizacion();
        }

        return cancelado;
    }

    /// <summary>
    /// Restablece el simulador a su estado inicial vaciando colecciones y memoria.
    /// </summary>
    public void Reiniciar()
    {
        lock (_bloqueo)
        {
            // Marca los procesos en ejecución como cancelados para que las tareas
            // async en curso salgan de su ciclo sin modificar el estado reiniciado.
            foreach (var proceso in ProcesosEjecucion)
            {
                proceso.Estado = "Cancelado";
                proceso.EnEjecucionActiva = false;
            }

            ProcesosEjecucion.Clear();

            while (ColaEspera.Count > 0)
            {
                ColaEspera.Dequeue();
            }

            ProcesosFinalizados.Clear();
            _memoriaUtilizada = 0;
            _totalProcesosCreados = 0;
            _picoMemoriaUsadaMb = 0;
            _generadorPid.Reiniciar();
        }

        NotificarActualizacion();
    }

    private static string? ValidarDatos(int memoria, int duracion)
    {
        if (memoria <= 0)
        {
            return "La memoria requerida debe ser mayor que 0 MB.";
        }

        if (memoria > MEMORIA_TOTAL)
        {
            return "La memoria requerida no puede ser mayor a 1024 MB.";
        }

        if (duracion <= 0)
        {
            return "La duración debe ser mayor que 0 segundos.";
        }

        return null;
    }

    private void IniciarProcesoInterno(Proceso proceso)
    {
        if (proceso.EnEjecucionActiva || proceso.Estado == "Ejecutando" || proceso.Estado == "Finalizado" || proceso.Estado == "Cancelado")
        {
            return;
        }

        if (ObtenerMemoriaDisponibleInterna() < proceso.MemoriaRequerida)
        {
            return;
        }

        _memoriaUtilizada += proceso.MemoriaRequerida;
        ActualizarPicoMemoriaInterna();
        proceso.Estado = "Ejecutando";
        proceso.HoraInicioEjecucion = DateTime.Now;
        proceso.TiempoRestante = proceso.Duracion;
        proceso.EnEjecucionActiva = true;
        ProcesosEjecucion.Add(proceso);

        _ = EjecutarProcesoAsync(proceso);
    }

    private void FinalizarProcesoInterno(Proceso proceso)
    {
        if (proceso.Estado == "Finalizado")
        {
            return;
        }

        proceso.Estado = "Finalizado";
        proceso.HoraFinalizacion = DateTime.Now;
        proceso.TiempoRestante = 0;
        ProcesosEjecucion.Remove(proceso);
        ProcesosFinalizados.Add(proceso);

        LiberarMemoriaInterna(proceso);
        RevisarColaEsperaInterna();
    }

    private void LiberarMemoriaInterna(Proceso proceso)
    {
        if (proceso.MemoriaRequerida <= 0)
        {
            return;
        }

        _memoriaUtilizada -= proceso.MemoriaRequerida;

        if (_memoriaUtilizada < 0)
        {
            _memoriaUtilizada = 0;
        }
    }

    private void ActualizarPicoMemoriaInterna()
    {
        if (_memoriaUtilizada > _picoMemoriaUsadaMb)
        {
            _picoMemoriaUsadaMb = _memoriaUtilizada;
        }
    }

    private double CalcularTiempoEsperaPromedioInterno()
    {
        var procesosConInicio = ProcesosEjecucion
            .Concat(ProcesosFinalizados)
            .Where(p => p.HoraCreacion.HasValue && p.HoraInicioEjecucion.HasValue)
            .ToList();

        if (procesosConInicio.Count == 0)
        {
            return 0;
        }

        return procesosConInicio.Average(proceso =>
            (proceso.HoraInicioEjecucion!.Value - proceso.HoraCreacion!.Value).TotalSeconds);
    }

    private void RevisarColaEsperaInterna()
    {
        while (ColaEspera.Count > 0)
        {
            Proceso siguiente = ColaEspera.Peek();

            if (ObtenerMemoriaDisponibleInterna() < siguiente.MemoriaRequerida)
            {
                break;
            }

            ColaEspera.Dequeue();
            IniciarProcesoInterno(siguiente);
        }
    }

    /// <summary>
    /// Cancela un proceso en ejecución, libera su memoria y revisa la cola de espera.
    /// La tarea async en curso detectará el cambio de estado y saldrá sin liberar de nuevo.
    /// </summary>
    private void CancelarProcesoEnEjecucionInterno(Proceso proceso)
    {
        if (proceso.Estado != "Ejecutando")
        {
            return;
        }

        proceso.Estado = "Cancelado";
        LiberarMemoriaInterna(proceso);
        ProcesosEjecucion.Remove(proceso);
        RevisarColaEsperaInterna();
    }

    /// <summary>
    /// Elimina un proceso de la cola FIFO reconstruyéndola sin ese elemento.
    /// </summary>
    private void CancelarProcesoEnColaInterno(Proceso proceso)
    {
        var procesosRestantes = ColaEspera.Where(p => p.PID != proceso.PID).ToList();

        while (ColaEspera.Count > 0)
        {
            ColaEspera.Dequeue();
        }

        foreach (var procesoRestante in procesosRestantes)
        {
            ColaEspera.Enqueue(procesoRestante);
        }

        proceso.Estado = "Cancelado";
    }

    private int ObtenerMemoriaDisponibleInterna()
    {
        return MEMORIA_TOTAL - _memoriaUtilizada;
    }

    private void NotificarActualizacion()
    {
        SimulacionActualizada?.Invoke();
    }
}
