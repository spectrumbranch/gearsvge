using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestZone : Zone
    {
        private CollisionTestUnitManager um;
        private CollisionTestController tc;

        internal CollisionTestZone() { Initialize(); }

        private void Initialize()
        {
            Register();
        }
        private void Register()
        {
            um = new CollisionTestUnitManager();
            tc = new CollisionTestController();

            base.RegisterManager(tc);
            base.RegisterManager(um);

            tc.CoupleUnitManager(um);
        }

        internal void Activate()
        {
            tc.Activate();
            um.Activate();
        }
    }
}
