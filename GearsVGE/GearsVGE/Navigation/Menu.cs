using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gears.Navigation
{
    //TODO: Allow more parameters later on down the line.
    /// <summary>
    /// Menu is an instantiable class that allows you to create your own menus!
    /// TODO: Params and constructor doc.
    /// </summary>
    public sealed class Menu : MenuState
    {
        public Menu(string menuText, IMenuItem[] menuItemList) : base(menuText, menuItemList) { }
        public Menu(string menuText, List<IMenuItem> menuItemList) : base(menuText, menuItemList) { }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
