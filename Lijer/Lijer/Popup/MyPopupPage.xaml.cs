using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Lijer.Popup
{
	public partial class MyPopupPage : PopupPage
	{
		public MyPopupPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        /*protected override Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }*/

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        /*protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }*/

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            return base.OnBackButtonPressed();
            
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }
    }
}