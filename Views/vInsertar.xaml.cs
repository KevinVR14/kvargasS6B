using System.Net;

namespace kvargasS6B.Views;

public partial class vInsertar : ContentPage
{
	public vInsertar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient client = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			client.UploadValues("http://127.0.0.1/wsestudiantes/estudiante.php", "POST", parametros);
			Navigation.PushAsync(new vEstudiante());
        }
		catch (Exception ex)
		{
			DisplayAlert("Error", ex.Message, "Cerrar");
		}
    }
}