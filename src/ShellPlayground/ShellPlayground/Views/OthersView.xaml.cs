using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellPlayground.Views
{
    public partial class OthersView : ContentPage
    {
        public OthersView()
        {
            InitializeComponent();
            AddSearchHandler("Search Added", SearchBoxVisiblity.Collapsable);
        }

        private void OnExpandSearchClicked(object sender, EventArgs e)
        {
            Shell.GetSearchHandler(this).SearchBoxVisibility = SearchBoxVisiblity.Expanded;
        }

        private void OnCollapseSearchClicked(object sender, EventArgs e)
        {
            Shell.GetSearchHandler(this).SearchBoxVisibility = SearchBoxVisiblity.Collapsable;
        }

        private void OnHideSearchClicked(object sender, EventArgs e)
        {
            Shell.GetSearchHandler(this).SearchBoxVisibility = SearchBoxVisiblity.Hidden;
        }

        private void OnHideTabsClicked(object sender, EventArgs e)
        {
            Shell.SetTabBarIsVisible(this, false);
        }

        private void OnShowTabsClicked(object sender, EventArgs e)
        {
            Shell.SetTabBarIsVisible(this, true);
        }

        private void OnHideNavClicked(object sender, EventArgs e)
        {
            Shell.SetNavBarIsVisible(this, false);
        }

        private void OnShowNavClicked(object sender, EventArgs e)
        {
            Shell.SetNavBarIsVisible(this, true);
        }

        private void OnAddTitleViewClicked(object sender, EventArgs e)
        {
            Shell.SetTitleView(this,
                new Label
                {
                    FontSize = 24,
                    TextColor = Color.White,
                    Text = "TitleView",
                    Margin = new Thickness(5, 10)
                });
        }

        private void OnRemoveTitleViewClicked(object sender, EventArgs e)
        {
            Shell.SetTitleView(this, null);
        }

        protected void AddSearchHandler(string placeholder, SearchBoxVisiblity visibility)
        {
            var searchHandler = new CustomSearchHandler
            {
                ShowsResults = true,
                ClearIconName = "Clear",
                QueryIconName = "Search",
                Placeholder = placeholder,
                SearchBoxVisibility = visibility,
                ClearPlaceholderEnabled = true
            };

            Shell.SetSearchHandler(this, searchHandler);
        }

        private class CustomSearchHandler : SearchHandler
        {
            protected async override void OnQueryChanged(string oldValue, string newValue)
            {
                base.OnQueryChanged(oldValue, newValue);

                if (string.IsNullOrEmpty(newValue))
                {
                    ItemsSource = null;
                }
                else
                {
                    List<string> results = new List<string>
                    {
                        newValue + "Test"
                    };

                    ItemsSource = results;

                    await Task.Delay(500);

                    results = new List<string>();

                    for (int i = 0; i < 10; i++)
                    {
                        results.Add(newValue + i);
                    }

                    ItemsSource = results;
                }
            }
        }
    }
}