using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private MenuItemCollection mic; 

        //graphics resources
        internal protected SpriteFont menuFont;
        internal protected SpriteFont menuItemFont;
       
        //hardcoded defaults at 1280x720
        //TODO: Parameterize this stuff.
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
            KeyboardInput.keyDown += new KeyboardInput.KeyStateEvent(KeyDown);
            MenuText = menuText;
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
          // elapsedTime -= gameTime.ElapsedGameTime.Milliseconds;
               KeyboardInput.UpdateInput();//TODO add input delay.
               //OLD_ProcessKeyboard(gameTime);

        }
        protected internal void DrawMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(menuFont, MenuText, menuTitlePosition, menuTitleColor);

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

        internal void KeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Enter:
                    mic.PushIndex(activeMenuIndex); /////
                    break;
                case Keys.Down:
                    if (activeMenuIndex != (mic.Length - 1))
                        activeMenuIndex++;
                    break;
                case Keys.Up:
                    if (activeMenuIndex != 0)
                    activeMenuIndex--;
                    break;
                case Keys.Left:
                    if(activeMenuIndex != 0)
                    activeMenuIndex = (int)MathHelper.Clamp(activeMenuIndex - maxRows, 0, mic.Length - 1);
                    break;
                case Keys.Right:
                    if(activeMenuIndex != (mic.Length - 1))
                    activeMenuIndex = (int)MathHelper.Clamp((int)(activeMenuIndex + maxRows), (int)0, (int)(mic.Length - 1));
                    break;
            }
        }

        public virtual void ThrowPushEvent()
        {

        }
    }
}
