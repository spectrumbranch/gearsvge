using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearsDebug
{
    public delegate void Execute(); //pointer function

    public class CCommands
    {
        //pass the function that contains the command to the executing parameter
        public CCommands(string name, Execute executing)
        {
            _name = name;
            Executor = executing;
        }

        private string _name;
        public Execute Executor;
        
    }
}
