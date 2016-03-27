using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Rubbish : Container
    {

       

        public Rubbish(int time)
            :base(time)
        {
            Body = '\u25B2';
            
            item = new Item[ItemsInTheAraay()];
            //ContItems = item;
        }

    }
}
