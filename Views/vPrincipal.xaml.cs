
using System.Security.Cryptography.X509Certificates;

namespace TariasTS3.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal(string usuario, string contraseña)
	{
		InitializeComponent();
		txtUsuario.Text = "El usuario es: "+ usuario;
		txtContrasena.Text = "La contraseña es: "+ contraseña;
    }
       
    
}