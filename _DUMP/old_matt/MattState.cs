using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Navigation;

namespace GearsDebug.Playable.RadialAssault.Credits
{
    class MattState : MenuReadyGameState
    {
        public MattZone mattZone;

        public MattState()
        {
            MenuText = "Matt's Test Unit";
            Initialize();
        }
        private void Initialize()
        {
            mattZone = new MattZone();
        }
        public override void Update(GameTime gameTime)
        {
            mattZone.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            mattZone.Draw(spriteBatch);
        }
    }
}
