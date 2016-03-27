using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Chest : Container
    {
        public bool isLocked { get; private set; }

        public Chest(int time)
            :base(time)
        {
            Body = '\u25A0';
            
            item = new Item[ItemsInTheAraay()];
            
        }


        

        /// <summary>
        /// Функция която генерира това което ще има в съндъка - имплементира IGrub.
        /// </summary>
        /// <param name="r1">параметър за повече бомби</param>
        public override void Surprise(int r1, Random rand)
        {
            base.Surprise(r1, rand);
            //Random rand = new Random();
            int x = 0;


            x = rand.Next(0, 2);
            if (x == 0) 
            { 
                isLocked = true; 
            }
            else 
            {
                isLocked = false;
            }

            //ContItems = item;
        }
    }
}
