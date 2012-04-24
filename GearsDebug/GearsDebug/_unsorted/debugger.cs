using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



using Gears.Cloud;

using GearsDebug.Navigation; //debug menu

namespace GearsDebug
{
    class debugger : GameState
    {
        /// <summary>
        /// identifier is for data passage identification.
        /// It is currently not used, but has potential future post-beta concepts for scripting.
        /// </summary>
        private const char identifier = 'd';

        /// <summary>
        /// The entry point for this class.
        /// </summary>
        public debugger()
        {
            Initialize();
            LoadContent();
        }
        private void Initialize()
        {

        }
        private void LoadContent()
        {

        }
        public override void Update(GameTime gameTime)
        {
            //Throw our debug menu out into the world. It self-pushes.
            DebugMenu tmd = new DebugMenu();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    };
}
