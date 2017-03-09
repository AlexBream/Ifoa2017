using IndacoNews.Entities;
using IndacoNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IndacoNews
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRefreshClicked(object sender, EventArgs e)
        {
            await GetLatestNews();
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }

        private async void OnDownloadNewsClicked(object sender, EventArgs e)
        {
            await GetLatestNews();
        }

        private async Task GetLatestNews()
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            RssService service = new RssService();
            IEnumerable<FeedItem> items = await service.GetNews("http://indaco.coop/feed/");
            News.ItemsSource = items;
            LoadingIndicator.IsRunning = false;
        }

        private void OnNewsSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FeedItem item = e.SelectedItem as FeedItem;
            if (item != null)
            {
                Device.OpenUri(new Uri(item.Link, UriKind.Absolute));
            }
        }

    }
}
