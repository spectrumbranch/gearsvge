using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*****  Take note that this page is meant to eventually be organized in case these 
 *      algorithms or structures can be reused.
 *****/

namespace GearsDebug
{
    /// <summary>
    /// DEPRECATED
    /// A static class that manages the ScreenStates of the game, and can be used to change these states.
    /// </summary>
    internal static class ScreenStateHandler
    {
        private static ScreenState _state;
        private static ScreenState _prevState = ScreenState.Null; //perhaps for later use
        private static string _data;

        //static handling functions
        public static void Shift(ScreenState target, string data)
        {
            _prevState = _state;
            _state = target; //this causes the shift in states starting at the next Update()/Draw() call.
            _data = data;
        }
        public static void Shift(ScreenState target)
        {
            Shift(target, "");
        }
        public static string Data()
        {
            string temp = _data;
            _data = "";
            return temp;
        }
        public static ScreenState State()
        {
            return _state;
        }
    }

    /// <summary>
    /// DEPRECATED
    /// Various states that the engine can be in.
    /// </summary>
    internal enum ScreenState
    {
        Splash,
        Menu,
        Gameplay,
        Pause,
        Cinematic,
        Loading,
        Debug,
        Null
    }

}
