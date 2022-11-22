using NLipsum.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Project_Life_on_Mars
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Operation3();

            //try
            //{

            //    //operation 1.load a dna sequence from a file
            //    string filepath = "";
            //    string dna_from_file = "";

            //    if (File.Exists(filepath))
            //    {
            //        StreamReader f = File.OpenText(filepath);
            //        dna_from_file = f.ReadLine();
            //        f.Close();
            //    }
            //    Console.WriteLine(dna_from_file);

            //    operation16(dna_from_file.ToUpper());

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}


            Console.ReadLine();


        }

        //function for 16.operation
        static void operation16(string a)
        {
            try
            {
                int abonds = 0, tbonds = 0, gbonds = 0, cbonds = 0, totalbonds = 0;

                char[] array = a.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'a')
                    { abonds++; }
                    else if (array[i] == 't')
                    { tbonds++; }
                    else if (array[i] == 'g')
                    { gbonds++; }
                    else if (array[i] == 'c')
                    { cbonds++; }

                    totalbonds = (gbonds + cbonds) * 3 + (abonds + tbonds) * 2;
                }
                Console.WriteLine("number of pairing with 2-hydrogen bonds  :  {0}", (abonds + tbonds));
                Console.WriteLine("number of pairing with 3-hydrogen bonds  :  {0}", (gbonds + cbonds));
                Console.WriteLine("total bonds is  :  {0}", totalbonds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

















        public static char[] Operation3()
        {
            Random random = new Random();
            char[] Nucleotides = { 'A', 'C', 'G', 'T' };
            char[] stop = { 'A', 'G' };
            char[] dna = { };

            //random bir sekilde 1 ve 6 arasinda secilen sayi kadar gen alma kodunu calistirmak icin
            for (int j = 0; j < random.Next(1, 7); j++)
            {
                //start ve stop kodonlari sonradan eklenecegi icin sadece aradaki kodonlarin ve bosluklarin sayisi 
                //bu da en az 5 en fazla 29 eleman eder ,bosluklar dahil
                int Nucleotidnumber = random.Next(5, 29);
                //kodonlar uc harftan olustuklari icin ve bu DNA nin kesin bir blob olmasi icin bir veya iki tane harf gelirse diye bu yontemi kullandim
                //once (3 kodon arti bir bosluk) 4 mod unu aldim ve
                //mod sonucunda cikardim
                // ACC GTT CGG C  gelirse diye
                int number = Nucleotidnumber % 4;
                number = Nucleotidnumber - number;

                //4 ilk   ATG_ + yukaridan gelen harf sayisi + TAG(stop kodonu)  
                char[] codons = new char[4 + number + 3];


                for (int i = 0; i < codons.Length; i++)
                {
                    codons[i] = Nucleotides[random.Next(0, 4)];
                    //tanimladigimiz fonksiyonu stop ve start kodonlarinin aralara karismamasi icin kullandik
                    codons = WrongCodonsInWrongPlaces(codons);

                    //her uc elemandan sonra bir bosluk ekler
                    if ((i + 1) % 4 == 0)
                    {
                        codons[i] = ' ';
                    }
                }

                // genin start ve stop kodonlarini ekledik
                codons[0] = 'A';
                codons[1] = 'T';
                codons[2] = 'G';
                codons[codons.Length - 3] = 'T';
                codons[codons.Length - 2] = stop[random.Next(0,2)];
                //TGG yi stop elemani olarak algilamamasi icin
                if ( codons[codons.Length - 2]=='G')
                {
                    codons[codons.Length - 1] = 'A';
                }
                else
                {
                    codons[codons.Length - 1] = stop[random.Next(0, 2)];
                }
                // her turde dna dizisine kaydedip donguden gelen kodon dizisini ekler
                dna = MyFunctionForArrayConcatenation(dna, codons);
            }

            // son olarak   GenderSelection()  fonskiyonundan gelen cinsiyeti genini diger genlerin uzerine yapistirir 
            dna = MyFunctionForArrayConcatenation( GenderSelection() , dna );
            /////ve mucize gerceklesir/////
            return dna;
        }


        //6 cinsiyet ihtimali arasinda birisini secmek icin kullanilmistir
        public static char[] GenderSelection()
        {

            Random random = new Random();
            char[] gender_array = { };

            int gender_gene = random.Next(1, 7);
            if (gender_gene == 1)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G'};
                gender_array = f1;
            }
            else if (gender_gene == 2)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G'};
                gender_array = f1;
            }
            else if (gender_gene == 3)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G'};
                gender_array = f1;
            }
            else if (gender_gene == 4)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'C', 'C', 'C', ' ', 'T', 'A', 'G'};
                gender_array = f1;
            }
            else if (gender_gene == 5)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'G', 'G', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G'};
                gender_array = f1;
            }
            else if (gender_gene == 6)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'G', 'G', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G'};
                gender_array = f1;
            }
            return gender_array;
        }














        //burada kullanicadan iki char array alir ve ikisini birlestirip ,olusturdugu yeni dizi icersinde kullaniciya gonderir
        static char[] MyFunctionForArrayConcatenation(char[] first_char_array, char[] second_char_array)
        {
            //first_char_array.Length + second_char_array.Length + 1       +1 iki dizi arasinda bor bosluk birakmak icin
            char[] result = new char[first_char_array.Length + second_char_array.Length + 1];
            
            //iki dizinin toplam sayisi ve +1 bosluk kadar calismasi gerekir
            for (int i = 0; i < (first_char_array.Length + second_char_array.Length + 1); i++)
            {
                //ilk dizinin elemanlarini sonuc dizisini ilk bolumune yerlestirir
                if (i < first_char_array.Length)
                {
                    result[i] = first_char_array[i];
                }
                //iki dizi arasinda bosluk birakir
                else if (i == first_char_array.Length)
                {
                    result[i] = ' ';
                }
                //bosluktan sonra ikinci diziyi yerlestirmek icin
                else
                {
                    // i - (first_char_array.Length + 1)   bu denklemle ikinci dizinin elemanlarina ulastim
                    result[i] = second_char_array[i - (first_char_array.Length + 1)];
                }
            }//sonuc olarak yeni bir dizi gonderir
            return result;
        }









        //bu fonksiyon start ve stop kodonlarinin genin icerisine karismasini engeller
        //fonksiyon parametere olarak kullanicidan bir   char[] array ister   ve  sonuc olarakta  char[]  gonderir  
        static char[] WrongCodonsInWrongPlaces(char[] array)
        {
            Random random = new Random();
            char[] Nucleotides = { 'A', 'T', 'G', 'C' };

            // array.Length - 2  kullandim cunku dizinin son iki elemanini kullanmasin yok array[i+2] ve i+1 girince error verir
            for (int i = 0; i < array.Length - 2; i++)
            {
                // eger bir eleman A ise ve ondan sonrakilar T ve G ise son elemani ayni harf geldigi surece random ata
                if (array[i] == 'A' && array[i + 1] == 'T' && array[i + 2] == 'G')
                {
                    while (array[i + 2] == 'G')
                    {
                        array[i + 2] = Nucleotides[random.Next(0, 4)];
                    }
                }
                //bunlarda ustteki ile ayni mantik
                if (array[i] == 'T' && array[i + 1] == 'A' && (array[i + 2] == 'A' || array[i + 2] == 'G'))
                {
                    while (array[i + 2] == 'G' || array[i + 2] == 'A')
                    {
                        array[i + 2] = Nucleotides[random.Next(0, 4)];
                    }
                }
                //bunlarda ustteki ile ayni mantik
                if (array[i] == 'T' && array[i + 1] == 'G' && array[i + 2] == 'A')
                {
                    while (array[i + 2] == 'A')
                    {
                        array[i + 2] = Nucleotides[random.Next(0, 4)];
                    }
                }
            }

            // ve sonuc olarak array dizisini gonder
            return array;

        }



    }

}
