
using Lijer.Popup;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lijer

    //TODO: en la funcion onItemClick limpiar la funcion (osea quitar el switch que hace el updateList, el updateList deberia de ir solamente en requestApi desde ahora) ..>Done
    //TODO: Eliminar los arreglos de prueba --> Todavia no!
    //TODO: Empezar a implementar los popuppage en los botones de la listview y empezar a pensar como cargar los datos de la web a ese view y tambien diseñar las paginas (ver beatifulExample.xaml)
    //TODO: Investigar como pasar datos de un view a otro --> Hecho! Solo se pasa por parametro en el constructor el producto a buscar
    //TODO: Buscar un buen background
    //TODO: Solucionar el problema de Windows(las imagenes no aparecen en esa plataforma)
    //Ir a view -> Task List!
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuscarMedicina : ContentPage
	{
		public BuscarMedicina ()
		{
			InitializeComponent ();

            /*Desaparecer las listas (se puede hacer directamente en el xaml ! isVisible = false ! */
            RecomendationList.IsVisible = false;
            MedicinesList.IsVisible = false;         
		}

        #region variables de prueba
        public static string medicinaSeleccionada = null;
        List<string> medicinasSugeridas = new List<String>
        {
            "Panadol", "Vitaflenaco", "Aspirinas", "Sueros", "Jeringas", "Papel", "Frenillos", "Pastas", "Todo"
        };

        //Arreglos de prueba
        string[] panadoles = { "Azul", "Roja", "Verde", "UltraFuerte" };
        string[] jeringas = { "Pequeña", "Mediana", "Grande" };
        string[] aspirinas = { "Fuerte", "Bayern", "Barca XD" };

        #endregion varibales

        #region funciones

        #region Documentacion de la funcion
        /// <summary>
        ///   Cuando el usuario esta haciendo la busqueda de una medicina en el objeto searchBar +
        ///   se muestran las sugerencias parecidas a ese producto farmaceutico a medida que va escribiendo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion Documentacion de la funcion
        private void onSearchTypingEvent(object sender, EventArgs e)
        {
            var searchedMedicine = searchBar.Text;
            var medicinesFound = Enumerable.Empty<string>();
            MedicinesList.IsVisible = false;

            if(searchedMedicine.Length >= 1)
            {
                //TODO: Instead of using the list(medicinasSugeridas) the list should be brought from the api like shown below in the example

                /* 
                 * Basic example of how this code should be when the api is up and ready
                 * List<Productos> RecommendedProducts = API.GetRecommendedMedicines(searchedMedicine); 
                 * foreach(Producto product in medicinesFound)
                 *     medicinesFound.add(product.Title);
                 * RecomendationList.ItemsSource = medicinesFound;
                 * RecomendationList.IsVisible = true; 
                 
                 */

                medicinesFound = medicinasSugeridas.Where(respuesta => respuesta.ToLower().Contains(searchedMedicine.ToLower()));
                RecomendationList.ItemsSource = medicinesFound;
                RecomendationList.IsVisible = true;
            }
            else
            {
                RecomendationList.IsVisible = false;
            }
         
        }

        #region Documentacion de la funcion
        /// <summary>
        ///     Cuando el usuario le dio el boton de buscar desde su teclado, sucede este evento
        ///     Este evento sucede generalmente cuando la lista de sugerencias no pudo encontrar lo que el usuario esta buscando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion
        private async void onSearchButtonClick(object sender, EventArgs e)
        {
            var searchBar = sender as SearchBar;
            var producto = searchBar.Text;
            RecomendationList.IsVisible = false;
            requestAPI(producto);

            await DisplayAlert("Buscando producto....", producto, "OK");
        }
        
        #region Documentacion de la funcion
        /// <summary>
        ///     Esta funcion lo que hace es agarrar el item que selecciono el usuario de la lista de sugerencias y buscar ese item +
        ///     con la funcion requestAPI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        #endregion Documentacion de la funcion
        private void onItemClickEvent(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            medicinaSeleccionada = e.Item as string;
            requestAPI(medicinaSeleccionada); // <-- Idea, just leave it there
            searchBar.Text = medicinaSeleccionada;
            var vm = BindingContext as MainViewModel; //Get binded object 
            RecomendationList.IsVisible = false;

            switch (medicinaSeleccionada)
            {
                case "Panadol":
                    vm.updateList(panadoles);
                    break;
                case "Aspirinas":
                    vm.updateList(aspirinas);
                    break;
                case "Jeringas":
                    vm.updateList(jeringas);
                    break;
            }
            MedicinesList.IsVisible = true;

            #region ideas comentadas
            //buscarMedicinaAPI(medicinaSeleccionada);
            //await DisplayAlert("Haz seleccionado una medicina!", "La medicina es: " + medicinaSeleccionada, "Que bien, Cerrar");
            #endregion
        }

        #region Documentacion de la funcion
        /// <summary>
        ///     Este evento sucede cuando el usuario ya selecciono un item de la lista de recomendaciones 
        ///     y le aparece una nueva lista que seria la lista de medicinas o productos que trae el servidor
        ///     de respuesta y cuando selecciona un item le aparece un menu de botones (tres botones)
        ///     La clase que se encarga de mostrar y esconder esos botones es la clase MainViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion Documentacion de la funcion
        private void onItemFromListaAPIClickEvent(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as MainViewModel; //vm representa View model
            var producto = e.Item as Producto;
            vm.HideOrShowProduct(producto);
        }

        #region Documentacion de la funcion
        /// <summary>
        ///     Este evento viene cuando el usuario le da click a la lista que trae el servidor de respuesta
        ///     y abre un menu con tres botones y dependiendo que boton le dio click el usuario tomara una accion esta funcion
        ///     Esas acciones son abrir otras pantallas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion Documentacion de la funcion
        private  void onItemButtonClicked(object sender, EventArgs e)
        {
            var btnClickeado = sender as Button;
            switch (btnClickeado.Text)
            {
                case "Info":
                    //Navigation.PushPopupAsync(new InfoView());
                    Navigation.PushPopupAsync(new BeatifulExample());
                    break;
                case "Por precio":
                    Navigation.PushPopupAsync(new PrecioView());
                    break;
                case "Por ubicacion":
                    Navigation.PushPopupAsync(new UbicacionView());
                    break;       
            }       

        }

        #region Documentacion de la funcion
        /// <summary>
        ///     Buscar en el servidor la medicinas relacionadas a este producto
        /// </summary>
        /// <param name="producto"></param>
        #endregion
        public async void requestAPI(string producto)
        {
            //TODO: requestApi fucntion
            /*
             *  Primero: Request Server
             *  Segundo: Parse Json
             *  Tercero: Get All Productos related names and make an array
             *  Cuarto: MainViewModel.updateList(serverArray) para que la listview tenga items del producto buscado
             */

            }

            #endregion funciones

        }

}