namespace Gears.Navigation
{
    //TODO: Allow more parameters later on down the line.
    /// <summary>
    /// Menu is an instantiable class that allows you to create your own menus!
    /// TODO: Params and constructor doc.
    /// </summary>
    internal sealed class Menu : MenuState
    {
        internal Menu(string menuText, IMenuItem[] menuItemList) : base(menuText, menuItemList) { }
        protected internal override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
        protected internal override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
