using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gears.Navigation
{
    public interface IMenuItem
    {
        string MenuText
        {
            get;
            set;
        }

        void ThrowPushEvent();
    }
}
