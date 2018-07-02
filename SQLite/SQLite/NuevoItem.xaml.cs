using SQLite.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NuevoItem : ContentPage
	{
		public NuevoItem ()
		{
			InitializeComponent ();
		}

        void Handle_Clicked(object sender, EventArgs e)
        {
            Tarea nuevaTarea = new Tarea()
            {
                Nombre = nombreEntry.Text,
                Fecha = fechaDatePicker.Date,
                Hora = horaTimePicker.Time,
                Completada = false
            };

            using(SQLiteConnection conexion = new SQLiteConnection(App.RutaDB))
            {
                conexion.CreateTable<Tarea>();
                var resultado = conexion.Insert(nuevaTarea);

                if (resultado > 0)
                    DisplayAlert("Exito", "Registro Guardado Correctamente", "OK!");

                else
                    DisplayAlert("Error", "No se guardo el registro", "OK!");
            }
        }
	}
}