using System;
using Xamarin.Forms;

namespace ShellPlayground.Views
{
    public partial class NavigationView : ContentPage
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        private void OnPushClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)Activator.CreateInstance(GetType()));
        }

        private void OnPopClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnPopToRootClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void OnNewNavigationClicked(object sender, EventArgs e)
        {
            (Application.Current.MainPage as Shell).GoToAsync($"app://shell/playground/maincontent/bottomtab1/toptab2", true);
        }
    }
}