using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace ChineseCheckers.Classes
{
    class Scaler
    {
        public static float DesignWidth = 1920;
        public static float DesignHeight = 1080;
        public static float scaleWidth, scaleHeight;
        public static int ScalingValue { get; } = 50;

        /// <summary>
        /// 
        /// </summary>
        public static void SetScale()
        {
            scaleWidth = (float)(ApplicationView.GetForCurrentView().VisibleBounds.Width / DesignWidth);
            scaleHeight = (float)(ApplicationView.GetForCurrentView().VisibleBounds.Height / DesignHeight);
        }

        /// <summary>
        /// Get current scale on window
        /// </summary>
        /// <returns> list with scale values </returns>
        public static float[] GetScale()
        {
            float[] scaleVect = new float[2];

            scaleVect[0] = (float)(ApplicationView.GetForCurrentView().VisibleBounds.Width / DesignWidth);
            scaleVect[1] = (float)(ApplicationView.GetForCurrentView().VisibleBounds.Height / DesignHeight);
            
            return scaleVect;
        }

        /// <summary>
        /// Scale the pictures after current window size
        /// </summary>
        /// <param name="source">Picture to scale</param>
        /// <returns>Scaled picture to fit window</returns>
        public static Transform2DEffect Img(CanvasBitmap source)
        {
            Transform2DEffect image;
            image = new Transform2DEffect() { Source = source };
            image.TransformMatrix = Matrix3x2.CreateScale(scaleWidth, scaleHeight);
            return image;
        }

        /// <summary>
        /// Rotate picture after jump to face jump direction
        /// </summary>
        /// <param name="source">Picture to rotate</param>
        /// <param name="angleD">Direction and amount to turn</param>
        /// <returns>Rotated image</returns>
        public static Transform2DEffect RotImg(CanvasBitmap source, int angleD)
        {
            Transform2DEffect image;
            float angleR;
            angleR = (float)(angleD*(float)Math.PI/180);
            image = new Transform2DEffect() { Source = source };
            Rect bds = image.GetBounds(source);
            Vector2 center;
            center.X = (int)((float)bds.Width / 2);
            center.Y = (int)((float)bds.Height / 2);
            image.TransformMatrix = Matrix3x2.CreateRotation(angleR, center) * Matrix3x2.CreateScale(scaleWidth, scaleHeight);
            return image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Xpos(float x)
        {
            return (float)(x * scaleWidth);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Ypos(float y)
        {
            return (float)(y * scaleHeight);
        }
    }
}
