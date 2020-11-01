using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;
using System.Linq;

namespace Hamnen
{
    class Skärm : Mother
    {
        const int xPosIn = 3, yPosIn = 7;       // Skriver ut titeln  "Inkommande båtar"
        const int xPosUt = 3, yPosUt = 17;            //  skriver ut titeln "Utgående båtar"
                                                      //const int xPosKaj = 9, yPosKaj = 4;

        public static int yPositionUt = yPosUt + 1;
        public static int yPositionIn = yPosIn + 1;


        public static void Titel()
        {

            //Console.SetWindowSize(80, 45);
            Console.ForegroundColor = ConsoleColor.White;
            SetCursorPosition(40, 1);
            Console.WriteLine("Stockholms Hamn");
            SetCursorPosition(1, 3);
            Write("KAJ -> |");
            SetCursorPosition(9, 3);
            Write(" 0.........10........20........30.........40........50........60...|");

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(xPosIn, yPosIn);
            Console.WriteLine("  Inkommande Båtar  ");


            //Console.SetCursorPosition(xPosIn, yPosIn + 1);
            //Console.WriteLine("______________________");

            Console.SetCursorPosition(xPosUt, yPosUt);
            Console.WriteLine("  Utgående Båtar  ");

            //Console.SetCursorPosition(xPosUt, yPosUt + 1);
            //Console.WriteLine("______________________");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void skrivaDay(int day)
        {
            Console.SetCursorPosition(11, 1);

            Console.WriteLine($"Dag {day}");      // pågående dag

            Console.SetCursorPosition(80, 1);
            Console.WriteLine($"Dag {day}");

        }
        public static void skrivaIngående(string s)
        {
            SetCursorPosition(xPosIn, yPositionIn++);
            Write(s);
        }

        public static void skrivautgående(string s)
        {
            Console.SetCursorPosition(xPosUt, yPositionUt++);
            Console.Write(s);
        }

        //public static void skrivaVikt(List<Båt> reg , int vikt)
        //{
        //   var q = from b in reg
        //           where( vikt)

        //}


        public static void cancelday()
        {

            for (int i = yPosIn + 3; i < yPositionIn; i++)
            {
                SetCursorPosition(xPosIn, i);
                Write("                                       ");
            }

            for (int i = yPosUt + 3; i < yPositionUt; i++)
            {
                SetCursorPosition(xPosUt, i);
                Write("                                             ");
            }

            yPositionUt = yPosUt + 3;
            yPositionIn = yPosIn + 3;
        }



        public static bool pausa(int delay)
        {
            for (int i = 1; i < delay; i++)
            {
                Thread.Sleep(1);   // ny dag
                if (Console.KeyAvailable == true)
                    return true;
            }
            return false;

        }
    }
}
