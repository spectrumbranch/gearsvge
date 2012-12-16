using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Navigation;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gears.Cloud;
using Gears.Cloud.Input;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestState : MenuReadyGameState
    {
        public CollisionTestZone zone;

        public CollisionTestState()
        {
            MenuText = "Collision Test";
            Initialize();
        }
        private void Initialize()
        {
            zone = new CollisionTestZone();
        }
        public override void Update(GameTime gameTime)
        {
            zone.Update(gameTime);
            if (StateIsActive()) { }
            else
            {
                ActivateState();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            zone.Draw(spriteBatch);
        }
        /// <summary>
        /// Contains logic that should be fired every time the state becomes active.
        /// This should fire especially in cases where the state had become inactive
        ///     and then regains activity once again.
        /// </summary>
        private void ActivateState()
        {
            _StateIsActive = true;
            Master.GetInputManager().GetCurrentInputHandler().ClearEventHandler();

            (Master.GetInputManager().GetCurrentInputHandler() as DefaultInput).EnableInput();


            zone.Activate();
        }
    }
}
