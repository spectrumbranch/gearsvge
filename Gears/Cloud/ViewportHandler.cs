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

namespace Gears.Cloud
{
    internal static class ViewportHandler
    {
        private static int _screenWidth;
        private static int _screenHeight;
        private static Viewport viewport = new Viewport(); //note

        private static void SetWidth(int w)
        {
            _screenWidth = w;
        }
        private static void SetHeight(int h)
        {
            _screenHeight = h;
        }
        public static void SetScreen(int w, int h)
        {
            //Filter input as to prevent crash
            if (w > 0 && h > 0)
            {
                SetWidth(w);
                SetHeight(h);
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
    }
}
