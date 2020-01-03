using Plugin.Settings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Quiz
{
    public partial class App : Application
    {
        public static bool IsVibrationOn = CrossSettings.Current.GetValueOrDefault("IsVibrationOn", true);
        public static bool IsMusicOn = CrossSettings.Current.GetValueOrDefault("IsMusicOn", true);
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
