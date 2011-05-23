using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Gears.Collisions
{
    public class CHitSphere : CHitShape
    {
        public CHitSphere(float radius, Vector2 position) 
            : base(shapeTypes.CIRCLE, position)
        {
            _radius = radius;
        }

        public override bool contains(CHitShape shape)
        {
            if (shape.shapeType == shapeTypes.CIRCLE)
            {
                float dist = 0;
                float sum = 0;
                CHitSphere temp = (CHitSphere)shape;

                dist = (float)Math.Sqrt(Math.Pow(shape.position.X - position.X, 2) + Math.Pow(shape.position.Y - position.Y, 2));
                sum = temp._radius + _radius;

                return (dist < sum);  
            }


            return false;
        }

        protected override void _scale(float percentage)
        {
            percentage /= 100;
            _radius *= percentage;
        }

        protected override void _translate(Vector2 amount)
        {
            _position += amount;
        }

        private float _radius;
    }
}
