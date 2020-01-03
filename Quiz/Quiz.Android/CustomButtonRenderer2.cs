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
using Quiz.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton2), typeof(CustomButtonRenderer2))]

namespace Quiz.Droid
{
    class CustomButtonRenderer2 : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            Android.Widget.Button button = Control as Android.Widget.Button;

            if (button != null)
            {
                button.Gravity = GravityFlags.Center;
                button.SetPadding(0, 0, 0, 0);
            }
        }
    }
}