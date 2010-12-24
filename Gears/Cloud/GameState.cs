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
    internal abstract class GameState
    {
        //TODO: Input hook (controller, mouse, keyboard, etc.)


        protected internal bool _IsOverlay = false;
        protected internal string _name = "Unassigned";
        internal bool IsOverlay()
        {
            return _IsOverlay;
        }
        internal string GetName()
        {
            return _name;
        }
        protected internal void SetName(string name)
        {
            _name = name;
        }
        
        protected internal abstract void Draw(SpriteBatch spriteBatch);
        protected internal abstract void Update(GameTime gameTime);
    }
}
