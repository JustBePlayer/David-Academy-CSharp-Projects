using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MagicWater : Item
    {
        //Инициализиране на магическата вода
        public MagicWater()
            :base(0,"Mwat", 0, 1)
        {

        }

        public override void Activate(Player player)
        {
            if (player.HealtPoints < 6)
            {
                player.UpdatePlayerStats(HealthPoints, 0);
            }
            Console.SetCursorPosition(Console.WindowWidth - 18, 6);
            Console.Write(Name);
            Stats.UpdateItemCount(0, 0, -1);    
        }
    }
}
