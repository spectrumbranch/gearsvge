using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gears.Cloud
{
    internal abstract class GameState
    {
        //TODO: Input hook? (controller, mouse, keyboard, etc.)

        protected internal bool _IsOverlay = false;
        internal bool IsOverlay()
        {
            return _IsOverlay;
        }  
        protected internal abstract void Draw(SpriteBatch spriteBatch);
        protected internal abstract void Update(GameTime gameTime);
    }
}
