using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IGrub
    {
         //Метод за генериране на предметите в контейнерите
          void Surprise(int r1, Random rand);
    }
}
