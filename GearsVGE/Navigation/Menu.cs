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
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
