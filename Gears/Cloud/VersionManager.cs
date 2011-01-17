using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gears.Cloud
{
    class VersionManager
    {
        public VersionManager() { }

        public string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }


        private string version;

        
    }
}
