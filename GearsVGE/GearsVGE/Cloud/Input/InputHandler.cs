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
        
        public virtual void Update(GameTime gameTime) { }

    }


}
