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
    public delegate void CreditsHaveCompletedEventHandler();

    public class MattCreditState : MenuReadyGameState
    {
        public event CreditsHaveCompletedEventHandler Completed;
        private bool eventThrown = false;

        private float creditScrollRate = 2.0f;

        private SpriteFont _font;
        private List<Credit> Credits = new List<Credit>();
        private Color _creditsColor = new Color(255, 0, 0);

       
        //TODO: Add credit for art and font
        private String[] creditsData = {
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
            public bool drawable = true;
        }

     
     
        public MattCreditState()
        {
            int y = ViewportHandler.GetWidth();
            int x = ViewportHandler.GetHeight();
            
            foreach (string key in creditsData)
            {
                Credits.Add(new Credit());
                Credits[Credits.Count() - 1].creditText = key;
                Credits[Credits.Count() - 1].position.X = x / 2;
                Credits[Credits.Count() - 1].position.Y = y / 2;
                y += 100;
            }
            MenuText = "Matt's Credit Menu";
            LoadContent();
        }

        private void LoadContent()
        {
            _font = ContentButler.GetGame().Content.Load<SpriteFont>(@"Fonts\MenuItem");
        }


        public override void Update(GameTime gameTime)
        {
            UpdateCreditText();
            UpdateCreditColor();
            HandleCreditFinish();
        }

        private void UpdateCreditColor()
        {
            byte delta = 1; //15,17,51,85
            if (this._creditsColor.R > 0 && this._creditsColor.B == 0)
            {
                this._creditsColor.R -= delta;
                this._creditsColor.G += delta;
            }
            else if (this._creditsColor.G > 0)
            {
                this._creditsColor.G -= delta;
                this._creditsColor.B += delta;
            }
            else
            {
                this._creditsColor.B -= delta;
                this._creditsColor.R += delta;
            }
        }

        private void HandleCreditFinish()
        {
            if (Credits.Count == 0 && !eventThrown)
            {
                if (Completed != null)
                {
                    Completed();
                }
                eventThrown = true;
            }
        }

        private void UpdateCreditText()
        {
            for (int i = 0; i < Credits.Count(); i++)
            {
                if (Credits[i].position.Y > 0)
                {
                    Credits[i].position.Y -= creditScrollRate;
                }
                else
                {
                    Credits[i].drawable = false;
                    Credits.RemoveAt(i);
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Credits.Count() ; i++)
            {
                spriteBatch.DrawString(_font, Credits[i].creditText, Credits[i].position, _creditsColor, 0.0f, new Vector2(0.0f, 20.0f), 1.0f, SpriteEffects.None, 0.0f);
            }
        }

    }
}
