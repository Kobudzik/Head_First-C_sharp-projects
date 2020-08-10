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
using Windows.UI.Popups;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalApp4_pancakes_redesign
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();
        MessageDialog msgbox = new MessageDialog("Sample");
        Lumberjack nextLumberjack;
        int lastAmount;

        public MainPage()
        {
            this.InitializeComponent();
            foreach (Flapjack flap in Enum.GetValues(typeof(Flapjack)))
            {
                flapjackList.Items.Add(flap);
            }
        }




        private void addFlapjacksButton_Click(object sender, RoutedEventArgs e)
        {
            if (breakfastLine.Count == 0)//jesli wszyscy zjedli to nic nie rob
                return;
            Flapjack selectedFood;
            if (flapjackList.SelectedIndex == (int)Flapjack.Crispy)
                selectedFood = Flapjack.Crispy;
            else if (flapjackList.SelectedIndex == (int)Flapjack.Soggy)
                selectedFood = Flapjack.Soggy;
            else if (flapjackList.SelectedIndex == (int)Flapjack.Browned)
                selectedFood = Flapjack.Browned;
            else selectedFood = Flapjack.Banana;

            Lumberjack currentLumberjack = breakfastLine.Peek();//dla aktualnego klienta
            currentLumberjack.TakeFlapjacks(selectedFood, int.Parse(ammountBox.Text));//dodaj wybrane nalesniki na stack
            RedrawList();
            Debug.WriteLine("Dodano " + selectedFood.ToString().ToLower() + ". W ilości: " + int.Parse(ammountBox.Text));



        }

        private void addLumberjackButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(lumberjackNameBox.Text)) return;
            breakfastLine.Enqueue(new Lumberjack(lumberjackNameBox.Text));
            lumberjackNameBox.Text = "";
            RedrawList();
        }

        private void nextLumberjackButton_Click(object sender, RoutedEventArgs e)
        {
            if (breakfastLine.Count == 0)
                msgbox.Content = "There are no clients here!";
            else
            {
                nextLumberjack = breakfastLine.Dequeue();
                lastAmount = nextLumberjack.FlapjackCount;
                nextLumberjack.EatFlapjacks();
                //breakfastLine.Dequeue().EatFlapjacks();            
                RedrawList();
            }
        }


        public void RedrawList()
        {

            //if (breakfastLine.Count == 0)
            //{
            //    foreach (Button child in belowFeedPanel.Children)
            //        child.IsEnabled = false;
            //}
            //else
            //    foreach (Button child in belowFeedPanel.Children)
            //        child.IsEnabled = true; 

            laneList.Items.Clear();
            if(nextLumberjack!=null)
                 infoViewer.Content = nextLumberjack.Name + " ate " + lastAmount;



            int number = 1;
            foreach (Lumberjack client in breakfastLine)
            {
                laneList.Items.Add(number + ". " + client.Name);
                number++;
            }
        }
    }
}
