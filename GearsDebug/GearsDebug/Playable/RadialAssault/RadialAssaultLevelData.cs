using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearsDebug.Playable.RadialAssault
{
    abstract class RadialAssaultLevelData
    {
        protected internal int _numSineAlien;
        protected internal int _numStraightLineAlien;
        protected internal int _numFiringStraightLineAlien;

        protected internal int _score;

        protected internal int _numLives;

        public int Score { get { return _score; } set { _score = value; } }
    }
}
