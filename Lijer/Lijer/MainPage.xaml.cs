using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Lijer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();     
		}

        private async void OpenWebCommand(Object sender,EventArgs e)
        {
            //await DisplayAlert("Hey", "Why u click me tho", "GTFO");  << FUNNY CODE
            //await DisplayAlert("Nothing", null, "Ful");

            await Navigation.PushAsync(new BuscarMedicina()); //Abrir nueva ventana
        }

        private void press(object sender, EventArgs e)
        {
            //Hacer un efecto visual cuando el usuario esta presionando el boton
            var btn = sender as Button;
            btn.TextColor = Color.Gray; //Simular click del boton
            btn.BorderColor = Color.Gray;
        }

        private void release(object sender, EventArgs e)
        {
            //Hacer un efecto visual cuando el usuario dejo de presionar el boton
            var btn = sender as Button;
            btn.TextColor = Color.White; //Simular cuando ya no hay click
            btn.BorderColor = Color.White;
        }

    }
}
