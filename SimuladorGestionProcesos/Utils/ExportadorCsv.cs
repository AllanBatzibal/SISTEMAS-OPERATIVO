using System.Reflection;
using System.Text;
using SimuladorGestionProcesos.Models;

namespace SimuladorGestionProcesos.Utils;

/// <summary>
/// Exporta datos del simulador a archivos CSV usando System.IO.
/// </summary>
public static class ExportadorCsv
{
    private static readonly (string Encabezado, Func<Proceso, string> ObtenerValor)[] ColumnasBase =
    [
        ("PID", proceso => proceso.PID.ToString()),
        ("Nombre", proceso => EscaparCampoCsv(proceso.Nombre)),
        ("MemoriaMB", proceso => proceso.MemoriaRequerida.ToString()),
        ("DuracionSeg", proceso => proceso.Duracion.ToString()),
        ("Estado", proceso => EscaparCampoCsv(proceso.Estado))
    ];

    private static readonly (string Propiedad, string Encabezado)[] ColumnasFechaOpcionales =
    [
        ("HoraCreacion", "HoraCreacion"),
        ("HoraInicioEjecucion", "HoraInicioEjecucion"),
        ("HoraFinalizacion", "HoraFinalizacion")
    ];

    /// <summary>
    /// Escribe el historial de procesos finalizados en un archivo CSV.
    /// </summary>
    public static void ExportarProcesosFinalizados(IEnumerable<Proceso> procesos, string rutaArchivo)
    {
        var columnas = ConstruirColumnas();
        var lineas = new List<string>
        {
            string.Join(",", columnas.Select(columna => columna.Encabezado))
        };

        foreach (var proceso in procesos)
        {
            lineas.Add(string.Join(",", columnas.Select(columna => columna.ObtenerValor(proceso))));
        }

        File.WriteAllLines(rutaArchivo, lineas, Encoding.UTF8);
    }

    /// <summary>
    /// Construye las columnas del CSV incluyendo marcas de tiempo si existen en el modelo.
    /// </summary>
    private static List<(string Encabezado, Func<Proceso, string> ObtenerValor)> ConstruirColumnas()
    {
        var columnas = ColumnasBase.ToList();

        foreach (var (propiedad, encabezado) in ColumnasFechaOpcionales)
        {
            PropertyInfo? propiedadInfo = typeof(Proceso).GetProperty(propiedad);
            if (propiedadInfo is null || propiedadInfo.PropertyType != typeof(DateTime?))
            {
                continue;
            }

            columnas.Add((encabezado, proceso =>
            {
                var valor = (DateTime?)propiedadInfo.GetValue(proceso);
                return FormatearFecha(valor);
            }));
        }

        return columnas;
    }

    /// <summary>
    /// Escapa un campo de texto para CSV cuando contiene comas o comillas.
    /// </summary>
    private static string EscaparCampoCsv(string valor)
    {
        if (valor.Contains(',') || valor.Contains('"') || valor.Contains('\n') || valor.Contains('\r'))
        {
            return $"\"{valor.Replace("\"", "\"\"")}\"";
        }

        return valor;
    }

    private static string FormatearFecha(DateTime? fecha)
    {
        return fecha?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
    }
}
