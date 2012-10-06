using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Cloud;

namespace Gears.Navigation
{
    public abstract class MenuReadyGameState : GameState, IMenuItem
    {
        private string menuText;
        public string MenuText
        {
            get { return menuText; }
            set
            {
                //18 chars or less to fit release 2 of menu implementation
                if (value.Length <= 18)
                {
                    menuText = value;
                }
                else
                {
                    //do nothing currently
                }
            }
        }
        public virtual void ThrowPushEvent()
        {

        }
    }
}
