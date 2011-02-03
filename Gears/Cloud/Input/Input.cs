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


        //
        private static KeyboardState oldKeyboardState, currentKeyboardState;
        private const int menuKeyMSDelay = 200; //200 milliseconds

        //Jon, please feel free to destroy the crap out of these functions.
        //They are temporary just so I can get the menu demos working.
        internal static KeyboardState GetOldKeyboardState()
        {
            return oldKeyboardState;
        }
        internal static KeyboardState GetCurrentKeyboardState()
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            return currentKeyboardState;
        }
        


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
