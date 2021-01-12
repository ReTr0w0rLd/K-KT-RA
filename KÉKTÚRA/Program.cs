using System;
using System.IO;

namespace KÉKTÚRA
{
    class Program
    {
        public static bool HianyosNev(string nev, bool pecset)
        {
            Console.WriteLine("Oláh Antal");
            //6
            if (nev.Contains("pecsetelohely") ^ (pecset == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            // Az adatok tárolásához előkészített tömbök:
            const int tengerszint = 192;
            string[] kiindulas = new string[20];
            string[] vegpont = new string[20];
            double[] hossz = new double[20];
            int[] emel = new int[20];
            int[] lejt = new int[20];
            bool[] pecset = new bool[20];
            int szakasz = 0;
            int szamlalo = 0;
            int szamlalo2 = 0;
            double osszeg = 0;
            double legkisebbhossz = 0;
            string legkisebbki;
            string legkisebbveg;
            int legmagasabb;
            int legmagasabbindex = 0;

            StreamReader sr = new StreamReader("kektura.csv");
            string adat = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                adat = sr.ReadLine();
                string[] ertekek = adat.Split(';');
                kiindulas[szamlalo] = ertekek[0];
                vegpont[szamlalo] = ertekek[1];
                hossz[szamlalo] = double.Parse(ertekek[2]);
                emel[szamlalo] = Int32.Parse(ertekek[3]);
                lejt[szamlalo] = Int32.Parse(ertekek[4]);
                if (ertekek[5] == "i")
                {
                    pecset[szamlalo] = true;
                }
                else
                {
                    pecset[szamlalo] = false;
                }
                szamlalo++;
            }
            sr.Close();
            //3:
            while (kiindulas[szamlalo2] != null)
            {
                szamlalo2++;
                szakasz++;
            }
            Console.WriteLine("3. Feladat: A szakaszok száma: {0} db", szakasz);
            //4:
            for (int i = 0; i < szakasz; i++)
            {
                osszeg += hossz[i];
            }
            Console.WriteLine("4. Feladat: A túra teljes hossza: {0} km", osszeg);
            //Feladat 5:
            legkisebbki = kiindulas[0];
            legkisebbveg = vegpont[0];
            legkisebbhossz = hossz[0];
            for (int i = 0; i < szakasz; i++)
            {
                if (hossz[i] < legkisebbhossz)
                {
                    legkisebbhossz = hossz[i];
                    legkisebbki = kiindulas[i];
                    legkisebbveg = vegpont[i];
                }
            }
            Console.WriteLine("5. feladat: a legrovidebb szakasz adatai: \n\tkezdete: \tvege: " +
                "{ 1} \n\tHossza: { 2} km", legkisebbki, legkisebbveg, legkisebbhossz);
            //7:
            Console.WriteLine("7. Feladat: Hiányos állomásnevek:");
            for (int i = 0; i < szakasz; i++)
            {
                if (HianyosNev(vegpont[i], pecset[i]) == true)
                {
                    Console.WriteLine("\t{0}", vegpont[i]);
                }
                else
                {
                    if (i == szakasz - 1)
                    {
                        Console.WriteLine("Nincs hiányos állomásnév!");
                    }
                    else
                    {
                    }
                }
            }
            //8:
            Console.WriteLine("8. Feladat: A túra legmagassabban fekvő végpontja:");
            legmagasabb = emel[0];
            for (int i = 0; i < szakasz; i++)
            {
                if (emel[i] > legmagasabb)
                {
                    legmagasabbindex = i;
                    legmagasabb = emel[i];
                }
            }
            Console.WriteLine("\tA végpont neve: {0}", vegpont[legmagasabbindex]);
            legmagasabb = tengerszint;
            for (int i = 0; i < legmagasabbindex + 1; i++)
            {
                legmagasabb += (emel[i] - lejt[i]);
            }
            Console.WriteLine("\tA végpont tengerszint feletti magassága: {0} m",
            legmagasabb);

        }
    }
}