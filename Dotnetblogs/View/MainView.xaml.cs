using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Phone.Tasks;

namespace Dotnetblogs.View
{
    public partial class MainView : PhoneApplicationPage
    {
        public MainView()
        {
            InitializeComponent();
            loadFeed();
        }

        private void feedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void loadFeed()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new System.Uri("http://feeds.feedburner.com/dotnetblogspl"));
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show(e.Error.Message);
                    });
            }
            else
            {
                this.State["feed"] = e.Result;

                UpdateFeedList(e.Result);
            }
        }
    }
}