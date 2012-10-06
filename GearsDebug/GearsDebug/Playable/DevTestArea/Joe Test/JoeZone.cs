using Microsoft.Xna.Framework;
using Gears.Playable;
using Gears.Cloud;

namespace GearsDebug.Playable.RadialAssault
{
    class JoeZone : Zone
    {
        //  The UnitManager handles the NPC units, including their spawning, death, and AI logic.
        private JoeZoneUnitManager um;

        //TODO: Need LevelManager, PlayerManager, MediaManager, and EffectsManager.
        //  The LevelManager handles background images, structure of the level, and so forth.
        //  The MediaManager handles any music or sound effects.
        //  The EffectsManager handles effects, including shaders and particles.


        //move around a bit. some of these are just here temporarily
        Vector2 WORMHOLE_COORDINATES = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
        Vector2 ENEMY_STARTING_LOCATION;//move to playermanager
        Vector2 ENEMY_IMAGE_ORIGIN = new Vector2(32, 32);//hardcoded, bad chris

        internal JoeZone()
        {
            Initialize();
            Register();
        }

        private void Initialize()
        {
            ENEMY_STARTING_LOCATION = new Vector2(WORMHOLE_COORDINATES.X, WORMHOLE_COORDINATES.Y + (196 + ENEMY_IMAGE_ORIGIN.Y)); //hardcode magic
        }
        private void Register()
        {
            Player[] _p = new Player[1];
            Player p1 = new RAPlayer(ENEMY_STARTING_LOCATION, Color.Azure, 0.0f/*, ENEMY_IMAGE_ORIGIN*/);//****
            _p[0] = p1;

            um = new JoeZoneUnitManager();

            base.Register(um);//register should allow a vector or linked list (or IEnumerable) for all manager types.
        }

    }
}
