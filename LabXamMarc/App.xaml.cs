using LabXamMarc.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabXamMarc
{
    public partial class App : Application
    {
        static public CrimeViewModel Crimes { get; set; } = new CrimeViewModel();
        public App()
        {
            InitializeComponent();
            NavigationPage page = new NavigationPage(new MainPage());
            page.BarBackgroundColor = (Color)Application.Current.Resources["NavBar"];
            page.BarTextColor = (Color)Application.Current.Resources["BarColor"];
            MainPage = page;
        }

        protected override async void OnStart()
        {
            await Crimes.LoadCrimesAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
