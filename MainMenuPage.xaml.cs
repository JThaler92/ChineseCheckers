using System;
using ChineseCheckers.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChineseCheckers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        public MainMenu()
        {
            this.InitializeComponent();

            RulesSettings();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// If the buttons are enable disable them, if buttons are disabled, enable them.
        /// </summary>
        public void ReverseButtons() 
        {
            Button_Play.IsEnabled = !Button_Play.IsEnabled;
            Button_Rules.IsEnabled = !Button_Rules.IsEnabled;
            Button_Quit.IsEnabled = !Button_Quit.IsEnabled;
        }

        /// <summary>
        /// Settings for RulesWindow
        /// </summary>
        public void RulesSettings() 
        {
            RulesWindow.IsHitTestVisible = false;
            RulesWindow.Text = Rule.RuleText;
        }

        /// <summary>
        ///  Opens a window that Explain the rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Rules_Click(object sender, RoutedEventArgs e)
        {
            ReverseButtons();
            if (RulesWindow.Visibility != Visibility.Visible)
            {
                RulesWindow.Visibility = Visibility.Visible;
                RulesWindowClose.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Closes the Rules window when pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RulesWindowClose_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow.Visibility = Visibility.Collapsed;
            RulesWindowClose.Visibility = Visibility.Collapsed;

            ReverseButtons();
        }
    }
}
