using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace NaturalSoftware.IRKit.Android
{
    [Activity( Label = "NaturalSoftware.IRKit.Android", MainLauncher = true, Icon = "@drawable/icon" )]
    public class Activity1 : Activity
    {
        //IRKitProvider irkit = new IRKitProvider( @"IRKitA1A3.local" );
        //IRKitProvider irkit = new IRKitProvider( @"IRKitA1A3" );
        IRKitProvider irkit = new IRKitProvider( @"10.0.1.46" );

        string message;

        int count = 1;

        protected override void OnCreate( Bundle bundle )
        {
            base.OnCreate( bundle );

            // Set our view from the "main" layout resource
            SetContentView( Resource.Layout.Main );



            {
                // Get our button from the layout resource,
                // and attach an event to it
                Button button = FindViewById<Button>( Resource.Id.Get );

                button.Click += async delegate
                {
                    message = await irkit.GetMessages();

                    var textView = FindViewById<TextView>( Resource.Id.textView );
                    textView.Text = "GetMessages:" + message;
                };
            }

            {
                Button button = FindViewById<Button>( Resource.Id.Post );
                button.Click += async delegate
                {
                    await irkit.PostMessages( message );
                };
            }
        }
    }
}

