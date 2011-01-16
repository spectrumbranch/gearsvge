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

using Gears.Cloud;
using Gears.Cloud.Events;
using Gears.Cloud._Debug;


namespace GearsDebug
{
    //TODO: Entire abstract unit architecture should be moved to \Playable\
    internal abstract class Unit
    {
        protected internal Vector2 _position;
        protected internal Color _color;
        protected internal float _rotation;
        protected internal float _scale = 1.0f; //may change!!!!! function it
        protected internal float _depth = 0.0f; //may change!!!!! function it

        protected internal string _textureFileName;
        protected internal Texture2D _texture;

        protected internal string _texFileLoc = null;
        protected internal abstract string TextureFileLocation { get; }

        protected internal const string _unitDir = @"Unit";


        /// <summary>
        /// This defaulted constructor is for debugging/testing purposes only.
        /// It is required in a regular game to use a parameterized constructor instead.
        /// </summary>
        internal Unit() : this(Vector2.Zero, Color.White, 0.0f, "example") { }
        //TODO: make unitparameters the primary constructor
        internal Unit(UnitParameters up) : this(up.Origin, up.Color, up.Rotation, up.TextureFileName) { }
        //TODO: make this constructor an alias constructor
        internal Unit(Vector2 origin, Color color, float rotation, string textureFileName)
        {
            _position = origin;
            _color = color;
            _rotation = rotation;
            _textureFileName = textureFileName;

            Initialize();
        }

        protected internal void Initialize()
        {

        }
        internal void LoadContent()
        {
            if (TextureFileLocation != null)
            {
                _texture = ContentButler.GetGame().Content.Load<Texture2D>(TextureFileLocation);
            }
            else
            {
                Debug.Out("DEV.ERROR##Unit::TextureFileLocation not set properly.");
                throw new Exception("DEV.ERROR##Unit::TextureFileLocation not set properly.");
            }
        }
        //NOTE:  The inherited function must call this at the end or beginning of it's definition.
        internal virtual void CheckEvents()
        {
            if (CGlobalEvents.GFrameTrigger.getEvent(0).triggered == true)
            {
                onFrame();
            }
            //I hope it's obvious that this will be a bunch of if statements to check each event :)
        }

        //NOTE:  The inherited function must call this at the end of it's definition.  This is so base
        //events are checked
        internal virtual void Update(GameTime gameTime)
        {
            //movement and such here
            CheckEvents();
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _rotation, Vector2.Zero, _scale, SpriteEffects.None, _depth);
        }

        //event handlers
        //the prototypes for various events are declared here.
        //Define them in the specific entity you want that event to act on
        //Also note, I can't implement the other events yet since no interface for their associated functionality exists in a concrete form yet.

        //TODO: Make an interface which holds these prototypes
        internal virtual void onFrame() { } //global event
        internal virtual void onAnimEnd() { }//local event
        internal virtual void onAnimStart() { }//local event
        internal virtual void onMapStart() { }//global event //onLoad  ? -> global Trigger
        internal virtual void onMapEnd() { }//global event   //onUnload? -> global Trigger
    }
}
