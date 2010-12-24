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

using Gears.Cloud._Debug;

namespace Gears.Cloud
{
    //TODO: Build the core of this class.
    internal static class Input
    {
        //Global cooldown only applies to registered input.
        private static TimeSpan _globalCooldown = new TimeSpan(0, 0, 0, 0, 100);

        private static bool _enabled = false;
        private static KeyboardState _keyState;

        internal static bool KeyEnter()
        {
            return _keyState.IsKeyDown(Keys.Enter);
        }
        internal static bool GetInputFlag()
        {
            return _enabled;
        }
        internal static void EnableInput()
        {
            _enabled = true;
        }
        internal static void DisableInput()
        {
            _enabled = false;
        }
    }
}
