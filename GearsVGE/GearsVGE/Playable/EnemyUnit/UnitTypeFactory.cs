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
    public abstract class UnitTypeFactory
    {
        private Unit[] _units;

        public UnitTypeFactory()
        {
            //
        }
        private void Initialize()
        {
            LoadContent();
        }
        private void LoadContent()
        {
            foreach (Unit u in _units)
            {
                u.LoadContent();
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach (Unit u in _units)
            {
                u.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Unit u in _units)
            {
                u.Draw(spriteBatch);
            }
        }
        protected internal void Register(Unit[] units)
        {
            _units = units;
            Initialize();
        }
    }
}
