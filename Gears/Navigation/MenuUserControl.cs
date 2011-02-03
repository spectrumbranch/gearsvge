namespace Gears.Navigation
{
    public abstract class MenuUserControl : IMenuItem
    {
        //TODO: SomeDataConnectionHook
        //TODO: SomeUserControlHook

        private string menuText;
        public string MenuText
        {
            get { return menuText; }
            set
            {
                //15 chars or less to fit release 2 of menu implementation
                if (value.Length <= 15)
                {
                    menuText = value;
                }
                else
                {
                    //do nothing currently
                }
            }
        }
        internal MenuUserControl(string menuText)
        {
            MenuText = menuText;
        }
        public virtual void ThrowPushEvent()
        {

        }
    }
}
