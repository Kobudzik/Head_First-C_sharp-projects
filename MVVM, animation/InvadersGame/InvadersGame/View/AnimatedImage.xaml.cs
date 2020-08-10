using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace InvadersGame.View
{
    public sealed partial class AnimatedImage : UserControl
    {
      
        public AnimatedImage()
        {

            this.InitializeComponent();
        }

        public AnimatedImage(IEnumerable<string> imageNames, TimeSpan interval)//konstuktor
            : this()
        {
            StartAnimation(imageNames, interval);
        }

        public void StartAnimation(IEnumerable<string> imageNames, TimeSpan interval)
        {
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTarget(animation, image);
            Storyboard.SetTargetProperty(animation, "Source");


            TimeSpan currentInterval = TimeSpan.FromMilliseconds(0);

            foreach (string imageName in imageNames)
            {
                ObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame();
                keyFrame.Value = CreateImageFromAssets(imageName);
                keyFrame.KeyTime = currentInterval;
                animation.KeyFrames.Add(keyFrame);
                currentInterval = currentInterval.Add(interval);
            }

            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            storyboard.AutoReverse = true;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }


        public void InvaderShot()
        {
            // invaderShotStoryboard is defined in the XAML for the user control AnimatedImage
            invaderShotStoryboard.Begin();
        }

        public void StartFlashing()
        {
            // flashStoryboard is defined in the XAML for the user control AnimatedImage
            flashStoryboard.Begin();
        }

        public void StopFlashing()
        {
            // flashStoryboard is defined in the XAML for the user control AnimatedImage
            flashStoryboard.Stop();
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/" + imageFilename));
        }
    }

}
