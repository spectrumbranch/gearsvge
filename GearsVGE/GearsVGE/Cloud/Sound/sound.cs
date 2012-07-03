using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Gears.Cloud.Sound
{
    class sound
    {
        private object _data; //i'd rather this be generic, but it was too complicated
        private Type _type;
        public bool loop = false;

        public sound(SoundEffect data)
        {
            _data = data;
            _type = typeof(SoundEffect);
        }

        public sound(Song data, bool loop = false)
        {
            _data = data;
            _type = typeof(Song);
            this.loop = loop;
        }

        public object soundData
        {
            get
            {
                return _data;
            }
        }

        public Type songOrEffect
        {
            get
            {
                return _type;
            }
        }

    }
}
