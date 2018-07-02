using SQLite.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaTareas : ContentPage
	{
		public ListaTareas ()
		{
			InitializeComponent ();

            var btnAdd = new ToolbarItem()
            {
                Text = "+"
            };

            btnAdd.Clicked += BtnAdd_Clicked;
            ToolbarItems.Add(btnAdd);
		}

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoItem());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conexion = new SQLiteConnection(App.RutaDB))
            {
                List<Tarea> lista = conexion.Table<Tarea>().Where(x => x.Completada == false).ToList();
                listaTareasListView.ItemsSource = lista;
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(App.RutaDB))
            {
                var tareaAcompletar = (sender as MenuItem).CommandParameter as Tarea;
                tareaAcompletar.Completada = true;

                conexion.Update(tareaAcompletar);

                List<Tarea> listaTareasFiltrada = conexion.Table<Tarea>().Where(x => x.Completada == false).ToList();
                listaTareasListView.ItemsSource = listaTareasFiltrada;
            }
        }
    }
}