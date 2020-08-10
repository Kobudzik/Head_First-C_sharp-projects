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

namespace test_binding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        PersonMaker personMakerObj = new PersonMaker();
        
        public MainPage()
        {
            DataContext = personMakerObj;
            this.InitializeComponent();
            personMakerObj.Persons.Add(new Person("Konrad"));
            personMakerObj.Persons.Add(new Person("Kamil"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            personMakerObj.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            personMakerObj.Persons.Add(new Person(newPersonName.Text));
        }
    }
}
