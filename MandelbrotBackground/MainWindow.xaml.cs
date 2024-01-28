using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MandelbrotBackground
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private int m_displayWidth=0;
        private int m_displayHeight=0;

        public MainWindow(AppSettings settings)
        {
            this.InitializeComponent();
            if (settings.IsVerbose())
            {
                Console.WriteLine("Window Initialized");
            }
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicked");
            myButton.Content = "Generating Background";
        }

        private void resetPathButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicked");
        }

        private void sliderZoom_ValueChanges (object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Value Changed");
        }
        private void zoomCheckbox_HandleCheck(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Checkbox Check");
        }
        private void zoomCheckbox_HandleUnchecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Checkbox UnCheck");
        }

        //private void DisplayListBox_SelectionChanged (object sender, SelectionChangedEventArgs e)
        //{
        //    ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
        //
        //    Console.WriteLine("Selection Changed");
        //}
        private void DisplayComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            Console.WriteLine("Selection Changed");
            Console.WriteLine("Selection Is Now {0:D}",DisplayComboBox.SelectedIndex);
            m_displayHeight = FetchHeight(DisplayComboBox.SelectedIndex);
            m_displayWidth= FetchWidth(DisplayComboBox.SelectedIndex);
        }

        private int FetchHeight(int displayComboBoxIdx)
        {
            int[] ydots = { 108, 360, 600, 768, 720, 800, 1024, 768, 768, 900, 
                            864, 900, 1200, 1050, 1080, 1200, 1152, 1536, 1080, 1440, 
                            1600, 1440, 2160};
            return (ydots[displayComboBoxIdx]);
        }

        private int FetchWidth(int displayComboBoxIdx)
        {
            int[] xdots = { 128, 640, 800, 1024, 1280, 1280, 1280, 1360, 1366, 1440,
                            1536, 1600, 1600, 1680, 1920, 1920, 2048, 2048, 2560, 2560,
                            2560, 3440, 3840 };
            return (xdots[displayComboBoxIdx]);
        }
    }

    public class AppSettings
    {
        // Member elements
        private static bool m_verbose = true;

        public AppSettings()
        {
            // ToDo : determine screen size
            if(m_verbose)
            {
                Console.WriteLine("Settings Created");
            }
        }
        public bool IsVerbose()
        {
            return(AppSettings.m_verbose);
        }

    }
}
