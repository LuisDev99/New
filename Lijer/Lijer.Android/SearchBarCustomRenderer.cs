using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Lijer;
using Lijer.Droid;
using Android.Content;
using Android.Views;

using System;
using Android.OS;



///* Class is made to force the search bar to be render in android version cause apparently this is a bug in 7.0 */

//[assembly: ExportRenderer(typeof(SearchBar), typeof(SearchBarCustomRenderer))]
//namespace Lijer
//{
//    public class SearchBarCustomRenderer : SearchBarRenderer
//    {

//        public SearchBarCustomRenderer(Context context) : base(context)
//        {

//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
//        {
//            base.OnElementChanged(e);

//            if (Device.RuntimePlatform == Device.Android)
//            {
//                //Fixes an android bug where the search bar would be hidden
//                e.HeightRequest = 40.0;
//            }

//        }

//    }
//}