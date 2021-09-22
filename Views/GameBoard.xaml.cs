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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChineseCheckers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameBoard : Page
    {

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
        public static Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        List<Node> nodes = NodeTool.InitiateNodes();

        public GameBoard()
        {
            InitializeComponent();
            Scaler.SetScale();
            Window.Current.SizeChanged += Current_SizeChanged;
            GameSession = new Session(nodes, 2);
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            Scaler.SetScale();
        }

        private void canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            DrawTool.DrawBoard(sender, args, GameSession.Board, NodeImgDefault, NodeImgRed, NodeImgGreen, NodeImgBlue, NodeImgPurple, NodeImgPink, NodeImgYellow);
            DrawTool.DrawMarbles(sender, args, GameSession.Board, MarbleImgGreen);
        }

        private void canvas_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());

        }

        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            NodeImgDefault = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/Default.png"));
            NodeImgRed = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/red.png"));
            NodeImgGreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/green.png"));
            NodeImgBlue = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/blue.png"));
            NodeImgPink = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/magenta.png"));
            NodeImgPurple = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/purple.png"));
            NodeImgYellow = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Leafs/50x50/yellow.png"));
            MarbleImgGreen = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/Images/Frogs/grongrod.png"));
        }

        private void canvas_Click(object sender, PointerRoutedEventArgs e)
        {

            //Debug.WriteLine(e.GetCurrentPoint(canvas).Position);
            var currentpos = e.GetCurrentPoint(canvas).Position;
            foreach (var N in nodes)
            {
                var x = (N.Pointer.X + 4) * Scaler.ScalingValue + (N.Pointer.Y * (Scaler.ScalingValue / 2));
                var y = (N.Pointer.Y + 4) * Scaler.ScalingValue;
                if (currentpos.X >= x && currentpos.X <= x + 55 && currentpos.Y >= y && currentpos.Y <= y + 55)
                {
                    Debug.WriteLine(N.MarbleID);
                    if (currentlySelected != null)
                    {
                        currentlySelected.Pointer = N.Pointer;
                        N.MarbleID = currentlySelected.Id;
                        currentlySelected = null;
                    }
                    else if (N.MarbleID != null)
                    {
                        currentlySelected = GameSession.Board.Marbles.Find(marble => marble.Id == N.MarbleID.Value);
                        break;
                    }

                }
            }

        }
    }
}