using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace NaturalSoftware.IRKit.WinRT
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //IRKitProvider irkit = new IRKitProvider( @"IRKitA1A3.local" );
        //IRKitProvider irkit = new IRKitProvider( @"IRKitA1A3" );
        IRKitProvider irkit = new IRKitProvider( @"10.0.1.46" );

        public MainPage()
        {
            this.InitializeComponent();
        }

        string messages;

        private async void Button_Click( object sender, RoutedEventArgs e )
        {
            try {
                messages = await irkit.GetMessages();
                TextMessage.Text = "GetMesages : " + messages;
            }
            catch ( Exception ex ) {
                MessageDialog dlg = new MessageDialog( ex.Message );
                dlg.ShowAsync();
            }
        }

        private async void Button_Click_1( object sender, RoutedEventArgs e )
        {
            try {
                await irkit.PostMessages( messages );
            }
            catch ( Exception ex ) {
                MessageDialog dlg = new MessageDialog( ex.Message );
                dlg.ShowAsync();
            }
        }
    }
}
