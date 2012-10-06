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
using Gears.Cartography;
using Gears.Cloud;

namespace GearsDebug.Cartography
{
    public sealed class TiledRectangle
    {
        private int _tileSide;          //rev 1 has fixed
        private Vector2 _dimensions;    //rev 1 has fixed
        private Texture2D[,] txt;

        public TiledRectangle(int tileSide, Vector2 dimensions)
        {
            _tileSide = tileSide;
            _dimensions = dimensions; //TODO: check to make sure this is not a Vector2(0,0)
            Initialize();
        }
        private void Initialize()
        {
            txt = new Texture2D[(int)_dimensions.X, (int)_dimensions.Y];
            for(int i = 0; i < (int)_dimensions.X; i++)
            {
                for (int j = 0; j < (int)_dimensions.Y; j++)
                {
                    txt[i,j] = new Texture2D(ContentButler.GetGame().GraphicsDevice, _tileSide, _tileSide);
                }
            }
        }


        /// <summary>
        /// a prototype debugger method (replace with a modular solution)
        /// </summary>
        /// <param name="tx2d"></param>
        /// <param name="tx2d0"></param>
        public void TestAssignTex(Texture2D tx2d, Texture2D tx2d0)
        {
            txt[0, 0] = tx2d;
            txt[0, 1] = tx2d0;
        }
        //make more modular
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(txt[0, 0], new Vector2(100,100), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            sb.Draw(txt[0, 1], new Vector2(100, 100 + 64), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

    }
}
