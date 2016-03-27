using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Wall : Plate
    {
        //Инициализация на данните за стената
        public Wall()
        {
            Body = '\u2593';
        }


    }
}
