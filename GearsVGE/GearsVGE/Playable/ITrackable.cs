using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gears.Playable
{
    public interface ITrackable
    {
        public string getUUID()
        {
            return this.uuid_.ToString();
        }

        private Guid uuid_ = Guid.NewGuid();
    }
}
