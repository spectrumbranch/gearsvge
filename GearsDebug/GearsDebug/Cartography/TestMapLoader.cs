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

using Gears.Navigation;
using Gears.Cloud;


namespace GearsDebug.Cartography
{
    public class TestMapLoader : MenuReadyGameState
    {
        private const byte _tileSize = 64; //64 x 64
        private int _tilesetIndex = 100; //100 is default

        //private Texture2D tt;
        private TiledRectangle tr;
        private Texture2D brick_default;// = ContentButler.GetGame().Content.Load<Texture2D>(@"Pixelcat\brick_default");
        private Texture2D brick_break;// = ContentButler.GetGame().Content.Load<Texture2D>(@"Pixelcat\brick_break");


        public TestMapLoader()
        {
            MenuText = "TestMapLoader";
            Initialize();
            LoadContent();
        }
        private void Initialize()
        {
            //experimental
            //RenderTarget2D rt2d = new RenderTarget2D(ContentButler.GetGame().GraphicsDevice, _tileSize, _tileSize, /**/1, SurfaceFormat.Single);
            //rt2d.
            tr = new TiledRectangle(_tileSize, new Vector2(1, 2));
        }
        private void LoadContent()
        {
            LoadTileset();
        }
        private void LoadTileset()
        {
           // ContentButler.loadTexture(_tilesetIndex, @"Pixelcat\brick_default");
            //ContentButler.loadTexture(_tilesetIndex+1, @"Pixelcat\brick_break");
            //tt.SetData<Texture2D>(
            //REPLACE THIS LINE WITH OTHER CONTENT//brick_default = ContentButler.GetGame().Content.Load<Texture2D>(@"Pixelcat\brick_default");
            //REPLACE THIS LINE WITH OTHER CONTENT//brick_break = ContentButler.GetGame().Content.Load<Texture2D>(@"Pixelcat\brick_break");
            //

            //tr.TestAssignTex(ContentButler.requestTexture(_tilesetIndex, 0), ContentButler.requestTexture(_tilesetIndex+1,0));

            tr.TestAssignTex(brick_default, brick_break);
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            tr.Draw(spriteBatch);
        }

    }
}
