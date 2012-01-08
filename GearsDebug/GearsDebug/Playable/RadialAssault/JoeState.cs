using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Navigation;

namespace GearsDebug.Playable.RadialAssault
{
    class JoeState : MenuReadyGameState
    {
        public JoeZone joeZone;

        public JoeState()
        {
            MenuText = "Enemy Unit 1";
            Initialize();
        }
        private void Initialize()
        {
            joeZone = new JoeZone();
        }
        public override void Update(GameTime gameTime)
        {
            joeZone.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            joeZone.Draw(spriteBatch);
        }
    }
}
