using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Cloud;
using Gears.Navigation;
using Microsoft.Xna.Framework.Audio;
using Gears.Cloud.Media;
using Microsoft.Xna.Framework.Media;

namespace GearsDebug.Media
{
    public class PlayTestMusic : MenuUserControl
    {
        public PlayTestMusic() : base("PlayTestMusic") { }

        public override void ThrowPushEvent()
        {
            Sound sound = new Sound(ContentButler.GetGame().Content.Load<Song>(@"Music/louchris monosynthlite"));

            AudioPlayer.queueAudio(sound);
        }
    }
}
