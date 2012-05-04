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
using Gears.Cloud;
using Gears.Cloud._Debug;

namespace GearsDebug.Playable.RadialAssault
{
    //TODO: Refactor out framework components to an abstract superclass.
    sealed class LaserBeam : IProjectile
    {
        private Trackable _ownerEntity = null;

        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _imageOrigin = new Vector2(1,10); //
        private Color _color = new Color(100,0,0); //
        private float _rotation = 0.0f;
        private float _scale = 1.0f; //may change!!!!! function it
        private float _depth = 0.0f; //may change!!!!! function it

        private string _textureFileName;
        private Texture2D _texture;

        private string _texFileLoc = null;
        private string fileloc = @"RadialAssault\laserproto";
        //private string fileloc = @"RadialAssault\firingstraightlinealien";
        private string TextureFileLocation { get { return fileloc; } }

        public LaserBeam(Vector2 startingPosition, Vector2 velocity, Trackable ownerEntity)
        {
            _position = startingPosition;
            _velocity = velocity;
            _ownerEntity = ownerEntity;


            Initialize();
        }

        private void Initialize()
        {
            _rotation = (float)Math.Atan(_velocity.Y / _velocity.X) + MathHelper.ToRadians(90.0f);

            LoadContent();
        }
        private void LoadContent()
        {
            try
            {
                if (TextureFileLocation != null)
                {
                    _texture = ContentButler.GetGame().Content.Load<Texture2D>(TextureFileLocation);
                }
                else
                {
                    HandleTextureFileLocationError(true);
                }
            }
            catch
            {
                HandleTextureFileLocationError(false);
            }
        }

        private void HandleTextureFileLocationError(bool throwException)
        {
            string __ERROR = "DEV.ERROR##Unit::TextureFileLocation not set properly.\n\t[" + TextureFileLocation + "]";
            Debug.Out(__ERROR);
            if (throwException)
            {
                throw new Exception(__ERROR);
            }
        }
        public int GetTimeout()
        {
            return 10000; //milliseconds. IDK?
        }

        public void Update(GameTime gameTime)
        {
            _position += _velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _rotation, _imageOrigin, _scale, SpriteEffects.None, _depth);
        }
    }
}
