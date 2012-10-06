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
using Gears.Cloud.Input;

namespace Gears.Cloud.Input
{
    public class DefaultInput : InputHandler
    {
        private static bool _enabled = false;
        private static KeyboardState _keyState;

        private KeyboardState _oldKeyboardState;
        private KeyboardState _currentKeyboardState;
        private event KeyboardStateEvent keyboardEventList;

        internal KeyboardState OldKeyboardState
        {
            get { return _oldKeyboardState; }
        }
        internal KeyboardState CurrentKeyboardState
        {
            get { return _currentKeyboardState; }
        }

        public bool GetInputFlag()
        {
            return _enabled;
        }
        public void EnableInput()
        {
            _enabled = true;
        }
        public void DisableInput()
        {
            _enabled = false;
        }

        public void ClearEventHandler()
        {
            keyboardEventList = null;
        }
        public void SubscribeInputHook(KeyboardStateEvent kse)
        {
            keyboardEventList += kse;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateKeyboardStates();

            if (keyboardEventList != null)
            {
                keyboardEventList(ref _currentKeyboardState, ref _oldKeyboardState);
            }
        }

        private void UpdateKeyboardStates()
        {
            _oldKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }

    }

    /*
    /// <summary>
    /// Input AKA Input Delegation/State Machine     rev.005
    /// 
    /// ***TODO:needs documentation***
    ///
    /// By spectrum AKA Christopher Bebry
    /// Copyright 2012. For use only within the Gears VGE and Spectrum Branch.
    /// http://www.spectrumbranch.com
    /// </summary>
    public static class DefaultInput_old
    {
        //Global cooldown only applies to registered input. Not implemented as of yet.
        private static TimeSpan _globalCooldown = new TimeSpan(0, 0, 0, 0, 100);

        private static bool _enabled = false;
        private static KeyboardState _keyState;

        public delegate void KeyboardStateEvent(ref KeyboardState CURRENT_KEYBOARD_STATE, ref KeyboardState OLD_KEYBOARD_STATE);

        private static event KeyboardStateEvent keyboardEventList;
        
        private const int menuKeyMSDelay = 200; //200 milliseconds

        private static KeyboardState _oldKeyboardState;
        private static KeyboardState _currentKeyboardState;
        internal static KeyboardState OldKeyboardState
        {
            get { return _oldKeyboardState; }
        }
        internal static KeyboardState CurrentKeyboardState
        {
            get { return _currentKeyboardState; }
        }

        public static void Update(GameTime gameTime)
        {
            UpdateKeyboardStates();

            if (keyboardEventList != null)
            {
                keyboardEventList(ref _currentKeyboardState, ref _oldKeyboardState);
            }
        }

        private static void UpdateKeyboardStates()
        {
            _oldKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
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
            DefaultInput_old.keyboardEventList = null;
        }
        public static void SubscribeInputHook(KeyboardStateEvent kse)
        {
            DefaultInput_old.keyboardEventList += kse;
        }
    }
     * */
}
