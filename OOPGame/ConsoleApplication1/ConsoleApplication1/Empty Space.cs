using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Empty_Space: Plate
    {
        //Инициализиране на празно пространство 
        public Empty_Space()
        {
            Body = ' ';
        }
    }
}
