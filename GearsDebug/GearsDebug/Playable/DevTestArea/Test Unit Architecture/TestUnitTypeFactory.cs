using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Playable;

namespace GearsDebug
{
    sealed internal class TestUnitTypeFactory : UnitTypeFactory
    {
        private TestUnit[] _tUnits;

        internal TestUnitTypeFactory()
        {
            Register();
        }
        private void Register()
        {
            _tUnits = new TestUnit[1];      //hardcode magic

            _tUnits[0] = new TestUnit();    //note that this constructor is default for testing only. 
                                            //each unit will DEFINITELY have a different constructor.

            base.Register(_tUnits);
        }
    }
}
