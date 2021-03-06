using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using ChineseCheckers.Classes.Tools;
using ChineseCheckers.Classes;
using Windows.UI.ViewManagement;
using System.Diagnostics;
using Windows.Media.Playback;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChineseCheckers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameBoard : Page
    {
        BoardBackground StarBackground = new BoardBackground();
        MediaPlayer ClickSound;
        Session GameSession;
        Marble currentlySelected;
        CanvasBitmap NodeImgDefault;
        CanvasBitmap NodeImgRed;
        CanvasBitmap NodeImgBlue;
        CanvasBitmap NodeImgGreen;
        CanvasBitmap NodeImgYellow;
        CanvasBitmap NodeImgPink;
        CanvasBitmap NodeImgPurple;
        CanvasBitmap MarbleImgGreen;
        CanvasBitmap MarbleImgBlue;
        CanvasBitmap MarbleImgRed;
        CanvasBitmap MarbleImgPink;
        CanvasBitmap MarbleImgPurple;
        CanvasBitmap MarbleImgYellow;
        CanvasBitmap Marker;

        public static Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        List<Node> nodes = NodeTool.InitiateNodes();
     
        /// <summary>
        /// Makes player win text to move
        /// </summary>
        enum Direction
        {
            Left, Right, Up, Down
        }
        Direction dirX = Direction.Right;
        Direction dirY = Direction.Up;
        public string winnerName = "";
        float winnerX = 0;
        float winnerY = 0;

        /// <summary>
        /// Initate GameBoard settings.
        /// </summary>
        public GameBoard()
        {
            ClickSound = new MediaPlayer();
            InitializeComponent();
            Scaler.SetScale();
            Window.Current.SizeChanged += Current_SizeChanged;
            GameSession = new Session(nodes, StartSettings.players);
            StarBackground.CreateStar(Star); 
        }

        /// <summary>
        /// Change visual settings when window size is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            Scaler.SetScale();
            StarBackground.CreateStar(Star);
        }

        /// <summary>
        /// Draws all images on the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {

            if (GameSession.HasWinner)
            {
                DrawTool.DrawWinnerText(sender, args, GameSession.Board, winnerX, winnerY);
            }
            else
            {
                DrawTool.DrawBoard(sender, args, GameSession.Board, NodeImgDefault, NodeImgRed, NodeImgGreen, NodeImgBlue, NodeImgPurple, NodeImgPink, NodeImgYellow);
                DrawTool.DrawMarbles(sender, args, GameSession.Board, MarbleImgGreen, MarbleImgPurple, MarbleImgRed, MarbleImgBlue, MarbleImgYellow, MarbleImgPink);
                DrawTool.DrawPlayersTurn(sender, args, GameSession);
                if (currentlySelected != null)
                {
                    var availableMoves = GameSession.Board.GetLegalJumps(currentlySelected);

                    DrawTool.DrawAvailableMoves(sender, args, availableMoves, Marker);
                }

            }
        }

        /// <summary>
        /// function that creates resources for the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void canvas_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        /// <summary>
        /// Import images to be used 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            NodeImgDefault = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/Default.png"));
            NodeImgRed = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/red.png"));
            NodeImgGreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/green.png"));
            NodeImgBlue = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/blue.png"));
            NodeImgPink = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/purple.png"));
            NodeImgPurple = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/magenta.png"));
            NodeImgYellow = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/yellow.png"));
            MarbleImgGreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/grongrod.png"));
            MarbleImgBlue = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/blagrod.png"));
            MarbleImgPink = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/rosagrod.png"));
            MarbleImgPurple = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/lilagrod.png"));
            MarbleImgYellow = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/gulgrod.png"));
            MarbleImgRed = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/rodgrod.png"));
            Marker = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/chalccircle.png"));
        }

        /// <summary>
        /// click event from CanvasAnimatedControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_Click(object sender, PointerRoutedEventArgs e)
        {                       
            var currentpos = e.GetCurrentPoint(canvas).Position; // Pointer where user clicks
            foreach (var N in nodes)
            {
                int x = (int)Scaler.Xpos((float)((N.Pointer.X + 12) * Scaler.ScalingValue + (N.Pointer.Y * (Scaler.ScalingValue / 2))));
                int y = (int)Scaler.Ypos((float)(N.Pointer.Y + 6) * Scaler.ScalingValue);

                float xScale = Scaler.GetScale()[0];
                float yScale = Scaler.GetScale()[1];

                int clickX = (int)(xScale * 55);
                int clickY = (int)(yScale * 55);

                if (currentpos.X >= x && currentpos.X <= x + clickX && currentpos.Y >= y && currentpos.Y <= y + clickY && Moving.move == false) 
                {          
                    if (currentlySelected != null && N.MarbleID == null) 
                    {             
                        var possibleJumps = GameSession.Board.GetLegalJumps(currentlySelected);
                        if (possibleJumps.Contains(N)) // If a marble is selected and place is available, move it
                        {
                            GameSession.Board.MarbleMove(N, currentlySelected);
                            currentlySelected = null;                           
                            GameSession.Turn();
                        }
                        else 
                        {
                            Sound.PlaySound(ClickSound, "ErrorFrog.mp3", 0.05f, false);
                            currentlySelected = null;
                        } 
                        break;
                    }
                    else
                    {
                        if (N.MarbleID != null) // If no marble selected, select a marble
                        {
                            if (GameSession.Board.Marbles.Find(marble => marble.Id == N.MarbleID).MarbleColor == GameSession.CurrentPlayer.ColorId)
                            {                              
                                currentlySelected = GameSession.Board.Marbles.Find(marble => marble.Id == N.MarbleID.Value);
                                Moving.SelectMarble(currentlySelected);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// update function from CanvasAnimatedControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            if (Moving.move)
            {
                Moving.GraphicMovment(GameSession.Board.Marbles);
            }

            if (GameSession.HasWinner)
            {
                MoveWinnerText();
            }           
        }

        /// <summary>
        /// Change varibles to move winner text
        /// </summary>
        private void MoveWinnerText()
        {
            //Horizontal movement
            if (winnerX <= -150)
            {
                dirX = Direction.Right;
            }
            if (winnerX >= 150)
            {
                dirX = Direction.Left;
            }

            if (dirX == Direction.Right)
            {
                winnerX += 2;
            }
            else if (dirX == Direction.Left)
            {
                winnerX -= 2;
            }

            //Vertical movement
            if (winnerY <= -20)
            {
                dirY = Direction.Down;
            }
            if (winnerY >= 20)
            {
                dirY = Direction.Up;
            }

            if (dirY == Direction.Down)
            {
                winnerY += 2;
            }
            else if (dirY == Direction.Up)
            {
                winnerY -= 2;
            }
        }

        /// <summary>
        /// return user to main menu page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainMenu));
        }
    }
}