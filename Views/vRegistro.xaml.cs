namespace TariasTS3.Views;

public partial class vRegistro : ContentPage
{
	public vRegistro()
	{
		InitializeComponent();
	}
	private void btnGuardar_Clicked(object sender, EventArgs e)
	{
		try
		{
			string usuario =txtUsuarioRegistro.Text;
			string contrasena = txtContrasenaRegistro.Text;
			Navigation.PushAsync(new vLogin(usuario, contrasena)); 
			DisplayAlert("Alerta", "Usuario registrado ", "OK");
        }
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
        }
    }
}