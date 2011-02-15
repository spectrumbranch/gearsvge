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
    internal sealed class KeyboardInput //: BareInput
    {
       // internal static override KeyboardState GetOldState();
        public TimeSpan _globalCooldown = new TimeSpan(0, 0, 0, 0, 100);

        private bool _enabled;
        public const int KeyMSDelay = 200;

        private static KeyboardState oldState, currentState;
        private static Keys[] pressedKeys;
        
        public delegate void KeyStateEvent(Keys key);
        public static event KeyStateEvent keyDown;
        public static event KeyStateEvent keyUp;

        internal static KeyboardState GetOldState()
        {
            oldState = GetCurrentState();
            return oldState;
        }

        internal static KeyboardState GetCurrentState()
        {
            oldState = currentState;
            currentState = Keyboard.GetState();
            return currentState;
        }

        internal static void UpdateInput()
        {
            GetOldState();
            pressedKeys = currentState.GetPressedKeys();
            
            foreach ( Keys keys in pressedKeys ) 
            {
                if(!oldState.Equals(keys))
                {
                    if (keyDown != null)
                    {
                        if(currentState.IsKeyDown(keys))
                        keyDown(keys);
                    }
                    else if (keyUp != null)
                    {
                        if(currentState.IsKeyUp(keys))
                        keyUp(keys);
                    }
                }
            }
        }

        internal bool GetInputFlag()
        {
            return _enabled;
        }
        internal void EnableInput()
        {
            _enabled = true;
        }
        internal void DisableInput()
        {
            _enabled = false;
        }
    }
}
