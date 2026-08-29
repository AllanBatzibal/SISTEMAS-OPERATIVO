namespace SimuladorGestionProcesos;

partial class FormPrincipal
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelEncabezado;
    private Label lblTitulo;
    private Button btnReiniciarSimulacion;
    private TableLayoutPanel layoutSuperior;
    private GroupBox grpCrearProceso;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblMemoria;
    private TextBox txtMemoria;
    private Label lblDuracion;
    private TextBox txtDuracion;
    private Button btnAgregarProceso;
    private Button btnGenerarAleatorios;
    private GroupBox grpMemoria;
    private Label lblRamTotal;
    private Label lblRamTotalValor;
    private Label lblRamUsada;
    private Label lblRamUsadaValor;
    private Label lblRamDisponible;
    private Label lblRamDisponibleValor;
    private ProgressBar progressBarMemoria;
    private Label lblPorcentajeMemoria;
    private TableLayoutPanel layoutPanelDerecho;
    private GroupBox grpMetricas;
    private Label lblTotalCreados;
    private Label lblTotalCreadosValor;
    private Label lblTotalFinalizados;
    private Label lblTotalFinalizadosValor;
    private Label lblEsperaPromedio;
    private Label lblEsperaPromedioValor;
    private Label lblPicoMemoria;
    private Label lblPicoMemoriaValor;
    private GroupBox grpEjecucion;
    private DataGridView dgvEjecucion;
    private Button btnCancelarEjecucion;
    private GroupBox grpEspera;
    private DataGridView dgvEspera;
    private Button btnCancelarEspera;
    private GroupBox grpFinalizados;
    private DataGridView dgvFinalizados;
    private Button btnVolverAEjecutar;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        panelEncabezado = new Panel();
        lblTitulo = new Label();
        btnReiniciarSimulacion = new Button();
        layoutSuperior = new TableLayoutPanel();
        grpCrearProceso = new GroupBox();
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblMemoria = new Label();
        txtMemoria = new TextBox();
        lblDuracion = new Label();
        txtDuracion = new TextBox();
        btnAgregarProceso = new Button();
        btnGenerarAleatorios = new Button();
        grpMemoria = new GroupBox();
        lblRamTotal = new Label();
        lblRamTotalValor = new Label();
        lblRamUsada = new Label();
        lblRamUsadaValor = new Label();
        lblRamDisponible = new Label();
        lblRamDisponibleValor = new Label();
        progressBarMemoria = new ProgressBar();
        lblPorcentajeMemoria = new Label();
        layoutPanelDerecho = new TableLayoutPanel();
        grpMetricas = new GroupBox();
        lblTotalCreados = new Label();
        lblTotalCreadosValor = new Label();
        lblTotalFinalizados = new Label();
        lblTotalFinalizadosValor = new Label();
        lblEsperaPromedio = new Label();
        lblEsperaPromedioValor = new Label();
        lblPicoMemoria = new Label();
        lblPicoMemoriaValor = new Label();
        grpEjecucion = new GroupBox();
        dgvEjecucion = new DataGridView();
        btnCancelarEjecucion = new Button();
        grpEspera = new GroupBox();
        dgvEspera = new DataGridView();
        btnCancelarEspera = new Button();
        grpFinalizados = new GroupBox();
        dgvFinalizados = new DataGridView();
        btnVolverAEjecutar = new Button();
        panelEncabezado.SuspendLayout();
        layoutSuperior.SuspendLayout();
        grpCrearProceso.SuspendLayout();
        layoutPanelDerecho.SuspendLayout();
        grpMemoria.SuspendLayout();
        grpMetricas.SuspendLayout();
        grpEjecucion.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEjecucion).BeginInit();
        grpEspera.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEspera).BeginInit();
        grpFinalizados.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvFinalizados).BeginInit();
        SuspendLayout();

        // panelEncabezado
        panelEncabezado.BackColor = Color.FromArgb(44, 62, 80);
        panelEncabezado.Controls.Add(btnReiniciarSimulacion);
        panelEncabezado.Controls.Add(lblTitulo);
        panelEncabezado.Dock = DockStyle.Top;
        panelEncabezado.Location = new Point(0, 0);
        panelEncabezado.Name = "panelEncabezado";
        panelEncabezado.Padding = new Padding(20, 16, 20, 16);
        panelEncabezado.Size = new Size(1184, 64);
        panelEncabezado.TabIndex = 0;

        // btnReiniciarSimulacion
        btnReiniciarSimulacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnReiniciarSimulacion.BackColor = Color.FromArgb(149, 165, 166);
        btnReiniciarSimulacion.Cursor = Cursors.Hand;
        btnReiniciarSimulacion.FlatAppearance.BorderSize = 0;
        btnReiniciarSimulacion.FlatStyle = FlatStyle.Flat;
        btnReiniciarSimulacion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnReiniciarSimulacion.ForeColor = Color.White;
        btnReiniciarSimulacion.Location = new Point(984, 16);
        btnReiniciarSimulacion.Name = "btnReiniciarSimulacion";
        btnReiniciarSimulacion.Size = new Size(180, 32);
        btnReiniciarSimulacion.TabIndex = 1;
        btnReiniciarSimulacion.Text = "REINICIAR SIMULACIÓN";
        btnReiniciarSimulacion.UseVisualStyleBackColor = false;
        btnReiniciarSimulacion.Click += btnReiniciarSimulacion_Click;

        // lblTitulo
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 16);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(520, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "SIMULADOR DE GESTIÓN DE PROCESOS EN MEMORIA";

        // layoutSuperior
        layoutSuperior.ColumnCount = 2;
        layoutSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layoutSuperior.Controls.Add(grpCrearProceso, 0, 0);
        layoutSuperior.Controls.Add(layoutPanelDerecho, 1, 0);
        layoutSuperior.Dock = DockStyle.Top;
        layoutSuperior.Location = new Point(0, 64);
        layoutSuperior.Name = "layoutSuperior";
        layoutSuperior.Padding = new Padding(16, 12, 16, 8);
        layoutSuperior.RowCount = 1;
        layoutSuperior.RowStyles.Add(new RowStyle(SizeType.Absolute, 280F));
        layoutSuperior.Size = new Size(1184, 292);
        layoutSuperior.TabIndex = 1;

        // layoutPanelDerecho
        layoutPanelDerecho.ColumnCount = 1;
        layoutPanelDerecho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPanelDerecho.Controls.Add(grpMemoria, 0, 0);
        layoutPanelDerecho.Controls.Add(grpMetricas, 0, 1);
        layoutPanelDerecho.Dock = DockStyle.Fill;
        layoutPanelDerecho.Location = new Point(597, 15);
        layoutPanelDerecho.Name = "layoutPanelDerecho";
        layoutPanelDerecho.RowCount = 2;
        layoutPanelDerecho.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
        layoutPanelDerecho.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
        layoutPanelDerecho.Size = new Size(568, 264);
        layoutPanelDerecho.TabIndex = 2;

        // grpCrearProceso
        grpCrearProceso.Controls.Add(lblNombre);
        grpCrearProceso.Controls.Add(txtNombre);
        grpCrearProceso.Controls.Add(lblMemoria);
        grpCrearProceso.Controls.Add(txtMemoria);
        grpCrearProceso.Controls.Add(lblDuracion);
        grpCrearProceso.Controls.Add(txtDuracion);
        grpCrearProceso.Controls.Add(btnGenerarAleatorios);
        grpCrearProceso.Controls.Add(btnAgregarProceso);
        grpCrearProceso.Dock = DockStyle.Fill;
        grpCrearProceso.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        grpCrearProceso.ForeColor = Color.FromArgb(44, 62, 80);
        grpCrearProceso.Location = new Point(19, 15);
        grpCrearProceso.Name = "grpCrearProceso";
        grpCrearProceso.Padding = new Padding(16);
        grpCrearProceso.Size = new Size(568, 264);
        grpCrearProceso.TabIndex = 0;
        grpCrearProceso.TabStop = false;
        grpCrearProceso.Text = "CREAR PROCESO";

        // lblNombre
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 9F);
        lblNombre.ForeColor = Color.FromArgb(52, 73, 94);
        lblNombre.Location = new Point(20, 36);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(54, 15);
        lblNombre.TabIndex = 0;
        lblNombre.Text = "Nombre:";

        // txtNombre
        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(20, 54);
        txtNombre.Name = "txtNombre";
        txtNombre.PlaceholderText = "Ej: Google Chrome (opcional)";
        txtNombre.Size = new Size(520, 25);
        txtNombre.TabIndex = 1;

        // lblMemoria
        lblMemoria.AutoSize = true;
        lblMemoria.Font = new Font("Segoe UI", 9F);
        lblMemoria.ForeColor = Color.FromArgb(52, 73, 94);
        lblMemoria.Location = new Point(20, 88);
        lblMemoria.Name = "lblMemoria";
        lblMemoria.Size = new Size(137, 15);
        lblMemoria.TabIndex = 2;
        lblMemoria.Text = "Memoria requerida (MB):";

        // txtMemoria
        txtMemoria.Font = new Font("Segoe UI", 10F);
        txtMemoria.Location = new Point(20, 106);
        txtMemoria.Name = "txtMemoria";
        txtMemoria.PlaceholderText = "Ej: 300";
        txtMemoria.Size = new Size(250, 25);
        txtMemoria.TabIndex = 2;

        // lblDuracion
        lblDuracion.AutoSize = true;
        lblDuracion.Font = new Font("Segoe UI", 9F);
        lblDuracion.ForeColor = Color.FromArgb(52, 73, 94);
        lblDuracion.Location = new Point(290, 88);
        lblDuracion.Name = "lblDuracion";
        lblDuracion.Size = new Size(110, 15);
        lblDuracion.TabIndex = 4;
        lblDuracion.Text = "Duración (segundos):";

        // txtDuracion
        txtDuracion.Font = new Font("Segoe UI", 10F);
        txtDuracion.Location = new Point(290, 106);
        txtDuracion.Name = "txtDuracion";
        txtDuracion.PlaceholderText = "Ej: 10";
        txtDuracion.Size = new Size(250, 25);
        txtDuracion.TabIndex = 3;

        // btnAgregarProceso
        btnAgregarProceso.BackColor = Color.FromArgb(52, 152, 219);
        btnAgregarProceso.Cursor = Cursors.Hand;
        btnAgregarProceso.FlatAppearance.BorderSize = 0;
        btnAgregarProceso.FlatStyle = FlatStyle.Flat;
        btnAgregarProceso.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        btnAgregarProceso.ForeColor = Color.White;
        btnAgregarProceso.Location = new Point(20, 148);
        btnAgregarProceso.Name = "btnAgregarProceso";
        btnAgregarProceso.Size = new Size(250, 38);
        btnAgregarProceso.TabIndex = 4;
        btnAgregarProceso.Text = "AGREGAR PROCESO";
        btnAgregarProceso.UseVisualStyleBackColor = false;
        btnAgregarProceso.Click += btnAgregarProceso_Click;

        // btnGenerarAleatorios
        btnGenerarAleatorios.BackColor = Color.FromArgb(155, 89, 182);
        btnGenerarAleatorios.Cursor = Cursors.Hand;
        btnGenerarAleatorios.FlatAppearance.BorderSize = 0;
        btnGenerarAleatorios.FlatStyle = FlatStyle.Flat;
        btnGenerarAleatorios.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnGenerarAleatorios.ForeColor = Color.White;
        btnGenerarAleatorios.Location = new Point(290, 148);
        btnGenerarAleatorios.Name = "btnGenerarAleatorios";
        btnGenerarAleatorios.Size = new Size(250, 38);
        btnGenerarAleatorios.TabIndex = 5;
        btnGenerarAleatorios.Text = "GENERAR PROCESOS ALEATORIOS";
        btnGenerarAleatorios.UseVisualStyleBackColor = false;
        btnGenerarAleatorios.Click += btnGenerarAleatorios_Click;

        // grpMemoria
        grpMemoria.Controls.Add(lblRamTotal);
        grpMemoria.Controls.Add(lblRamTotalValor);
        grpMemoria.Controls.Add(lblRamUsada);
        grpMemoria.Controls.Add(lblRamUsadaValor);
        grpMemoria.Controls.Add(lblRamDisponible);
        grpMemoria.Controls.Add(lblRamDisponibleValor);
        grpMemoria.Controls.Add(progressBarMemoria);
        grpMemoria.Controls.Add(lblPorcentajeMemoria);
        grpMemoria.Dock = DockStyle.Fill;
        grpMemoria.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        grpMemoria.ForeColor = Color.FromArgb(44, 62, 80);
        grpMemoria.Location = new Point(597, 15);
        grpMemoria.Name = "grpMemoria";
        grpMemoria.Padding = new Padding(16);
        grpMemoria.Size = new Size(568, 146);
        grpMemoria.TabIndex = 0;
        grpMemoria.TabStop = false;
        grpMemoria.Text = "ESTADO DE MEMORIA";

        // grpMetricas
        grpMetricas.Controls.Add(lblTotalCreados);
        grpMetricas.Controls.Add(lblTotalCreadosValor);
        grpMetricas.Controls.Add(lblTotalFinalizados);
        grpMetricas.Controls.Add(lblTotalFinalizadosValor);
        grpMetricas.Controls.Add(lblEsperaPromedio);
        grpMetricas.Controls.Add(lblEsperaPromedioValor);
        grpMetricas.Controls.Add(lblPicoMemoria);
        grpMetricas.Controls.Add(lblPicoMemoriaValor);
        grpMetricas.Dock = DockStyle.Fill;
        grpMetricas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        grpMetricas.ForeColor = Color.FromArgb(44, 62, 80);
        grpMetricas.Location = new Point(3, 155);
        grpMetricas.Name = "grpMetricas";
        grpMetricas.Padding = new Padding(16);
        grpMetricas.Size = new Size(562, 106);
        grpMetricas.TabIndex = 1;
        grpMetricas.TabStop = false;
        grpMetricas.Text = "MÉTRICAS";

        // lblTotalCreados
        lblTotalCreados.AutoSize = true;
        lblTotalCreados.Font = new Font("Segoe UI", 9F);
        lblTotalCreados.ForeColor = Color.FromArgb(52, 73, 94);
        lblTotalCreados.Location = new Point(20, 28);
        lblTotalCreados.Name = "lblTotalCreados";
        lblTotalCreados.Size = new Size(103, 15);
        lblTotalCreados.TabIndex = 0;
        lblTotalCreados.Text = "Procesos creados:";

        // lblTotalCreadosValor
        lblTotalCreadosValor.AutoSize = true;
        lblTotalCreadosValor.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblTotalCreadosValor.ForeColor = Color.FromArgb(44, 62, 80);
        lblTotalCreadosValor.Location = new Point(220, 26);
        lblTotalCreadosValor.Name = "lblTotalCreadosValor";
        lblTotalCreadosValor.Size = new Size(15, 19);
        lblTotalCreadosValor.TabIndex = 1;
        lblTotalCreadosValor.Text = "0";

        // lblTotalFinalizados
        lblTotalFinalizados.AutoSize = true;
        lblTotalFinalizados.Font = new Font("Segoe UI", 9F);
        lblTotalFinalizados.ForeColor = Color.FromArgb(52, 73, 94);
        lblTotalFinalizados.Location = new Point(300, 28);
        lblTotalFinalizados.Name = "lblTotalFinalizados";
        lblTotalFinalizados.Size = new Size(118, 15);
        lblTotalFinalizados.TabIndex = 2;
        lblTotalFinalizados.Text = "Procesos finalizados:";

        // lblTotalFinalizadosValor
        lblTotalFinalizadosValor.AutoSize = true;
        lblTotalFinalizadosValor.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblTotalFinalizadosValor.ForeColor = Color.FromArgb(44, 62, 80);
        lblTotalFinalizadosValor.Location = new Point(470, 26);
        lblTotalFinalizadosValor.Name = "lblTotalFinalizadosValor";
        lblTotalFinalizadosValor.Size = new Size(15, 19);
        lblTotalFinalizadosValor.TabIndex = 3;
        lblTotalFinalizadosValor.Text = "0";

        // lblEsperaPromedio
        lblEsperaPromedio.AutoSize = true;
        lblEsperaPromedio.Font = new Font("Segoe UI", 9F);
        lblEsperaPromedio.ForeColor = Color.FromArgb(52, 73, 94);
        lblEsperaPromedio.Location = new Point(20, 58);
        lblEsperaPromedio.Name = "lblEsperaPromedio";
        lblEsperaPromedio.Size = new Size(145, 15);
        lblEsperaPromedio.TabIndex = 4;
        lblEsperaPromedio.Text = "Espera promedio (seg.):";

        // lblEsperaPromedioValor
        lblEsperaPromedioValor.AutoSize = true;
        lblEsperaPromedioValor.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblEsperaPromedioValor.ForeColor = Color.FromArgb(52, 152, 219);
        lblEsperaPromedioValor.Location = new Point(220, 56);
        lblEsperaPromedioValor.Name = "lblEsperaPromedioValor";
        lblEsperaPromedioValor.Size = new Size(25, 19);
        lblEsperaPromedioValor.TabIndex = 5;
        lblEsperaPromedioValor.Text = "0.0";

        // lblPicoMemoria
        lblPicoMemoria.AutoSize = true;
        lblPicoMemoria.Font = new Font("Segoe UI", 9F);
        lblPicoMemoria.ForeColor = Color.FromArgb(52, 73, 94);
        lblPicoMemoria.Location = new Point(300, 58);
        lblPicoMemoria.Name = "lblPicoMemoria";
        lblPicoMemoria.Size = new Size(118, 15);
        lblPicoMemoria.TabIndex = 6;
        lblPicoMemoria.Text = "Pico de memoria (MB):";

        // lblPicoMemoriaValor
        lblPicoMemoriaValor.AutoSize = true;
        lblPicoMemoriaValor.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblPicoMemoriaValor.ForeColor = Color.FromArgb(231, 76, 60);
        lblPicoMemoriaValor.Location = new Point(470, 56);
        lblPicoMemoriaValor.Name = "lblPicoMemoriaValor";
        lblPicoMemoriaValor.Size = new Size(44, 19);
        lblPicoMemoriaValor.TabIndex = 7;
        lblPicoMemoriaValor.Text = "0 MB";

        // lblRamTotal
        lblRamTotal.AutoSize = true;
        lblRamTotal.Font = new Font("Segoe UI", 9F);
        lblRamTotal.ForeColor = Color.FromArgb(52, 73, 94);
        lblRamTotal.Location = new Point(20, 36);
        lblRamTotal.Name = "lblRamTotal";
        lblRamTotal.Size = new Size(68, 15);
        lblRamTotal.TabIndex = 0;
        lblRamTotal.Text = "RAM TOTAL:";

        // lblRamTotalValor
        lblRamTotalValor.AutoSize = true;
        lblRamTotalValor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblRamTotalValor.ForeColor = Color.FromArgb(44, 62, 80);
        lblRamTotalValor.Location = new Point(200, 32);
        lblRamTotalValor.Name = "lblRamTotalValor";
        lblRamTotalValor.Size = new Size(63, 20);
        lblRamTotalValor.TabIndex = 1;
        lblRamTotalValor.Text = "1024 MB";

        // lblRamUsada
        lblRamUsada.AutoSize = true;
        lblRamUsada.Font = new Font("Segoe UI", 9F);
        lblRamUsada.ForeColor = Color.FromArgb(52, 73, 94);
        lblRamUsada.Location = new Point(20, 68);
        lblRamUsada.Name = "lblRamUsada";
        lblRamUsada.Size = new Size(74, 15);
        lblRamUsada.TabIndex = 2;
        lblRamUsada.Text = "RAM USADA:";

        // lblRamUsadaValor
        lblRamUsadaValor.AutoSize = true;
        lblRamUsadaValor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblRamUsadaValor.ForeColor = Color.FromArgb(231, 76, 60);
        lblRamUsadaValor.Location = new Point(200, 64);
        lblRamUsadaValor.Name = "lblRamUsadaValor";
        lblRamUsadaValor.Size = new Size(44, 20);
        lblRamUsadaValor.TabIndex = 3;
        lblRamUsadaValor.Text = "0 MB";

        // lblRamDisponible
        lblRamDisponible.AutoSize = true;
        lblRamDisponible.Font = new Font("Segoe UI", 9F);
        lblRamDisponible.ForeColor = Color.FromArgb(52, 73, 94);
        lblRamDisponible.Location = new Point(20, 100);
        lblRamDisponible.Name = "lblRamDisponible";
        lblRamDisponible.Size = new Size(102, 15);
        lblRamDisponible.TabIndex = 4;
        lblRamDisponible.Text = "RAM DISPONIBLE:";

        // lblRamDisponibleValor
        lblRamDisponibleValor.AutoSize = true;
        lblRamDisponibleValor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblRamDisponibleValor.ForeColor = Color.FromArgb(39, 174, 96);
        lblRamDisponibleValor.Location = new Point(200, 96);
        lblRamDisponibleValor.Name = "lblRamDisponibleValor";
        lblRamDisponibleValor.Size = new Size(63, 20);
        lblRamDisponibleValor.TabIndex = 5;
        lblRamDisponibleValor.Text = "1024 MB";

        // progressBarMemoria
        progressBarMemoria.Location = new Point(20, 138);
        progressBarMemoria.Name = "progressBarMemoria";
        progressBarMemoria.Size = new Size(470, 24);
        progressBarMemoria.Style = ProgressBarStyle.Continuous;
        progressBarMemoria.TabIndex = 6;

        // lblPorcentajeMemoria
        lblPorcentajeMemoria.AutoSize = true;
        lblPorcentajeMemoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblPorcentajeMemoria.ForeColor = Color.FromArgb(44, 62, 80);
        lblPorcentajeMemoria.Location = new Point(500, 142);
        lblPorcentajeMemoria.Name = "lblPorcentajeMemoria";
        lblPorcentajeMemoria.Size = new Size(27, 15);
        lblPorcentajeMemoria.TabIndex = 7;
        lblPorcentajeMemoria.Text = "0%";

        // grpEjecucion
        grpEjecucion.Controls.Add(dgvEjecucion);
        grpEjecucion.Controls.Add(btnCancelarEjecucion);
        grpEjecucion.Dock = DockStyle.Top;
        grpEjecucion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        grpEjecucion.ForeColor = Color.FromArgb(44, 62, 80);
        grpEjecucion.Location = new Point(0, 356);
        grpEjecucion.Name = "grpEjecucion";
        grpEjecucion.Padding = new Padding(16, 20, 16, 16);
        grpEjecucion.Size = new Size(1184, 210);
        grpEjecucion.TabIndex = 2;
        grpEjecucion.TabStop = false;
        grpEjecucion.Text = "PROCESOS EN EJECUCIÓN";

        // btnCancelarEjecucion
        btnCancelarEjecucion.BackColor = Color.FromArgb(231, 76, 60);
        btnCancelarEjecucion.Cursor = Cursors.Hand;
        btnCancelarEjecucion.Dock = DockStyle.Bottom;
        btnCancelarEjecucion.Enabled = false;
        btnCancelarEjecucion.FlatAppearance.BorderSize = 0;
        btnCancelarEjecucion.FlatStyle = FlatStyle.Flat;
        btnCancelarEjecucion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnCancelarEjecucion.ForeColor = Color.White;
        btnCancelarEjecucion.Location = new Point(16, 164);
        btnCancelarEjecucion.Name = "btnCancelarEjecucion";
        btnCancelarEjecucion.Size = new Size(1152, 30);
        btnCancelarEjecucion.TabIndex = 1;
        btnCancelarEjecucion.Text = "CANCELAR";
        btnCancelarEjecucion.UseVisualStyleBackColor = false;
        btnCancelarEjecucion.Click += btnCancelarEjecucion_Click;

        // dgvEjecucion
        dgvEjecucion.Dock = DockStyle.Fill;
        dgvEjecucion.Location = new Point(16, 38);
        dgvEjecucion.Name = "dgvEjecucion";
        dgvEjecucion.Size = new Size(1152, 126);
        dgvEjecucion.TabIndex = 0;

        // grpEspera
        grpEspera.Controls.Add(dgvEspera);
        grpEspera.Controls.Add(btnCancelarEspera);
        grpEspera.Dock = DockStyle.Top;
        grpEspera.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        grpEspera.ForeColor = Color.FromArgb(44, 62, 80);
        grpEspera.Location = new Point(0, 566);
        grpEspera.Name = "grpEspera";
        grpEspera.Padding = new Padding(16, 20, 16, 16);
        grpEspera.Size = new Size(1184, 190);
        grpEspera.TabIndex = 3;
        grpEspera.TabStop = false;
        grpEspera.Text = "COLA DE ESPERA";

        // btnCancelarEspera
        btnCancelarEspera.BackColor = Color.FromArgb(231, 76, 60);
        btnCancelarEspera.Cursor = Cursors.Hand;
        btnCancelarEspera.Dock = DockStyle.Bottom;
        btnCancelarEspera.Enabled = false;
        btnCancelarEspera.FlatAppearance.BorderSize = 0;
        btnCancelarEspera.FlatStyle = FlatStyle.Flat;
        btnCancelarEspera.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnCancelarEspera.ForeColor = Color.White;
        btnCancelarEspera.Location = new Point(16, 144);
        btnCancelarEspera.Name = "btnCancelarEspera";
        btnCancelarEspera.Size = new Size(1152, 30);
        btnCancelarEspera.TabIndex = 1;
        btnCancelarEspera.Text = "CANCELAR";
        btnCancelarEspera.UseVisualStyleBackColor = false;
        btnCancelarEspera.Click += btnCancelarEspera_Click;

        // dgvEspera
        dgvEspera.Dock = DockStyle.Fill;
        dgvEspera.Location = new Point(16, 38);
        dgvEspera.Name = "dgvEspera";
        dgvEspera.Size = new Size(1152, 106);
        dgvEspera.TabIndex = 0;

        // grpFinalizados
        grpFinalizados.Controls.Add(dgvFinalizados);
        grpFinalizados.Controls.Add(btnVolverAEjecutar);
        grpFinalizados.Dock = DockStyle.Fill;
        grpFinalizados.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        grpFinalizados.ForeColor = Color.FromArgb(44, 62, 80);
        grpFinalizados.Location = new Point(0, 756);
        grpFinalizados.Name = "grpFinalizados";
        grpFinalizados.Padding = new Padding(16, 20, 16, 16);
        grpFinalizados.Size = new Size(1184, 175);
        grpFinalizados.TabIndex = 4;
        grpFinalizados.TabStop = false;
        grpFinalizados.Text = "PROCESOS FINALIZADOS";

        // btnVolverAEjecutar
        btnVolverAEjecutar.BackColor = Color.FromArgb(39, 174, 96);
        btnVolverAEjecutar.Cursor = Cursors.Hand;
        btnVolverAEjecutar.Dock = DockStyle.Bottom;
        btnVolverAEjecutar.Enabled = false;
        btnVolverAEjecutar.FlatAppearance.BorderSize = 0;
        btnVolverAEjecutar.FlatStyle = FlatStyle.Flat;
        btnVolverAEjecutar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnVolverAEjecutar.ForeColor = Color.White;
        btnVolverAEjecutar.Location = new Point(16, 129);
        btnVolverAEjecutar.Name = "btnVolverAEjecutar";
        btnVolverAEjecutar.Size = new Size(1152, 30);
        btnVolverAEjecutar.TabIndex = 1;
        btnVolverAEjecutar.Text = "VOLVER A EJECUTAR";
        btnVolverAEjecutar.UseVisualStyleBackColor = false;
        btnVolverAEjecutar.Click += btnVolverAEjecutar_Click;

        // dgvFinalizados
        dgvFinalizados.Dock = DockStyle.Fill;
        dgvFinalizados.Location = new Point(16, 38);
        dgvFinalizados.Name = "dgvFinalizados";
        dgvFinalizados.Size = new Size(1152, 91);
        dgvFinalizados.TabIndex = 0;

        // FormPrincipal
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(236, 240, 241);
        ClientSize = new Size(1184, 901);
        Controls.Add(grpFinalizados);
        Controls.Add(grpEspera);
        Controls.Add(grpEjecucion);
        Controls.Add(layoutSuperior);
        Controls.Add(panelEncabezado);
        Font = new Font("Segoe UI", 9F);
        Name = "FormPrincipal";
        panelEncabezado.ResumeLayout(false);
        panelEncabezado.PerformLayout();
        layoutSuperior.ResumeLayout(false);
        grpCrearProceso.ResumeLayout(false);
        grpCrearProceso.PerformLayout();
        layoutPanelDerecho.ResumeLayout(false);
        grpMemoria.ResumeLayout(false);
        grpMemoria.PerformLayout();
        grpMetricas.ResumeLayout(false);
        grpMetricas.PerformLayout();
        grpEjecucion.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEjecucion).EndInit();
        grpEspera.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEspera).EndInit();
        grpFinalizados.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvFinalizados).EndInit();
        ResumeLayout(false);
    }
}
