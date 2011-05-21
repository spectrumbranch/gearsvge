using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Navigation;
using Gears.Cartography;

namespace GearsDebug.Cartography
{
    internal class PerformMapDeserialize : MenuUserControl
    {
        internal PerformMapDeserialize() : base("LoadMapData")   {  }
        public override void ThrowPushEvent()
        {
            MapEngine me = new MapEngine();
            me.DebugDeserialize("load0.xml");
        }
    }
}
