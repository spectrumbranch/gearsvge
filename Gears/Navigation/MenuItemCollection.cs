using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        //the exception throwing may be removed in the future, to allow "enter" handling of any non-gamestate menu items. 
        //the name of the function will change if that happens.
        internal void PushIndex(int index)
        {
            //if (_mi[index].GetType(). == typeof(GameState)) //TODO: this check needs to benchmark with "is" to see which is faster.
            if (_mi[index] is GameState)
            {
                Master.Push((GameState)_mi[index]);
            }
            else
            {
                _mi[index].ThrowPushEvent();
                //throw new ArgumentException("Gears.Navigation.MenuItemCollection::PushIndex(" + index + ") : You can only call Master.Push on a GameState type object.");
            }
        }
        internal string GetIndexMenuText(int index)
        {
            return _mi[index].MenuText;
        }
    }
}
