using ChineseCheckers.Classes;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Drawing;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChineseCheckers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        MediaPlayer BGsound;
        MediaPlayer ClickSound;

        int players;

        public static CanvasBitmap MenuScreen;
        public MainMenu()
        {
            this.InitializeComponent();
            RulesSettings();
            ClickSound = new MediaPlayer();
            BGsound = new MediaPlayer();
            Sound.PlaySound(BGsound, "frog.mp3", 0.01f, true);
        }

        /// <summary>
        /// Settings for clicksound
        /// </summary>
        public void ClickingSound()
        {
            Sound.PlaySound(ClickSound, "icecube.mp3", 0.05f, false);
        }

        /// <summary>
        /// If the buttons are enable disable them, if buttons are disabled, enable them.
        /// </summary>
        public void ReverseButtons()
        {

            if (Button_Play.Visibility == Visibility.Collapsed)
            {
                Button_Play.Visibility = Visibility.Visible;
                Button_Rules.Visibility = Visibility.Visible;
                Button_Quit.Visibility = Visibility.Visible;
            }
            else if (Button_Play.Visibility == Visibility.Visible)
            {
                Button_Play.Visibility = Visibility.Collapsed;
                Button_Rules.Visibility = Visibility.Collapsed;
                Button_Quit.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Open or close the rules window depending on current status
        /// </summary>
        public void ShowRules()
        {
            if (RulesWindow.Visibility != Visibility.Visible)
            {
                RulesWindow.Visibility = Visibility.Visible;
                RulesWindowClose.Visibility = Visibility.Visible;
                RulesPicture.Visibility = Visibility.Visible;
            }
            else if (RulesWindow.Visibility == Visibility.Visible)
            {
                RulesWindow.Visibility = Visibility.Collapsed;
                RulesWindowClose.Visibility = Visibility.Collapsed;
                RulesPicture.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Open or close the play window depending on current status
        /// </summary>
        public void ShowPlay() 
        {
            PlayWindow.Text = "\t\t\tChoose amount of players:";
            PlayWindow.IsHitTestVisible = false;

            if (PlayWindow.Visibility != Visibility.Visible)
            {
                PlayWindow.Visibility = Visibility.Visible;
                PlayWindowClose.Visibility = Visibility.Visible;

                TwoPlayers.Visibility = Visibility.Visible;
                ThreePlayers.Visibility = Visibility.Visible;
                FourPlayers.Visibility = Visibility.Visible;
                SixPlayers.Visibility = Visibility.Visible;

                StartGame.Visibility = Visibility.Visible;
            }
            else if (PlayWindow.Visibility == Visibility.Visible)
            {
                PlayWindow.Visibility = Visibility.Collapsed;
                PlayWindowClose.Visibility = Visibility.Collapsed;

                TwoPlayers.Visibility = Visibility.Collapsed;
                ThreePlayers.Visibility = Visibility.Collapsed;
                FourPlayers.Visibility = Visibility.Collapsed;
                SixPlayers.Visibility = Visibility.Collapsed;

                StartGame.Visibility = Visibility.Collapsed;
            }      
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
        /// Saves the name and player input
        /// </summary>
        public void SetNames()
        {
            StartSettings.players = players - 1;

            StartSettings.playerOne = PlayerOneName.Text;
            StartSettings.playerTwo = PlayerTwoName.Text;
            StartSettings.playerThree = PlayerThreeName.Text;
            StartSettings.playerFour = PlayerFourName.Text;
            StartSettings.playerFive = PlayerFiveName.Text;
            StartSettings.playerSix = PlayerSixName.Text;
        }

        /// <summary>
        /// Change all Textboxed to collapsed
        /// </summary>
        private void HideAllNames()
        {
            PlayerOneName.Visibility = Visibility.Collapsed;
            PlayerTwoName.Visibility = Visibility.Collapsed;
            PlayerThreeName.Visibility = Visibility.Collapsed;
            PlayerFourName.Visibility = Visibility.Collapsed;
            PlayerFiveName.Visibility = Visibility.Collapsed;
            PlayerSixName.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Change all frog images to collapsed
        /// </summary>
        private void HideAllImages() 
        {
            PlayerOneImage.Visibility = Visibility.Collapsed;
            PlayerTwoImage.Visibility = Visibility.Collapsed;
            PlayerThreeImage.Visibility = Visibility.Collapsed;
            PlayerFourImage.Visibility = Visibility.Collapsed;
            PlayerFiveImage.Visibility = Visibility.Collapsed;
            PlayerSixImage.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        ///  Opens a window that Explain the rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Rules_Click(object sender, RoutedEventArgs e)
        {
            ClickingSound();
            ReverseButtons();
            ShowRules();
        }

        /// <summary>
        /// Closes the Rules window when pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RulesWindowClose_Click(object sender, RoutedEventArgs e)
        {
            ClickingSound();
            ShowRules();
            ReverseButtons();
        }

        /// <summary>
        /// Send player Play window when pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            ClickingSound();
            ReverseButtons();
            ShowPlay();
        }

        /// <summary>
        /// Close the Play window when pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayWindowClose_Click(object sender, RoutedEventArgs e)
        {
            ClickingSound();
            ShowPlay();
            ReverseButtons();
            HideAllNames();
            HideAllImages();
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

        /// <summary>
        /// Starts the game with choosen settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (players != null && players > 0)
            {
                SetNames();

                Sound.StopSound(BGsound);
                this.Frame.Navigate(typeof(GameBoard));
            }
        }

        /// <summary>
        /// Set options for two players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoPlayers_Click(object sender, RoutedEventArgs e)
        {
            players = 2;

            HideAllNames();
            HideAllImages();

            PlayerOneImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/blagrod.png"));
            PlayerTwoImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/lilagrod.png"));

            PlayerOneImage.Visibility = Visibility.Visible;
            PlayerTwoImage.Visibility = Visibility.Visible;

            PlayerOneName.Visibility = Visibility.Visible;
            PlayerTwoName.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set options for three players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreePlayers_Click(object sender, RoutedEventArgs e)
        {
            players = 3;

            HideAllNames();
            HideAllImages();

            PlayerOneImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/blagrod.png"));
            PlayerTwoImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/rosagrod.png"));
            PlayerThreeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/gulgrod.png"));

            PlayerOneImage.Visibility = Visibility.Visible;
            PlayerTwoImage.Visibility = Visibility.Visible;
            PlayerThreeImage.Visibility = Visibility.Visible;

            PlayerOneName.Visibility = Visibility.Visible;
            PlayerTwoName.Visibility = Visibility.Visible;
            PlayerThreeName.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set options for four players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FourPlayers_Click(object sender, RoutedEventArgs e)
        {
            players = 4;

            HideAllNames();
            HideAllImages();

            PlayerOneImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/grongrod.png"));
            PlayerTwoImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/rodgrod.png"));
            PlayerThreeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/rosagrod.png"));
            PlayerFourImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/gulgrod.png"));

            PlayerOneImage.Visibility = Visibility.Visible;
            PlayerTwoImage.Visibility = Visibility.Visible;
            PlayerThreeImage.Visibility = Visibility.Visible;
            PlayerFourImage.Visibility = Visibility.Visible;

            PlayerOneName.Visibility = Visibility.Visible;
            PlayerTwoName.Visibility = Visibility.Visible;
            PlayerThreeName.Visibility = Visibility.Visible;
            PlayerFourName.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set options for six players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SixPlayers_Click(object sender, RoutedEventArgs e)
        {
            players = 6;

            HideAllNames();
            HideAllImages();

            PlayerOneImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/blagrod.png"));
            PlayerTwoImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/rodgrod.png"));
            PlayerThreeImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/rosagrod.png"));
            PlayerFourImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/lilagrod.png"));
            PlayerFiveImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/gulgrod.png"));
            PlayerSixImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/Frogs/grongrod.png"));

            PlayerOneImage.Visibility = Visibility.Visible;
            PlayerTwoImage.Visibility = Visibility.Visible;
            PlayerThreeImage.Visibility = Visibility.Visible;
            PlayerFourImage.Visibility = Visibility.Visible;
            PlayerFiveImage.Visibility = Visibility.Visible;
            PlayerSixImage.Visibility = Visibility.Visible;

            PlayerOneName.Visibility = Visibility.Visible;
            PlayerTwoName.Visibility = Visibility.Visible;
            PlayerThreeName.Visibility = Visibility.Visible;
            PlayerFourName.Visibility = Visibility.Visible;
            PlayerFiveName.Visibility = Visibility.Visible;
            PlayerSixName.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set current text as empty when Textbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerOneName_GettingFocus(UIElement sender, Windows.UI.Xaml.Input.GettingFocusEventArgs args)
        {
            PlayerOneName.Text = "";
        }

        /// <summary>
        /// If Textbox is empty when unselected, puts back default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerOneName_LosingFocus(UIElement sender, Windows.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            if (PlayerOneName.Text.Trim() == "")
            {
                PlayerOneName.Text = "Player One";
            }
        }

        /// <summary>
        /// Set current text as empty when Textbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerTwoName_GettingFocus(UIElement sender, Windows.UI.Xaml.Input.GettingFocusEventArgs args)
        {
            PlayerTwoName.Text = "";
        }

        /// <summary>
        /// If Textbox is empty when unselected, puts back default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerTwoName_LosingFocus(UIElement sender, Windows.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            if (PlayerTwoName.Text.Trim() == "")
            {
                PlayerTwoName.Text = "Player Two";
            }
        }

        /// <summary>
        /// Set current text as empty when Textbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerThreeName_GettingFocus(UIElement sender, Windows.UI.Xaml.Input.GettingFocusEventArgs args)
        {
            PlayerThreeName.Text = "";
        }

        /// <summary>
        /// If Textbox is empty when unselected, puts back default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerThreeName_LosingFocus(UIElement sender, Windows.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            if (PlayerThreeName.Text.Trim() == "")
            {
                PlayerThreeName.Text = "Player Three";
            }
        }

        /// <summary>
        /// Set current text as empty when Textbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerFourName_GettingFocus(UIElement sender, Windows.UI.Xaml.Input.GettingFocusEventArgs args)
        {
            PlayerFourName.Text = "";
        }

        /// <summary>
        /// If Textbox is empty when unselected, puts back default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerFourName_LosingFocus(UIElement sender, Windows.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            if (PlayerFourName.Text.Trim() == "")
            {
                PlayerFourName.Text = "Player Four";
            }
        }

        /// <summary>
        /// Set current text as empty when Textbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerFiveName_GettingFocus(UIElement sender, Windows.UI.Xaml.Input.GettingFocusEventArgs args)
        {
            PlayerFiveName.Text = "";
        }

        /// <summary>
        /// If Textbox is empty when unselected, puts back default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerFiveName_LosingFocus(UIElement sender, Windows.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            if (PlayerFiveName.Text.Trim() == "")
            {
                PlayerFiveName.Text = "Player Five";
            }
        }

        /// <summary>
        /// Set current text as empty when Textbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerSixName_GettingFocus(UIElement sender, Windows.UI.Xaml.Input.GettingFocusEventArgs args)
        {
            PlayerSixName.Text = "";
        }

        /// <summary>
        /// If Textbox is empty when unselected, puts back default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PlayerSixName_LosingFocus(UIElement sender, Windows.UI.Xaml.Input.LosingFocusEventArgs args)
        {
            if (PlayerSixName.Text.Trim() == "")
            {
                PlayerSixName.Text = "Player Six";
            }
        }
    }
}
