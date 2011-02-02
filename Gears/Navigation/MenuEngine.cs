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

using Gears.Cartography;
using Gears.Cloud;
using Gears.Cloud._Debug;

using GearsDebug;


namespace Gears.Navigation
{
    public enum DebugMenuOption
    {
        Null,
        XMLSerializerTest,
        XMLDeserializerTest,
        DebugOutTest,
        SubMenuTest,
        TestPlayState,
        ViewportHandlerTest,
        Exit
    }
    //work in progress. see flowchart.
    internal sealed class MenuEngine
    {
        public MenuEngine()
        {
            Initialize();
            LoadContent();
        }
        private void Initialize() { }
        private void LoadContent() { }
        internal void Draw(SpriteBatch spriteBatch) { }
        internal void Update(GameTime gameTime) { }

    }

    //MenuEngineX is old technology that is phasing out in a future revision.
    internal class MenuEngineX : GameState
    {
        //menu data
        private OLD_MenuItem[] menu;
        //? enum ?
        private DebugMenuOption menuState;


        //graphics resources
        internal protected SpriteFont menuFont;
        internal protected SpriteFont menuItemFont;

        //input
        private KeyboardState oldKeyboardState, currentKeyboardState;
        private const int menuKeyMSDelay = 200; //200 milliseconds

        //hardcoded defaults at 1280x720
        private string menuTitle = "Debug Menu";
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


        public MenuEngineX(OLD_MenuItem[] menuItemList)
        {
            Debug.Out("MenuEngineX Constructor");
            Initialize(menuItemList);
            LoadContent();
        }

        protected void Initialize(OLD_MenuItem[] menuItemList)
        {
            //menuFont = new SpriteFont
            //menuItemFont;

            //Initialize the default debugMenuState. This should ALWAYS be defaulted to Null.
            //In this scenario, Null means the menu is not shifted to an option and is therefore only a Menu.
            menuState = DebugMenuOption.Null;

            //Load the menu item data for use as a functional menu.
            menu = new OLD_MenuItem[menuItemList.Length];
            for (int i = 0; i < menuItemList.Length; i++)
            {
                menu[i] = new OLD_MenuItem(menuItemList[i].GetTitle(), menuItemList[i].GetAction());
            }

        }
        /// <summary>
        /// Causes a shift in the menu state to "target" starting at the next Update() call.
        /// </summary>
        /// <param name="target">The target menu option.</param>
        protected void Shift(DebugMenuOption target)
        {
            menuState = target;
        }

        private void LoadContent()
        {
            menuFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (menuState)
            {
                case DebugMenuOption.Null:
                    DrawMenu(spriteBatch);
                    break;
                case DebugMenuOption.XMLSerializerTest:
                    //replace this later
                    spriteBatch.DrawString(menuFont, "XMLSerializerTest", new Vector2(250.0f, 500.0f), new Color(100, 100, 255));
                    break;
                case DebugMenuOption.XMLDeserializerTest:
                    //replace this later
                    spriteBatch.DrawString(menuFont, "XMLDeserializerTest", new Vector2(250.0f, 500.0f), new Color(100, 200, 255));
                    break;
                case DebugMenuOption.DebugOutTest:
                    //replace this later
                    spriteBatch.DrawString(menuFont, "DebugOutTest", new Vector2(250.0f, 500.0f), new Color(100, 100, 255));
                    break;
                case DebugMenuOption.SubMenuTest:
                    //
                    break;
                case DebugMenuOption.TestPlayState:
                    //
                    break;
                case DebugMenuOption.ViewportHandlerTest:
                    //
                    break;
                case DebugMenuOption.Exit:
                    //
                    break;
                default:
                    //
                    break;
            }

        }

        protected internal void DrawMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(menuFont, menuTitle, menuTitlePosition, menuTitleColor);

            //for (int j = 0; j * maxRows <= numMenuItems; j++) //keep this CHRIS
            for (int j = 0; j < maxColumns; j++)
            {
                //for (int i=0; (i + j*maxRows) % maxRows <numMenuItems % maxRows; i++) //keep this CHRIS
                for (int i = 0; i < menu.Length - (j * maxRows) && i < maxRows; i++)
                {
                    if (activeMenuIndex == (i + (maxRows * j)))
                    {
                        spriteBatch.DrawString(menuItemFont, menu[i + (maxRows * j)].GetTitle(), menuItemOriginPosition + (j * menuItemHorizontalOffset) + (i * menuItemVerticalOffset), activeItemColor);
                    }
                    else
                    {
                        spriteBatch.DrawString(menuItemFont, menu[i + (maxRows * j)].GetTitle(), menuItemOriginPosition + (j * menuItemHorizontalOffset) + (i * menuItemVerticalOffset), menuItemColor);
                    }
                }
            }
        }
        
        protected internal override void Update(GameTime gameTime)
        {
            switch (menuState)
            {
                case DebugMenuOption.Null:
                    OLD_ProcessKeyboard(gameTime);
                    break;
                case DebugMenuOption.XMLSerializerTest:
                    RunXMLSerializerTest();
                    Shift(DebugMenuOption.Null);
                    break;
                case DebugMenuOption.XMLDeserializerTest:
                    RunXMLDeserializerTest();
                    Shift(DebugMenuOption.Null);
                    break;
                case DebugMenuOption.DebugOutTest:
                    Debug.Out("##Test Successful.");
                    Shift(DebugMenuOption.Null);
                    break;
                case DebugMenuOption.SubMenuTest:
                    Debug.Out("SubMenuTest");
                    Input.DisableInput();///////////////////
                    Master.Push(new DemoMenu());
                    Shift(DebugMenuOption.Null);
                    break;
                case DebugMenuOption.TestPlayState:
                    Debug.Out("TestPlayState");
                    Input.DisableInput();///////////////////
                    Master.Push(new TestPlayState());
                    Shift(DebugMenuOption.Null);
                    break;
                case DebugMenuOption.ViewportHandlerTest:
                    Debug.Out("ViewportHandlerTest");
                    Input.DisableInput();
                    Master.Push(new ViewportHandlerTest());
                    Shift(DebugMenuOption.Null);
                    break;
                case DebugMenuOption.Exit:
                    ContentButler.GetGame().Exit();
                    break;
                default:
                    Shift(DebugMenuOption.Null);
                    break;
            }
        }

        private void RunXMLSerializerTest()
        {
            MapEngine mapEngine = new MapEngine();
            mapEngine.DebugSerialize();
        }
        private void RunXMLDeserializerTest()
        {
            MapEngine mapEngine = new MapEngine();
            mapEngine.DebugDeserialize();
        }
        protected internal void OLD_ProcessKeyboard(GameTime gameTime)//used to be virtual
        {
            //This is a terribly built input processor. 
            //It MUST be redone.


            //currently this keyboard processing is only built to run for the menu.
            //DO NOT use it for the options. they should handle their own anyway
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            currentKeyboardState.GetPressedKeys();

            // TODO: currently the enter key can fire multiple times in one pressdown and should be fixed.
            //      reproduce this by pressing the enter key and repeatedly pressing space, for example.
            if (currentKeyboardState.IsKeyDown(Keys.Enter) && 
                currentKeyboardState != oldKeyboardState)
            {
                Shift(menu[activeMenuIndex].GetAction());
            }
            else
            {
                if (currentKeyboardState.IsKeyDown(Keys.Down) &&
                    activeMenuIndex != (menu.Length - 1) &&
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
                    activeMenuIndex = (int)MathHelper.Clamp(activeMenuIndex - maxRows, 0, menu.Length - 1);
                }
                if (currentKeyboardState.IsKeyDown(Keys.Right) &&
                    activeMenuIndex != (menu.Length - 1) && 
                    currentKeyboardState != oldKeyboardState)
                {
                    activeMenuIndex = (int)MathHelper.Clamp((int)(activeMenuIndex + maxRows), (int)0, (int)(menu.Length - 1));
                }
            }
        }

    }
}
