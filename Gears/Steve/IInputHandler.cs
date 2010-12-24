using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GearsDebug
{
    //the interface...

    //and the class implementation of the interface
    public class CInputManager
    {
        
        //initialize everything
        public CInputManager()
        {
            _timer = new Stopwatch();
            ComboList = new List<CCommands>();
            _availableCombos = new List<CCommands[]>();
            _timer.Start();
            KeyMapping = new Dictionary<Keys, CCommands>();
            ButtonMapping = new Dictionary<Buttons, CCommands>();
   
        }

        //detects if a controller is plugged in
        private bool checkController(GamePadState padState)
        {
            return padState.IsConnected;
        }

        public void update_Input(GamePadState padState, KeyboardState keyState)
        {
            _controllerPlugged = checkController(padState);
            checkTimer();

            //check if a button or key was pressed
            //if so, go to the binding list and execute the appropriate action
            if (_controllerPlugged)
            {
                foreach (Buttons x in ButtonMapping.Keys)
                {
                    if (buttonHeld(0,x,padState))
                    {
                        ButtonMapping[x].Executor();
                    }
                }
            }
            else
            {
                foreach (Keys x in KeyMapping.Keys)
                {
                    if (keyHeld(0, x, keyState))
                    {
                        KeyMapping[x].Executor();
                    }
                }
            }  
        }

        //detects if a button is held
        public bool buttonHeld(int playerID, Buttons buttonCheck, GamePadState padState)
        {
            //reset the timer and add to the combolist
            _timer.Reset();
            _timer.Start();
            //get the command associated with this button or key
            padState = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);

            if (padState.IsButtonDown(buttonCheck))
            {
                ComboList.Add(ButtonMapping[buttonCheck]);
            }
            return padState.IsButtonDown(buttonCheck);   
        }

        //detects if a button is released
        public bool buttonReleased(int playerID, Buttons buttonCheck, GamePadState padState)
        {
            return padState.IsButtonUp(buttonCheck);  
        }

        public bool keyHeld(int playerID, Keys keyCheck, KeyboardState keyState)
        {
            //reset the timer and add to the combolist
            _timer.Reset();
            _timer.Start();
            keyState = Keyboard.GetState();
            //get the command associated with this button or key

            if (keyState.IsKeyDown(keyCheck))
            {
                ComboList.Add(KeyMapping[keyCheck]);
            }
            return keyState.IsKeyDown(keyCheck);
        }

        public bool keyReleased(int playerID, Keys keyCheck, KeyboardState keyState)
        {
            return keyState.IsKeyUp(keyCheck);
        }

        //checks if we got a combo.
        public bool checkCombo(CCommands[] combo)
        {
            return _availableCombos.Contains(combo);
        }

        //adds a combo to the available list
        public void addCombo(CCommands[] combo)
        {
            _availableCombos.Add(combo);
        }

        //checks the timer to see if it needs to empty the combo list
        public void checkTimer()
        {
            if (_timer.ElapsedMilliseconds == 50)
            {
                _timer.Reset();
                ComboList.Clear();
            }
        }

        private Stopwatch _timer; //the timer will be checked to clear out the combo list
        public List<CCommands> ComboList; //fill this up as buttons are pressed to check for combos.  Clear it out if no buttons are pressed after x seconds
        private List<CCommands[]> _availableCombos; //the combos that the game has available
        private bool _controllerPlugged;
        public Dictionary<Buttons, CCommands> ButtonMapping;
        public Dictionary<Keys, CCommands> KeyMapping;
        
        
    };
}
