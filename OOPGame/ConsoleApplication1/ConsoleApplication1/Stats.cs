using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Stats
    {
        //Брой елемнти
        public static int BombCount { get; private set; }
        public static int DiamondCount { get; private set; }
        public static int MagicWaterCount { get; private set; }
        
        /// <summary>
        /// Функция, която показва колко стойността на полетата
        /// </summary>
        public static void ShowStats()
        {
            Console.SetCursorPosition(Console.WindowWidth - 18, 7);
            Console.Write("B:{0,3} D:{1,3} MW{2,3}", BombCount, DiamondCount, MagicWaterCount);
        }

        /// <summary>
        /// Функция, която изчислява стойностите
        /// </summary>
        /// <param name="bomb">бомби</param>
        /// <param name="diamond">диаманти</param>
        /// <param name="magicwater">магически води</param>
        public static void UpdateItemCount(int bomb, int diamond, int magicwater)
        {
            BombCount += bomb;
            DiamondCount += diamond;
            MagicWaterCount += magicwater;
        }

        /// <summary>
        /// Функция, която нулира стойностите.
        /// </summary>
        public static void DefaultCount()
        {
            BombCount = 0;
            DiamondCount = 0;
            MagicWaterCount = 0;
        }

        
    }
}
