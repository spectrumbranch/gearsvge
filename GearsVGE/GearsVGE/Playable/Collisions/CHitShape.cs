using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Gears.Collisions
{

    enum shapeTypes
    {
        BOX = 0,
        CIRCLE
    }
    abstract public class CHitShape
    {
        protected CHitShape(shapeTypes type, Vector2 position)
        {
            _shapeType = type;
            _position = position;
        }

        public abstract bool contains(CHitShape shape);
        protected abstract void _scale(float percentage);
        protected abstract void _translate(Vector2 amount);

        public void transform(float percentage, Vector2 amount)
        {
            _scale(percentage);
            _translate(amount);
        }

        public shapeTypes shapeType
        {
            get
            {
                return _shapeType;
            }
        }

        public Vector2 position
        {
            get
            {
                return _position;
            }
        }

        private shapeTypes _shapeType;
        protected Vector2 _position;

        
    }
}
