namespace TariasTS3.Views;

public partial class vLogin : ContentPage
{
	public vLogin()
	{
        InitializeComponent();
	}
	string usuario = "";
	string contrasena = "";
    public vLogin(string usuarioregistro, string contrasenaregistro)
	{

		InitializeComponent();
		usuario = usuarioregistro; //renato
		contrasena = contrasenaregistro; //123

    }

	private void btnIniciarSesion_Clicked(object sender, EventArgs e)
	{
		try
		{
			string usuarioIngresado = txtUsuario.Text;
			string contrasenaIngresada = txtContrasena.Text;
			if (usuario == usuarioIngresado && contrasena == contrasenaIngresada)
			{
				Navigation.PushAsync(new vPrincipal(usuario, contrasena));
			}
			else
			{
				DisplayAlert("Alerta", "Usuario o contraseña incorrectos", "Cerrar");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("ERROR" +ex.Message);
		}
        

    }
	private void btnRegistro_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new vRegistro()); //abre registro
    }
}