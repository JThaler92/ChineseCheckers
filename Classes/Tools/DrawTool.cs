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

namespace ChineseCheckers.Classes.Tools
{
    class DrawTool
    {
 
        public static void DrawBoard(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, GameBoard board, CanvasBitmap nodeCommon, CanvasBitmap nodeRed, CanvasBitmap nodeGreen, CanvasBitmap nodeBlue, CanvasBitmap nodePink, CanvasBitmap nodePurple, CanvasBitmap nodeYellow)
        {
            //temp
           
            foreach (var N in board.Nodes)
            {
                var x = (N.Pointer.X + 4) * Scaler.ScalingValue + (N.Pointer.Y * (Scaler.ScalingValue / 2));
                var y = (N.Pointer.Y + 4) * Scaler.ScalingValue;

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
        public static void DrawMarbles(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, GameBoard board, CanvasBitmap marbleGreen, CanvasBitmap marblePurple, CanvasBitmap marbleRed, CanvasBitmap marbleBlue, CanvasBitmap marbleYellow, CanvasBitmap marblePink)
        {
            foreach (var M in board.Marbles)
            {
                var x = (M.Pointer.X + 4) * Scaler.ScalingValue + (M.Pointer.Y * (Scaler.ScalingValue / 2));
                var y = (M.Pointer.Y + 4) * Scaler.ScalingValue;
                switch (M.MarbleColor)
                {
                    case PlayerColor.Blue:
                        args.DrawingSession.DrawImage(Scaler.Img(marbleBlue), x + 3, y + 3);
                        break;
                    case PlayerColor.Green:
                        args.DrawingSession.DrawImage(Scaler.Img(marbleGreen), x + 3, y + 3);
                        break;
                    case PlayerColor.Yellow:
                        args.DrawingSession.DrawImage(Scaler.Img(marbleYellow), x + 3, y + 3);
                        break;
                    case PlayerColor.Pink:
                        args.DrawingSession.DrawImage(Scaler.Img(marblePink), x + 3, y + 3);
                        break;
                    case PlayerColor.Purple:
                        args.DrawingSession.DrawImage(Scaler.Img(marblePurple), x + 3, y + 3);
                        break;
                    case PlayerColor.Red:
                        args.DrawingSession.DrawImage(Scaler.Img(marbleRed), x + 3, y + 3);
                        break;
                    default:
                        break;

                }
                args.DrawingSession.DrawText(M.Id.ToString(), x, y, Colors.Black);
            }
        }
    }
}
