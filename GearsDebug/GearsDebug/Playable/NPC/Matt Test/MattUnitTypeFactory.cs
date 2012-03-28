using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Playable;

namespace GearsDebug.Playable.Matt
{
    sealed internal class MattUnitTypeFactory : UnitTypeFactory
    {
        private MattUnit[] _tUnits;

        internal MattUnitTypeFactory()
        {
            Register();
        }
        private void Register()
        {
            _tUnits = new MattUnit[1];      //hardcode magic

            _tUnits[0] = new MattUnit();    //note that this constructor is default for testing only. 
                                            //each unit will DEFINITELY have a different constructor.

            base.Register(_tUnits);
        }
    }
}
