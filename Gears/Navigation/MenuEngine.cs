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

    internal abstract class MenuItem : GameState
    {
        //arbitary possibilities of gamestates. 
        //keep in mind that a MenuItem IS_A GameState.
        protected internal GameState[] menu;

        //graphics resources
        protected internal SpriteFont menuFont; //set to ContentButler dictionary string!
        protected internal SpriteFont menuItemFont; //set to ContentButler dictionary string!

        //input
        protected internal KeyboardState oldKeyboardState, currentKeyboardState;
        protected internal const int menuKeyMSDelay = 200; //200 milliseconds
        protected internal const int menuInitInputMSDelay = 100; //100 milliseconds
        protected internal int menuInitBegun;

        //hardcoded defaults at 1280x720
        protected internal string menuTitle = "Debug Menu"; //maybe this will be _name?
        protected internal Vector2 menuTitlePosition = new Vector2(85, 30);
        protected internal Color menuTitleColor = new Color(255, 255, 255);

        protected internal Vector2 menuItemOriginPosition = new Vector2(35, 134);
        protected internal Vector2 menuItemVerticalOffset = new Vector2(0, 46);
        protected internal Vector2 menuItemHorizontalOffset = new Vector2(247, 0);
        protected internal Color menuItemColor = new Color(225, 225, 225);
        protected internal uint maxRows = 10;
        protected internal uint maxColumns = 3;

        protected internal int activeMenuIndex = 0; //0 == default; the first item in the list
        protected internal Color activeItemColor = new Color(200, 125, 125);

        //TESTING!
        protected internal MenuItemAction _action; //TESTING!


        //start
        internal MenuItem()
        {
            //Debug.Out("MenuEngine Constructor");
            Initialize();
            LoadContent();
        }

        //not done
        protected void Initialize()
        {
            

            //hardcode bad but good for single test
            //Load the menu item data for use as a functional menu.

            //STACK OVERFLOW LOL
            //menu = new MenuItem[1]; //TODO: MAGIC NUMBER
            //menu[0] = new DemoMenu();

            //proposed:
            //<Populate menu> (menu = new GameState[LENGTH];)
            //for (int i = 0; i < LENGTH; i++)
            //{
            //    menu[i] = new GameState(); //may need to loop through different array parts depending on types
            //}
        }

        private void LoadContent()
        {
            //TODO: replace with a font singleton from ContentButler in the cloud
            menuFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
            menuItemFont = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
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
                        spriteBatch.DrawString(menuItemFont, menu[i + (maxRows * j)].GetName(), menuItemOriginPosition + (j * menuItemHorizontalOffset) + (i * menuItemVerticalOffset), activeItemColor);
                    }
                    else
                    {
                        spriteBatch.DrawString(menuItemFont, menu[i + (maxRows * j)].GetName(), menuItemOriginPosition + (j * menuItemHorizontalOffset) + (i * menuItemVerticalOffset), menuItemColor);
                    }
                }
            }
        }

        protected internal void SetAction(MenuItemAction action)
        {
            _action = action;
        }

        //workability for usercontrol possibility.
        //unimplemented
        protected internal void DoAction()//, ref GameState? obj)
        {
            switch (_action)
            {
                case MenuItemAction.Null:
                    Debug.Out("DoAction(MenuItemAction.Null) being fired.");
                    break;
                case MenuItemAction.PushState:
                    Debug.Out("DoAction(MenuItemAction.PushState) being fired.");
                    break;
                case MenuItemAction.PopStack:
                    Debug.Out("DoAction(MenuItemAction.PopStack) being fired.");
                    Master.Pop();
                    break;
                case MenuItemAction.UserControl:
                    Debug.Out("DoAction(MenuItemAction.UserControl) being fired.");
                    break;
                default:
                    Debug.Out("DoAction(##default!) being fired.");
                    break;
            }
        }
        protected internal MenuItem GetActiveMenuItem()//out MenuItem menuItem
        {
            //polymorphic aspect needs to be checked. 
            //this code is prone to errors and probably should be subject to a try/catch block.
            return (MenuItem)menu[activeMenuIndex];
        }

        protected internal virtual void ProcessKeyboard(GameTime gameTime)
        {
            //INTEGRATE INTO INPUT CLASS

            //This is a terribly built input processor. 
            //It MUST be redone.

            //TODO: Make this entire section more modular. 
            //      there may be another way around this also.
            //    --May remove this entire section.
            if (!Input.GetInputFlag()) //input is disabled
            {
                Input.EnableInput();
                menuInitBegun = gameTime.TotalRealTime.Milliseconds;
            }
            else 
            {
                if (gameTime.TotalRealTime.Milliseconds - menuInitBegun <= menuInitInputMSDelay)
                {
                    //delay to prevent undesired input trailing from the previous GameState.
                    //this space intentionally left blank
                }
                else // we have exceeded the delay
                {
                    //currently this keyboard processing is only built to run for the menu.
                    //DO NOT use it for the options. they should handle their own anyway
                    oldKeyboardState = currentKeyboardState;
                    currentKeyboardState = Keyboard.GetState();

                    currentKeyboardState.GetPressedKeys();

                    // TODO: currently the enter key can fire multiple times in one pressdown and should be fixed.
                    //       To test this issue, press enter, then rapidly press any other key (ex: space)
                    //       because of the way the code is currently setup, the enter will refire every time the
                    //       additional key is fired.
                    if (currentKeyboardState.IsKeyDown(Keys.Enter) &&
                        currentKeyboardState != oldKeyboardState)
                    {
                        ////////////
                        //menu[activeMenuIndex].DoAction();
                        GetActiveMenuItem().DoAction();
                        //DoAction(); //////////////////
                        ////////////
                        //Shift(menu[activeMenuIndex].GetAction());
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
    }
    
    internal enum MenuItemAction
    {
        Null, //does nothing
        PushState,
        PopStack,
        UserControl
    }

    //MenuEngine is old technology that is phasing out in a future revision.
    class MenuEngine : GameState
    {
        //remove later. debug only
        //DebugMenu debugmenu;

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
       

        
        
        public MenuEngine(OLD_MenuItem[] menuItemList)
        {
            Debug.Out("MenuEngine Constructor");
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
