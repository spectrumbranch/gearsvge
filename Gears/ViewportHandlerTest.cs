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

using Gears.Cloud;

namespace GearsDebug
{
    /// <summary>
    /// ViewportHandlerTest is for testing via the debugger state menu ONLY.
    /// </summary>
    sealed internal class ViewportHandlerTest : GameState
    {
        private static Rectangle safeArea;
        private static SpriteFont menuItemFont;

        public ViewportHandlerTest()
        {
            Initialize();
        }

        private void Initialize()
        {
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
            
        }

        protected internal override void Update(GameTime gameTime)
        {
            safeArea = ViewportHandler.GetViewport().TitleSafeArea;
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            // We want to avoid going OUT of the screen, right? The values may be changed to your own bidding. 
            float safeAreaRight = safeArea.Right * .99f;
            float safeAreBottom = safeArea.Bottom * .96f;

            // Top Left
            spriteBatch.DrawString(menuItemFont, @"+
Top", new Vector2(safeArea.Left, safeArea.Top), Color.White);
            // Top Right
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeAreaRight, safeArea.Top), Color.White);
            // Center
            spriteBatch.DrawString(menuItemFont, @"+
Center", new Vector2(safeArea.Center.X, safeArea.Center.Y), Color.White);
            // Top Center -------------------------------------- (Stick this line after + sign, if you want to test distance)
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeArea.Center.X, safeArea.Top), Color.White);
            // Left Center
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeArea.Left, safeArea.Center.Y), Color.White);
            // Right Center
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeAreaRight, safeArea.Center.Y), Color.White);
            // Bottom Center
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeArea.Center.X, safeAreBottom), Color.White);
            // Bottom Left
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeArea.Left, safeAreBottom), Color.White);
            // Bottom Right
            spriteBatch.DrawString(menuItemFont, "+", new Vector2(safeAreaRight, safeAreBottom), Color.White);

        }
    }
}