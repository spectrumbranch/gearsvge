using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Navigation;

namespace GearsDebug.Playable.RadialAssault
{
    class RadialAssaultGame : MenuReadyGameState
    {
        public Zone1 zone1;

        public RadialAssaultGame()
        {
            MenuText = "Radial Assault";
            Initialize();
        }
        private void Initialize()
        {
            zone1 = new Zone1();
        }
        public override void Update(GameTime gameTime)
        {
            zone1.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            zone1.Draw(spriteBatch);
        }
    }
}
