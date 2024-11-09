using kvargasS6B.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace kvargasS6B.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://127.0.0.1/wsestudiantes/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estudiantes;

    public vEstudiante()
	{
		InitializeComponent();
        Listar();
	}

	public async void Listar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estudiantes = new ObservableCollection<Estudiante>(mostrarEstudiantes);
        lvEstudiantes.ItemsSource = estudiantes;
	}

    private void btnAbrir_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vInsertar());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var estudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminar(estudiante));
    }
}