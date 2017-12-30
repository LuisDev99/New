
using System;
using System.Collections.ObjectModel;

namespace Lijer
{
    public class MainViewModel
    {
        private Producto _oldProducto;

        public ObservableCollection<Producto> Productos { get; set; }

        public MainViewModel()
        {
            Productos = new ObservableCollection<Producto>();

        }

        /// <summary>
        ///     Cuando el usuario le da click a la lista que viene de la API, aparecera un dropdown menu 
        ///     con tres botones o desaparecera el menu, dependiendo del estado de la visibilidad
        /// </summary>
        /// <param name="producto"></param>
        public void HideOrShowProduct(Producto producto)
        {
            if(_oldProducto == producto)
            {
                //Click en el mismo item hara que se desaparezca los botones
                producto.IsVisible = !producto.IsVisible;
                UpdateProducto(producto);
            }
            else
            {
                if(_oldProducto != null)
                {
                    //Esconder un item previamente abierto
                    _oldProducto.IsVisible = false;
                    UpdateProducto(_oldProducto);
                }
                //Mostrar item seleccionado
                producto.IsVisible = true;
                UpdateProducto(producto);
            }
            _oldProducto = producto;
        }

        private void UpdateProducto(Producto producto)
        {
            
            var index = Productos.IndexOf(producto);
            Productos.Remove(producto);
            Productos.Insert(index, producto);
        }

        /// <summary>
        ///     Esta funcion lo que hace es limpiar la listview y cargar los productos que vienen del server
        ///     y cargarlos a la listview. Esta funcion se llamara cuando el usuario ya encontro el producto que quiere ver
        ///     y pues se cargaran los todos los nuevos resultados gracias a esta funcion
        /// </summary>
        /// <param name="nuevaLista">La lista de productos disponibles(este arreglo de strings viene como respuesta del servidor)</param>
        public void updateList(string[] nuevaLista)
        {
            Productos.Clear(); //Limpiar la lista para no guardar viejos valores
            _oldProducto = null;

            foreach (string str in nuevaLista)
            {
                Productos.Add(new Producto
                {
                    Title = str,
                });
            }
        }
    }

}
