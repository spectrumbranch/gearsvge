using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Cloud;
using Gears.Navigation;
using Microsoft.Xna.Framework.Audio;
using Gears.Cloud.Sound;
using Microsoft.Xna.Framework.Media;

namespace GearsDebug.Media
{
    public class PlayTestMusic : MenuUserControl
    {
        public PlayTestMusic() : base("PlayTestMusic") { }

        public override void ThrowPushEvent()
        {
            sound sound = new sound(@ContentButler.GetGame().Content.Load<Song>("Music/louchris monosynthlite"));

            AudioPlayer.queueAudio(sound);
            //ContentButler.GetGame().Exit();
        }
    }
}
