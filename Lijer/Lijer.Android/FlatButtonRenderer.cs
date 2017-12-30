using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Lijer;
using Lijer.Droid;
using Android.Content;
using Android.Views;

///Esta clase es para darle borde al boton cuando este en android, en ios no es necesario hacer esto

[assembly: ExportRenderer(typeof(Button), typeof(FlatButtonRenderer))]
namespace Lijer
{
    public class FlatButtonRenderer : ButtonRenderer
    {
       
        public FlatButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) {
            base.OnElementChanged(e);
           /* Android.Widget.Button thisButton = Control as Android.Widget.Button;
            thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) => 
            {
                if (e2.Event.Action == MotionEventActions.Down)
                {
                    Control.SetTextColor(Android.Graphics.Color.Gray);
                }
                else if (e2.Event.Action == MotionEventActions.Up)
                {
                    Control.SetTextColor(Android.Graphics.Color.White);
                    System.Diagnostics.Debug.WriteLine("TouchDownEvent");
                }
                
            };*/
        }

    }
}