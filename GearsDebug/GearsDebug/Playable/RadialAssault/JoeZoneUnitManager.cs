using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Playable;

namespace GearsDebug.Playable.RadialAssault
{
    class JoeZoneUnitManager : UnitManager
    {
        private Enemy1Factory esf;

        internal JoeZoneUnitManager()
        {
            Register();
        }

        private void Register()
        {
            esf = new Enemy1Factory();
            List<UnitTypeFactory> _lFact = new List<UnitTypeFactory>();
            _lFact.Add(esf); //iterate this for each UnitTypeFactory



            base.Register(_lFact.ToArray());
            _lFact = null; //this probably isn't necessary, is it?
        }
    }
}
