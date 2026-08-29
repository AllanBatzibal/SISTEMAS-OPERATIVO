using SimuladorGestionProcesos.Services;

namespace SimuladorGestionProcesos.Tests;

/// <summary>
/// Pruebas unitarias de la lógica de memoria, cola y admisión de procesos.
/// </summary>
public class GestorProcesosTests
{
    [Fact]
    public void AgregarProceso_ConMemoriaDisponible_IniciaEjecucionYDescuentaMemoria()
    {
        var gestor = new GestorProcesos();

        var resultado = gestor.AgregarProceso("Chrome", 300, 10);

        Assert.True(resultado.Exito);
        Assert.NotNull(resultado.Proceso);
        Assert.Equal("Ejecutando", resultado.Proceso!.Estado);
        Assert.Equal(300, gestor.MemoriaUtilizada);
        Assert.Equal(GestorProcesos.MEMORIA_TOTAL - 300, gestor.MemoriaDisponible);
        Assert.Single(gestor.ObtenerProcesosEnEjecucion());
        Assert.Empty(gestor.ObtenerColaEspera());
    }

    [Fact]
    public void AgregarProceso_SinMemoriaSuficiente_EnviaProcesoAColaDeEspera()
    {
        var gestor = new GestorProcesos();

        gestor.AgregarProceso("ProcesoA", 900, 10);
        var resultado = gestor.AgregarProceso("ProcesoB", 200, 15);

        Assert.True(resultado.Exito);
        Assert.NotNull(resultado.Proceso);
        Assert.Equal("En espera", resultado.Proceso!.Estado);
        Assert.Equal(900, gestor.MemoriaUtilizada);
        Assert.Single(gestor.ObtenerColaEspera());
        Assert.Equal("ProcesoB", gestor.ObtenerColaEspera()[0].Nombre);
    }

    [Theory]
    [InlineData(0, 10, "La memoria requerida debe ser mayor que 0 MB.")]
    [InlineData(-5, 10, "La memoria requerida debe ser mayor que 0 MB.")]
    [InlineData(1025, 10, "La memoria requerida no puede ser mayor a 1024 MB.")]
    [InlineData(300, 0, "La duración debe ser mayor que 0 segundos.")]
    [InlineData(300, -1, "La duración debe ser mayor que 0 segundos.")]
    public void AgregarProceso_ConDatosInvalidos_DevuelveError(int memoria, int duracion, string mensajeEsperado)
    {
        var gestor = new GestorProcesos();

        var resultado = gestor.AgregarProceso("Invalido", memoria, duracion);

        Assert.False(resultado.Exito);
        Assert.Null(resultado.Proceso);
        Assert.Equal(mensajeEsperado, resultado.Error);
        Assert.Equal(0, gestor.MemoriaUtilizada);
        Assert.Empty(gestor.ObtenerProcesosEnEjecucion());
        Assert.Empty(gestor.ObtenerColaEspera());
    }

    [Fact]
    public void FinalizarProceso_LiberaMemoriaYAdmiteProcesoEnCola()
    {
        var gestor = new GestorProcesos();

        var resultadoA = gestor.AgregarProceso("ProcesoA", 900, 10);
        var resultadoB = gestor.AgregarProceso("ProcesoB", 200, 8);

        Assert.Equal("Ejecutando", resultadoA.Proceso!.Estado);
        Assert.Equal("En espera", resultadoB.Proceso!.Estado);
        Assert.Single(gestor.ObtenerColaEspera());

        gestor.FinalizarProceso(resultadoA.Proceso);

        Assert.Equal(200, gestor.MemoriaUtilizada);
        Assert.Equal(GestorProcesos.MEMORIA_TOTAL - 200, gestor.MemoriaDisponible);
        Assert.Empty(gestor.ObtenerColaEspera());
        Assert.Single(gestor.ObtenerProcesosEnEjecucion());
        Assert.Equal("ProcesoB", gestor.ObtenerProcesosEnEjecucion()[0].Nombre);
        Assert.Equal("Ejecutando", gestor.ObtenerProcesosEnEjecucion()[0].Estado);
        Assert.Single(gestor.ObtenerProcesosFinalizados());
        Assert.Equal("Finalizado", gestor.ObtenerProcesosFinalizados()[0].Estado);
    }
}
