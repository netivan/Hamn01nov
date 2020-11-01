using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;
using System.Threading;
using System.Linq;
using System.Text;

namespace Hamnen
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Båt> HamnRegister = new List<Båt>();   // registret av hamnen i vilken alla inkommande båtar läggs in. ( i början är tom)
            int kPlats;
            Kaj.initKaj();  // skriver ut "." dvs att befriar alla platser av kajen

            Skärm.Titel();    //   skriver ut titeln på console

            for (int day = 1; day < 30; day++)

            {

                Skärm.skrivaDay(day);     // skriver ut day inkommande och utgående båtar

                Skärm.cancelday();



                foreach (var b in HamnRegister)//Båtarna lämnar hamnen
                {
                    if ((day - b.aDag) == b.dagarIhamnen)   // Båtar lämnar hamnen med följande villkoret 
                    {
                        Kaj.RemoveBåt(b.kajPlats, b.antalPlatser);

                        Skärm.skrivautgående(b.message1());
                        Register.SkrivutHamnaregister(HamnRegister, day);
                        Thread.Sleep(900);
                    }
                }

                for (int i = 0; i < 5; i++)           // det finns 5 båtar som kommer in varje dag
                {
                    Båt b = new Båt(day);    // structorn anråpas   // skapar objekt båt.  ( b är en slumpmässig båt ) 
                    kPlats = Kaj.insertBåt(b.hamnplats);
                    if (kPlats >= 0)          //båten har placerats i kajen
                    {
                        b.kajPlats = kPlats;

                        HamnRegister.Add(b);
                        Skärm.skrivaIngående(b.message1());      //  dessa är båtarna som kom till hamnen



                        //Kaj.stampa();

                        Register.SkrivutHamnaregister(HamnRegister, day);
                    }
                    else
                    {
                        Skärm.skrivaIngående($"{b.typ} har ingen plats på kajen");
                        Console.Beep();
                    }
                    if (Skärm.pausa(500)) break;

                    //Thread.Sleep(1000);

                }

                if (Skärm.pausa(1000)) break;


                //Thread.Sleep(1800);   // ny dag


            }

        }
    }
}

