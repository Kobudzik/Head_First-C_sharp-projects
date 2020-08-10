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

namespace animacja_powtorka.View
{
    public sealed partial class AnimatedImage : UserControl
    {
        public AnimatedImage()
        {
            this.InitializeComponent();
        }


        public AnimatedImage(IEnumerable<string> imageNames, TimeSpan interval) //overloaded constructor NOT USED HERE- USED WHEN CREATING OBJECTS IN c#
            : this()
        { 
            StartAnimation(imageNames, interval); 
        }

        public void StartAnimation(IEnumerable<string> imageNames, TimeSpan interval)   // creates storyboard and key frame animation objects to animate the Source property of the Image control. 
        {
            Storyboard storyboard = new Storyboard();
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
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

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        { 
            return new BitmapImage(new Uri("ms-appx:///Assets/" + imageFilename));
        }
    }

}

