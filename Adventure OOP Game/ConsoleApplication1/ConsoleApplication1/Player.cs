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
    class Player
    {
        //Характеристики на Играча

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public int HealtPoints { get; private set; }
        public int Points { get; private set; }

        private bool _stop = false;

        private readonly int _unlockTime = 3000;

        public int UnlockTime
        {
            get { return _unlockTime; }
        }

        private int _next = 2;
        private bool _passKey = false;

        //Метод който се използва за прехвърляне на бройа на намерените предмети от генерирането им при местенето на играча
        

        public void PlayerBaseValue()
        {
            PositionX = 4;
            PositionY = 4;
        }


       

        //фигурката на играча
        private char body = '\u263A';

        //конструктор с инициализация на Играча
        public Player(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            HealtPoints = 6;
            Points = 0;
        }

        public bool PassKey
        {
            get { return _passKey; }
            private set { _passKey = value; }
        }

        
        public int Next
        {
            get { return _next; }
            set { _next = value; }
        }
        
        public bool Stop
        {
            get { return _stop; }
            private set { _stop = value; }
        }

        

        //служи за проверка дали искаме да отворим съндика
        private bool _startThreadIfPassKey = false;

        public bool StartThreadIfPassKey
        {
            get { return _startThreadIfPassKey; }
            private set { _startThreadIfPassKey = value; }
        }

        public void UpdatePlayerStats(int healthPoints, int points)
        {
            HealtPoints += healthPoints;
            Points += points;
        }

        
        /// <summary>
        ///  Функция която служи за преместване на играча и всякакви видове проверки след като стъпи на ново квадратче
        /// </summary>
        /// <param name="field">Масива с Плочките</param>
        /// <param name="st">таймера</param>
        /// <returns></returns>
        public bool Move(Plate[,] field, ref Stopwatch st)
        {
            Stop = false;
            StartThreadIfPassKey = false;
            PassKey = false;

            
            if (!Console.KeyAvailable)
                return true ;
            ConsoleKeyInfo info = Console.ReadKey(true);

            while (Console.KeyAvailable)

                info = Console.ReadKey(true);

            int newX = 0;
            int newY = 0;

            Thread.Sleep(100);
            body = ' ';
            OutPutPlayer();
            body = '\u263A';


            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        newX = PositionX;
                        newY = PositionY - 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    {
                        newX = PositionX + 1;
                        newY = PositionY; 
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        newX = PositionX;
                        newY = PositionY + 1;    
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        newX = PositionX - 1;
                        newY = PositionY;
                    }
                    break;
            }

            //Проверка за стена/колона
            if (ChekForWallAndPillar(newX, newY, field)) 
                return true;

            if (!isChestLocked(newX, newY, field, ref st)) 
                return true;

            CheckContainer(newX, newY, field);

            if (field[newX, newY] is Exit)
            {
                st.Stop();
                Stop = true;
                newX = 4;
                newY = 4;

            }
            if (HealtPoints <= 0) 
            {
                return false; 
            }

            field[newX, newY] = new Empty_Space();

            PositionX = newX;
            PositionY = newY;


            return true;
            
        }

        /// <summary>
        /// Функция която служи за отпечатване на местоположението на играча в конзолата
        /// </summary>
        public void OutPutPlayer()
        {
                Console.SetCursorPosition(PositionX, PositionY);
                Console.Write(body);     
        }

        /// <summary>
        /// //Функция, която проверява дали искаме да отиден на следващото ниво
        /// </summary>
        /// <returns>true/false</returns>
        public bool NextLevelOrNo()
        {
            Console.SetCursorPosition(Console.WindowWidth - 18, 15);
            Console.Write("NextLevel[y,n]?: ");
            ConsoleKeyInfo info = Console.ReadKey();

            switch (info.Key)
            {
                case ConsoleKey.Y: { return true; } 
                default: {  return false; } 
            }
            
        }

        /// <summary>
        /// Функция за проверка на контейнер
        /// </summary>
        /// <param name="posX">позичия x</param>
        /// <param name="posY">позиция y</param>
        /// <param name="field">Масива с плочките</param>
        public void CheckContainer(int posX, int posY, Plate[,] field)
        {
            if (field[posX, posY] is Rubbish || field[posX, posY] is Chest)
            {
                Thread.Sleep(((Container)field[posX, posY]).Time);
                for (int j = 0; j < ((Container)field[posX, posY]).item.Length; j++)
                {
                    ((Container)field[posX, posY]).item[j].Activate(this);
   
                }
            }
        }

        /// <summary>
        /// Фукнция която проверява дали съндъка е заключен
        /// </summary>
        /// <param name="posX">позиция x</param>
        /// <param name="posY">позиция y</param>
        /// <param name="field">Масива с плочките</param>
        /// <param name="st">таймера</param>
        /// <returns>връща true, ако искаме да го отключим и false ако не искаме</returns>
        public bool isChestLocked(int posX, int posY, Plate[,] field, ref Stopwatch st)
        {
            if (field[posX, posY] is Chest)
            {
                if (((Chest)field[posX, posY]).isLocked)
                {
                    st.Stop();
                    PassKey = true;
                    if (!OpenWithPassKeyOrNo())
                    {
                        return false;
                    }
                    StartThreadIfPassKey = true;
                }
                
            }

            return true;
        }

        public bool ChekForWallAndPillar(int posX, int posY, Plate[,] field)
        {
            if (posX <= 1 || field[posX, posY] is Wall || field[posX, posY] is Pillar) 
            { 
                return true; 
            }
            
            return false;
        }

        /// <summary>
        /// Функция която служи да ни попита дали да използваме шперц при отваряне.
        /// </summary>
        /// <returns>да - true / не - false</returns>
        public bool OpenWithPassKeyOrNo()
        {
            
            Console.SetCursorPosition(Console.WindowWidth - 18, 15);
            Console.Write("PassKey?[3s]: ");
            ConsoleKeyInfo info = Console.ReadKey();


            
            switch (info.Key)
            {
                case ConsoleKey.Y: 
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 18, 15);
                        for (int i = Console.WindowWidth - 18; i < Console.WindowWidth; i++)
                        {
                            Console.Write(' ');
                        }
                        return true; 
                    } 
                default: 
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 18, 15);
                        for (int i = Console.WindowWidth - 18; i < Console.WindowWidth; i++)
                        {
                            Console.Write(' ');
                        }
                        return false; 
                    } 
            }
            
             
        }
        
    }
}
