﻿using ChineseCheckers.Classes;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChineseCheckers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        MediaPlayer player;
        MediaPlayer buttonPlayer;

        public static CanvasBitmap MenuScreen;
        public MainMenu()
        {
            this.InitializeComponent();
            RulesSettings();

            buttonPlayer = new MediaPlayer();

            player = new MediaPlayer();
            BackgroundSound.PlayBackgroundSound(player);
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
            ButtonclickSounds.PlayButtonClickSounds(buttonPlayer);
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

        /// <summary>
        /// Send player to gaming board when play is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            ButtonclickSounds.PlayButtonClickSounds(buttonPlayer);
            this.Frame.Navigate(typeof(GameBoard));
        }

        /// <summary>
        /// Quits the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {          
            Environment.Exit(0);
        }
    }
}
