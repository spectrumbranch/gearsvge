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
using Gears.Navigation;

namespace GearsDebug
{
    //TODO: Remove hardcoded initialization and migrate to a data-based method (xml serialization of objects)
    class debugger : GameState
    {
        //The menu for the debug screen.
        private MenuEngine menu;

        //identifier is for data passage identification. 
        //<<currently not used, but has future post-beta concepts for scripting>>
        private const char identifier = 'd';

        //The directory that contains content for this state
        private const string _stateDir = @"Debug";

        /// <summary>
        /// The entry point for this class. 
        /// Runs all initialization logic and loads graphical content for this class to the game.
        /// </summary>
        public debugger()
        {
            base.SetName("Debugger State");
            Initialize();
            LoadContent();
        }
        private void Initialize()
        {
            //Grab script data and clear the script cache
            //<<currently not used, but has future post-beta concepts for scripting>>
            Script(ScreenStateHandler.Data());

            //TODO: Make the menu item data pass down from an actual database/XML.
            //Load the menu item data to pass down to the MenuEngine
            OLD_MenuItem[] LoadMenuItemData = new OLD_MenuItem[7]; //make index based on data
            LoadMenuItemData[0] = new OLD_MenuItem("XMLSerializerTest", DebugMenuOption.XMLSerializerTest);
            LoadMenuItemData[1] = new OLD_MenuItem("XMLDeserializerTest", DebugMenuOption.XMLDeserializerTest);
            LoadMenuItemData[2] = new OLD_MenuItem("DebugOutTest", DebugMenuOption.DebugOutTest);
            LoadMenuItemData[3] = new OLD_MenuItem("SubMenuTest", DebugMenuOption.SubMenuTest);
            LoadMenuItemData[4] = new OLD_MenuItem("TestPlayState", DebugMenuOption.TestPlayState);
            LoadMenuItemData[5] = new OLD_MenuItem("ViewportHandlerTest", DebugMenuOption.ViewportHandlerTest);
            LoadMenuItemData[6] = new OLD_MenuItem("Exit", DebugMenuOption.Exit);
            // /end TODO

            //Initialize the menu and load its data.
            menu = new MenuEngine(LoadMenuItemData);
            
            //example
            //exampleZone = new Zone();

        }
        private void LoadContent()
        {
            //Load the Menu DEPRECATED
            //menu.LoadContent();
        }
        protected internal override void Update(GameTime gameTime)
        {
            //Update the Menu
            menu.Update(gameTime);
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            //Draw the Menu
            menu.Draw(spriteBatch);
        }



        //<<currently not used, but has future post-alpha concepts for scripting>>
        //SCRIPT NEEDS TO BE WORKED ON
        private void Script(string script)
        {
            if (script == null) //error checking
                script = ""; //sanitize null passes for people who dont script properly
            Verify(ref script);
            switch (script)
            {
                case "":
                    break;
                default:
                    break;
            }
        }
        //WORK ON
        private bool Verify(ref string msg)
        {
            if (msg.Length > 1)
            {
                if (msg.StartsWith("d"))
                {
                    msg = msg.Remove(0, 1);
                    return true;
                }
            }
            return false;
        }

    };
}
