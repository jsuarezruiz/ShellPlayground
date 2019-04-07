using System.Diagnostics;
using Xamarin.Forms;

namespace ShellPlayground
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        void OnShellNavigating(object sender, ShellNavigatingEventArgs e)
        {
            Debug.WriteLine($"Current: {e.Current?.Location}");
            Debug.WriteLine($"Source: {e.Source}");
            Debug.WriteLine($"Target: {e.Target?.Location}");
            Debug.WriteLine($"CanCancel: {e.CanCancel}");
        }
    }
}