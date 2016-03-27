using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApplication1
{
    class Field
    {
        //Масив от различни видове плочки
        protected Plate[,] field = new Plate[Console.WindowWidth - 20, Console.WindowHeight - 1]; 

        //празен конструктор
        public Field()
        {

        }


        //свойство за връщане на масива
        public Plate[,] ReturnField
        {
            get { return field; }
            protected set { field = value; }
        }

       

        /// <summary>
        /// Добавяне на рамка
        /// </summary>
        public virtual void AddWall()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = new Empty_Space();
                    
                }

            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                field[i, 0] = new Wall();
            }

            for (int i = 0; i < field.GetLength(1); i++)
            {
                field[0, i] = new Wall();
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                field[i, field.GetLength(1) - 1] = new Wall();
            }

            for (int i = 0; i < field.GetLength(1); i++)
            {
                field[field.GetLength(0) - 1, i] = new Wall();
            }
        }

        /// <summary>
        /// Показване на масива
        /// </summary>
        public void ShowField()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int k = 0; k < field.GetLength(0); k++)
                {
                    Console.Write(field[k, i].Body);
                    
                }
                Console.WriteLine();
               
            }
        }
    
    }
}
