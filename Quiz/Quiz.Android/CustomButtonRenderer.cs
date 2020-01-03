using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Quiz;
using Quiz.CustomElements;
using Quiz.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Quiz.Droid
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            Android.Widget.Button button = Control as Android.Widget.Button;

            if (button != null)
            {
                //button.TextSize = 25;
                button.Gravity = GravityFlags.Left;
                button.SetPadding(0, 0, 0, 0);
            }
        }
    }
}