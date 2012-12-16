using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;

namespace GearsDebug.Playable.DevTestArea.Collision
{
    class CollisionTestUnitManager : UnitManager
    {
        //private EnemyShipFactory esf;

        private CollisionTestUnitAFactory _testUnitAFactory;
        private CollisionTestUnitBFactory _testUnitBFactory;

        internal CollisionTestUnitManager()
        {
            Register();
        }

        private void Register()
        {
            _testUnitAFactory = new CollisionTestUnitAFactory();
            _testUnitBFactory = new CollisionTestUnitBFactory();

            List<UnitTypeFactory> _lFact = new List<UnitTypeFactory>();
            _lFact.Add(_testUnitAFactory);
            _lFact.Add(_testUnitBFactory);

            base.Register(_lFact.ToArray());
        }

        internal void SpawnCollisionTestUnitA()
        {
            if (_testUnitAFactory.GetUnitCount() == 0)
            {
                _testUnitAFactory.SpawnUnit();
            }
        }
        internal void SpawnCollisionTestUnitB()
        {
            if (_testUnitBFactory.GetUnitCount() == 0)
            {
                _testUnitBFactory.SpawnUnit();
            }
        }

        internal void Activate()
        {
            //bubble down activate calls as needed.
        }
    }
}
