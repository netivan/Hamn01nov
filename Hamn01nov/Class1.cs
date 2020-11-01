using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hamnen
{
    public enum TYP  //sorters båtar
    {
        Roddbåt = 1,
        Motorbåt = 2,
        Segelbåt = 3,
        Lastfartyg = 4,
        Katamaran = 5
    }
    struct Övrigt
    {
        public string Beskrivning;
        public int value;
        public string mått;
    }
    class Båt
    {
        public ConsoleColor färg;
        int maxTyp = 4;
        public TYP typ;             //typ av båt : 1,2,3,4,5 
        public string Identitetsnummer;
        public int vikt;           //kg
        public int maxHastighet;  // Km/h
        public string hamnplats;   //H: halv hamnplats, F: ett hamnplats
        public int dagarIhamnen;  //dagar med stopp vid hamnen
        public Övrigt övrigt;

        //------
        public int aDag;   //ankomstdag till hamnen
        public int kajPlats;   // Första platsen i kajen 
        public int antalPlatser;    //  anatal hamnplatser båten ockuperar
        static Random r = new Random();

        public Båt(int day)
        {
            typ = (TYP)r.Next(1, maxTyp + 1);   //  motorbåt (exempel)

            aDag = day;
            switch (typ)
            {
                case (TYP)1:
                    infoRoddbåt();
                    break;
                case (TYP)2:
                    infoMotorbåt();
                    break;
                case (TYP)3:
                    infoSegelbåt();
                    break;
                case (TYP)4:
                    infoLastfartyg();
                    break;
                case (TYP)5:
                    infoKatamaran();
                    break;
                    //default:
                    //  break;
            }

        }
        private void infoRoddbåt()
        {

            vikt = r.Next(10, 31) * 10;  //båtens vikt 100 kg
            maxHastighet = r.Next(1, 4); //båtens hastighet i knop
            dagarIhamnen = 1; //Roddbåtar stannar I hamnen 1 dag
            övrigt.Beskrivning = "Antal passagerare :";
            övrigt.value = r.Next(1, 7);//Max antal passagerare (1 til 6)
            övrigt.mått = " ";
            Identitetsnummer = "R-" + RandomCode(3);
            antalPlatser = 0;    //  halv plats ockuperad
            hamnplats = "H";
            färg = ConsoleColor.DarkRed;
        }




        private void infoMotorbåt()
        {
            vikt = r.Next(20, 300) * 10;  //båtens vikt fr. 200 upp till 3000kg
            maxHastighet = r.Next(1, 61); //båtens hastighet i knop
            dagarIhamnen = 3; //Motorbåtar stannar i hamnen 3 dagar
            övrigt.Beskrivning = " hästkrafter ";
            övrigt.value = r.Next(11, 1000);//Max antal hästkrafter(10 til 1000hk)
            övrigt.mått = "hk";
            Identitetsnummer = "M-" + RandomCode(3);
            antalPlatser = 1;  // 
            hamnplats = "M";
            färg = ConsoleColor.Green;
        }
        private void infoSegelbåt()
        {
            vikt = r.Next(80, 600) * 10;  //båtens vikt fr. 800 kg upp till 6000kg
            maxHastighet = r.Next(1, 61); //båtens hastighet i knop
            dagarIhamnen = 4; //Segelbåtar stannar i hamnen 4 dagar
            övrigt.Beskrivning = "Båtlängd ";
            övrigt.value = r.Next(11, 61);//Max längd(10 till 60 fot)
            övrigt.mått = "fot";
            Identitetsnummer = "S-" + RandomCode(3);
            antalPlatser = 2;
            hamnplats = "SS";
            färg = ConsoleColor.Blue;

        }
        private void infoLastfartyg()
        {
            vikt = r.Next(300, 2000) * 10;  //båtens vikt fr. 3000 kg upp till 20000kg
            maxHastighet = r.Next(0, 21); //båtens hastighet i knop
            dagarIhamnen = 6; //Lastfartyg stannar i hamnen 6 dagar
            övrigt.Beskrivning = "Last : ";
            övrigt.value = r.Next(11, 61);//Max antal lastade containers(0 till 500 containrar)
            övrigt.mått = "containers ";
            Identitetsnummer = "L-" + RandomCode(3);
            antalPlatser = 4;
            hamnplats = "LLLL";
            färg = ConsoleColor.Magenta;
        }
        private void infoKatamaran()
        {
            vikt = r.Next(120, 800) * 10;  //båtens vikt fr. 120 kg upp till 8000kg
            maxHastighet = r.Next(0, 13); //båtens hastighet i knop
            dagarIhamnen = r.Next(0, 11); //Katamaranen stannar i hamnen fr. 1 till 10 dagar
            övrigt.Beskrivning = "Antal bäddplatser ";
            övrigt.value = r.Next(0, 3);//Max antal bäddplatser(1 till 4 bäddplatser)
            övrigt.mått = "Persons";
            Identitetsnummer = "K-" + RandomCode(3);
            antalPlatser = 3;
            hamnplats = "KKK";

        }

        //public string message1() => $"{typ} [{Identitetsnummer}] -> plats {kajPlats}";    Lambda

        public string message1()
        {
            return $"  {typ} [{Identitetsnummer}] -> plats {kajPlats}";
        }

        public static string RandomCode(int length)       //  vi får ett slumpmässigt  kod av typbåt
        {

            string s = "";
            for (int i = 0; i < length; i++)
                s += (Char)r.Next('A', 'Z'); //genererar ett slumpmässigt tal mellan 65(A) och 90(Z)
            return s;


            //  //  return ((Char)r.Next(65, 90) + (Char)r.Next(65, 90) + (Char)r.Next(65, 90)).ToString();

            // return (Char)33;
        }






    }


}
