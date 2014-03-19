using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace NaturalSoftware.IRKit.iOS
{
    public class MyViewController : UIViewController
    {
        //IRKitProvider irkit = new IRKitProvider( @"IRKitA1A3.local" );
        //IRKitProvider irkit = new IRKitProvider( @"IRKitA1A3" );
        IRKitProvider irkit = new IRKitProvider( @"10.0.1.46" );

        UIButton buttonGetMessage;
        UIButton buttonPostMessage;

        UILabel labelMessage;

        int numClicks = 0;
        float buttonWidth = 200;
        float buttonHeight = 50;

        string message;

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            {
                buttonGetMessage = UIButton.FromType( UIButtonType.RoundedRect );

                buttonGetMessage.Frame = new RectangleF(
                    View.Frame.Width / 2 - buttonWidth / 2,
                    View.Frame.Height / 2 - buttonHeight,
                    buttonWidth,
                    buttonHeight );

                buttonGetMessage.SetTitle( "Get", UIControlState.Normal );

                buttonGetMessage.TouchUpInside += async ( object sender, EventArgs e ) =>
                {
                    try {
                        labelMessage.Text = "GetMessages start";
                        message = await irkit.GetMessages();
                        labelMessage.Text = "GetMessages:" + message;
                    }
                    catch ( Exception ex ) {
                        labelMessage.Text = ex.Message;
                    }
                };

                buttonGetMessage.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                                                    UIViewAutoresizing.FlexibleBottomMargin;
                View.AddSubview( buttonGetMessage );
            }

            {
                buttonPostMessage = UIButton.FromType( UIButtonType.RoundedRect );

                buttonPostMessage.Frame = new RectangleF(
                    View.Frame.Width / 2 - buttonWidth / 2,
                    View.Frame.Height / 2,
                    buttonWidth,
                    buttonHeight );

                buttonPostMessage.SetTitle( "Post", UIControlState.Normal );

                buttonPostMessage.TouchUpInside += ( object sender, EventArgs e ) =>
                {
                    try {
                        irkit.PostMessages( message );
                    }
                    catch ( Exception ex) {
                        labelMessage.Text = ex.Message;
                    }
                };

                buttonPostMessage.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                                                     UIViewAutoresizing.FlexibleBottomMargin;
                View.AddSubview( buttonPostMessage );
            }

            {
                labelMessage =new UILabel();
                labelMessage.Frame = new RectangleF(
                    View.Frame.Width / 2 - buttonWidth / 2,
                    View.Frame.Height / 2 + buttonHeight,
                    buttonWidth,
                    buttonHeight );
                View.AddSubview( labelMessage );
            }

        }

    }
}

