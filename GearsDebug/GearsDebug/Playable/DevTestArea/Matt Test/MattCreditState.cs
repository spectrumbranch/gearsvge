using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gears.Navigation;
using Gears.Cloud;



namespace GearsDebug.Playable.Matt
{
  public class MattCreditState : MenuReadyGameState
    {

    
      int y = ViewportHandler.GetWidth();
      int x = ViewportHandler.GetHeight();
      private SpriteFont _font;
      public List<Credit> Credits = new List<Credit>();
      String[] creditsData = {
    "Radial Assault",
    "\n",
    "\n",
    "Produced by Spectrum Branch",
    "and the Gears R&D Team",
    "\n",
    "Lead Software/Systems Engineer",
    "Christopher Bebry",
    "\n",
    "Gears R&D Lead Software Engineers",
    "Steven Calandra",
    "Steven Barbaro",
    "\n",
    "Gears R&D Software Dev Interns",
    "Matt Vegh",
    "Joseph Bebry",
    "\n",
    "Radial Assault Concept Development",
    "Eric Steinsdoerfer",
    "\n",
    "\n",
    "Thanks for playing",
    "Brought to you from the Gears R&D Team",
    "\n",
    "Copyright 2009-2012",
    "\n" 
};

      public class Credit
      {
          public Vector2 position = new Vector2();
          public string creditText = "";
      }

     
     
        public MattCreditState()
        {

            foreach (string key in creditsData)
            {
                Credit credit = new Credit();
                Credits.Add(credit);
                Credits[Credits.Count() - 1].creditText = key;
                Credits[Credits.Count() - 1].position.X = x / 2;
                Credits[Credits.Count() - 1].position.Y = y / 2;
                y += 100;
            }
            MenuText = "Matt's Credit Menu";
            LoadContent();
           
        }

        public override void Update(GameTime gameTime)
        {
            
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(Credits[Credits.Count() - 1].position.Y > 0)
            {
                for (int i = 0; i < Credits.Count() ; i++)
                {
                    spriteBatch.DrawString(_font, Credits[i].creditText, Credits[i].position, new Color(0, 0, 225));
                    Credits[i].position.Y -= 2;
                }
                
            }
        }

        private void LoadContent()
        {
            _font = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuFont");
        }



    }
}
