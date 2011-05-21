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
    /// Input AKA Input State Machine     rev.002
    /// 
    /// ***TODO:needs documentation***
    ///
    /// By spectrum AKA Christopher Bebry, batchfile AKA Jonathan Basniak.
    /// Copyright 2011. For use only within the Gears VGE and Spectrum Branch.
    /// http://www.spectrumbranch.com
    /// </summary>
    internal static class Input
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

        internal static void Update(GameTime gameTime)
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

        internal static void ClearEventHandler()
        {
            Input.keyDown = null;
            Input.keyUp = null;
        }
    }
}
