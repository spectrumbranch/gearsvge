using Gears.Cloud;

namespace Gears.Navigation
{
    internal sealed class MenuItemCollection
    {
        private IMenuItem[] _mi;

        internal int Length
        {
            get { return _mi.Length; }
        }
        internal MenuItemCollection(IMenuItem[] menuItems)
        {
            _mi = menuItems;
        }
        internal void PushIndex(int index)
        {
            //TODO: this check needs to benchmark with "is" to see which is faster. 
            //if (_mi[index].GetType(). == typeof(GameState)) 
            if (_mi[index] is GameState)
            {
                Master.Push((GameState)_mi[index]);
            }
            else
            {
                _mi[index].ThrowPushEvent();
            }
        }
        internal string GetIndexMenuText(int index)
        {
            return _mi[index].MenuText;
        }
    }
}
