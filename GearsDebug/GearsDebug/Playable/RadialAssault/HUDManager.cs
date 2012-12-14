using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Gears.Playable;
using Gears.Cloud;

namespace GearsDebug.Playable.RadialAssault
{
    class HUDManager : IManager
    {
        private RadialAssaultLevelData _levelData;

        private SpriteFont _scoreFont;
        private Vector2 _scorePosition = new Vector2(85, 30);
        private Color _scoreColor = new Color(225, 225, 225);


        

        public HUDManager(RadialAssaultLevelData levelData)
        {
            _levelData = levelData;
            LoadContent();
        }

        private void LoadContent()
        {
            _scoreFont = Master.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
            
        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_scoreFont, _levelData.Score.ToString(), _scorePosition, _scoreColor);

        }

    }
}
