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
using Gears.Navigation;
using Gears.Cloud;
using System.Windows.Forms;
using System.Drawing;

namespace GearsDebug.Forms
{
    internal sealed class TestWinForms : MenuReadyGameState
    {
        private static TextBox text1;
        private bool _init = false;

        public TestWinForms()
        {
            MenuText = "TestWinForms";
            Initialize();
        }

        private void Initialize()
        {
            // Note -- I apologies for this ball of code. This is just to show
            // off that you can modify the properties of Form objects still.
            text1 = new TextBox();
            text1.Location = new System.Drawing.Point(40, 40);
            text1.BorderStyle = BorderStyle.None;
            text1.Multiline = true;
            text1.Size = new Size(400, 400);
            text1.Text = MenuText;
            // HACK -- Object would otherwise draw over the Debugger Menu if this option was not set. 
            text1.Visible = false;
            // REQUIRED -- This is what makes System.Forms draw on XNA. This brings it to XNA's window handle, allowing it to draw. 
            Control.FromHandle(ContentButler.GetGame().Window.Handle).Controls.Add(text1);
            base._HandlesInput = true;
            _init = true;
        }

        /// <summary>
        /// Contains logic that should be fired every time the state becomes active.
        /// This should fire especially in cases where the state had become inactive
        ///     and then regains activity once again.
        /// </summary>
        private void ActivateState()
        {
            _StateIsActive = true;
            Input.ClearEventHandler();
            Input.keyDown += new Input.KeyboardStateEvent(KeyDown);
        }
        /// <summary>
        /// Contains logic that should be fired every time the state becomes inactive.
        /// This was originally implemented to avoid function pointers AKA delegates
        ///     from firing out of the Master.stack order.
        /// </summary>
        private void InactivateState()
        {
            Input.ClearEventHandler();
            _StateIsActive = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (_init != true)
            {
                Initialize();
            }
            else
            {

                // BUG -- Strange. You have to click OFF the game window first, then back onto the game window for the Input method to fire properly. Thoughts?
                if (ContentButler.GetGame().IsActive)
                {
                    UpdateInput(gameTime);
                }
                else
                {
                    ActivateState();
                }
            }
        }

        /// <summary>
        /// Only should be run if the state is active.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateInput(GameTime gameTime)
        {
            Input.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw textbox
            text1.Visible = true;
        }


        /// <summary>
        /// Event based Input hook for MenuState.
        /// </summary>
        /// <param name="currentKeyboardState">Passed from Input class.</param>
        /// <param name="oldKeyboardState">Passed from Input class.</param>
        private void KeyDown(ref KeyboardState currentKeyboardState, ref KeyboardState oldKeyboardState)
        {
            //Note -- Be careful about using "Keys.Key" now. Have to explictly specify which you're using, so the compiler doesn't get confused.
            if(currentKeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape) &&
                currentKeyboardState != oldKeyboardState)
            {
                ThrowPushEvent();
            }
        }

        public override void ThrowPushEvent()
        {
            _init = false;
            Control.FromHandle(ContentButler.GetGame().Window.Handle).Controls.Remove(text1);
            text1.Dispose();
            Master.Pop();
        }

    }
}