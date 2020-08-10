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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1unversal2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Random random = new Random();
        DispatcherTimer enemyTimer = new DispatcherTimer();
        DispatcherTimer targetTimer = new DispatcherTimer();

        bool humanCaptured = false;

        public MainPage()
        {
            this.InitializeComponent();

            enemyTimer.Tick += EnemyTimer_Tick;
            enemyTimer.Interval = TimeSpan.FromSeconds(2);//dodaje enemy

            targetTimer.Tick += TargetTimer_Tick;
            targetTimer.Interval = TimeSpan.FromSeconds(.1);//odlicza czas
        }

        private void TargetTimer_Tick(object sender, object e)
        {
            progressBar.Value += 1;
            if (progressBar.Value >= progressBar.Maximum)
                EndTheGame();
        }

        private void EnemyTimer_Tick(object sender, object e)
        {
            AddEnemy();
        }

        private void EndTheGame()
        {
           if(!playArea.Children.Contains(gameOverText))//jesli nie zawiera gameOverText
            {
                enemyTimer.Stop();
                targetTimer.Stop();
                humanCaptured = false;
                startButton.Visibility = Visibility.Visible;
                playArea.Children.Add(gameOverText);
            }
        }

       

        private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToAnimate)
        {
            Storyboard storyboard = new Storyboard()
            { 
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            DoubleAnimation animation = new DoubleAnimation()//animacja Z DO
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
            };

            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartGame();

        }

        private void StartGame()
        {
            human.IsHitTestVisible = true;
            humanCaptured = false;
            progressBar.Value = 0;
            startButton.Visibility = Visibility.Collapsed;
            playArea.Children.Clear();
            playArea.Children.Add(target);
            playArea.Children.Add(human);
            enemyTimer.Start();
            targetTimer.Start();

        }

        private void AddEnemy()
        {          
            
           ContentControl enemy = new ContentControl();
           enemy.Template = Resources["enemyTemplate"] as ControlTemplate;

           AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, "(Canvas.Left)");

           AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100),
              random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");

           playArea.Children.Add(enemy);

            enemy.PointerEntered += enemy_PointerEntered;
        }

        private void enemy_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if(humanCaptured)
            {
                EndTheGame();
            }
        }

        private void human_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if(enemyTimer.IsEnabled)
            {
                humanCaptured = true;
                human.IsHitTestVisible = false;
            }
        }

        private void target_PointerEntered(object sender, PointerRoutedEventArgs e)//jesli dojdzie w portal
        {
            if(targetTimer.IsEnabled && humanCaptured)
            {
                progressBar.Value = 0;
                Canvas.SetLeft(target, random.Next(100, (int)playArea.ActualWidth - 100));
                Canvas.SetTop(target, random.Next(100, (int)playArea.ActualHeight - 100));
                //Canvas.SetLeft(target, random.Next(100, (int)playArea.ActualWidth - 100));
               // Canvas.SetTop(target, random.Next(100, (int)playArea.ActualHeight - 100));
                humanCaptured = false;
                human.IsHitTestVisible = true;
            }
        }

        private void playArea_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if(humanCaptured)
            {
                Point pointerPosition = e.GetCurrentPoint(null).Position;
                Point relativePosition = grid.TransformToVisual(playArea).TransformPoint(pointerPosition);
                if(Math.Abs(relativePosition.X-Canvas.GetLeft(human))>human.ActualWidth*3
                    || (Math.Abs(relativePosition.Y-Canvas.GetTop(human))>human.ActualHeight*3))
                    {
                    humanCaptured = true;
                    human.IsHitTestVisible = true;
                }
                else
                {
                    Canvas.SetLeft(human, relativePosition.X - human.ActualWidth / 2);
                    Canvas.SetTop(human, relativePosition.Y - human.ActualHeight / 2);
                }
            }
        }

        private void playArea_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if(humanCaptured)
            {
                EndTheGame();
            }

        }
    }
}
