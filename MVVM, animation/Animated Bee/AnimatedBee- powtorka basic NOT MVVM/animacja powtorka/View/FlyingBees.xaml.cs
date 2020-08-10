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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace animacja_powtorka.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlyingBees : Page
    {
        public FlyingBees()
        {
            this.InitializeComponent();


            List<string> imageNames = new List<string>();

            imageNames.Add("Bee animation 1.png");
            imageNames.Add("Bee animation 2.png");
            imageNames.Add("Bee animation 3.png");
            imageNames.Add("Bee animation 4.png");

            firstBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(50));//obiekty juz zrobione- w xamlu
            secondBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(10));
            thirdBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(100));

            //TYLKO RUSZANIE- animacja osobno
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            Storyboard.SetTarget(animation, firstBee);
            Storyboard.SetTargetProperty(animation, "(Canvas.Left)");
            animation.From = 50;
            animation.To = 450;
            animation.Duration = TimeSpan.FromSeconds(3);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
