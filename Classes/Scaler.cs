using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    class Scaler
    {

        public static void SetScale()
        {
            MainPage.scaleWidth = (float)MainPage.bounds.Width / MainPage.DesignWidth;
            MainPage.scaleHeight = (float)MainPage.bounds.Height / MainPage.DesignHeight;
        }

        public static Transform2DEffect Img(CanvasBitmap source)
        {
            return ScaleImage(source, MainPage.scaleWidth, MainPage.scaleHeight);
        }

        private static Transform2DEffect ScaleImage(CanvasBitmap source, float scaleX, float scaleY)
        {
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            image.TransformMatrix = Matrix3x2.CreateScale(MainPage.scaleWidth, MainPage.scaleHeight);
            return image;
        }

    }
}
