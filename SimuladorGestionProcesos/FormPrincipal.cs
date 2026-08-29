using SimuladorGestionProcesos.Models;
using SimuladorGestionProcesos.Services;

namespace SimuladorGestionProcesos;

/// <summary>
/// Formulario principal del simulador de gestión de procesos en memoria.
/// </summary>
public partial class FormPrincipal : Form
{
    private readonly GestorProcesos _gestor = new();

    public FormPrincipal()
    {
        InitializeComponent();
        ConfigurarInterfaz();
        _gestor.SimulacionActualizada += Gestor_SimulacionActualizada;
        ActualizarInterfaz();
    }

    private void ConfigurarInterfaz()
    {
        Text = "Simulador de Gestión de Procesos en Memoria";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1100, 780);

        ConfigurarDataGridView(dgvEjecucion);
        ConfigurarDataGridView(dgvEspera);
        ConfigurarDataGridView(dgvFinalizados);

        dgvEjecucion.Columns.Add("PID", "PID");
        dgvEjecucion.Columns.Add("Nombre", "Nombre");
        dgvEjecucion.Columns.Add("Memoria", "Memoria");
        dgvEjecucion.Columns.Add("Duracion", "Duración");
        dgvEjecucion.Columns.Add("Restante", "Tiempo restante");
        dgvEjecucion.Columns.Add("Estado", "Estado");

        dgvEspera.Columns.Add("PID", "PID");
        dgvEspera.Columns.Add("Nombre", "Nombre");
        dgvEspera.Columns.Add("Memoria", "Memoria");
        dgvEspera.Columns.Add("Duracion", "Duración");
        dgvEspera.Columns.Add("Estado", "Estado");

        dgvFinalizados.Columns.Add("PID", "PID");
        dgvFinalizados.Columns.Add("Nombre", "Nombre");
        dgvFinalizados.Columns.Add("Memoria", "Memoria");
        dgvFinalizados.Columns.Add("Estado", "Estado");

        progressBarMemoria.Minimum = 0;
        progressBarMemoria.Maximum = GestorProcesos.MEMORIA_TOTAL;
        progressBarMemoria.Value = 0;

        txtMemoria.KeyPress += SoloNumeros_KeyPress;
        txtDuracion.KeyPress += SoloNumeros_KeyPress;

        dgvFinalizados.SelectionChanged += dgvFinalizados_SelectionChanged;
        dgvEjecucion.SelectionChanged += dgvEjecucion_SelectionChanged;
        dgvEspera.SelectionChanged += dgvEspera_SelectionChanged;
    }

    private static void ConfigurarDataGridView(DataGridView grid)
    {
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeRows = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.RowHeadersVisible = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
        grid.DefaultCellStyle.SelectionForeColor = Color.White;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
    }

    private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private async void btnAgregarProceso_Click(object sender, EventArgs e)
    {
        btnAgregarProceso.Enabled = false;

        try
        {
            string nombre = txtNombre.Text.Trim();

            if (!int.TryParse(txtMemoria.Text.Trim(), out int memoria))
            {
                MessageBox.Show(
                    "Ingrese un valor numérico válido para la memoria requerida.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDuracion.Text.Trim(), out int duracion))
            {
                MessageBox.Show(
                    "Ingrese un valor numérico válido para la duración.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (memoria <= 0)
            {
                MessageBox.Show(
                    "La memoria requerida debe ser mayor que 0 MB.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (memoria > GestorProcesos.MEMORIA_TOTAL)
            {
                MessageBox.Show(
                    "La memoria requerida no puede ser mayor a 1024 MB.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (duracion <= 0)
            {
                MessageBox.Show(
                    "La duración debe ser mayor que 0 segundos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var resultado = await Task.Run(() => _gestor.AgregarProceso(nombre, memoria, duracion));

            if (!resultado.Exito)
            {
                MessageBox.Show(
                    resultado.Error ?? "No se pudo agregar el proceso.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            txtNombre.Clear();
            txtMemoria.Clear();
            txtDuracion.Clear();
            txtNombre.Focus();
        }
        finally
        {
            btnAgregarProceso.Enabled = true;
        }
    }

    private void Gestor_SimulacionActualizada()
    {
        if (InvokeRequired)
        {
            BeginInvoke(ActualizarInterfaz);
            return;
        }

        ActualizarInterfaz();
    }

    private void ActualizarInterfaz()
    {
        lblRamTotalValor.Text = $"{GestorProcesos.MEMORIA_TOTAL} MB";
        lblRamUsadaValor.Text = $"{_gestor.MemoriaUtilizada} MB";
        lblRamDisponibleValor.Text = $"{_gestor.MemoriaDisponible} MB";

        int porcentaje = (int)Math.Round(
            (_gestor.MemoriaUtilizada / (double)GestorProcesos.MEMORIA_TOTAL) * 100);

        progressBarMemoria.Value = Math.Clamp(_gestor.MemoriaUtilizada, 0, GestorProcesos.MEMORIA_TOTAL);
        lblPorcentajeMemoria.Text = $"{porcentaje}%";

        ActualizarGridEjecucion();
        ActualizarGridEspera();
        ActualizarGridFinalizados();
    }

    private void ActualizarGridEjecucion()
    {
        dgvEjecucion.Rows.Clear();

        foreach (var proceso in _gestor.ProcesosEjecucion)
        {
            int indice = dgvEjecucion.Rows.Add(
                proceso.PID,
                proceso.Nombre,
                $"{proceso.MemoriaRequerida} MB",
                $"{proceso.Duracion} s",
                $"{proceso.TiempoRestante} s",
                proceso.Estado);

            dgvEjecucion.Rows[indice].Tag = proceso;
        }

        ActualizarEstadoBotonCancelarEjecucion();
    }

    private void ActualizarGridEspera()
    {
        dgvEspera.Rows.Clear();

        foreach (var proceso in _gestor.ColaEspera)
        {
            int indice = dgvEspera.Rows.Add(
                proceso.PID,
                proceso.Nombre,
                $"{proceso.MemoriaRequerida} MB",
                $"{proceso.Duracion} s",
                proceso.Estado);

            dgvEspera.Rows[indice].Tag = proceso;
        }

        ActualizarEstadoBotonCancelarEspera();
    }

    private void ActualizarGridFinalizados()
    {
        dgvFinalizados.Rows.Clear();

        foreach (var proceso in _gestor.ProcesosFinalizados)
        {
            int indice = dgvFinalizados.Rows.Add(
                proceso.PID,
                proceso.Nombre,
                $"{proceso.MemoriaRequerida} MB",
                proceso.Estado);

            // Guarda la referencia al proceso finalizado para poder re-ejecutarlo.
            dgvFinalizados.Rows[indice].Tag = proceso;
        }

        ActualizarEstadoBotonReejecutar();
    }

    private void dgvFinalizados_SelectionChanged(object? sender, EventArgs e)
    {
        ActualizarEstadoBotonReejecutar();
    }

    private void dgvEjecucion_SelectionChanged(object? sender, EventArgs e)
    {
        ActualizarEstadoBotonCancelarEjecucion();
    }

    private void dgvEspera_SelectionChanged(object? sender, EventArgs e)
    {
        ActualizarEstadoBotonCancelarEspera();
    }

    /// <summary>
    /// Habilita el botón de cancelación solo cuando hay un proceso en ejecución seleccionado.
    /// </summary>
    private void ActualizarEstadoBotonCancelarEjecucion()
    {
        btnCancelarEjecucion.Enabled = dgvEjecucion.SelectedRows.Count > 0
            && dgvEjecucion.SelectedRows[0].Tag is Proceso;
    }

    /// <summary>
    /// Habilita el botón de cancelación solo cuando hay un proceso en cola seleccionado.
    /// </summary>
    private void ActualizarEstadoBotonCancelarEspera()
    {
        btnCancelarEspera.Enabled = dgvEspera.SelectedRows.Count > 0
            && dgvEspera.SelectedRows[0].Tag is Proceso;
    }

    /// <summary>
    /// Habilita el botón de re-ejecución solo cuando hay un proceso finalizado seleccionado.
    /// </summary>
    private void ActualizarEstadoBotonReejecutar()
    {
        btnVolverAEjecutar.Enabled = dgvFinalizados.SelectedRows.Count > 0
            && dgvFinalizados.SelectedRows[0].Tag is Proceso;
    }

    private async void btnVolverAEjecutar_Click(object sender, EventArgs e)
    {
        if (dgvFinalizados.SelectedRows.Count == 0
            || dgvFinalizados.SelectedRows[0].Tag is not Proceso procesoOriginal)
        {
            return;
        }

        btnVolverAEjecutar.Enabled = false;

        try
        {
            // Crea una instancia nueva con los mismos datos; el PID y la admisión
            // se resuelven en AgregarProceso, igual que al agregar un proceso manual.
            var resultado = await Task.Run(() => _gestor.AgregarProceso(
                procesoOriginal.Nombre,
                procesoOriginal.MemoriaRequerida,
                procesoOriginal.Duracion));

            if (!resultado.Exito)
            {
                MessageBox.Show(
                    resultado.Error ?? "No se pudo volver a ejecutar el proceso.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        finally
        {
            ActualizarEstadoBotonReejecutar();
        }
    }

    private async void btnCancelarEjecucion_Click(object sender, EventArgs e)
    {
        if (dgvEjecucion.SelectedRows.Count == 0
            || dgvEjecucion.SelectedRows[0].Tag is not Proceso proceso)
        {
            return;
        }

        btnCancelarEjecucion.Enabled = false;

        try
        {
            await Task.Run(() => _gestor.CancelarProceso(proceso));
        }
        finally
        {
            ActualizarEstadoBotonCancelarEjecucion();
        }
    }

    private async void btnCancelarEspera_Click(object sender, EventArgs e)
    {
        if (dgvEspera.SelectedRows.Count == 0
            || dgvEspera.SelectedRows[0].Tag is not Proceso proceso)
        {
            return;
        }

        btnCancelarEspera.Enabled = false;

        try
        {
            await Task.Run(() => _gestor.CancelarProceso(proceso));
        }
        finally
        {
            ActualizarEstadoBotonCancelarEspera();
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _gestor.SimulacionActualizada -= Gestor_SimulacionActualizada;
        base.OnFormClosed(e);
    }
}
