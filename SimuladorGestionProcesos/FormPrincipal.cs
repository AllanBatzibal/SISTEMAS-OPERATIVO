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
            dgvEjecucion.Rows.Add(
                proceso.PID,
                proceso.Nombre,
                $"{proceso.MemoriaRequerida} MB",
                $"{proceso.Duracion} s",
                $"{proceso.TiempoRestante} s",
                proceso.Estado);
        }
    }

    private void ActualizarGridEspera()
    {
        dgvEspera.Rows.Clear();

        foreach (var proceso in _gestor.ColaEspera)
        {
            dgvEspera.Rows.Add(
                proceso.PID,
                proceso.Nombre,
                $"{proceso.MemoriaRequerida} MB",
                $"{proceso.Duracion} s",
                proceso.Estado);
        }
    }

    private void ActualizarGridFinalizados()
    {
        dgvFinalizados.Rows.Clear();

        foreach (var proceso in _gestor.ProcesosFinalizados)
        {
            dgvFinalizados.Rows.Add(
                proceso.PID,
                proceso.Nombre,
                $"{proceso.MemoriaRequerida} MB",
                proceso.Estado);
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _gestor.SimulacionActualizada -= Gestor_SimulacionActualizada;
        base.OnFormClosed(e);
    }
}
