using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Playable;

namespace GearsDebug.Playable.RadialAssault
{
    class Zone1UnitManager : UnitManager
    {
        private EnemyShipFactory esf;

        private SineAlienFactory _sineAlienFactory;

        internal Zone1UnitManager()
        {
            Register();
        }

        private void Register()
        {
            _sineAlienFactory = new SineAlienFactory();

            esf = new EnemyShipFactory();
            List<UnitTypeFactory> _lFact = new List<UnitTypeFactory>();
            _lFact.Add(esf); //iterate this for each UnitTypeFactory
            _lFact.Add(_sineAlienFactory);


            base.Register(_lFact.ToArray());
            _lFact = null; //this probably isn't necessary, is it?
        }

        internal void Activate()
        {
            //Keep bubbling down Activate calls
        }

        internal void SpawnSineAlien()
        {
            _sineAlienFactory.Spawn();
        }
    }
}
