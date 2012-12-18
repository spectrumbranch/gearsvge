using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Cloud;
using Microsoft.Xna.Framework.Input;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestController : IManager
    {
        private CollisionTestPlayerManager _playerManager = null;

        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch)  { }

        internal void Activate()
        {
            ActivateInputHooks();
        }

        private void ActivateInputHooks()
        {
            Master.GetInputManager().GetCurrentInputHandler().SubscribeInputHook(KeyDown);
        }

        /// <summary>
        /// Event based Input hook for CollisionTestController.
        /// </summary>
        /// <param name="currentKeyboardState">Passed from Input class. The current keyboard state as of this update frame.</param>
        /// <param name="oldKeyboardState">Passed from Input class. The previous keyboard state with respect to this update frame.</param>
        internal void KeyDown(ref KeyboardState currentKeyboardState, ref KeyboardState oldKeyboardState)
        {
            if (_playerManager != null)
            {
                ///////////////////
                // Test Commands //
                ///////////////////

                if (currentKeyboardState.IsKeyDown(Keys.Space) &&
                    currentKeyboardState.IsKeyDown(Keys.Space) != oldKeyboardState.IsKeyDown(Keys.Space))
                {
                    //TODO: Trigger test for collision function!
                }
            }
        }

        internal void CouplePlayerManager(CollisionTestPlayerManager pm)
        {
            _playerManager = pm;
        }
    }
}
