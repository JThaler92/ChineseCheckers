using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCheckers.Enums;
using ChineseCheckers.Classes;
using Windows.UI;
using Microsoft.Graphics.Canvas.Text;
using Windows.UI.Text;

namespace ChineseCheckers.Classes.Tools
{
    class DrawTool
    {
        /// <summary>
        /// Draws the game board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="board">Current gameboard instance</param>
        /// <param name="nodeCommon">Neutral picture</param>
        /// <param name="nodeRed">Red home picture</param>
        /// <param name="nodeGreen">Green home picture</param>
        /// <param name="nodeBlue">Blue home picture</param>
        /// <param name="nodePink">Pink home picture</param>
        /// <param name="nodePurple">Purple home picture</param>
        /// <param name="nodeYellow">Yellow home picture</param>
        public static void DrawBoard(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, GameBoard board, CanvasBitmap nodeCommon, CanvasBitmap nodeRed, CanvasBitmap nodeGreen, CanvasBitmap nodeBlue, CanvasBitmap nodePink, CanvasBitmap nodePurple, CanvasBitmap nodeYellow)
        {
            foreach (var N in board.Nodes)
            {
                int x = (int)Scaler.Xpos((float)((N.Pointer.X + 12) * Scaler.ScalingValue + (N.Pointer.Y * (Scaler.ScalingValue / 2)))); // Set x value to make star shape
                int y = (int)Scaler.Ypos((float)(N.Pointer.Y + 6) * Scaler.ScalingValue);   // Set y value to make star shape           

                switch (N.CampColorId)
                {
                    case PlayerColor.Blue:
                        args.DrawingSession.DrawImage(Scaler.Img(nodeBlue), x, y);
                        break;
                    case PlayerColor.Green:
                        args.DrawingSession.DrawImage(Scaler.Img(nodeGreen), x, y);
                        break;
                    case PlayerColor.Yellow:
                        args.DrawingSession.DrawImage(Scaler.Img(nodeYellow), x, y);
                        break;
                    case PlayerColor.Pink:
                        args.DrawingSession.DrawImage(Scaler.Img(nodePink), x, y);
                        break;
                    case PlayerColor.Purple:
                        args.DrawingSession.DrawImage(Scaler.Img(nodePurple), x, y);
                        break;
                    case PlayerColor.Red:
                        args.DrawingSession.DrawImage(Scaler.Img(nodeRed), x, y);
                        break;
                    default:
                        args.DrawingSession.DrawImage(Scaler.Img(nodeCommon), x, y);
                        break;
                }
            }
        }

        /// <summary>
        /// Draws all marble on board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="board">Current gameboard instance</param>
        /// <param name="marbleGreen">Green marble picture</param>
        /// <param name="marblePurple">Purple marble picture</param>
        /// <param name="marbleRed">Red marble picture</param>
        /// <param name="marbleBlue">Blue marble picture</param>
        /// <param name="marbleYellow">Yellow marble picture</param>
        /// <param name="marblePink">Pink marble picture</param>
        public static void DrawMarbles(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, GameBoard board, CanvasBitmap marbleGreen, CanvasBitmap marblePurple, CanvasBitmap marbleRed, CanvasBitmap marbleBlue, CanvasBitmap marbleYellow, CanvasBitmap marblePink)
        {
            foreach (var M in board.Marbles)
            {
                int x = (int)Scaler.Xpos((float)((M.Pointer.X + 12) * Scaler.ScalingValue + (M.Pointer.Y * (Scaler.ScalingValue / 2))));
                int y = (int)Scaler.Ypos((float)(M.Pointer.Y + 6) * Scaler.ScalingValue);

                switch (M.MarbleColor)
                {
                    case PlayerColor.Blue:
                        args.DrawingSession.DrawImage(Scaler.RotImg(marbleBlue, M.Angle_theta), x + 3, y + 3);
                        break;
                    case PlayerColor.Green:
                        args.DrawingSession.DrawImage(Scaler.RotImg(marbleGreen, M.Angle_theta), x + 3, y + 3);
                        break;
                    case PlayerColor.Yellow:
                        args.DrawingSession.DrawImage(Scaler.RotImg(marbleYellow, M.Angle_theta), x + 3, y + 3);
                        break;
                    case PlayerColor.Pink:
                        args.DrawingSession.DrawImage(Scaler.RotImg(marblePink, M.Angle_theta), x + 3, y + 3);
                        break;
                    case PlayerColor.Purple:
                        args.DrawingSession.DrawImage(Scaler.RotImg(marblePurple,M.Angle_theta), x + 3, y + 3);
                        break;
                    case PlayerColor.Red:
                        args.DrawingSession.DrawImage(Scaler.RotImg(marbleRed, M.Angle_theta), x + 3, y + 3);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Draws circle to show available moves.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="nodes">Available nodes to jump to</param>
        /// <param name="marker">Picture to show locations</param>
        public static void DrawAvailableMoves(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, List<Node> nodes, CanvasBitmap marker)
        {
            foreach (var n in nodes)
            {
                int x = (int)Scaler.Xpos((float)((n.Pointer.X + 12) * Scaler.ScalingValue + (n.Pointer.Y * (Scaler.ScalingValue / 2))));
                int y = (int)Scaler.Ypos((float)(n.Pointer.Y + 6) * Scaler.ScalingValue);
                args.DrawingSession.DrawImage(Scaler.Img(marker), x + 5, y + 5);
            }
        }

        /// <summary>
        /// Display whos turn it is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="gameSession">Current gameboard instance</param>
        public static void DrawPlayersTurn(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, Session gameSession)
        {
            string text = $"Player {gameSession.CurrentPlayer.Name}'s turn";
            args.DrawingSession.DrawText(text, (int)Scaler.Xpos(50), (int)Scaler.Ypos(25), Colors.AliceBlue);
        }

        /// <summary>
        /// Draws a winner text on the board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="board">Current gameboard instance</param>
        /// <param name="x">x value for text</param>
        /// <param name="y">y value for text</param>
        public static void DrawWinnerText(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, GameBoard board, float x, float y)
        {            
            CanvasTextFormat textFormat = new CanvasTextFormat()
            {
                FontSize = 56,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,                                      
            };
                        
            args.DrawingSession.DrawText($"{board.GameWinner} WINS!", (int)Scaler.Xpos(Scaler.DesignWidth / 2 + x), Scaler.Ypos(Scaler.DesignHeight / 2 + y - textFormat.FontSize), Colors.AliceBlue, textFormat);
        }

    }
}
