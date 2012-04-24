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
using System.Text;
using Gears.Playable;
using Gears.Cloud;
using Gears.Navigation;

namespace GearsDebug.Playable.RadialAssault
{
    public class DebugManager : IManager
    {
        private Zone1UnitManager _unitManager;

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //leave blank for now
        }

        internal void Activate()
        {
            ActivateInputHooks();
        }

        private void ActivateInputHooks()
        {
            Input.SubscribeInputHook(KeyDown);
        }

        /// <summary>
        /// Event based Input hook for DebugManager.
        /// </summary>
        /// <param name="currentKeyboardState">Passed from Input class.</param>
        /// <param name="oldKeyboardState">Passed from Input class.</param>
        internal void KeyDown(ref KeyboardState currentKeyboardState, ref KeyboardState oldKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.J) &&
                currentKeyboardState.IsKeyDown(Keys.J) != oldKeyboardState.IsKeyDown(Keys.J))
            {
                //Spawn Straight Line Alien
                _unitManager.SpawnStraightLineAlien();
            }

            if (currentKeyboardState.IsKeyDown(Keys.K) &&
            currentKeyboardState.IsKeyDown(Keys.K) != oldKeyboardState.IsKeyDown(Keys.K))
            {
                //Spawn Sine Alien
                _unitManager.SpawnSineAlien();
            }

            if (currentKeyboardState.IsKeyDown(Keys.L) &&
            currentKeyboardState.IsKeyDown(Keys.L) != oldKeyboardState.IsKeyDown(Keys.L))
            {
                //Spawn Firing Straight Line Alien
            }
        }

        internal void CoupleUnitManager(Zone1UnitManager um)
        {
            _unitManager = um;
        }
    }
}
