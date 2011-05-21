using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Navigation;
using Gears.Cartography;

namespace GearsDebug.Cartography
{
    internal class PerformMapSerialize : MenuUserControl
    {
        internal PerformMapSerialize() : base("SaveMapData")
        {

        }

        public override void ThrowPushEvent()
        {
            MapEngine me = new MapEngine();
            me.DebugSerialize("save0.1.0.xml");
        }
    }
}
