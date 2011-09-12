using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;

namespace GearsDebug.Playable.PolarCoordinates
{
    class Zone1 : Zone
    {
        //  The UnitManager handles the NPC units, including their spawning, death, and AI logic.
        private Zone1UnitManager um;

        //TODO: Need LevelManager, PlayerManager, MediaManager, and EffectsManager.
        //  The LevelManager handles background images, structure of the level, and so forth.
        //  The PlayerManager handles all player-related interfaces and components.
        //  The MediaManager handles any music or sound effects.
        //  The EffectsManager handles effects, including shaders and particles.

        internal Zone1()
        {
            Register();
        }
        private void Register()
        {
            um = new Zone1UnitManager();

            base.Register(um);//register should allow a vector or linked list for all manager types.
        }

    }
}
