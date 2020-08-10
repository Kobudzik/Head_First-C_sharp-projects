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
using Windows.System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalApp9_text_editor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool textChanged = false;
        bool loading = false;
        IStorageFile saveFile = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loading) //The loading field keeps it from adding  * immediately after it’s loaded
            {
                loading = false;
                return;
            }


            if (!textChanged)
            {
                filename.Text += "*";
                saveButton.IsEnabled = true;
                textChanged = true;
            }
        }

        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            if (textChanged)//jesli tekst zmieniony a klikamy OPEN
            {
                MessageDialog overwriteDialog = new MessageDialog("You have unsaved changes. Are you sure you want to load a new file?");
                overwriteDialog.Commands.Add(new UICommand("Yes"));
                overwriteDialog.Commands.Add(new UICommand("No"));
                overwriteDialog.DefaultCommandIndex = 1;
                UICommand result = await overwriteDialog.ShowAsync() as UICommand;
                if (result != null && result.Label == "No")//jeśli esc albo NO
                    return;
            }
            OpenFile();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }


        private async void OpenFile()
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".xaml");

            IStorageFile file = await picker.PickSingleFileAsync();

            if (file != null)//jesli wybrano plik
            { 
                string fileContents = await FileIO.ReadTextAsync(file); //zczytuje tekst
                loading = true;
                text.Text = fileContents;//wypelnia textbox content
                textChanged = false;
                filename.Text = file.Name;//wypelnia textbox name
                saveFile = file;//ustawia saveFile na odczytany plik
            }
        }

        private async void SaveFile()
        {
            if (saveFile == null)//jesli saveFile nieustawiony(po otwarciu)
            {
                FileSavePicker picker = new FileSavePicker
                {
                    DefaultFileExtension = ".txt",
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary
                };
                picker.FileTypeChoices.Add("Text File", new List<string>() { ".txt" });
                picker.FileTypeChoices.Add("XML File", new List<string>() { ".xml", ".xaml" });

                saveFile = await picker.PickSaveFileAsync();
                if (saveFile == null)
                    return;
            }

            await FileIO.WriteTextAsync(saveFile, text.Text);
            await new MessageDialog("Wrote " + saveFile.Name).ShowAsync();
            textChanged = false;
            filename.Text = saveFile.Name;
        }

    }
}
