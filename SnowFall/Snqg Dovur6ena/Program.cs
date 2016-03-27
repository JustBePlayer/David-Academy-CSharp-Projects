using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snqg_Dovur6ena
{
    class Program
    {
        static void SnowFall(char[,] snqg) // Това е функцията, която предвижва снежинките с един ред надолу.

        {

            for (int i = snqg.GetLength(0) - 1; i > 0; i--)
            {
                for (int k = snqg.GetLength(1) - 1; k > 0; k--)
                {
                    if (snqg[i, k] == ' ')
                    {
                        if (snqg[i, k - 1] == '*')
                        {
                            snqg[i, k] = '*';
                            snqg[i, k - 1] = ' ';
                        }
                        
                    }
                }
            }
        }
        static void AddStars(char[,] snqg) // Това е функция която добавя снежинките/звездички

        {
            Random rnd = new Random();
            int DaliVali;
            int stoinost = 25;

            for (int i = 0; i < snqg.GetLength(0); i++)
            {
                DaliVali = rnd.Next(0, stoinost); //1 = vali; 
                if (DaliVali == 1)
                    snqg[i, 0] = '*';
                

            }
        }

        static void SnowShow(char[,] snqg) //Това е функия която извежда масива
        {
            for (int j = 0; j < snqg.GetLength(1); j++)
            {
                for (int k = 0; k < snqg.GetLength(0); k++)
                {
                    

                    Console.Write(snqg[k, j]);

                }

            }
        }
        static void Main(string[] args)
        {
            //Потвърждение за продължение

        Here:
            Console.WriteLine("Искате ли да завали сняг ? Ако е така просто натиснете [Y]. Ако искате да излезете натиснете [N]");
            ConsoleKeyInfo otgovor = Console.ReadKey();
        
            switch(otgovor.Key)
        {   
                
                case ConsoleKey.Y:
            {
                Console.Clear();
                goto Yes;
            }
                case ConsoleKey.N:
            {
                
                goto No;
            }
                default:
            {

                goto Here;
            }
        }

            Yes:
            char[,] snqg = new char[Console.WindowWidth, Console.WindowHeight];


            for (int i = 0; i < snqg.GetLength(0); i++)
            {
                for (int k = 0; k < snqg.GetLength(1); k++)
                {
                    snqg[i, k] = ' ';
                    
                }

            }
            


            do
            {
                while (!Console.KeyAvailable)
                {
                    System.Threading.Thread.Sleep(1);
                    Console.SetCursorPosition(0, 0);
                    AddStars(snqg); //Добави снежинки/звездички
                    
                    SnowFall(snqg); //Премести снежинките/звездичките
                    
                    SnowShow(snqg); //Покажи масива


                    
                }
            }
            while (Console.ReadKey(true).Key == ConsoleKey.Escape);  //При натискане на клавиш спри
            No:

            Console.Clear(); // Изчисти конзолата --- Ползвам го само за да може ако въведа в началото "N" да мога да приключа програмата.
            
            
            
            
        }
    }
}
