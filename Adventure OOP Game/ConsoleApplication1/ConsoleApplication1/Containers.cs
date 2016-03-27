using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Container : Plate,IGrub
    {
        // време за изчакване
        
        private Item[] _item;

        protected readonly int _time;
        public  int Time 
        {
            get { return _time; }
        }

        //инициализация на данните
        public Item[] item
        {
            get { return _item; }
            protected set { _item = value; }
        }

        public Container(int time)
        {
            _time = time;
        }

        public int ItemsInTheAraay()
        {
            Random rand = new Random();
            int x = rand.Next(1, 4);
            return x;
        }
        //функция за генериране на елементите в масива
        public virtual void Surprise(int r1, Random rand)
        {
            //Random rand = new Random();
            int x = 0;

            for (int i = 0; i < _item.Length; i++)
            {
                x = rand.Next(0, r1 + 2);
                if (x < r1) { item[i] = new Bomb(); Name = item[i].Name; }
                if (x == r1) { item[i] = new Diamond(); Name = item[i].Name; }
                if (x > r1) { item[i] = new MagicWater(); Name = item[i].Name; }
            }
            //ContItems = item;
        }

        
        
    }
}
