﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearsDebug
{
    sealed internal class TestUnitManager : UnitManager
    {
        private TestUnitTypeFactory _tFactory; //theres only 1 of each type of factory afaic
        //this should be also tested with at least two different factories

        internal TestUnitManager()
        {
            Register();
        }
        private void Register()
        {
            _tFactory = new TestUnitTypeFactory();

            List<UnitTypeFactory> _lFact = new List<UnitTypeFactory>();

            _lFact.Add(_tFactory); //iterate this for each UnitTypeFactory

            base.Register(_lFact.ToArray());

            _lFact = null; //this probably isn't necessary, is it? LOL I understand scope you dummy.
        }
    }
}
