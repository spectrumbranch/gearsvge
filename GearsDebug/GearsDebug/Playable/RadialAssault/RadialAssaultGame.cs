using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Navigation;
using Gears.Cloud;
using Gears.Cloud.Input;

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
            if (StateIsActive())  { }
            else
            {
                ActivateState();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            zone1.Draw(spriteBatch);
        }

        /// <summary>
        /// Contains logic that should be fired every time the state becomes active.
        /// This should fire especially in cases where the state had become inactive
        ///     and then regains activity once again.
        /// </summary>
        private void ActivateState()
        {
            _StateIsActive = true;
            DefaultInput.ClearEventHandler();
            DefaultInput.EnableInput();
            //Input.keyDown += new Input.KeyboardStateEvent(KeyDown);
            zone1.Activate();
        }
    }
}
