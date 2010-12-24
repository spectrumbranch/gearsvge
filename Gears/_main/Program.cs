using System;

using GearsDebug;

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

