namespace TariasTS3.Views;

public partial class Vista2 : ContentPage
{
    public string Tipo { get; set; } = "No especificado";
    public string Numero { get; set; } = "No especificado";
    public string Nombres { get; set; } = "No especificado";
    public string Apellidos { get; set; } = "No especificado";
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Correo { get; set; } = "No especificado";
    public decimal Salario { get; set; } = 0;
    public decimal AporteIESS { get; set; } = 0;



    public Vista2()
    {
        InitializeComponent();
        CargarLabels();
    }


    public Vista2(string tipo, string numero, string nombres, string apellidos, DateTime fecha, string correo, decimal salario)
    {
        InitializeComponent();

        Tipo = tipo;
        Numero = numero;
        Nombres = nombres;
        Apellidos = apellidos;
        Fecha = fecha;
        Correo = correo;
        Salario = salario;
        AporteIESS = Math.Round(salario * 0.0945m, 2);

        CargarLabels();
    }

    private void CargarLabels()
    {
        lblTipo.Text = $"Tipo de Identificación: {Tipo}";
        lblNumero.Text = $"Número: {Numero}";
        lblNombres.Text = $"Nombres: {Nombres}";
        lblApellidos.Text = $"Apellidos: {Apellidos}";
        lblFecha.Text = $"Fecha de Nacimiento: {Fecha:dd/MM/yyyy}";
        lblCorreo.Text = $"Correo: {Correo}";
        lblSalario.Text = $"Salario: ${Salario:N2}";
        lblIESS.Text = $"Aporte IESS (9.45%): ${AporteIESS:N2}";
    }


    private async void OnExportarClicked(object sender, EventArgs e)
    {
        try
        {
            string nombreArchivo = $"Contacto_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string ruta = Path.Combine(FileSystem.AppDataDirectory, nombreArchivo);

            string contenido = $"{lblTipo.Text}\n" +
                              $"{lblNumero.Text}\n" +
                              $"{lblNombres.Text}\n" +
                              $"{lblApellidos.Text}\n" +
                              $"{lblFecha.Text}\n" +
                              $"{lblCorreo.Text}\n" +
                              $"{lblSalario.Text}\n" +
                              $"{lblIESS.Text}";

            File.WriteAllText(ruta, contenido);

            await DisplayAlert("Éxito", $"Archivo guardado en:\n{ruta}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo guardar el archivo:\n{ex.Message}", "OK");
        }
    }
}