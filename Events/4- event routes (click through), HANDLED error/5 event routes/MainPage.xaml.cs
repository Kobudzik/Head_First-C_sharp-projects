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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _5_event_routes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<string> outputItems = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            output.ItemsSource = outputItems;
        }

        private void StackPanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource) 
                outputItems.Clear();

            outputItems.Add("The panel was pressed");
        }

        private void Border_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource) 
                outputItems.Clear(); 

             outputItems.Add("The border was pressed");
            
            if (borderSetsHandled.IsOn)
                e.Handled = true;
        }

        private void Ellipse_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource) 
                outputItems.Clear(); 

            outputItems.Add("The ellipse was pressed");

            if (ellipseSetsHandled.IsOn) 
                e.Handled = true;

        }

        private void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource)
                outputItems.Clear();

            outputItems.Add("The rectangle was pressed");

            if(rectangleSetsHandled.IsOn) 
                e.Handled = true;

        }

        private void UpdateHitTestButton(object sender, RoutedEventArgs e)
        {
            grayRectangle.IsHitTestVisible = newHitTestVisibleValue.IsOn;
        }

        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (sender == e.OriginalSource) 
                outputItems.Clear(); 

            outputItems.Add("The grid was pressed");
            
            if (gridSetsHandled.IsOn) 
                e.Handled = true;
        }
    }
}
