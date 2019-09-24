using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Toolkit.Wpf.UI.XamlHost;

namespace ModernWpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var geolocator = new Windows.Devices.Geolocation.Geolocator() { DesiredAccuracyInMeters = 5 };
            var pos = await geolocator.GetGeopositionAsync();
            LongBlock.Text = $"{pos.Coordinate.Point.Position.Longitude:#.00}";
            LatBlock.Text = $"{pos.Coordinate.Point.Position.Latitude:#.00}";
            await TheMap.TrySetViewAsync(pos.Coordinate.Point, 15.0);
        }

        private void WindowsXamlHost_ChildChanged(object sender, EventArgs e)
        {
            if (sender is WindowsXamlHost windowsXamlHost &&
                windowsXamlHost.Child is Windows.UI.Xaml.Controls.TextBox textBox)
            {
                textBox.FontSize = 24;
                var executeCount = 0;
                Task.Run(() =>
                {
                    while (true)
                    {
                        executeCount++;
                        Dispatcher.BeginInvoke((Action)(() => {
                            textBox.Text =
                                string.Join(string.Empty,
                                    Enumerable.Range(0, 20).Select(i => i % 5 == executeCount % 5 ? "🍣" : "＞"));
                            WpfTextBox.Text = textBox.Text;
                        }));
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    }
                });
            }
        }
    }
}
