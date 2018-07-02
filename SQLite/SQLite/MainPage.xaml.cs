﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {            
            if(string.IsNullOrEmpty(usuarioEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
            {                
                resultadoLabel.Text = "Debe escribir usuario y contraseña";
            }
            else
            {
                resultadoLabel.Text = "Inicio de Sesión Exitosa";
                await Navigation.PushAsync(new ListaTareas());
            }
        }
    }
}
