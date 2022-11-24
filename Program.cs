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


            Console.WriteLine(Operation3());
            Console.WriteLine(Space_remover(Operation3()));



            
            





            Console.ReadLine();


        }




        //-------------------------------------------------------------------------------------------------------------
        static void Operation1()
        {
            try
            {
                //operation 1.load a dna sequence from a file
                string filepath = "";
                string dna_from_file = "";

                if (File.Exists(filepath))
                {
                    StreamReader f = File.OpenText(filepath);
                    dna_from_file = f.ReadLine();
                    f.Close();
                }
                Console.WriteLine(dna_from_file);
                operation16(dna_from_file.ToUpper());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }







        //-------------------------------------------------------------------------------------------------------------
        static String My_ToUpper(string a) {
            
            for (int i = 0; i < a.Length ; i++)
            {

            }


            return a; 
        }
        //-------------------------------------------------------------------------------------------------------------






        //-------------------------------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------------















        //-------------------------------------------------------------------------------------------------------------
        static char[] Operation3()
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
                codons[codons.Length - 2] = stop[random.Next(0, 2)];
                //TGG yi stop elemani olarak algilamamasi icin
                if (codons[codons.Length - 2] == 'G')
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
            dna = MyFunctionForArrayConcatenation(GenderSelection(), dna);
            /////ve mucize gerceklesir/////
            return dna;
        }





        //6 cinsiyet ihtimali arasinda birisini secmek icin kullanilmistir
        static char[] GenderSelection()
        {

            Random random = new Random();
            char[] gender_array = { };

            int gender_gene = random.Next(1, 7);
            if (gender_gene == 1)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
                gender_array = f1;
            }
            else if (gender_gene == 2)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G' };
                gender_array = f1;
            }
            else if (gender_gene == 3)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
                gender_array = f1;
            }
            else if (gender_gene == 4)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'C', 'C', 'C', ' ', 'T', 'A', 'G' };
                gender_array = f1;
            }
            else if (gender_gene == 5)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'G', 'G', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G' };
                gender_array = f1;
            }
            else if (gender_gene == 6)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'G', 'G', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
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
        //-------------------------------------------------------------------------------------------------------------










        //-------------------------------------------------------------------------------------------------------------
        //DNA daki bosluklari silip islemlerde kolaylik saglamak icin 
        static char[] Space_remover(char[] array_with_spaces)
        {    
            char [] spaceless_Array = new char[100];
            int count = 0;
            for (int i = 0; i < array_with_spaces.Length ; i++)
            {
                if (array_with_spaces[i] != ' ' )
                {
                    spaceless_Array[count] = array_with_spaces[i];                   
                    count++;
                }
            }
            return spaceless_Array;
        }
        //-------------------------------------------------------------------------------------------------------------







        //-------------------------------------------------------------------------------------------------------------------------------------------
        //Operation 4
        static void Operation4(char[] arrayToCheck)
        {
            char[] startCodon = { 'A', 'T', 'G' };
            char[] stopCodon1 = { 'T', 'A', 'G' };
            char[] stopCodon2 = { 'T', 'G', 'A' };
            char[] stopCodon3 = { 'T', 'A', 'A' };
            int length = arrayToCheck.Length;
            try
            {
                if (arrayToCheck.Length != 0)
                {
                    if (length % 3 == 0)
                    {
                        if (arrayToCheck[0] == startCodon[0] && arrayToCheck[1] == startCodon[1] && arrayToCheck[2] == startCodon[2])
                        {
                            if (arrayToCheck[length - 3] == stopCodon1[0] && arrayToCheck[length - 2] == stopCodon1[1] && arrayToCheck[length - 1] == stopCodon1[2])
                            {
                                CheckIfThereIsStartOrStopCodonsInsideGene(arrayToCheck);
                            }
                            else if (arrayToCheck[length - 3] == stopCodon2[0] && arrayToCheck[length - 2] == stopCodon2[1] && arrayToCheck[length - 1] == stopCodon2[2])
                            {
                                CheckIfThereIsStartOrStopCodonsInsideGene(arrayToCheck);
                            }
                            else if (arrayToCheck[length - 3] == stopCodon3[0] && arrayToCheck[length - 2] == stopCodon3[1] && arrayToCheck[length - 1] == stopCodon3[2])
                            {
                                CheckIfThereIsStartOrStopCodonsInsideGene(arrayToCheck);
                            }
                            else
                            {
                                Console.WriteLine("Gene structure error5");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Gene structure error6");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Codon structure error");
                    }
                }
                else
                {
                    Console.WriteLine("Empty gene error");
                }
            }
            catch
            {
                Console.WriteLine("Unexpected value");
            }
        }





        //Operation 4'un icinde kullanilan fonksiyon
        static void CheckIfThereIsStartOrStopCodonsInsideGene(char[] Gene_Sequence)
        {
            for (int i = 0; i <= Gene_Sequence.Length - 3; i++)
            {
                if (Gene_Sequence[i + 3] == 'A' && Gene_Sequence[i + 4] == 'T' && Gene_Sequence[i + 5] == 'G')
                {
                    Console.WriteLine("Gene structure error1");
                    break;
                }
                else if (Gene_Sequence[i + 3] == 'T' && Gene_Sequence[i + 4] == 'A' && (Gene_Sequence[i + 5] == 'A' || Gene_Sequence[i + 5] == 'G'))
                {
                    Console.WriteLine("Gene structure error2");
                    break;
                }
                else if (Gene_Sequence[i + 3] == 'T' && Gene_Sequence[i + 4] == 'G' && Gene_Sequence[i + 5] == 'A')
                {
                    Console.WriteLine("Gene structure error3");
                    break;
                }
                else if (Gene_Sequence.Length == 6)
                {
                    Console.WriteLine("Gene structure is OK. (Not BLOB DNA,but OK)");
                    break;
                }
                else
                {
                    Console.WriteLine("Gene structure error4");
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------











        //-------------------------------------------------------------------------------------------------------------------------------------------
        static string[] Operation7(char[] GeneArray)
        {

            string[] Amino_acids = new string[GeneArray.Length / 3];

            for (int i = 0; i < GeneArray.Length; i += 3)
            {
                if (GeneArray[i] == 'G' && GeneArray[i + 1] == 'C')
                {
                    Amino_acids[i / 3] = "Ala";
                }
                else if (GeneArray[i] == 'C' && GeneArray[i + 1] == 'G')
                {
                    Amino_acids[i / 3] = "Arg";
                }
                else if (GeneArray[i] == 'C' && GeneArray[i + 1] == 'T')
                {
                    Amino_acids[i / 3] = "Leu";
                }
                else if (GeneArray[i] == 'G' && GeneArray[i + 1] == 'G')
                {
                    Amino_acids[i / 3] = "Gly";
                }
                else if (GeneArray[i] == 'C' && GeneArray[i + 1] == 'C')
                {
                    Amino_acids[i / 3] = "Pro";
                }
                else if (GeneArray[i] == 'T' && GeneArray[i + 1] == 'C')
                {
                    Amino_acids[i / 3] = "Ser";
                }
                else if (GeneArray[i] == 'A' && GeneArray[i + 1] == 'C')
                {
                    Amino_acids[i / 3] = "Thr";
                }
                else if (GeneArray[i] == 'G' && GeneArray[i + 1] == 'T')
                {
                    Amino_acids[i / 3] = "Val";
                }
                else if (GeneArray[i] == 'A' && GeneArray[i + 1] == 'A')
                {
                    if (GeneArray[i + 2] == 'T' || GeneArray[i + 2] == 'C')
                    {
                        Amino_acids[i / 3] = "Asn";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "Lys";
                    }
                }
                else if (GeneArray[i] == 'A' && GeneArray[i + 1] == 'T')
                {
                    if (GeneArray[i + 2] == 'G')
                    {
                        Amino_acids[i / 3] = "Met";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "Ile";
                    }
                }
                else if (GeneArray[i] == 'C' && GeneArray[i + 1] == 'A')
                {
                    if (GeneArray[i + 2] == 'A' || GeneArray[i + 2] == 'G')
                    {
                        Amino_acids[i / 3] = "Gln";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "His";
                    }
                }
                else if (GeneArray[i] == 'T' && GeneArray[i + 1] == 'T')
                {
                    if (GeneArray[i + 2] == 'C' || GeneArray[i + 2] == 'T')
                    {
                        Amino_acids[i / 3] = "Phe";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "Leu";
                    }
                }
                else if (GeneArray[i] == 'T' && GeneArray[i + 1] == 'G')
                {
                    if (GeneArray[i + 2] == 'T' || GeneArray[i + 2] == 'C')
                    {
                        Amino_acids[i / 3] = "Cys";
                    }
                    else if (GeneArray[i + 2] == 'G')
                    {
                        Amino_acids[i / 3] = "Trp";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "END";
                    }
                }
                else if (GeneArray[i] == 'G' && GeneArray[i + 1] == 'A')
                {
                    if (GeneArray[i + 2] == 'T' || GeneArray[i + 2] == 'C')
                    {
                        Amino_acids[i / 3] = "Asp";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "Glu";
                    }
                }
                else if (GeneArray[i] == 'A' && GeneArray[i + 1] == 'G')
                {
                    if (GeneArray[i + 2] == 'T' || GeneArray[i + 2] == 'C')
                    {
                        Amino_acids[i / 3] = "Ser";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "Arg";
                    }
                }
                else if (GeneArray[i] == 'T' && GeneArray[i + 1] == 'A')
                {
                    if (GeneArray[i + 2] == 'T' || GeneArray[i + 2] == 'C')
                    {
                        Amino_acids[i / 3] = "Tyr";
                    }
                    else
                    {
                        Amino_acids[i / 3] = "END";
                    }
                }
            }

            return Amino_acids;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------




















    }

}
