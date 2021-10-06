using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ChineseCheckers.Classes
{
    public class BoardBackground
    {
        Vector2[] points =
        {
                new Vector2(-6f,9.5f), // Röd spets
                new Vector2(-1,4.5f), //Rosa/röd
                new Vector2(-1,-0.5f), // Rosa spets
                new Vector2(4f,-0.5f), // rosa/lila
                new Vector2(8.55f,-4.7f), // lila spets
                new Vector2(9f,-0.5f), // lila / gul
                new Vector2(14,-0.5f), // gul spets
                new Vector2(9,4.5f), // gul/ grön
                new Vector2(9,9.5f), //grön spets
                new Vector2(4,9.5f), // grön/blå
                new Vector2(-0.7f,14), // blå spets
                new Vector2(-1,9.5f), // blå / röd
        };

        Vector2[] targetPoints = new Vector2[12];

        double xMovement = -0.2;
        int yMovement = 0;

        int arrayCount;

        public Vector2[] SetTargetPoints()
        {
            foreach (var b in points)
            {
                int x = (int)Scaler.Xpos((float)(b.X + 12) * Scaler.ScalingValue + (b.Y * (Scaler.ScalingValue / 2)));
                int y = (int)Scaler.Ypos((float)(b.Y + 6) * Scaler.ScalingValue);

                int paddingX = (int)Scaler.Xpos((float)(xMovement) * Scaler.ScalingValue + ((Scaler.ScalingValue / 2)));
                int paddingY = (int)Scaler.Ypos((float)(yMovement) * Scaler.ScalingValue);

                targetPoints[arrayCount] = new Vector2(paddingX + x, paddingY + y);
                arrayCount += 1;
            }

            arrayCount = 0;

            return targetPoints;
        }

        public void CreateStar(Windows.UI.Xaml.Shapes.Polygon star) 
        {
            PointCollection polyPoints = new PointCollection();
            Vector2[] test1 = SetTargetPoints();
            Point P = new Point();

            foreach (var item in test1)
            {   
                P.X = (int)item.X;
                P.Y = (int)item.Y;

                polyPoints.Add(P);
            }

            star.Points = polyPoints;
        }
    }
}