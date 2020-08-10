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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalApp111_Brian_Excuse_redesign
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SetToCurrentTimeClick(object sender, RoutedEventArgs e)
        {
            excuseManager.SetToCurrentTime();
        }

        private void NewExcuseButtonClick(object sender, RoutedEventArgs e)
        {
            excuseManager.NewExcuseAsync();
        }

        private async void FolderButtonClick(object sender, RoutedEventArgs e)
        {
            bool folderChosen = await excuseManager.ChooseNewFolderAsync();
            
            if (folderChosen)
            {
                save.IsEnabled = true; 
                randomExcuse.IsEnabled = true;
            }

        }

        private void randomExcuse_Click(object sender, RoutedEventArgs e)
        {
            excuseManager.OpenRandomExcuseAsync();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            excuseManager.OpenExcuseAsync();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            excuseManager.SaveCurrentExcuseAsync();
        }

        private void saveAs_Click(object sender, RoutedEventArgs e)
        {
            excuseManager.SaveCurrentExcuseAsAsync();
        }
    }
}
