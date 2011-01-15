using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

/*
 * For resolution detection, you can call out to GraphicsAdapter and use SuppoertedDisplayModes to fetch the resolutions 
 * supported by the end-users GPU. I'll add this when the viewport handler is approved.
 */

namespace Gears.Cloud
{
    internal static class ViewportHandler
    {
        private static int _screenWidth;
        private static int _screenHeight;
        private static Matrix _matrixScale = new Matrix();
        private static Vector3 _scale = new Vector3();
        private static Rectangle _titleSafeArea = viewport.TitleSafeArea;
        private static Viewport viewport = new Viewport(); //note

        private static void SetWidth(int w)
        {
            _screenWidth = w;
        }
        private static void SetHeight(int h)
        {
            _screenHeight = h;
        }

        private static void SetTitleSafeArea(Rectangle safe)
        {
            _titleSafeArea = safe;
        }

        private static void ProjectionMatrix(float w, float h)
        {
            _scale = new Vector3(_screenWidth / w, _screenHeight / h, 1);
            _matrixScale = Matrix.CreateScale(_scale);
        }

        public static void SetScreen(int w, int h)
        {
            //Filter input as to prevent crash
            if (w > 0 && h > 0)
            {
                SetWidth(w);
                SetHeight(h);
                ProjectionMatrix(w, h);
            }
            else
            {
                throw new System.ArgumentException("Developer Error: Viewport parameters cannot be less than or equal to zero.", "ViewportHandler.SetScreen(w,h)");
            }
        }

        public static int GetWidth()
        {
            return _screenWidth;
        }
        public static int GetHeight()
        {
            return _screenHeight;
        }

        public static Rectangle GetSafeArea()
        {
            return _titleSafeArea;
        }

        public static Matrix GetTransformationMatrix()
        {
            return _matrixScale;
        }
    }
}
