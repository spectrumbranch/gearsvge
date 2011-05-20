﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gears.Cloud.Events
{
    class CBaseEventTrigger
    {
        public CBaseEventTrigger() 
        {
            Events = new List<CEvent>();
        }

        public void signalHandler(CEvent ev)
        {
            ev.triggered = true;
        }

        public CEvent getEvent(int index)
        {
            return Events[index];
        }

        protected void AddEvent(CEvent ev)
        {
            Events.Add(ev);
        }

        protected List<CEvent> Events;
    }
}
