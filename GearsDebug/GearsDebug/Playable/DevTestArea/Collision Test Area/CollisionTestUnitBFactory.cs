using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Gears.Cloud;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestUnitBFactory : UnitTypeFactory
    {
        private List<CollisionTestUnitB> units = new List<CollisionTestUnitB>();
        private Vector2 IMAGE_ORIGIN = new Vector2(0, 0);
        private Vector2 STARTING_LOCATION;

        internal CollisionTestUnitBFactory()
        {
            STARTING_LOCATION = new Vector2(ViewportHandler.GetWidth() * 0.75f, ViewportHandler.GetHeight() / 2.0f);
            Register();
        }
        private void Register()
        {
            base.Register(units);
        }
        internal void SpawnUnit()
        {
            units.Add(new CollisionTestUnitB(STARTING_LOCATION, Color.OrangeRed, 0.0f, IMAGE_ORIGIN));
            this.Register();
        }
        internal int GetUnitCount()
        {
            return units.Count;
        }
    }
}
