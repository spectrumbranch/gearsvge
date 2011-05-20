namespace Gears.Navigation
{
    public interface IMenuItem
    {
        string MenuText
        {
            get;
            set;
        }
        void ThrowPushEvent();
    }
}
