using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Gears.Cloud;
using Microsoft.Xna.Framework.Input;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestUnitA : Player
    {
        private string fileloc = @"Debug\Collision\collisionUnitA";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal CollisionTestUnitA(Vector2 origin, Color color, float rotation, Vector2 imageOrigin)
            : base(origin, color, rotation, imageOrigin)  {  InitializeLocal(); }

        private void InitializeLocal()
        {

        }

        public override void Activate()
        {
            ActivateInputHooks();
        }
        private void ActivateInputHooks()
        {
            Master.GetInputManager().GetCurrentInputHandler().SubscribeInputHook(KeyDown);
        }
        /// <summary>
        /// Event based Input hook for CollisionTestUnitA.
        /// </summary>
        /// <param name="currentKeyboardState">Passed from Input class.</param>
        /// <param name="oldKeyboardState">Passed from Input class.</param>
        internal void KeyDown(ref KeyboardState currentKeyboardState, ref KeyboardState oldKeyboardState)
        {
            int magnitude = 1;
            if (currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                //Turbo Mode!
                magnitude = 10;
            }
            if (currentKeyboardState.IsKeyDown(Keys.W))
            {
                this.Move(Direction.Up, magnitude);
            }
            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                this.Move(Direction.Down, magnitude);
            }
            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                this.Move(Direction.Left, magnitude);
            }
            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                this.Move(Direction.Right, magnitude);
            }
        }

        private void Move(Direction direction, int magnitude = 1)
        {
            switch (direction)
            {
                case Direction.Up:
                    this._position.Y -= magnitude;
                    break;
                case Direction.Down:
                    this._position.Y += magnitude;
                    break;
                case Direction.Right:
                    this._position.X += magnitude;
                    break;
                case Direction.Left:
                    this._position.X -= magnitude;
                    break;
            }
        }
    }
}
