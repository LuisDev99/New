using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lijer.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrecioView : PopupPage
	{
		public PrecioView ()
		{
			InitializeComponent ();
		}

        public async void onClosePageClick(object sender, EventArgs e)
        {
            await Navigation.RemovePopupPageAsync(this);
        }
    }
}