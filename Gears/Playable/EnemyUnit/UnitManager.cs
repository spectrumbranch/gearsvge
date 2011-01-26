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

namespace Gears.Playable
{
    internal abstract class UnitManager
    {
        private UnitTypeFactory[] _factories;

        internal UnitManager()
        {

        }
        private void Initialize()
        {
            //
        }
        internal void Update(GameTime gameTime)
        {
            foreach (UnitTypeFactory utf in _factories)
            {
                utf.Update(gameTime);
            }
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (UnitTypeFactory utf in _factories)
            {
                utf.Draw(spriteBatch);
            }
        }
        protected internal void Register(UnitTypeFactory[] factories)
        {
            _factories = factories;
            Initialize();
        }
    }
}
