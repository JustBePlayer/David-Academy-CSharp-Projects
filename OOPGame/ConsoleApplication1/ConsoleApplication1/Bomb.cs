using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bomb : Item
    {
        //конструктор за инициализация на бомба
        public Bomb()
            :base(1,"Bomb",0,0)
        {
            
        }


        public override void Activate(Player player)
        {
            
            player.UpdatePlayerStats(-Damage, 0);
            Console.SetCursorPosition(Console.WindowWidth - 18, 6);
            Console.Write(Name);
            Stats.UpdateItemCount(-Damage, 0, 0);  
        }
    }
}
