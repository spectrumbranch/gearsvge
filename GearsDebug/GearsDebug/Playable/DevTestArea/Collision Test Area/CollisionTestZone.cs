using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;
using Microsoft.Xna.Framework;
using Gears.Cloud;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestZone : Zone
    {
        private CollisionTestController tc;
        private CollisionTestPlayerManager pm;

        internal CollisionTestZone() { Initialize(); }

        private void Initialize()
        {
            Register();
        }
        private void Register()
        {
            tc = new CollisionTestController();
            pm = new CollisionTestPlayerManager();

            base.RegisterManager(tc);
            base.RegisterManager(pm);

            tc.CouplePlayerManager(pm);
        }

        internal void Activate()
        {
            tc.Activate();
            pm.Activate();
        }
    }
}
