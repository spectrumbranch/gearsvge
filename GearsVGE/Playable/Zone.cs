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


namespace Gears.Playable
{
    public abstract class Zone
    {
        //Managers
        private UnitManager _uManager;
        //private ProjectileManager projectileManager;

        public Zone()
        {
            //Initialize();
        }
        //This is currently not called.
        private void Initialize()
        {

            //projectileManager = new ProjectileManager();
        }
        //DEPRECATED -- but still might be used for the projectile manager until a change is made.
        private void LoadContent(Game game, string parentDir)
        {

            //?Load the content for each Manager in the Zone //THIS WILL CHANGE 
            //projectileManager.LoadContent(game, /*contentDir*/); //THIS CALL WILL BECOME INVALID
        }
        public void Update(GameTime gameTime)
        {
            //Update Units
            _uManager.Update(gameTime);

            //Update Projectiles
            //projectileManager.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Units
            _uManager.Draw(spriteBatch);

            //Draw Projectiles
            //projectileManager.Draw(spriteBatch);
        }
        protected internal void Register(UnitManager manager)
        {
            _uManager = manager;
            //Initialize();
        }
    }
}
