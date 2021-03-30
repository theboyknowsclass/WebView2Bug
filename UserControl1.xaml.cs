using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private WebView2 _webView2;

        public Window1()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            try
            {
                var coreWebView2Environment = await GetDefaultEnvironmentAsync();
                WebView2Host.Children.Clear();
                _webView2 = new WebView2();
                _webView2.CoreWebView2InitializationCompleted += WebView2_OnCoreWebView2InitializationCompleted;
                _webView2.ZoomFactor = 0.7;
                WebView2Host.Children.Add(_webView2);
                await _webView2.EnsureCoreWebView2Async(coreWebView2Environment);

            }
            catch (Exception e)
            {

            }
        }

        private async Task<CoreWebView2Environment> GetDefaultEnvironmentAsync()
        {
            try
            {
                return await CoreWebView2Environment.CreateAsync(null, "C:\\Temp");
            }
            catch (Exception e)
            {

                return null;
            }
        }

        private void WebView2_OnCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            _webView2.Source = new Uri("http://www.google.co.uk");
        }
    }
}