using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Playable;

namespace GearsDebug.Playable.NPC
{
    sealed internal class SteveUnitTypeFactory : UnitTypeFactory
    {
        private Steve_Test.SteveUnit[] _tUnits;

        internal SteveUnitTypeFactory()
        {
            Register();
        }
        private void Register()
        {
            _tUnits = new Steve_Test.SteveUnit[1];      //hardcode magic

            _tUnits[0] = new Steve_Test.SteveUnit();    //note that this constructor is default for testing only. 
            //each unit will DEFINITELY have a different constructor.

            base.Register(_tUnits);
        }
    }
}
