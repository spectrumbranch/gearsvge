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
using Gears.Playable;
using Gears.Playable.Projectile;

namespace GearsDebug.Playable.RadialAssault
{
    sealed class LaserBeam : IProjectile
    {
        protected internal Vector2 _position;
        protected internal Vector2 _imageOrigin;
        protected internal Color _color;
        protected internal float _rotation;
        protected internal float _scale = 1.0f; //may change!!!!! function it
        protected internal float _depth = 0.0f; //may change!!!!! function it
        protected internal Texture2D _texture;
        protected internal string _texFileLoc = null;

        public LaserBeam(Vector2 startingPosition, Vector2 direction/*,,,*/)
        {
            _position = startingPosition;

        }

        public int GetTimeout()
        {
            return 10000; //milliseconds. IDK?
        }

        public void Update(GameTime gameTime)
        {
            //TODO
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _rotation, _imageOrigin, _scale, SpriteEffects.None, _depth);
        }
    }
}
