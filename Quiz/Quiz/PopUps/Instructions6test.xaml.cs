using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.PopUps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Instructions6test : PopupPage
    {
		public Instructions6test ()
		{
			InitializeComponent ();
            Random random = new Random();
            switch (random.Next(2))
            {
                case 0: image.Source = "dumldore2.png"; break;
                case 1: image.Source = "grum.png"; break;
            }
		}
	}
}