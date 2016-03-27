using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace SpaceCraft
{
    class Program
    {
        /// <summary>
        ///  Функция за преместване на космическия кораб на дясно,ляво,горе и долу и проверява за  сблъсък с астероидите
        /// </summary>
        /// <param name="asteroids">преместване и проверяжане за сблъсък</param>
        /// <returns></returns>
        static bool SpaceCraftManualMove(char[,] asteroids)
        {

            if (!Console.KeyAvailable)
                return true;
            ConsoleKeyInfo info = Console.ReadKey(true);

            while (Console.KeyAvailable)

                info = Console.ReadKey(true);
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        for (int i = asteroids.GetLength(0) - 1; i >= 0; i--)
                        {
                            if (asteroids[i, 0] == '=' || asteroids[i, 0] == '+' || asteroids[i, 0] == '|' || asteroids[i, 0] == 'o' || asteroids[i, 0] == '>')
                            {
                                break;
                            }
                            for (int k = 0; k < asteroids.GetLength(1); k++)
                            {
                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                                {
                                    if (asteroids[i, k - 1] == '*') return false;

                                    asteroids[i, k - 1] = asteroids[i, k];
                                    asteroids[i, k] = ' ';


                                }


                            }
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        for (int i = asteroids.GetLength(0) - 1; i >= 0; i--)
                        {
                            if (asteroids[i, asteroids.GetLength(1) - 1] == '=' || asteroids[i, asteroids.GetLength(1) - 1] == '+' || asteroids[i, asteroids.GetLength(1) - 1] == '|' || asteroids[i, asteroids.GetLength(1) - 1] == 'o' || asteroids[i, asteroids.GetLength(1) - 1] == '>')
                            {
                                break;
                            }
                            for (int k = asteroids.GetLength(1) - 1; k >= 0; k--)
                            {
                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                                {
                                    if (asteroids[i, k + 1] == '*') return false;
                                   
                                    asteroids[i, k + 1] = asteroids[i, k];
                                    asteroids[i, k] = ' ';
                                }

                            }
                        }
                    }
                    break;

                case ConsoleKey.RightArrow:
                    {
                        for (int k = asteroids.GetLength(1) - 1; k >= 0; k--)
                        {
                            if (asteroids[asteroids.GetLength(0) - 1, k] == '=' || asteroids[asteroids.GetLength(0) - 1, k] == '+' || asteroids[asteroids.GetLength(0) - 1, k] == '|' || asteroids[asteroids.GetLength(0) - 1, k] == 'o' || asteroids[asteroids.GetLength(0) - 1, k] == '>')
                            {
                                break;
                            }
                            for (int i = asteroids.GetLength(0) - 1; i >= 0; i--)
                            {

                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                                {
                                    if (asteroids[i + 1, k] == '*') return false;

                                    
                                    asteroids[i + 1, k] = asteroids[i, k];
                                    asteroids[i, k] = ' ';
                                }
                            }
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        for (int k = 0; k < asteroids.GetLength(1); k++)
                        {
                            if (asteroids[0, k] == '=' || asteroids[0, k] == '+' || asteroids[0, k] == '|' || asteroids[0, k] == 'o' || asteroids[0, k] == '>')
                            {
                                break;
                            }
                            for (int i = 0; i < asteroids.GetLength(0); i++)
                            {

                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                                {
                                    if (asteroids[i - 1, k] == '*') return false;

                                    
                                    asteroids[i - 1, k] = asteroids[i, k];
                                    asteroids[i, k] = ' ';
                                }
                            }
                        }
                    }
                    break;

            }

            return true;
        }  

        /// <summary>
        /// Функция за създаването на космическия кораб
        /// </summary>
        /// <param name="asteroids"> космически кораб </param>
        static void CreateSpaceCraft(char[,] asteroids)
        {

            asteroids[0, (asteroids.GetLength(1) - 1) / 2 - 1] = '=';
            asteroids[0, (asteroids.GetLength(1) - 1) / 2] = ' ';
            asteroids[0, (asteroids.GetLength(1) - 1) / 2 + 1] = '=';

            asteroids[1, (asteroids.GetLength(1) - 1) / 2 - 1] = '+';
            asteroids[1, (asteroids.GetLength(1) - 1) / 2] = '|';
            asteroids[1, (asteroids.GetLength(1) - 1) / 2 + 1] = '+';

            asteroids[2, (asteroids.GetLength(1) - 1) / 2 - 1] = '=';
            asteroids[2, (asteroids.GetLength(1) - 1) / 2] = 'o';
            asteroids[2, (asteroids.GetLength(1) - 1) / 2 + 1] = '=';

            asteroids[3, (asteroids.GetLength(1) - 1) / 2 - 1] = '+';
            asteroids[3, (asteroids.GetLength(1) - 1) / 2] = '|';
            asteroids[3, (asteroids.GetLength(1) - 1) / 2 + 1] = '+';

            asteroids[4, (asteroids.GetLength(1) - 1) / 2 - 1] = '>';
            asteroids[4, (asteroids.GetLength(1) - 1) / 2] = ' ';
            asteroids[4, (asteroids.GetLength(1) - 1) / 2 + 1] = '>';


        } 


        /// <summary>
        ///  Това е функцията, която предвижва астероидите от дясно на ляво
        /// </summary>
        /// <param name="asteroids">предвижва астероидите</param>
        /// <param name="speed">скоростна променлива</param>
        /// <returns></returns>
        static bool MoveAsteroids(char[,] asteroids, int speed) 
        {
            speed++;
            if (speed > 900)
            {
                for (int i = 0; i < asteroids.GetLength(0) - 4; i++)
                {
                    for (int k = 0; k < asteroids.GetLength(1) - 4; k++)
                    {
                        if (asteroids[i, k] == ' ' || asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                        {
                            if (asteroids[i + 4, k] == '*' || asteroids[i + 1, k] == '*')
                            {
                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>') return false;

                                asteroids[i, k] = '*';
                                asteroids[i + 4, k] = ' ';
                            }

                        }

                    }
                    if (asteroids[i, 0] == '*')
                    {
                        asteroids[i, 0] = ' ';
                    }


                }

            }
            if (speed > 600)
            {
                for (int i = 0; i < asteroids.GetLength(0) - 3; i++)
                {
                    for (int k = 0; k < asteroids.GetLength(1) - 3; k++)
                    {
                        if (asteroids[i, k] == ' ' || asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                        {
                            if (asteroids[i + 3, k] == '*' || asteroids[i + 1, k] == '*')
                            {
                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>') return false;

                                asteroids[i, k] = '*';
                                asteroids[i + 3, k] = ' ';
                            }

                        }

                    }
                    if (asteroids[i, 0] == '*')
                    {
                        asteroids[i, 0] = ' ';
                    }


                }

            }
            else if (speed > 300)
            {
                for (int i = 0; i < asteroids.GetLength(0) - 2; i++)
                {
                    for (int k = 0; k < asteroids.GetLength(1) - 2; k++)
                    {
                        if (asteroids[i, k] == ' ' || asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                        {
                            if (asteroids[i + 2, k] == '*' || asteroids[i + 1, k] == '*')
                            {
                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>') return false;

                                asteroids[i, k] = '*';
                                asteroids[i + 2, k] = ' ';
                            }

                        }

                    }
                    if (asteroids[i, 0] == '*')
                    {
                        asteroids[i, 0] = ' ';
                    }


                }

            }
            else
            {
                for (int i = 0; i < asteroids.GetLength(0) - 1; i++)
                {
                    for (int k = 0; k < asteroids.GetLength(1) - 1; k++)
                    {
                        if (asteroids[i, k] == ' ' || asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>')
                        {
                            if (asteroids[i + 1, k] == '*')
                            {
                                if (asteroids[i, k] == '=' || asteroids[i, k] == '+' || asteroids[i, k] == '|' || asteroids[i, k] == 'o' || asteroids[i, k] == '>') return false;

                                asteroids[i, k] = '*';
                                asteroids[i + 1, k] = ' ';
                            }

                        }
                    }


                }
            }
            return true;
        }


        /// <summary>
        /// // Това е функцията, която трие астероидите за да не се натрупват
        /// </summary>
        /// <param name="asteroids">трие астероидите</param>
        /// <param name="speed">скоростна променлива</param>
        static void Delete(char[,] asteroids, int speed)
        {
            for (int i = 0; i < asteroids.GetLength(1) - 1; i++)
            {
                if (asteroids[0, i] == '*')
                {
                    asteroids[0, i] = ' ';

                    if (speed > 300)
                        asteroids[1, i] = ' ';
                    if (speed > 600)
                        asteroids[2, i] = ' ';
                    if (speed > 900)
                        asteroids[3, i] = ' ';
                }
            }
        }

        /// <summary>
        /// Функция,която генерира първи ред астероиди
        /// </summary>
        /// <param name="asteroids">генериране на астероиди</param>
        /// <param name="speed">скоростна променлива</param>
  

        static void AddStars(char[,] asteroids, int speed) 
        {
            Random rnd = new Random();
            int add;
            int stoinost = 200;

            if (speed > 900)
                stoinost = 10;

            if (speed > 600)
                stoinost = 40;

            if (speed > 300)
                stoinost = 100;


            for (int i = 0; i < asteroids.GetLength(1) - 1; i++)
            {
                add = rnd.Next(0, stoinost); //1 = vali; 
                if (add == 1)

                    asteroids[asteroids.GetLength(0) - 1, i] = '*';

            }
        }


        /// <summary>
        /// Това е функия, която извежда масива и го оцетява.
        /// </summary>
        /// <param name="asteroids">небе от цветни астероиди.</param>
        static void ShowMatrix(char[,] asteroids) 
        {
            Console.SetCursorPosition(0, 0); // Позициониране на курсора

            for (int j = 0; j < asteroids.GetLength(1); j++)
            {
                for (int k = 0; k < asteroids.GetLength(0); k++)
                {
                    switch (asteroids[k, j])
                    {
                        case '=':
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            break;

                        case '*':
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            break;

                        case '+':
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case '>':
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case '|':
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            break;
                        case 'o':
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            break;


                    }

                    Console.Write(asteroids[k, j]);

                }


            }
        }


        /// <summary>
        /// Главна програма 
        /// </summary>
        /// <param name="args">програма</param>
        static void Main(string[] args)
        {
            char[,] asteroids = new char[Console.WindowWidth, Console.WindowHeight];

            int speed = 0; //Скоростна променлива
            int DistanceCount = 0; //служи за измерване на разстоянието  спрямо изминатото разстояние на астероидите

            for (int i = 0; i < asteroids.GetLength(0); i++)
            {
                for (int k = 0; k < asteroids.GetLength(1); k++)
                {
                    asteroids[i, k] = ' ';

                }

            }
            CreateSpaceCraft(asteroids);

            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Console.CursorVisible = false;

            do
            {
                speed++;

                AddStars(asteroids, speed);

                if (!MoveAsteroids(asteroids, speed)) break;
                Delete(asteroids, speed);

                ShowMatrix(asteroids);
                if (!SpaceCraftManualMove(asteroids)) break;

                DistanceCount++;

            }
            while (true);


            Console.CursorVisible = true;
            Console.Clear();
            Console.ResetColor();

            Console.WriteLine("Game Over");
            Console.WriteLine("Distance: {0} ", DistanceCount);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.ReadLine();
        }  // Главна програма
    }
}
