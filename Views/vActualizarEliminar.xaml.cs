using kvargasS6B.Models;
using System.Net;

namespace kvargasS6B.Views;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar()
	{
		InitializeComponent();
    }

    public vActualizarEliminar(Estudiante estudiante)
    {
        InitializeComponent();
        txtCodigo.Text = estudiante.codigo.ToString();
        txtNombre.Text = estudiante.nombre;
        txtApellido.Text = estudiante.apellido;
        txtEdad.Text = estudiante.edad.ToString();
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient client = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            client.UploadValues("http://127.0.0.1/wsestudiantes/estudiante.php?codigo="+ txtCodigo.Text + "&nombre="+ txtNombre.Text + "&apellido="+ txtApellido.Text + "&edad="+ txtEdad.Text, "PUT", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient client = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            client.UploadValues("http://127.0.0.1/wsestudiantes/estudiante.php?codigo="+ txtCodigo.Text, "DELETE", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}