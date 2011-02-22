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
    /// <summary>
    /// ViewportHandler
    /// The ViewportHandler _depends_ on ContentButler.  Without ContentButler, ViewportHandler would _not_ be functional, and will FAIL.
    /// NOTE: (PROPOSAL ONLY indicates the message is directed towards a topic NOT related to initial issue)
    ///     PROPOSAL ONLY: The "projectionMatrix" will be used to help calculate the value differences between what is on the screen, and what isn't based on the viewport.  
    ///     Discussion is vital, for further progression now.
    /// TODO: (Not required for version 0.1.0, if listed feature is not in issue ticket for version 0.1.0)
    ///     - PROPOSAL ONLY: Write code for handling projection matrixes(will write up in proposals for this)
    ///     - PROPOSAL ONLY: Implement support for multiple viewports. This will enable split-screen gaming, and has other functionalities, as well. (In-game GUIs, perhaps)
    ///     - Add logic for defaulting to native resolution.
    ///     - Clean up.
    ///     - Add any missing features?
    /// </summary>
    public static class ViewportHandler
    {
        private static int _screenWidth;
        private static int _screenHeight;
        private static Matrix _matrixScale = new Matrix();
        private static Vector3 _scale = new Vector3();
        private static Viewport _viewport; //note

        // private static Dictionary<int, List<Viewport>> _viewports; // PROPOSAL ONLY: For future implementation, we will soon support multiple viewports. We'll wait for the camera to be implemented for this.

        private static void SetWidth(int w)
        {
            _screenWidth = w;
        }
        private static void SetHeight(int h)
        {
            _screenHeight = h;
        }

        private static void SetViewport(Viewport viewport)
        {
            _viewport = viewport;
            _viewport.Width = GetWidth();
            _viewport.Height = GetHeight();
        }
        /// <summary>
        /// FetchResolutions() UNFINISHED. PRELIMINARY. However, it can function if you wish to play with it, as there is not much to it.
        /// </summary>
        private static void FetchResolutions()
        {
            foreach (DisplayMode mode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
            {
                // TODO: Add logic for defaulting to native resolution.
                Gears.Cloud._Debug.Debug.Out(mode.ToString());
            }
        }
        /// <summary>
        /// SetScaleMatrix (public)
        /// _scale is a Vector3 object which is the scaleMatrix. This may be useful for re-scaling the screen to a smaller or bigger resolution,
        /// if desired.  Currently, it is set to 1,1,1 regardless of the result, to disable the function.  However, the functionality "is" there.
        /// If you were to go about scaling this way, you would want to be alert that _screenWidth and _screenHeight are your base resolutions, so
        /// they must stay the same. Only modify the paramters, float w(current width of the window), and float h (current height of the window), so 
        /// the scale matrix calculates properly. ( I will later demonstrate how to go about scaling this way. )
        /// </summary>
        /// <param name="w">Screen Width</param>
        /// <param name="h">Screen Height</param>
        public static void SetScaleMatrix(float w, float h)
        {
            _scale = new Vector3(_screenWidth / w, _screenHeight / h, 1); // z value remains 1 always. 
            _matrixScale = Matrix.CreateScale(_scale);
        }
        /// <summary>
        /// Defines game screen size, sets up viewport, and scales screen if desired.
        /// </summary>
        /// <param name="w">ScreenWidth</param>
        /// <param name="h">ScreenHeight</param>
        public static void SetScreen(int w, int h)
        {
            //Filter input as to prevent crash
            if (w > 0 && h > 0)
            {
                SetWidth(w);
                SetHeight(h);
                SetViewport(ContentButler.GetGame().GraphicsDevice.Viewport);
                SetScaleMatrix(w, h); //Intentionally placed here. Will be moved to demonstrate usage in later revision.
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

        public static Viewport GetViewport()
        {
            return _viewport;
        }

        public static Matrix GetScaleMatrix()
        {
            return _matrixScale;
        }
    }
}
