using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Gears.Cloud;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestUnitAFactory : UnitTypeFactory
    {
        private List<CollisionTestUnitA> units = new List<CollisionTestUnitA>();
        private Vector2 IMAGE_ORIGIN = new Vector2(0, 0);
        private Vector2 STARTING_LOCATION;

        internal CollisionTestUnitAFactory()
        {
            STARTING_LOCATION = new Vector2(ViewportHandler.GetWidth() * 0.25f, ViewportHandler.GetHeight() / 2.0f);
            Register();
        }
        private void Register()
        {
            base.Register(units);
        }
        internal void SpawnUnit()
        {
            units.Add(new CollisionTestUnitA(STARTING_LOCATION, Color.CadetBlue, 0.0f, IMAGE_ORIGIN));
            this.Register();
        }
        internal int GetUnitCount()
        {
            return units.Count;
        }
    }
}
