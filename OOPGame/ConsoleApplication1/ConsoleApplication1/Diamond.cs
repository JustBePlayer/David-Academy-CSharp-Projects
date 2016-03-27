using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Diamond : Item
    {

        //инициализиране на данните за предмета диаманд
        public Diamond()
            :base(0,"Diam",1,0)
        {
           

        }
        public override void Activate(Player player)
        {
            player.UpdatePlayerStats(0, Points);
            Console.SetCursorPosition(Console.WindowWidth - 18, 6);
            Console.Write(Name);
            Stats.UpdateItemCount(0, -1, 0);
        }
    }
}
