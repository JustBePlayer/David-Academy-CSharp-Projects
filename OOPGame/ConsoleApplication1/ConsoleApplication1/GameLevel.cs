using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class GameLevel
    {

        public Field Field { get; private set; }

       

        private int r1 = 1;

        public int Exit_X { get; private set; }
        public int Exit_Y { get; private set; }

        public int Level { get; private set; }

        public GameLevel(int level, Field field)
            
        {
            Level = level;
            Field = field;
            AddWall();
        }

        /// <summary>
        /// Функция която служи за Генериране на случайни координати за изхода в края на игралното поле
        /// </summary>
        public void ExitCoord()
        {
            Random rand = new Random();
            int temp = rand.Next(Field.ReturnField.GetLength(0) - 6, Field.ReturnField.GetLength(0) - 2);
            Exit_X = temp;

            temp = rand.Next(3, Field.ReturnField.GetLength(1) - 3);
            Exit_Y = temp;
        }

        public void MoveToNextlevel()
        {
            Level++;
        }

        /// <summary>
        /// Презаписан метод за генериране на препядствия вътре в игралното поле
        /// </summary>
        private void AddWall()
        {
            
            if (Level == 1)
            {
                r1 = 1;
                AddItems(200,300);
            }

            if (Level == 2)
            {
                r1 = 3;
                AddItems(150, 200);
            }

            if (Level == 3)
            {
                r1 = 5;
                AddItems(120, 150);
            }
            if (Level == 4)
            {
                r1 = 8;
                AddItems(100, 100);
            }

            if (Level == 5)
            {
                r1 = 10;
                AddItems(75, 70);
            }

            if (Level == 6)
            {
                r1 = 13;
                AddItems(45, 50);
            }
 
        }


        /// <summary>
        /// Функция, която служи за генериране на плочките в играта по зададени стойности.
        /// </summary>
        /// <param name="random1">случаен параметър за бомби</param>
        /// <param name="random2">случаен параметър за диаманти</param>
        private void AddItems(int random1, int random2)
        {
            ExitCoord();

            //char[,] field = ReturnField;

            int x = 1;
            Random rand = new Random();

            for (int i = 2; i < Field.ReturnField.GetLength(0) - 2; i++)
            {
                for (int k = 2; k < Field.ReturnField.GetLength(1) - 2; k++)
                {
                   
                        if (i == Exit_X && k == Exit_Y)
                        {
                            Field.ReturnField[i, k] = new Exit();
                        }
                        else
                        {
                            x = rand.Next(0, random1);
                            switch (x)
                            {
                                case 1: { Field.ReturnField[i, k] = new Wall(); } break;
                                case 2: { Field.ReturnField[i, k] = new Pillar(); } break;
                            }

                            x = rand.Next(0, random2);
                            if (x == 1)
                            {
                                x = rand.Next(0,3);
                                if (x < 2)
                                {
                                    Field.ReturnField[i, k] = new Rubbish(2000);
                                }
                                else
                                {
                                    Field.ReturnField[i, k] = new Chest(1000);
                                }

                                ((Container)Field.ReturnField[i, k]).Surprise(r1, rand);

                                    for (int j = 0; j < ((Container)Field.ReturnField[i, k]).item.Length; j++)
                                    {

                                        if (((Container)Field.ReturnField[i, k]).item[j] is Bomb)
                                        {
                                            Stats.UpdateItemCount(1, 0, 0);
                                        }
                                        if (((Container)Field.ReturnField[i, k]).item[j] is Diamond)
                                        {
                                            Stats.UpdateItemCount(0, 1, 0);
                                        }
                                        if (((Container)Field.ReturnField[i, k]).item[j] is MagicWater)
                                        {
                                            Stats.UpdateItemCount(0, 0, 1);
                                        }
                                    }

                            }

                            
                        }

                }
            }
        }

       
    }
}
