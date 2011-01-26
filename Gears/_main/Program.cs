using System;
using GearsDebug;

//This file is scheduled to not exist in future versions of Gears. Gears will become a library.
namespace Gears
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GearsDebug.GearsDebug game = new GearsDebug.GearsDebug())
            {
                game.Run();
            }
        }
    }
}

