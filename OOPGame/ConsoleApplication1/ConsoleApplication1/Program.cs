using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// //пита дали искаме да минем в следващото ниво или не (ако сме го минали вече) 
        /// </summary>
        /// <returns>да - true / не - false</returns>
        static bool GoToNextLevelIfYouHaveAlreadyReachedIt()
        {
             if (!Console.KeyAvailable)
                return false ;
             Console.SetCursorPosition(Console.WindowWidth - 18, 16);
            ConsoleKeyInfo info = Console.ReadKey();

            while (Console.KeyAvailable)
           
                info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.D1: { return true; } 
                    default: { return false; } 
                }
            
            
        }


        /*Важно!!! Преди да ЗАПОЧНЕТЕ !!! !!!
         * Играта съдържа 6 нива с различна трудност.
         * При проверка дали искаме да отворим съндък с шперц се отговаря с y - за да или произволен клавиш различен от y
         * Ако сме стигнали края на нивото и сме избрали да останем в него - чрез задържане на клавиша '1' можем да преминем на следващото ниво
         * Когато преровим контейнер и намерим в него разни неща на екрана се изписва намерения последен предмет.
         */
        static void Main(string[] args)
        {

            //Генериране на поле(което по късно ще служи за инициализиране на полето в GameLeverl) и играч.
            Field f1 = new Field();
            Player player = new Player(4,4);

            //Добавяне на ограда
            f1.AddWall();

            //генериране на Нивото и изписване на масива в конзолата
            GameLevel field = new GameLevel(1, f1);
            field.Field.ShowField();

            //скриване на курсора
            Console.CursorVisible = false;

            //Хронометър, който играе ролята на таймер
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Изписване на нивото
            Console.SetCursorPosition(Console.WindowWidth - 18, 2);
            Console.Write("Level: {0}",field.Level);
            

            //Безкраен цикъл в който се обединяват функциите които са нужни .
            while (true)
            {
                Console.SetCursorPosition(0, 0);
               
                // Ако функцията върне false по някаква причина играта да спре
                if (player.Move(field.Field.ReturnField, ref stopWatch) == false)
                    break;

                //Проверка дали е стъпено върху бутона за следващото ниво
                if (player.Stop == true)
                {
                    //проверка дали искаме да отидем на следващото ниво и ако не искаме player Next не се променя за да може да върнем, когато поискаме 
                    player.Next = 1;

                    //Ако искаме да отидем на ново ниво подготвяме само това което е нужно за следващото ниво. 
                    if (player.NextLevelOrNo())
                    {
                        field.MoveToNextlevel();
                        int temp = field.Level;
                        f1.AddWall();
                        player.Next = 2;
                        Stats.DefaultCount();
                        field = new GameLevel(temp, f1);


                    }
                        //оставаме си в същото ниво и си генерираме нещата които са характерни за него отново
                    else
                    {
                        f1.AddWall();
                        Stats.DefaultCount();
                        field = new GameLevel(field.Level, f1);
                    }

                    
                    //служи за изтриване, ако има нещо на мястото за питане в конзолата
                    Console.SetCursorPosition(Console.WindowWidth - 18, 15);
                    for (int i = Console.WindowWidth - 18; i < Console.WindowWidth ; i++)
                    {
                        Console.Write(' ');
                    }
                    
                    //Методи характерни и за двете опции (Искаме или не искаме да преминем на ново ниво)
                    field.Field.ShowField();
                    //player.Stop = false;
                    Console.SetCursorPosition(Console.WindowWidth - 18, 2);
                    Console.Write("Level: {0}", field.Level);
                    stopWatch.Reset();
                    stopWatch.Start();
                }

                //Проверка дали искаме да преминем в следващото ниво ако вече сме минали старото
                if (player.Next == 1)
                {
                    if (GoToNextLevelIfYouHaveAlreadyReachedIt())
                    {

                        field.MoveToNextlevel();

                        int temp = field.Level;
                        f1.AddWall();
                        Stats.DefaultCount();
                        field = new GameLevel(temp, f1);
                        player.PlayerBaseValue();
                        
                        field.Field.ShowField();
                        //player.Stop = false;
                        Console.SetCursorPosition(Console.WindowWidth - 18, 2);
                        Console.Write("Level: {0}", field.Level);
                        stopWatch.Reset();
                        stopWatch.Start();
                        player.Next = 0;
                    }

                }

                //Проверка дали сме минали максималното 6 ниво и да спрем ако сме го минали.
                if (field.Level > 6)
                {
                    break;
                }

                //Забавяне при намиране на заключен съндък
                if (player.PassKey == true)
                {
                   // player.PassKey = false;
                    stopWatch.Start();

                    if(player.StartThreadIfPassKey == true)
                    Thread.Sleep(player.UnlockTime);

                    //player.StartThreadIfPassKey = false;
                }

                //Отпечатване на играча и неговите характеристики
                player.OutPutPlayer();
                Console.SetCursorPosition(Console.WindowWidth - 18, 4);
                Console.Write("HP:{0}",player.HealtPoints);

                Console.SetCursorPosition(Console.WindowWidth - 12, 4);
                Console.Write("P:{0}", player.Points);

              

                // Отпечатване на времето
                Console.SetCursorPosition(Console.WindowWidth - 18, 10);
                Console.Write("Timer(60sec): {0,3}",60 - stopWatch.Elapsed.Seconds);

                //Проверка дали е минала 1 минута и ако е минала програмата трябва да спре
                if (stopWatch.Elapsed.Minutes >= 1) { break; }

                Stats.ShowStats();
              
            }

            //спиране на брояча и изкарване на точките
            stopWatch.Stop();
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("Player Points: {0}", player.Points);

            Console.ReadLine();
            
        }
    
    }
}
