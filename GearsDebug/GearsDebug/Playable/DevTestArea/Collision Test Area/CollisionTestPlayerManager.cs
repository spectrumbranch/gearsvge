using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Gears.Cloud;
using Microsoft.Xna.Framework.Graphics;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestPlayerManager : PlayerManager
    {
        private Vector2 IMAGE_ORIGIN = new Vector2(0, 0);
        private Vector2 STARTING_LOCATION_UNITA = new Vector2(ViewportHandler.GetWidth() * 0.25f, ViewportHandler.GetHeight() / 2.0f);
        private Vector2 STARTING_LOCATION_UNITB = new Vector2(ViewportHandler.GetWidth() * 0.75f, ViewportHandler.GetHeight() / 2.0f);

        private CollisionTestUnitA testUnitA;
        private CollisionTestUnitB testUnitB;

        public CollisionTestPlayerManager() { InitializeLocal(); }

        private void InitializeLocal()
        {
            testUnitA = new CollisionTestUnitA(STARTING_LOCATION_UNITA, Color.CadetBlue, 0.0f, IMAGE_ORIGIN);
            testUnitB = new CollisionTestUnitB(STARTING_LOCATION_UNITB, Color.OrangeRed, 0.0f, IMAGE_ORIGIN);
        }

        public override void Activate()
        {
            testUnitA.Activate();
            testUnitB.Activate();
        }
        public override void Update(GameTime gameTime)
        {
            testUnitA.Update(gameTime);
            testUnitB.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            testUnitA.Draw(spriteBatch);
            testUnitB.Draw(spriteBatch);
        }
    }
}
