using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Gears.Cloud.Input
{
    public abstract class InputHandler
    {
        public delegate void KeyboardStateEvent(ref KeyboardState CURRENT_KEYBOARD_STATE, ref KeyboardState OLD_KEYBOARD_STATE);
        protected event KeyboardStateEvent keyboardEventList;


        protected KeyboardState _oldKeyboardState;
        protected KeyboardState _currentKeyboardState;

        public virtual void Update(GameTime gameTime)
        {
            if (keyboardEventList != null)
            {
                keyboardEventList(ref _currentKeyboardState, ref _oldKeyboardState);
            }
        }

        public void ClearEventHandler()
        {
            keyboardEventList = null;
        }


        public void SubscribeInputHook(KeyboardStateEvent kse)
        {
            keyboardEventList += kse;
        }

    }


}
