using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestUnitA : Unit
    {
        private string fileloc = @"Debug\Collision\collisionUnitA";
        protected override string TextureFileLocation { get { return fileloc; } }

        internal CollisionTestUnitA(Vector2 origin, Color color, float rotation, Vector2 imageOrigin)
            : base(origin, color, rotation, imageOrigin)  {  InitializeLocal(); }

        private void InitializeLocal()
        {

        }
    }   
}
