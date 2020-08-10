using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InvadersGame.View
{
    public sealed partial class InvadersGamePage : Page
    {
        public InvadersGamePage()
        {
            this.InitializeComponent();
        }

        private void playArea_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePlayAreaSize(playArea.RenderSize);
        }


        private void pageRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePlayAreaSize(new Size(e.NewSize.Width, e.NewSize.Height - 160));
        }

        private void UpdatePlayAreaSize(Size newPlayAreaSize)
        {
            double targetWidth;
            double targetHeight;
            if (newPlayAreaSize.Width > newPlayAreaSize.Height)
            {
                targetWidth = newPlayAreaSize.Height * 4 / 3;
                targetHeight = newPlayAreaSize.Height;
                double leftRightMargin = (newPlayAreaSize.Width - targetWidth) / 2;
                playArea.Margin = new Thickness(leftRightMargin, 0, leftRightMargin, 0);
            }
            else
            {
                targetHeight = newPlayAreaSize.Width * 3 / 4;
                targetWidth = newPlayAreaSize.Width;
                double topBottomMargin = (newPlayAreaSize.Height - targetHeight) / 2;
                playArea.Margin = new Thickness(0, topBottomMargin, 0, topBottomMargin);
            }
            playArea.Width = targetWidth;
            playArea.Height = targetHeight;
            InvadersViewModel.PlayAreaSize = playArea.RenderSize; 
        }







        //Keyboard event handlers 

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown += KeyDownHandler;
            Window.Current.CoreWindow.KeyUp += KeyUpHandler;
            base.OnNavigatedTo(e);        
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= KeyDownHandler;
            Window.Current.CoreWindow.KeyUp -= KeyUpHandler; 
            base.OnNavigatedFrom(e);
        }


        private void KeyDownHandler(object sender, KeyEventArgs e) 
        {
            InvadersViewModel.KeyDown(e.VirtualKey);
        }

        private void KeyUpHandler(object sender, KeyEventArgs e) 
        {
            InvadersViewModel.KeyUp(e.VirtualKey);
        }


        //event handlers for swipes and taps


        private void pageRoot_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e) 
        {
            if (e.Delta.Translation.X < -1) InvadersViewModel.LeftGestureStarted(); 
            else if (e.Delta.Translation.X > 1) InvadersViewModel.RightGestureStarted(); 
        }

        private void pageRoot_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e) 
        {
           InvadersViewModel.LeftGestureCompleted(); 
           InvadersViewModel.RightGestureCompleted(); 
        }

        private void pageRoot_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InvadersViewModel.Tapped(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InvadersViewModel.StartGame();
        }
    }

}
