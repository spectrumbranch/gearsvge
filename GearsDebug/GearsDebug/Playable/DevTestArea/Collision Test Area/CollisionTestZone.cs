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
        private HUDManager hm;

        internal CollisionTestZone() { Initialize(); }

        private void Initialize()
        {
            Register();
        }
        private void Register()
        {
            tc = new CollisionTestController();
            pm = new CollisionTestPlayerManager();
            hm = new HUDManager();

            base.RegisterManager(tc);
            base.RegisterManager(pm);
            base.RegisterManager(hm);

            tc.CouplePlayerManager(pm);
        }

        internal void Activate()
        {
            tc.Activate();
            pm.Activate();
            hm.Activate();
        }
    }
}
