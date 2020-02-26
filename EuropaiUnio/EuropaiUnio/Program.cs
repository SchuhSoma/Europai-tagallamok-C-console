using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EuropaiUnio
{
    class Program
    {
        static List<EUtagallamok> EutagallamokList;
        static List<string> CsatDatumok;
        static List<string> Evek;
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------------------------\n");
            Feladat2Beolvasas();
            Console.WriteLine("\n------------------------------------\n");
            Feladat3Tagallamokszama();
            Console.WriteLine("\n------------------------------------\n");
            Feladat42007esCsat();
            Console.WriteLine("\n------------------------------------\n");
            Feladat5MOcsat();
            Console.WriteLine("\n------------------------------------\n");
            Feladat6Majus();
            Console.WriteLine("\n------------------------------------\n");
            Feladat7Legutolso();
            Console.WriteLine("\n------------------------------------\n");
            Feladat8Satisztika();
            Console.ReadKey();
        }

        private static void Feladat8Satisztika()
        {
            Console.WriteLine("8.Feladat: Készítsen statisztikát a csatlakozás dátumai szerint");
            Evek = new List<string>();
            foreach (var e in EutagallamokList)
            {
               if(!Evek.Contains(e.Ev))
               {
                    Evek.Add(e.Ev);
               }
            }
            foreach (var e in Evek)
            { int db = 0;
                foreach (var cs in EutagallamokList)
                {
                    if(cs.Ev==e)
                    {
                        db++;
                    }
                }
                Console.WriteLine("\t{0} : {1,-3} ország",e,db);
            }
        }

        private static void Feladat7Legutolso()
        {
            Console.WriteLine("7.Feladat: Határozza meg melyik ország csatlakozott utolkjára");
            CsatDatumok = new List<string>();
            foreach (var e in EutagallamokList)
            {
                if(!CsatDatumok.Contains(e.CsatlakozasDatum))
                {
                    CsatDatumok.Add(e.CsatlakozasDatum);
                }
            }
            CsatDatumok.Sort();
            CsatDatumok.Reverse();
            foreach (var cs in CsatDatumok)
            {
                //Console.WriteLine("{0}",cs);
            }
            foreach (var e in EutagallamokList)
            {
                if(e.CsatlakozasDatum==CsatDatumok[0])
                {
                    Console.WriteLine("\tAz utoljára csatlakozott tagállam: {0}",e.EutagallamNeve);
                }
            }
        }

        private static void Feladat6Majus()
        {
            Console.WriteLine("6.Feladat: Határozza meg volt-e májusban csatlakozás:");
            int szamlalo = 0;
            string Kulcsszo = "05";
            while (szamlalo < EutagallamokList.Count && EutagallamokList[szamlalo].CsatlakozasDatum.Contains(Kulcsszo))
            {
                szamlalo++;
            }
            if (szamlalo == EutagallamokList.Count)
            {
                Console.WriteLine("\tSajnos nem volt Májusi csatlakozás");
            }
            else
            {
                Console.WriteLine("\tVolt Májusi csatlakozás a listában");
            }
        }

        private static void Feladat5MOcsat()
        {
            Console.WriteLine("5.Feladat: Határozza meg Magyarország csatlakozási dátumát");
            int szamlalo = 0;
            string Kulcsszo = "magyarország";
            while(szamlalo<EutagallamokList.Count && Kulcsszo!=EutagallamokList[szamlalo].EutagallamNeve.ToLower())
            {
                szamlalo++;
            }
            if(szamlalo==EutagallamokList.Count)
            {
                Console.WriteLine("\tSajnos Magyarország nem csatlakozott az Eu-hoz 2018-ig");
            }
            else
            {
                Console.WriteLine("\tMagyarország az EU-hoz: {0}-ban csatlakozott",EutagallamokList[szamlalo].CsatlakozasDatum);
            }
        }

        private static void Feladat42007esCsat()
        {
            Console.WriteLine("4.Feladat: határozza meg kik csatlakoztak 2007-ben");
            int db = 0;
            foreach (var e in EutagallamokList)
            {
                if(e.CsatlakozasDatum.Contains("2007"))
                {
                    db++;
                    Console.WriteLine("\t{0,-20}: {1}", e.EutagallamNeve,e.CsatlakozasDatum);
                }
            }
            Console.WriteLine("\tA 2007-ben csatlakozottak száma: {0}",db);
        }

        private static void Feladat3Tagallamokszama()
        {
            Console.WriteLine("3.Feladat: Határozza meg 2018-ig hány tagállama volt az EU-nak");
            Console.WriteLine("\tTagállamok száma a listában: {0}", EutagallamokList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat: Beolvasás");
            EutagallamokList = new List<EUtagallamok>();
            var sr = new StreamReader(@"EUcsatlakozas.txt", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                EutagallamokList.Add(new EUtagallamok(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás.\n\tBeolvasott sorok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
        }
    }
}
