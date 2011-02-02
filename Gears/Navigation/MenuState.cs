using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Gears.Navigation
{
    /// <summary>
    /// MenuState   rev.002
    ///     Abstract class, intended to be inherited from and then instantiated
    ///     with constructor parameters. Every MenuState is a Menu, and contains
    ///     a MenuItemCollection, which is simply a collection of possible 
    ///     MenuStates for use in the MenuState/Engine logic.
    ///     
    ///     To avoid feature creep, this revision does not include parameterized
    ///     fonts or font sizes or window sizes. This is done on purpose and can
    ///     easily be refactored in on a later revision.
    /// By spectrum AKA Christopher Bebry.
    /// Copyright 2011. For use only within the Gears VGE and Spectrum Branch.
    /// http://www.spectrumbranch.com
    /// </summary>
    internal abstract class MenuState : GameState, IMenuItem
    {
        private MenuItemCollection mic; //  TODO: PLAN AND SIMULATE/TEST LOADING THE MENUITEMCOLLECTION

        //graphics resources
        internal protected SpriteFont menuFont;
        internal protected SpriteFont menuItemFont;

        //hardcoded defaults at 1280x720
        //private string menuTitle = "Debug Menu";//////////////////////
        private Vector2 menuTitlePosition = new Vector2(85, 30);
        private Color menuTitleColor = new Color(255, 255, 255);

        private Vector2 menuItemOriginPosition = new Vector2(35, 134);
        private Vector2 menuItemVerticalOffset = new Vector2(0, 46);
        private Vector2 menuItemHorizontalOffset = new Vector2(247, 0);
        private Color menuItemColor = new Color(225, 225, 225);
        private uint maxRows = 10;
        private uint maxColumns = 3;

        private int activeMenuIndex = 0; //0 = default
        private Color activeItemColor = new Color(200, 125, 125);

        private string menuText;
        public string MenuText
        {
            get { return menuText; }
            set
            {
                //15 chars or less to fit release 2 of menu implementation
                if (value.Length <= 15)
                {
                    menuText = value;
                }
                else
                {
                    //do nothing currently
                }
            }
        }

        internal MenuState(string menuText, IMenuItem[] menuItemList)
        {
            mic = new MenuItemCollection(menuItemList);
            Initialize(menuText);
            LoadContent();
        }
        private void Initialize(string menuText)
        {
            MenuText = menuText;
            base.SetName(MenuText);
        }
        private void LoadContent()
        {
            menuFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            DrawMenu(spriteBatch);
        }
        protected internal override void Update(GameTime gameTime)
        {
            OLD_ProcessKeyboard(gameTime);
        }

        protected internal void DrawMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(menuFont, base.GetName(), menuTitlePosition, menuTitleColor);

            //for (int j = 0; j * maxRows <= numMenuItems; j++) //keep this CHRIS
            for (int j = 0; j < maxColumns; j++)
            {
                //for (int i=0; (i + j*maxRows) % maxRows <numMenuItems % maxRows; i++) //keep this CHRIS
                for (int i = 0; i < mic.Length - (j * maxRows) && i < maxRows; i++)
                {
                    if (activeMenuIndex == (i + (maxRows * j))) //if the item we are drawing is active
                    {
                        spriteBatch.DrawString(menuItemFont, mic.GetIndexMenuText((int)(i + (maxRows * j))), menuItemOriginPosition + (j * menuItemHorizontalOffset) + (i * menuItemVerticalOffset), activeItemColor);
                    }
                    else //the item is not an active item
                    {
                        spriteBatch.DrawString(menuItemFont, mic.GetIndexMenuText((int)(i + (maxRows * j))), menuItemOriginPosition + (j * menuItemHorizontalOffset) + (i * menuItemVerticalOffset), menuItemColor);
                    }
                }
            }
        }


        protected internal void OLD_ProcessKeyboard(GameTime gameTime)//used to be virtual
        {
            //This is a terribly built input processor. 
            //It MUST be redone.

            KeyboardState currentKeyboardState = Input.GetCurrentKeyboardState();
            KeyboardState oldKeyboardState = Input.GetOldKeyboardState();

            //currently this keyboard processing is only built to run for the menu.
            //DO NOT use it for the options. they should handle their own anyway
            //oldKeyboardState = currentKeyboardState;
            //currentKeyboardState = Keyboard.GetState();

            currentKeyboardState.GetPressedKeys();

            // TODO: currently the enter key can fire multiple times in one pressdown and should be fixed.
            //      reproduce this by pressing the enter key and repeatedly pressing space, for example.
            if (currentKeyboardState.IsKeyDown(Keys.Enter) &&
                currentKeyboardState != oldKeyboardState)
            {
                mic.PushIndex(activeMenuIndex); /////
            }
            else
            {
                if (currentKeyboardState.IsKeyDown(Keys.Down) &&
                    activeMenuIndex != (mic.Length - 1) &&
                    currentKeyboardState != oldKeyboardState)
                {
                    activeMenuIndex++;
                }
                if (currentKeyboardState.IsKeyDown(Keys.Up) &&
                    activeMenuIndex != 0 &&
                    currentKeyboardState != oldKeyboardState)
                {
                    activeMenuIndex--;
                }
                if (currentKeyboardState.IsKeyDown(Keys.Left) &&
                    activeMenuIndex != 0 &&
                    currentKeyboardState != oldKeyboardState)
                {
                    activeMenuIndex = (int)MathHelper.Clamp(activeMenuIndex - maxRows, 0, mic.Length - 1);
                }
                if (currentKeyboardState.IsKeyDown(Keys.Right) &&
                    activeMenuIndex != (mic.Length - 1) &&
                    currentKeyboardState != oldKeyboardState)
                {
                    activeMenuIndex = (int)MathHelper.Clamp((int)(activeMenuIndex + maxRows), (int)0, (int)(mic.Length - 1));
                }
            }
        }

        public virtual void ThrowPushEvent()
        {

        }
    }
}
