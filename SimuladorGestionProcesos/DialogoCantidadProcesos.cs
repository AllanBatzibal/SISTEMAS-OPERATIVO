namespace SimuladorGestionProcesos;

/// <summary>
/// Diálogo para solicitar cuántos procesos aleatorios se desean generar.
/// </summary>
public class DialogoCantidadProcesos : Form
{
    private readonly Label lblCantidad = new();
    private readonly NumericUpDown numCantidad = new();
    private readonly Button btnAceptar = new();
    private readonly Button btnCancelar = new();

    /// <summary>
    /// Cantidad de procesos seleccionada por el usuario (entre 1 y 20).
    /// </summary>
    public int CantidadSeleccionada => (int)numCantidad.Value;

    public DialogoCantidadProcesos()
    {
        Text = "Generar procesos aleatorios";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(320, 150);
        Font = new Font("Segoe UI", 9F);
        BackColor = Color.FromArgb(236, 240, 241);

        lblCantidad.AutoSize = true;
        lblCantidad.Location = new Point(20, 24);
        lblCantidad.Text = "¿Cuántos procesos desea generar? (1-20)";

        numCantidad.Location = new Point(20, 50);
        numCantidad.Size = new Size(280, 25);
        numCantidad.Minimum = 1;
        numCantidad.Maximum = 20;
        numCantidad.Value = 5;

        btnAceptar.Text = "Generar";
        btnAceptar.DialogResult = DialogResult.OK;
        btnAceptar.BackColor = Color.FromArgb(52, 152, 219);
        btnAceptar.FlatStyle = FlatStyle.Flat;
        btnAceptar.FlatAppearance.BorderSize = 0;
        btnAceptar.ForeColor = Color.White;
        btnAceptar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnAceptar.Location = new Point(124, 95);
        btnAceptar.Size = new Size(85, 32);

        btnCancelar.Text = "Cancelar";
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.FlatAppearance.BorderSize = 0;
        btnCancelar.ForeColor = Color.White;
        btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnCancelar.Location = new Point(215, 95);
        btnCancelar.Size = new Size(85, 32);

        Controls.Add(lblCantidad);
        Controls.Add(numCantidad);
        Controls.Add(btnAceptar);
        Controls.Add(btnCancelar);

        AcceptButton = btnAceptar;
        CancelButton = btnCancelar;
    }
}
