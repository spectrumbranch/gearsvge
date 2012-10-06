using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Gears.Cloud.Input
{
    public class InputManager
    {
        private Stack<InputHandler> _inputs = new Stack<InputHandler>();

        public InputManager()
        {
            this._inputs.Push(new DefaultInput());
        }

        public InputHandler GetCurrentInputHandler()
        {
            return _inputs.Peek();
        }

        public void Update(GameTime gameTime)
        {
            this.GetCurrentInputHandler().Update(gameTime);
        }
    }
}
