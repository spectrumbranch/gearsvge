using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Gears.Cloud;

using Gears.Playable;

namespace GearsDebug.Playable.RadialAssault.Credits
{
    sealed internal class MattUnitTypeFactory : UnitTypeFactory
    {
         
        private Vector2 originOfCircle = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
        private MattUnit[] _tUnits;

        internal MattUnitTypeFactory()
        {
            Register();
        }
        private void Register()
        {
            _tUnits = new MattUnit[1];      //hardcode magic

            _tUnits[0] = new MattUnit(originOfCircle, Color.Red, 0.0f, "test" );    //note that this constructor is default for testing only. 
                                            //each unit will DEFINITELY have a different constructor.

            base.Register(_tUnits);
        }
    }
}
