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
            foreach (var N in board.Nodes)
            {
                int x = (int)Scaler.Xpos((float)((N.Pointer.X + 12) * Scaler.ScalingValue + (N.Pointer.Y * (Scaler.ScalingValue / 2))));
                int y = (int)Scaler.Ypos((float)(N.Pointer.Y + 6) * Scaler.ScalingValue);              

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
        public static void DrawAvailableMoves(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, List<Node> nodes, CanvasBitmap marker)
        {
            foreach (var n in nodes)
            {
                int x = (int)Scaler.Xpos((float)((n.Pointer.X + 12) * Scaler.ScalingValue + (n.Pointer.Y * (Scaler.ScalingValue / 2))));
                int y = (int)Scaler.Ypos((float)(n.Pointer.Y + 6) * Scaler.ScalingValue);
                args.DrawingSession.DrawImage(Scaler.Img(marker), x + 5, y + 5);
            }
        }
        public static void DrawPlayersTurn(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args, Session gameSession)
        {
            string text = $"Player {gameSession.CurrentPlayer.ColorId}'s turn";
            args.DrawingSession.DrawText(text, (int)Scaler.Xpos(50), (int)Scaler.Ypos(25), Colors.AliceBlue);
        }
    }
}
