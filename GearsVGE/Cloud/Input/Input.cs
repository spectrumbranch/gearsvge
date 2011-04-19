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
    /// <summary>
    /// Input AKA Input State Machine     rev.003
    /// 
    /// ***TODO:needs documentation***
    ///
    ///     Changelog:
    ///     - Make input class accessible outside of the core.
    ///                 Jonathan Basniak(rev.003, 04/19/2011)
    /// 
    /// By spectrum AKA Christopher Bebry, batchfile AKA Jonathan Basniak.
    /// Copyright 2011. For use only within the Gears VGE and Spectrum Branch.
    /// http://www.spectrumbranch.com
    /// </summary>
    public static class Input
    {
        //Global cooldown only applies to registered input. Not implemented as of yet.
        private static TimeSpan _globalCooldown = new TimeSpan(0, 0, 0, 0, 100);

        private static bool _enabled = false;
        private static KeyboardState _keyState;

        public delegate void KeyboardStateEvent(ref KeyboardState CurrentKeyboardState, ref KeyboardState OldKeyboardState);
        public static event KeyboardStateEvent keyDown;
        public static event KeyboardStateEvent keyUp;

        //
        private static KeyboardState oldKeyboardState, currentKeyboardState;
        private const int menuKeyMSDelay = 200; //200 milliseconds


        internal static KeyboardState OldKeyboardState
        {
            get { return oldKeyboardState; }
        }
        internal static KeyboardState CurrentKeyboardState
        {
            get { return currentKeyboardState; }
        }

        public static void Update(GameTime gameTime)
        {
            UpdateKeyboardStates();

            Keys[] currentPressedKeys = CurrentKeyboardState.GetPressedKeys();

            foreach (Keys keys in currentPressedKeys)
            {
                if (!OldKeyboardState.Equals(keys))
                {
                    if (keyDown != null)
                    {
                        if (CurrentKeyboardState.IsKeyDown(keys))
                        {
                            keyDown(ref currentKeyboardState, ref oldKeyboardState);
                        }
                    }
                    else if (keyUp != null)
                    {
                        if (CurrentKeyboardState.IsKeyUp(keys))
                        {
                            keyUp(ref currentKeyboardState, ref oldKeyboardState);
                        }
                    }
                }
            }
        }

        private static void UpdateKeyboardStates()
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public static bool KeyEnter()
        {
            return _keyState.IsKeyDown(Keys.Enter);
        }
        public static bool GetInputFlag()
        {
            return _enabled;
        }
        public static void EnableInput()
        {
            _enabled = true;
        }
        public static void DisableInput()
        {
            _enabled = false;
        }

        public static void ClearEventHandler()
        {
            Input.keyDown = null;
            Input.keyUp = null;
        }
    }
}
