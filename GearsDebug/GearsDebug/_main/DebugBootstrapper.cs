using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Cloud;
using GearsDebug.Navigation; //debug menu

namespace GearsDebug
{
    /// <summary>
    /// The debug bootstrapper for GearsDebug.
    /// </summary>
    class DebugBootstrapper : GameState
    {
        /// <summary>
        /// The entry point for this class.
        /// </summary>
        public DebugBootstrapper()
        {
            Initialize();
            LoadContent();
        }
        private void Initialize() {  }
        private void LoadContent() {  }

        public override void Update(GameTime gameTime)
        {
            //Throw our debug menu out into the world. It self-pushes.
            DebugMenu tmd = new DebugMenu();
        }
        public override void Draw(SpriteBatch spriteBatch) { }
    };
}
