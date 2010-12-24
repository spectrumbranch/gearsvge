using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Gears.Cloud;

namespace GearsDebug
{
    //not implemented yet
    public enum SplashMode
    {
        FullscreenTimed,
        FullscreenPressStart
        //other types can be added when a need is justified
    }
    //TODO: eventually this class will become more modular for stacking 
    //          multiple splash screens together modularly. 
    //          "give me the content and where it should go and I'll handle it" type of class.
    //      The point of the enums are to allow the designer to choose one of a few choices of 
    //          splash screen types. For example, FullscreenTimed is a full screen image with 
    //          an expiration timer, then it sends you to <some GameState>.
    internal class Splash : GameState
    {
        private bool _init = false; //whether or not this has been initialized

        //texture related fields
        private Rectangle splashRectangle;
        private Texture2D splashBackgroundTexture;

        //expiration fields
        // expiration limits the screen to exist for only splashScreenExpirationSeconds seconds.
        private const int splashScreenExpirationSeconds = 5;
        private int splashScreenBegun;


        public Splash()
        {
            base.SetName("Splash");
        }
        private void Initialize()
        {
            LoadContent();
            splashRectangle = new Rectangle(0, 0, ViewportHandler.GetWidth(), ViewportHandler.GetHeight());

            _init = true;
        }
        private void LoadContent()
        {
            splashBackgroundTexture = CContentManager.GetGame().Content.Load<Texture2D>(@"Splash\splash");
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            if (_init)
            {
                spriteBatch.Draw(splashBackgroundTexture, splashRectangle, Color.White);
            }
        }
        protected internal override void Update(GameTime gameTime)
        {
            if (!_init)
            {
                Initialize();
                splashScreenBegun = gameTime.TotalRealTime.Seconds;
            }
            else // we have initialized our splash screen already.
            {
                if (gameTime.TotalRealTime.Seconds - splashScreenBegun <= splashScreenExpirationSeconds)
                {
                    //still loading. this space intentionally left blank
                }
                else // we have exceeded the expiration timer
                {
                    //cleanup before giving control back
                    Unload();
                }
            }
        }

        private void Unload()
        {
            //switch over to menu
            Master.Pop();
            Master.Push(new MainMenu());

            //splashBackgroundTexture = null; //unnecessary? you tell me.
            _init = false;
        }
     
    }
}
