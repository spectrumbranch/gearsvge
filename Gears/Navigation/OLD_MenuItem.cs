using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Gears.Cloud;
using Gears.Cloud._Debug;

namespace Gears.Navigation
{
    class OLD_MenuItem
    {
        private DebugMenuOption _action;
        private string _title;

        public OLD_MenuItem(string title, DebugMenuOption action) //MenuType
        {
            SetTitle(title);
            SetAction(action);
        }

        public void SetTitle(string title)
        {
            _title = title;
        }
        public void SetAction(DebugMenuOption action)
        {
            _action = action;
        }
        public string GetTitle()
        {
            return _title;
        }
        public DebugMenuOption GetAction()
        {
            return _action;
        }
    }
}