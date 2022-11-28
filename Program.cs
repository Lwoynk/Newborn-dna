using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1zcxzxczxc
{
    internal class Program
    {
        static void Main(string[] args)
        {



            char[] DNA_sequence = Space_remover(Operation3());
            Console.Write("DNA strand      :  ");
            Console.WriteLine(Operation3());

            Console.WriteLine("\nFind codons (find a codon sequence, starting from mth codon)\n");
            Console.Write("enter number for m : ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nenter string for search: ");

            string m = Convert.ToString(Console.ReadLine());
            char[] arama = m.ToCharArray();


            int sayac9 = 0;

            bool varmı = false;

            for (int i = (x - 1) * 3; i < DNA_sequence.Length - ((x - 1) * 3) - arama.Length + 1; i = i + 3)
            {
                sayac9 = 0;
                for (int j = 0; j < arama.Length; j++)
                {
                    if (DNA_sequence[j + i] == arama[j])
                    {
                        sayac9++;
                    }

                    if (sayac9 == arama.Length)
                    {
                        varmı = true;
                        Console.Write("Codon sequence  :  ");
                        Console.Write(m);
                        Console.Write("\nStarting from   :  " + x);
                        Console.WriteLine("\nResult          :  " + ((i / 3) + 1));
                        break;
                    }
                }
            }

            if (varmı == false)
            {
                Console.WriteLine("yok");
            }



            Console.ReadLine();
        }







        //-------------------------------------------------------------------------------------------------------------
        //operation 1.load a dna sequence from a file
        static char[] Operation1(string filepath)
        {

            char[] DNA_sequence_in_CharArray;
            string dna_from_file = "";

            if (File.Exists(filepath))
            {
                StreamReader f = File.OpenText(filepath);
                dna_from_file = f.ReadLine();
                f.Close();
            }
            DNA_sequence_in_CharArray = dna_from_file.ToCharArray();

            return DNA_sequence_in_CharArray;
        }
        //--------------------------------------------------------------------------------------------------------------








        //-------------------------------------------------------------------------------------------------------------
        //function for 16.operation
        static void Operation16(char[] array)
        {

            int abonds = 0, tbonds = 0, gbonds = 0, cbonds = 0, totalbonds = 0;


            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'A')
                { abonds++; }
                else if (array[i] == 'T')
                { tbonds++; }
                else if (array[i] == 'G')
                { gbonds++; }
                else if (array[i] == 'C')
                { cbonds++; }

                totalbonds = (gbonds + cbonds) * 3 + (abonds + tbonds) * 2;
            }
            Console.WriteLine("\nOperation 16");
            Console.WriteLine("\nnumber of pairing with 2-hydrogen bonds  :  {0}", (abonds + tbonds));
            Console.WriteLine("number of pairing with 3-hydrogen bonds  :  {0}", (gbonds + cbonds));
            Console.WriteLine("total bonds is  :  {0}", totalbonds);


        }
        //-------------------------------------------------------------------------------------------------------------















        //-------------------------------------------------------------------------------------------------------------
        //Operaton3
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





        //Tum cinsiyetleri ekle
        static char[] GenderSelection()
        {

            Random random = new Random();
            char[] gender_array = { };

            int gender_gene = random.Next(1, 7);

            if (gender_gene == 1)
            {
                char[] female = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
                gender_array = female;
            }
            else if (gender_gene == 2)
            {
                char[] female = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G' };
                gender_array = female;
            }
            else if (gender_gene == 3)
            {
                char[] female = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G' };
                gender_array = female;
            }
            else if (gender_gene == 4)
            {
                char[] female = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
                gender_array = female;
            }
            else if (gender_gene == 5)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'C', 'C', 'C', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 6)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'G', 'G', 'G', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 7)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'G', 'G', 'G', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 8)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'C', 'C', 'C', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 9)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'C', 'C', 'C', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 10)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'G', 'G', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 11)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'G', 'G', 'G', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 12)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'C', 'C', 'C', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 13)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'C', 'C', 'C', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
                gender_array = male;
            }
            else if (gender_gene == 14)
            {
                char[] male = { 'A', 'T', 'G', ' ', 'G', 'G', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G' };
                gender_array = male;
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
            char[] spaceless_Array = new char[100];
            int count = 0;
            for (int i = 0; i < array_with_spaces.Length; i++)
            {
                if (array_with_spaces[i] != ' ')
                {
                    spaceless_Array[count] = array_with_spaces[i];
                    count++;
                }
            }
            return spaceless_Array;
        }
        //-------------------------------------------------------------------------------------------------------------









        //-------------------------------------------------------------------------------------------------------------------------------------------
        //Not done yet
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
        //Operation 6
        static void Operation6(char[] Produce_complement_array)
        {
            Console.Write("DNA strand  :  ");
            Console.WriteLine(Produce_complement_array);
            Console.Write("Complement  :  ");
            char[] DNA_sequence = Produce_complement_array;

            char[] operation6result;
            operation6result = DNA_sequence;

            for (int i = 0; i < operation6result.Length; i++)
            {
                char temp = operation6result[i];
                if (operation6result[i] == 'A')
                    Console.Write('T');
                else if (operation6result[i] == 'T')
                    Console.Write('A');
                else if (operation6result[i] == 'G')
                    Console.Write('C');
                else if (operation6result[i] == 'C')
                    Console.Write('G');
                else
                    Console.Write(" ");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------










        //-------------------------------------------------------------------------------------------------------------------------------------------
        static void Operation7(char[] GeneArray)
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
            //bosluk fonksiyoonu ekle
            Console.Write("DNA strand   :  ");
            Console.WriteLine(GeneArray);
            Console.Write("Amino acids  :  ");
            for (int i = 0; i < Amino_acids.Length; i++)
            {
                Console.Write(Amino_acids[i] + " ");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------











        //-------------------------------------------------------------------------------------------------------------------------------------------

        //        //operation 8
        //Console.WriteLine("Delete codons (delete n codons, starting from mth codon)\n");
        //Console.Write("enter number for m : ");
        //int x = Convert.ToInt32(Console.ReadLine());

        //Console.Write("enter number for n : ");
        //int y = Convert.ToInt32(Console.ReadLine());

        //char[] operation3result = Space_remover(Operation3());
        //Console.Write("DNA strand(stage 1)  :  ");
        //Console.WriteLine(operation3result);
        //Console.WriteLine("Delete " + y + " codons, starting from " + x + "rd " + "codon.");
        //char[] operation8result;
        //operation8result = operation3result;
        //Console.Write("DNA strand(stage 2)  :  ");
        //for (int i = 0; i < operation3result.Length; i++)   
        //{
        //    if (i < (((x - 1) * 3) ))
        //    {
        //        operation8result[i] = operation3result[i];
        //        Console.Write(operation8result[i]);
        //    }
        //    else if (i >= (((x - 1) * 3) ) + (3 * y))
        //    {
        //        operation8result[i - ((x - 1) * 3)] = operation3result[i];
        //        Console.Write(operation8result[i - ((x - 1) * 3)]);
        //    }
        //}

        //-------------------------------------------------------------------------------------------------------------------------------------------











        //-------------------------------------------------------------------------------------------------------------------------------------------
        //operation 9

        //Console.WriteLine("\nInsert codons(insert a codon sequence, starting from mth codon)\n");
        //Console.Write("enter number for m : ");
        //int x = Convert.ToInt32(Console.ReadLine());

        //Console.Write("\nenter string for add: ");

        //string k = Convert.ToString(Console.ReadLine());
        //char[] ekleme = k.ToCharArray();

        //char[] DNA_sequence = Space_remover(Operation3());
        //Console.WriteLine(DNA_sequence);

        //char[] operation9result = new char[DNA_sequence.Length + ekleme.Length];
        ////operation9result = DNA_sequence;

        //for (int i = 0; i < (x - 1) * 3; i++)
        //{
        //    operation9result[i] = DNA_sequence[i];
        //    Console.Write(operation9result[i]);
        //}

        //for (int l = 0; l < ekleme.Length; l++)
        //{
        //    operation9result[l + (x - 1) * 3] = ekleme[l];
        //    Console.Write(operation9result[l + (x - 1) * 3]);
        //}

        //for (int j = 0; j <= DNA_sequence.Length - ((x - 1) * 3 + ekleme.Length + 1); j++)
        //{
        //    operation9result[((x - 1) * 3) + ekleme.Length + j] = DNA_sequence[j + ((x - 1) * 3)];
        //    Console.Write(operation9result[j + ((x - 1) * 3) + ekleme.Length]);
        //}

        //---------------------------------------------------------------------------------------------------------------------------------------------







        //---------------------------------------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------------------------------------------------------------------







        //---------------------------------------------------------------------------------------------------------------------------------------------

        //operation 11  
        //Console.Write("enter number for x starting from: ");
        //int x = Convert.ToInt32(Console.ReadLine());

        //Console.Write("enter number for y how much: ");
        //int y = Convert.ToInt32(Console.ReadLine());
        //char[] operation3result = Space_remover(Operation3());
        //Console.WriteLine(operation3result);

        //if (y % 2 == 1)
        //{
        //    for (int i = ((x - 1) * 3) ; i < ((x - 1) * 3) + ((y / 2) * 3); i++)
        //    {
        //        char temp = operation3result[i];
        //        operation3result[i] = operation3result[i + (((y - 1) * 3))];
        //        operation3result[i + (((y - 1) * 3))] = temp;
        //    }
        //    Console.WriteLine(operation3result);
        //}



        //if (y % 2 == 0)
        //{
        //    for (int i = ((x - 1) * 3) ; i <= (((x - 1) * 3) - 1) + ((y / 2) * 3); i++)
        //    {
        //        char temp = operation3result[i];
        //        operation3result[i] = operation3result[i + (((y - 1) * 3))];
        //        operation3result[i + (((y - 1) * 3))] = temp;
        //    }
        //    Console.WriteLine(operation3result);
        //}
        //---------------------------------------------------------------------------------------------------------------------------------------------









        //---------------------------------------------------------------------------------------------------------------------------------------------
        //operation 12 
        //Console.WriteLine(Operation3());

        //char[] operation3result = Operation3();

        //int countera = 0;
        //int counterb = 0;
        //int counterc = 0;
        //int counterd = 0;
        //for (int i = 0; i < operation3result.Length - 2; i++)
        //{
        //    if (operation3result[i] == 'A')
        //    {
        //        if (operation3result[i + 1] == 'T')
        //        {
        //            if (operation3result[i + 2] == 'G')
        //            {
        //                countera++;
        //            }
        //        }
        //    }
        //    if (operation3result[i] == 'T')
        //    {
        //        if (operation3result[i + 1] == 'A')
        //        {
        //            if (operation3result[i + 2] == 'A')
        //            {
        //                counterb++;
        //            }
        //        }
        //    }
        //    if (operation3result[i] == 'T')
        //    {
        //        if (operation3result[i + 1] == 'G')
        //        {
        //            if (operation3result[i + 2] == 'A')
        //            {
        //                counterc++;
        //            }
        //        }
        //    }
        //    if (operation3result[i] == 'T')
        //    {
        //        if (operation3result[i + 1] == 'A')
        //        {
        //            if (operation3result[i + 2] == 'G')
        //            {
        //                counterd++;
        //            }
        //        }
        //    }

        //}
        //if(countera == (counterc + counterb + counterd))
        //{
        //    Console.WriteLine("\nNumber of genes: " + countera);
        //}

        //else if(countera == (counterc + counterb + counterd))
        //{
        //    Console.WriteLine("This is not BLOB");
        //    Console.WriteLine("\nNumber of genes: " + (counterc + counterb + counterd));
        //}
        //---------------------------------------------------------------------------------------------------------------------------------------------






        //--------------------------------------------------------------------------------------------------------------------------------------------
        //operation 13

        //char[] DNA_sequence = Space_remover(Operation3());
        //Console.Write("DNA strand      :  ");
        //Console.WriteLine(Operation3());

        //int count = 0;
        //int count13 = 99;
        //int count13sonkucuk = 99;
        //int degisken = 0;
        //int degisken1 = 0;
        //int counttoplam = 0;
        //int atgindexson = 0;

        //for (int i = 0; i < DNA_sequence.Length - 2; i = i + 3)
        //{

        //    if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
        //    {
        //        degisken1 = i / 3 + 1; ;
        //    }

        //    if ((DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'G') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'A'))
        //    {
        //        counttoplam = counttoplam + count;
        //        degisken = i / 3 + 1;
        //        count = (degisken) - counttoplam;


        //        if (count > count13 && count13sonkucuk > count13)
        //        {
        //            if (count13 != 0 && count13 != 1)
        //            {
        //                count13sonkucuk = count13;
        //                atgindexson = degisken1;
        //            }
        //        }
        //        else if (count13 >= count && count13sonkucuk > count)
        //        {
        //            if (count != 1)
        //            {
        //                count13sonkucuk = count;
        //                atgindexson = degisken1;
        //            }

        //        }
        //        count13 = count;
        //    }

        //}

        //Console.Write("\nShortest gene                :  ");
        //for (int i = (atgindexson - 1) * 3; i < (atgindexson - 1) * 3 + (count13sonkucuk * 3); i++)
        //{
        //    Console.Write(DNA_sequence[i]);
        //}

        //Console.WriteLine("\nNumber of codons in the gene :  " + count13sonkucuk);
        //Console.WriteLine("Position of the gene         :  " + atgindexson);

        //--------------------------------------------------------------------------------------------------------------------------------------------
    }
}

        //Operation 14
        //    char[] DNA_sequence = Space_remover(Operation3());
        //    Console.Write("DNA strand      :  ");
        //    Console.WriteLine(Operation3());

        //    int count = 0;
        //    int count14 = -99;
        //    int count14sonbuyuk = -99;
        //    int degisken = 0;
        //    int degisken1 = 0;
        //    int counttoplam = 0;
        //    int atgindexson = 0;

        //    for (int i = 0; i < DNA_sequence.Length - 2; i = i + 3)
        //    {

        //        if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
        //        {
        //            degisken1 = i / 3 + 1; ;
        //        }

        //        if ((DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'G') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'A'))
        //        {
        //            counttoplam = counttoplam + count;
        //            degisken = i / 3 + 1;
        //            count = (degisken) - counttoplam;


        //            if (count < count14 && count14sonbuyuk < count14)
        //            {
                        
        //                    count14sonbuyuk = count14;
        //                    atgindexson = degisken1;
                        
        //            }
        //            else if (count14 <= count && count14sonbuyuk < count)
        //            {
                        
        //                    count14sonbuyuk = count;
        //                    atgindexson = degisken1;
                        

        //            }
        //            count14 = count;
        //        }

        //    }

        //    Console.Write("\nLongest gene                :  ");
        //    for (int i = (atgindexson - 1) * 3; i < (atgindexson - 1) * 3 + (count14sonbuyuk * 3); i++)
        //    {
        //        Console.Write(DNA_sequence[i]);
        //    }

        //    Console.WriteLine("\nNumber of codons in the gene :  " + count14sonbuyuk);
        //    Console.WriteLine("Position of the gene         :  " + atgindexson);

        //    Console.ReadLine();

        //}








