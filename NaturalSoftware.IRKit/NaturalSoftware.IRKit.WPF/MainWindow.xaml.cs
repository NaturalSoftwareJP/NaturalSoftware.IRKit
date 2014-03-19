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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NaturalSoftware.IRKit.WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        IRKitProvider irkit = new IRKitProvider( "IRKitA1A3.local" );

        public MainWindow()
        {
            InitializeComponent();
        }

        string messages;

        private async void Button_Click( object sender, RoutedEventArgs e )
        {
            messages = await irkit.GetMessages();
            TextMessage.Text = messages;
        }

        private async void Button_Click_1( object sender, RoutedEventArgs e )
        {
            await irkit.PostMessages( messages );
        }

        private async void Button_Click_2( object sender, RoutedEventArgs e )
        {
            TextMessage.Text = await irkit.PostKeys();
        }
    }
}
