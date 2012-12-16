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
        private CollisionTestUnitManager _unitManager = null;

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

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
            if (_unitManager != null)
            {
                ///////////////////
                // Test Commands //
                ///////////////////

                if (currentKeyboardState.IsKeyDown(Keys.Space) &&
                    currentKeyboardState.IsKeyDown(Keys.Space) != oldKeyboardState.IsKeyDown(Keys.Space))
                {
                    //TODO: Trigger test for collision function!
                }


                /////////////////
                // Test Unit A //
                /////////////////
                if (currentKeyboardState.IsKeyDown(Keys.NumPad1) &&
                    currentKeyboardState.IsKeyDown(Keys.NumPad1) != oldKeyboardState.IsKeyDown(Keys.NumPad1))
                {
                    _unitManager.SpawnCollisionTestUnitA();
                }
                if (currentKeyboardState.IsKeyDown(Keys.W) &&
                    currentKeyboardState.IsKeyDown(Keys.W) != oldKeyboardState.IsKeyDown(Keys.W))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitAUp();
                }
                if (currentKeyboardState.IsKeyDown(Keys.S) &&
                    currentKeyboardState.IsKeyDown(Keys.S) != oldKeyboardState.IsKeyDown(Keys.S))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitADown();
                }

                if (currentKeyboardState.IsKeyDown(Keys.A) &&
                    currentKeyboardState.IsKeyDown(Keys.A) != oldKeyboardState.IsKeyDown(Keys.A))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitALeft();
                }
                if (currentKeyboardState.IsKeyDown(Keys.D) &&
                    currentKeyboardState.IsKeyDown(Keys.D) != oldKeyboardState.IsKeyDown(Keys.D))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitARight();
                }

                /////////////////
                // Test Unit B //
                /////////////////
                if (currentKeyboardState.IsKeyDown(Keys.NumPad2) &&
                    currentKeyboardState.IsKeyDown(Keys.NumPad2) != oldKeyboardState.IsKeyDown(Keys.NumPad2))
                {
                    _unitManager.SpawnCollisionTestUnitB();
                }

                if (currentKeyboardState.IsKeyDown(Keys.Up) &&
                    currentKeyboardState.IsKeyDown(Keys.Up) != oldKeyboardState.IsKeyDown(Keys.Up))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitBUp();
                }
                if (currentKeyboardState.IsKeyDown(Keys.Down) &&
                    currentKeyboardState.IsKeyDown(Keys.Down) != oldKeyboardState.IsKeyDown(Keys.Down))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitBDown();
                }

                if (currentKeyboardState.IsKeyDown(Keys.Left) &&
                    currentKeyboardState.IsKeyDown(Keys.Left) != oldKeyboardState.IsKeyDown(Keys.Left))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitBLeft();
                }
                if (currentKeyboardState.IsKeyDown(Keys.Right) &&
                    currentKeyboardState.IsKeyDown(Keys.Right) != oldKeyboardState.IsKeyDown(Keys.Right))
                {
                    //TODO:
                    //_unitManager.MoveCollisionTestUnitBRight();
                }
            }
        }

        internal void CoupleUnitManager(CollisionTestUnitManager um)
        {
            _unitManager = um;
        }
    }
}
