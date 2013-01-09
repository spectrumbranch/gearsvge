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
    public class GearsDebug : Microsoft.Xna.Framework.Game
    {
        //Screen Resolution defaults
        private static int GameResolutionWidth = 1920;
        private static int GameResolutionHeight = 1080;
        private static int WindowResolutionWidth = 800;
        private static int WindowResolutionHeight = 600;
        //private static int ScreenWidth = 800;
        //private static int ScreenHeight = 600;

        private static bool resultionIndependent = true; // DON'T CHANGE THIS DURING RUNTIME FOR NOW
        private Vector2 baseScreenSize = new Vector2(GameResolutionWidth, GameResolutionHeight);


        private GraphicsDeviceManager graphics;
        private GraphicsDevice device;
        private SpriteBatch spriteBatch;

        public GearsDebug()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = @"GearsDebugContent";

            //We currently only support Reach, not HiDef.
            //Normally this is set in the project properties window, 
            //             but this runtime code is here just in case.
            if (graphics.GraphicsProfile != GraphicsProfile.Reach)
            {
                graphics.GraphicsProfile = GraphicsProfile.Reach;
            }
            IsFixedTimeStep = true;
        }
        
        protected override void Initialize()
        {
            //GEARSDEBUG VERSION. This is the version of the game module, not the VGE.
            VersionManager.Version = "ALPHA";

            //Register our Game to Master
            Master.Initialize(this);

            //Setup screen display/graphics device
            ViewportHandler.SetScreen(GameResolutionWidth, GameResolutionHeight);
            graphics.PreferredBackBufferWidth = WindowResolutionWidth;
            graphics.PreferredBackBufferHeight = WindowResolutionHeight;
            //graphics.
            graphics.IsFullScreen = false;
            //graphics.
            graphics.ApplyChanges();
            

            #if DEBUG
                Window.Title = "Gears [Debug] v." + VersionManager.Version + " using GearsVGE v." + VersionManager.GearsVGEVersion;

                // MAYBE TODO: Make this enum based for easier switching?
                //  DEBUG :: The uncommented line will change the default state that runs first.
                //  Only one of the following Master.Push() lines should be uncommented at a time.
                //Master.Push(new Splash());    //Uncomment this line to start game normally.
                Master.Push(new DebugBootstrapper());    //Uncomment this line to start the game with debug menu.
                //  END of Master.Push() lines
                
            #else //release
                Window.Title = "Gears v." + VersionManager.Version;
                Master.Push(new Splash()); //Start game normally
            #endif


            Gears.Cloud.Media.AudioPlayer.start();

            //Master.GetInputManager().GetCurrentInputHandler()
            base.Initialize();
        }

        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(device);

            if (resultionIndependent)
            {
                GameResolutionWidth = ViewportHandler.GetWidth();
                GameResolutionHeight = ViewportHandler.GetHeight();
            }
            else
            {
                GameResolutionWidth = device.PresentationParameters.BackBufferWidth;
                GameResolutionHeight = device.PresentationParameters.BackBufferHeight;
            }
        }

        protected override void UnloadContent()
        {
            Gears.Cloud.Media.AudioPlayer.stop();
        }

        protected override void Update(GameTime gameTime)
        {
            Master.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Vector3 screenScalingFactor;
            if (resultionIndependent)
            {
                float horScaling = (float)device.PresentationParameters.BackBufferWidth / ViewportHandler.GetWidth();
                float verScaling = (float)device.PresentationParameters.BackBufferHeight / ViewportHandler.GetHeight();
                screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            }
            else
            {
                screenScalingFactor = new Vector3(1, 1, 1);
            }

            Matrix globalTransformation = Matrix.CreateScale(screenScalingFactor);


            
            /**************************************/
            device.Clear(Master.GetClearColor());

            //spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, globalTransformation);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, RasterizerState.CullNone, null, globalTransformation);
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);//, SaveStateMode.None);//, ViewportHandler.GetScaleMatrix());

            Master.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}