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
using System.Text;
using Gears.Playable;
using Gears.Cloud;
using Gears.Navigation;

namespace GearsDebug.Playable.RadialAssault
{
    class Zone1 : Zone
    {
        private DebugManager _DM;

        private Zone1LevelData _levelData;

        //  The PlayerManager handles all player-related interfaces and components.
        private RAPlayerManager pmTEST;

        //  The UnitManager handles the NPC units, including their spawning, death, and AI logic.
        private Zone1UnitManager um;

        private HUDManager hud;

        //TODO: Need LevelManager, PlayerManager, MediaManager, and EffectsManager.
        //  The LevelManager handles background images, structure of the level, and so forth.
        //  The MediaManager handles any music or sound effects.
        //  The EffectsManager handles effects, including shaders and particles.


        //move around a bit. some of these are just here temporarily
        Vector2 WORMHOLE_COORDINATES = new Vector2(ViewportHandler.GetWidth() / 2, ViewportHandler.GetHeight() / 2);
        Vector2 PLAYER_STARTING_LOCATION;//move to playermanager
        Vector2 PLAYER_IMAGE_ORIGIN = new Vector2(16, 16);//hardcoded, bad chris

        internal Zone1()
        {
            Initialize();
            Register();
        }

        private void Initialize()
        {
            _levelData = new Zone1LevelData();
            PLAYER_STARTING_LOCATION = new Vector2(WORMHOLE_COORDINATES.X, WORMHOLE_COORDINATES.Y + (300 + PLAYER_IMAGE_ORIGIN.Y)); //hardcode magic
        
        }
        private void Register()
        {
            RAPlayer[] _p = new RAPlayer[1];
            RAPlayer p1 = new RAPlayer(PLAYER_STARTING_LOCATION, Color.Azure, 0.0f/*, PLAYER_IMAGE_ORIGIN*/);//****
            _p[0] = p1;

            pmTEST = new RAPlayerManager(_p);
            um = new Zone1UnitManager();
            hud = new HUDManager(_levelData);

            _DM = new DebugManager();

            base.RegisterManager(_DM);
            base.RegisterManager(pmTEST);
            base.RegisterManager(hud);
            base.RegisterManager(um);

            _DM.CoupleUnitManager(um);

            //base.RegisterPlayerManager(pmTEST);
            //base.Register(um);//register should allow a vector or linked list (or IEnumerable) for all manager types.
        
            
        }


        internal void Activate()
        {
            _DM.Activate();
            pmTEST.Activate();
            um.Activate();
        }
        
    }
}
