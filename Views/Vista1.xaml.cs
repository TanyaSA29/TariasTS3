using System.Text.RegularExpressions;

namespace TariasTS3.Views;

public partial class Vista1 : ContentPage
{
	public Vista1()
	{
		InitializeComponent();
	}
    private async void OnVerDetallesClicked(object sender, EventArgs e)
    {
        OcultarError();

        if (pickerTipo.SelectedIndex == -1)
        {
            MostrarError("Seleccione un tipo de identificación.");
            return;
        }

        string tipo = pickerTipo.SelectedItem.ToString();
        string numero = entryNumero.Text?.Trim() ?? "";

     
        if (tipo == "CI" && !Regex.IsMatch(numero, "^\\d{10}$"))
        {
            MostrarError("La CI debe tener exactamente 10 números.");
            return;
        }

        if (tipo == "RUC" && !Regex.IsMatch(numero, "^\\d{13}$"))
        {
            MostrarError("El RUC debe tener exactamente 13 números.");
            return;
        }

        if (string.IsNullOrWhiteSpace(entryNombres.Text) ||
            !Regex.IsMatch(entryNombres.Text, "^[A-Za-zÀ-ÿ\\s]+$"))
        {
            MostrarError("Los nombres deben contener solo letras.");
            return;
        }

        if (string.IsNullOrWhiteSpace(entryApellidos.Text) ||
            !Regex.IsMatch(entryApellidos.Text, "^[A-Za-zÀ-ÿ\\s]+$"))
        {
            MostrarError("Los apellidos deben contener solo letras.");
            return;
        }

        if (string.IsNullOrWhiteSpace(entryCorreo.Text) ||
            !Regex.IsMatch(entryCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            MostrarError("El correo electrónico no es válido.");
            return;
        }

        if (!decimal.TryParse(entrySalario.Text, out decimal salario) || salario < 0)
        {
            MostrarError("Ingrese un salario válido");
            return;
        }

        // Datos correctos
        await DisplayAlert("Validación Exitosa",
            "Los datos fueron aceptados. ✨", "Continuar");
        await Navigation.PushAsync(new Vista2(
            tipo,
            numero,
            entryNombres.Text.Trim(),
            entryApellidos.Text.Trim(),
            dpFecha.Date,
            entryCorreo.Text.Trim(),
            salario
        ));
    }
    private void MostrarError(string mensaje)
    {
        lblError.Text = mensaje;
        frameError.IsVisible = true;
    }

    private void OcultarError()
    {
        frameError.IsVisible = false;
    }
}