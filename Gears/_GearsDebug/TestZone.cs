using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Gears.Playable;

namespace GearsDebug
{
    sealed internal class TestZone : Zone
    {
        private TestUnitManager _tum;

        internal TestZone()
        {
            Register();
        }
        private void Register()
        {
            _tum = new TestUnitManager();

            base.Register(_tum);
        }


    }
}
