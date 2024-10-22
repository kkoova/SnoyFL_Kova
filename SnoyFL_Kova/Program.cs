using Microsoft.Xna.Framework;
using System;

namespace SnoyFL_Kova
{
    static class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        [STAThread]
        static void Main()
        {
           using (var game = new SnowfallGame())
            {
                game.Run();
            }
        }
    }
}
