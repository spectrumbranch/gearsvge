using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gears.Playable
{
    public class Trackable
    {
        public string getUUID()
        {
            return this.uuid_.ToString();
        }

        private Guid uuid_ = Guid.NewGuid();
    }
}
