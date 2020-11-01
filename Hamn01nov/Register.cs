using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;
using System.Linq;

namespace Hamnen
{


    class Register
    {

        const int xPosHmReg = 50, yPosHmReg = 7;
        public static void SkrivutHamnaregister(List<Båt> reg, int day)  

        {
 /* var = IEnumerable*/   IEnumerable<Båt> dagensRegister = from b in reg   // dagenRegister är en lista , det finns alla båtar som är i hamnen en x dag.   
                    where (day - b.aDag) < b.dagarIhamnen     // (pågående dag - ankomstdagen av båten) ska vara < dagarna båten ska stanna i hamnen
                    orderby b.kajPlats
                    select b;
            
            flotta(dagensRegister);      // räcknar båtarna enligt typ som finns i kajen en x dag   (ex. Motorbåtar[5])
            
            
            statistik(dagensRegister);
            




            int ypos = yPosHmReg;
            SetCursorPosition(xPosHmReg, ypos++);
            Console.BackgroundColor = ConsoleColor.Blue;
            Write("     H A M N R E G I S T R E T      ");
            Console.BackgroundColor = ConsoleColor.Black;
            SetCursorPosition(xPosHmReg, ypos++);
            Write("--------------------------------------");
            string sPlats, övrigt;
            foreach (var b in dagensRegister)       // skriver ut alla båtar som finns i listan q 
            {
                sPlats = b.kajPlats.ToString();
                if (b.antalPlatser > 1)
                    sPlats += "-" + (b.kajPlats + b.antalPlatser - 1).ToString();
                //sPlats += "".Substring(0, b.antalPlatser - 1);

                övrigt = b.övrigt.Beskrivning + b.övrigt.value.ToString() + b.övrigt.mått;


                SetCursorPosition(xPosHmReg, ypos++);

                Write("{0,-5} [{1,5}] ", sPlats, b.Identitetsnummer);
                Console.ForegroundColor = b.färg;
                Write(" {0,-10}  ", b.typ);
                Console.ForegroundColor = ConsoleColor.White;
                Write("{0,-15} ", övrigt);
                // 
            }
            for (int i = 1; i < 7 && ypos < 40; i++)
            {
                SetCursorPosition(xPosHmReg, ypos++);
                WriteLine($"                                                                   ");
            }

            
        }
        public static void flotta(IEnumerable<Båt> dagensRegister)
        {
            var q1 = from b in dagensRegister         // delat i grupp alla båttyper
                     group b by b.typ;

            SetCursorPosition(80, 12);

            foreach (var z in q1)
            {
                Write("{0,2} [{1,2}]", z.Key, z.Count());
            }

            Console.BackgroundColor = ConsoleColor.Blue;
            SetCursorPosition(80, 3);
            Write($" Båtar som finns på kajen {dagensRegister.Count()} ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void statistik(IEnumerable<Båt> dagensRegister)


        { double Media = (from b in dagensRegister
                          select b.vikt).Average();

            double totalVikt = (from b in dagensRegister
                                select b.vikt).Sum();

            double medelHastighet = (from b in dagensRegister
                                     select b.maxHastighet).Average();

            double ledigaPlatser = Kaj.ledigaPlatser();

            Console.SetCursorPosition(2, 32);
            Console.Write($"Lediga Platser: {ledigaPlatser}  Total Vikt: {totalVikt}  Medelhastighet: {medelHastighet}  ");


        }
    }
}
