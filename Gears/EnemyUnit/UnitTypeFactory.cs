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

namespace GearsDebug
{
    internal abstract class UnitTypeFactory
    {
        private unit[] _units;

        internal UnitTypeFactory()
        {
            //
        }
        private void Initialize()
        {
            LoadContent();
        }
        private void LoadContent()
        {
            foreach (unit u in _units)
            {
                u.LoadContent();
            }
        }
        internal void Update(GameTime gameTime)
        {
            foreach (unit u in _units)
            {
                u.Update(gameTime);
            }
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (unit u in _units)
            {
                u.Draw(spriteBatch);
            }
        }
        protected internal void Register(unit[] units)
        {
            _units = units;
            Initialize();
        }
    }
}
