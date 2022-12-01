using System;
using System.IO;
using System.Threading;

namespace Tigers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int LoadOperationNumbere_user=0;
            char[] DNA_User1 = { };
            char[] DNA_User_Original = { };



            //A small starting show
            Random random = new Random();
            int timing = 300;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\t\t\t\t\t--------->    LIFE ON MARS!   <----------");
                Console.WriteLine("\t\t\t\t\t--------->    LIFE ON MARS!   <----------");

                for (int j = 0; j < 40; j++)
                {
                    Console.SetCursorPosition(random.Next(1, 120), random.Next(3, 28));
                    Thread.Sleep(2);
                    Console.Write("*");
                }
                Thread.Sleep(timing);
                timing -= 30;
                Console.Clear();
            }



            Console.WriteLine("Select an option to load a DNA sequence");
            Console.WriteLine("     Operation 1. Load a DNA sequence from a file.");
            Console.WriteLine("     Operation 2. Load a DNA sequence from a string.");
            Console.WriteLine("     Operation 3. Generate random DNA sequence of a BLOB.");
            Console.Write("\nPlease enter only the number of operation you want to load DNA :    ");
            

            try
            {
                LoadOperationNumbere_user = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(LoadOperationNumbere_user);
            }
            catch
            {
                Console.WriteLine("Unexpected Value.");
            }






            if( 1 <= LoadOperationNumbere_user  &&  LoadOperationNumbere_user <= 3)
            {
                if (LoadOperationNumbere_user == 1)
                {
                    //Add file path
                    DNA_User1 = Space_remover(Operation1(""));
                    DNA_User_Original = DNA_User1;
                }
                else if(LoadOperationNumbere_user == 2)
                {
                    Console.WriteLine("Please enter the DNA sequence:");
                    DNA_User1 = Space_remover(Console.ReadLine().ToCharArray());
                    DNA_User_Original = DNA_User1;
                }
                else if( LoadOperationNumbere_user == 3 )
                {
                    char genderSelection_forOperation3 = ' ';
                    try
                    {
                        Console.WriteLine("Please enter the gender of BLOB\nF or f for female:\nM or m for male:");
                        genderSelection_forOperation3 = Convert.ToChar(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Unexpected Value.");
                    }


                    if (genderSelection_forOperation3 == 'F' || genderSelection_forOperation3 == 'f')
                    {
                        DNA_User1 = Space_remover(Operation3('F'));
                        DNA_User_Original = DNA_User1;
                    }
                    else if (genderSelection_forOperation3 == 'M' || genderSelection_forOperation3 == 'm')
                    {
                        DNA_User1 = Space_remover(Operation3('M'));
                        DNA_User_Original = DNA_User1;
                    }
                    else
                    {
                        Console.WriteLine("Unexpected value.");
                    }
                }
            }


            Console.Clear();
            Console.Write("DNA strand 1: " );
            Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));


            Console.WriteLine("\nNow there is List of Operations you can do with your DNA:\n");
            Console.WriteLine("***\t4).  Check DNA gene structure\n");
            Console.WriteLine("***\t5).  Check DNA of BLOB organism\n");
            Console.WriteLine("***\t6).  Produce complement of a DNA sequence\n");
            Console.WriteLine("***\t7).  Determine amino acids\n");
            Console.WriteLine("***\t8).  Delete codons (delete n codons, starting from mth codon)\n");
            Console.WriteLine("***\t9).  Insert codons (insert a codon sequence, starting from mth codon)\n");
            Console.WriteLine("***\t10). Find codons (find a codon sequence, starting from mth codon)\n");
            Console.WriteLine("***\t11). Reverse codons (reverse n codons, starting from mth codon)\n");
            Console.WriteLine("***\t12). Find the number of genes in a DNA strand (BLOB or not)\n");
            Console.WriteLine("***\t13). Find the shortest gene in a DNA strand\n");
            Console.WriteLine("***\t14). Find the longest gene in DNA strand\n");
            Console.WriteLine("***\t15). Find the most repeated n-nucleotide sequence in a DNA strand (STR - Short Tandem Repeat)\n");
            Console.WriteLine("***\t16). Hydrogen bond statistics for a DNA strand\n");
            Console.WriteLine("***\t17). Simulate BLOB generations using DNA strand 1 and 2 (DNA strand 3 is for the newborn)\n");
            Console.WriteLine("***\t18). Exit the menu");
            
            int temp1 = Convert.ToInt32(Console.ReadLine());

            while (temp1 != 18) {

                if (temp1 == 4)
                {
                    Console.WriteLine(Operation4(DNA_User1));

                }
                else if (temp1 == 5)
                {
                    Console.WriteLine(Operation5(DNA_User1));
                }
                else if (temp1 == 6)
                {
                    Console.Write("DNA strand  :  ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    DNA_User1 = Operation6(DNA_User1);
                    Console.Write("Complement  :  ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                }
                else if (temp1 == 7)
                {
                    Console.WriteLine("Working on it.....");
                }
                else if (temp1 == 8)
                {
                    Console.Write("How many codons do you want to delete :   ");
                    int codonCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("And from which codon do want to start deleting :   ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());

                    Console.Write("DNA strand (stage 1)  :  ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    Console.WriteLine("Delete {0} codons, starting from {1} th codon.", codonCount, startingFrom);
                    Console.Write("DNA strand (stage 2)  :  ");
                    DNA_User1 = Operation8( DNA_User1 , codonCount , startingFrom );
                    Console.WriteLine( AddSpaceBetweenCodons( DNA_User1 ) );

                }
                else if (temp1 == 9)
                {
                    Console.Write("Enter codons which you want to insert :   ");
                    string codonSequence = Console.ReadLine();
                    Console.Write("Starting from :   ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());

                    Console.Write("DNA strand (stage 1)  :\t");
                    Console.WriteLine( AddSpaceBetweenCodons(DNA_User1) );
                    Console.Write("Codon sequence        :\t" );
                    Console.WriteLine( AddSpaceBetweenCodons(  codonSequence.ToCharArray() ) );
                    Console.Write("Starting from         :\t");
                    Console.WriteLine( startingFrom );
                    Console.Write("DNA strand (stage 2)  :\t");
                    DNA_User1 = Operation9(DNA_User1, codonSequence , startingFrom );
                    Console.WriteLine( AddSpaceBetweenCodons(DNA_User1) );

                }
                else if (temp1 == 10)
                {
                    Console.Write("Please enter the codon sequence you want to find :  ");
                    string Codon_string_Operation10 = Console.ReadLine();
                    Console.Write("From which codon you want to start searching :  ");
                    int codonIndex = Convert.ToInt32(Console.ReadLine());
                    Operation10(DNA_User1 ,Codon_string_Operation10 ,codonIndex);
                }
                else if (temp1 == 11)
                {
                    Console.Write("Please enter the number of codons to reverse :  ");
                    int NumberOfCodons = Convert.ToInt32(Console.ReadLine());
                    Console.Write("From which codon you want to start reversing :  ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());
                    Console.Write("DNA strand (stage 1) :  ");
                    Console.WriteLine(DNA_User1);
                    DNA_User1=Operation11( DNA_User1,NumberOfCodons,startingFrom );
                    Console.WriteLine("Reverse {0} codons, starting from {1}th codon. ", NumberOfCodons, startingFrom);
                    Console.Write("DNA strand (stage 2) :  ");
                    Console.WriteLine( AddSpaceBetweenCodons(DNA_User1) );

                }
                else if (temp1 == 12)
                {
                    Operation12(DNA_User1);
                }
                else if(temp1 == 13)
                {
                    Operation13(DNA_User1);
                }
                else if(temp1 == 14)
                {
                    Operation14(DNA_User1);
                }
                else if(temp1 == 15)
                {
                    Console.Write("DNA strand\t\t:  ");
                    DNA_User1 = Space_remover(DNA_User1);
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    Console.Write("Enter number of nucleotide\t:  ");
                    int nucleotidNumber = Convert.ToInt32(Console.Read());
                    Operation15(DNA_User1,nucleotidNumber);

                }
                else if(temp1 == 16)
                {
                    Console.WriteLine("DNA strand  : ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    operation16(DNA_User1);
                }



                temp1 = Convert.ToInt32(Console.ReadLine());
            }































































            Console.ReadLine(); 
        }






        //   Operation1     //-------------------------------------------------------
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









        //   Operation3     //-------------------------------------------------------
        static char[] Operation3(char gender)
        {
            Random random = new Random();
            char[] Nucleotides = { 'A', 'C', 'G', 'T' };
            char[] stop = { 'A', 'G' };
            char[] dna = { };


            for (int j = 0; j < random.Next(1, 7); j++)
            {

                int Nucleotidnumber = random.Next(5, 29);


                int number = Nucleotidnumber % 4;
                number = Nucleotidnumber - number;

                char[] codons = new char[4 + number + 3];


                for (int i = 0; i < codons.Length; i++)
                {
                    codons[i] = Nucleotides[random.Next(0, 4)];
                    codons = WrongCodonsInWrongPlaces(codons);

                    if ((i + 1) % 4 == 0)
                    {
                        codons[i] = ' ';
                    }
                }

                codons[0] = 'A';
                codons[1] = 'T';
                codons[2] = 'G';
                codons[codons.Length - 3] = 'T';
                codons[codons.Length - 2] = stop[random.Next(0, 2)];

                if (codons[codons.Length - 2] == 'G')
                {
                    codons[codons.Length - 1] = 'A';
                }
                else
                {
                    codons[codons.Length - 1] = stop[random.Next(0, 2)];
                }

                dna = MyFunctionForArrayConcatenation(dna, codons);
            }

            dna = MyFunctionForArrayConcatenation(GenderSelection(gender), dna);
            return dna;
        }




        static char[] GenderSelection(char gender)
        {

            Random random = new Random();
            char[] gender_array = { };
            int gender_gene = 0;

            if (gender == 'F' || gender == 'f')
            {
                gender_gene = random.Next(1, 5);
            }
            else if (gender == 'M' || gender == 'm')
            {
                gender_gene = random.Next(5, 15);
            }


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




        static char[] WrongCodonsInWrongPlaces(char[] array)
        {
            Random random = new Random();
            char[] Nucleotides = { 'A', 'T', 'G', 'C' };


            for (int i = 0; i < array.Length - 2; i++)
            {

                if (array[i] == 'A' && array[i + 1] == 'T' && array[i + 2] == 'G')
                {
                    while (array[i + 2] == 'G')
                    {
                        array[i + 2] = Nucleotides[random.Next(0, 4)];
                    }
                }

                if (array[i] == 'T' && array[i + 1] == 'A' && (array[i + 2] == 'A' || array[i + 2] == 'G'))
                {
                    while (array[i + 2] == 'G' || array[i + 2] == 'A')
                    {
                        array[i + 2] = Nucleotides[random.Next(0, 4)];
                    }
                }

                if (array[i] == 'T' && array[i + 1] == 'G' && array[i + 2] == 'A')
                {
                    while (array[i + 2] == 'A')
                    {
                        array[i + 2] = Nucleotides[random.Next(0, 4)];
                    }
                }
            }
            return array;
        }









        //   Operation4     //-------------------------------------------------------

        static string Operation4(char[] DNA_sequence)
        {
            string message = "";
            int[] indexnumberofATG = arrayOfIndexNumbersOfATGs(DNA_sequence);
            int[] indexNumber_of_stopCodons = arrayOfIndexNumbersOfStopCodons(DNA_sequence);
            if (DNA_sequence.Length % 3 == 0)
            {
                if (DNA_sequence[0] == 'A' && DNA_sequence[1] == 'T' && DNA_sequence[2] == 'G')
                {
                    if (indexNumber_of_stopCodons.Length == indexnumberofATG.Length)
                    {
                        for (int i = 0; i < indexNumber_of_stopCodons.Length; i++)
                        {
                            if ((indexnumberofATG[i] < indexNumber_of_stopCodons[i]))
                            {
                                for (int j = indexnumberofATG[i] + 3; j < indexNumber_of_stopCodons[i]; j += 3)
                                {
                                    if (DNA_sequence[j] == 'A' && DNA_sequence[j + 1] == 'T' && DNA_sequence[j + 2] == 'G')
                                    {
                                        message = "DNA structure error.";
                                    }
                                    else if (DNA_sequence[j] == 'T' && DNA_sequence[j + 1] == 'A' && (DNA_sequence[j + 2] == 'G' || DNA_sequence[j + 2] == 'A'))
                                    {
                                        message = "DNA structure error.";
                                    }
                                    else if (DNA_sequence[j] == 'T' && DNA_sequence[j + 1] == 'G' && DNA_sequence[j + 2] == 'A')
                                    {
                                        message = "DNA structure error.";
                                    }
                                    else
                                    {
                                        message = "DNA structure is OK.";
                                    }
                                }

                            }
                            else
                            {
                                message = "DNA structure error.";
                            }
                        }
                    }
                    else
                    {
                        message = "Gene structure error.";
                    }

                }
                else
                {
                    message = "Gene structure error.";
                }


                if (message == "DNA structure is OK.")
                {
                    for (int j = 0; j < indexnumberofATG.Length; j++)
                        if (indexnumberofATG[j] + 3 == indexNumber_of_stopCodons[j])
                        {
                            message = "DNA structure is OK. (Not BLOB DNA, but OK)";
                        }
                }


            }
            else
            {
                message = "Gene structure error.";
            }

            return message;
        }








        //   Operation5     //-------------------------------------------------------

        static string Operation5(char[] DNA_sequence)
        {
            int[] indexnumberofATG = arrayOfIndexNumbersOfATGs(DNA_sequence);
            int[] indexNumber_of_stopCodons = arrayOfIndexNumbersOfStopCodons(DNA_sequence);
            string finalMessage = "";

            if (DNA_sequence.Length % 3 == 0)
            {

                string message_of_gender = "";
                bool gender_situation = false;

                if (DNA_sequence[0] == 'A' && DNA_sequence[1] == 'T' && DNA_sequence[2] == 'G')
                {

                    if (DNA_sequence[9] == 'T' && DNA_sequence[10] == 'G' && DNA_sequence[11] == 'A')
                    {

                        if (DNA_sequence[3] == DNA_sequence[4] && DNA_sequence[4] == DNA_sequence[5] && DNA_sequence[6] == DNA_sequence[7] && DNA_sequence[7] == DNA_sequence[8])
                        {
                            gender_situation = true;
                        }
                        else
                        {
                            message_of_gender = "Gender error.";
                        }

                    }
                    else if (DNA_sequence[9] == 'T' && DNA_sequence[10] == 'A' && (DNA_sequence[11] == 'G' || DNA_sequence[11] == 'A'))
                    {

                        if (DNA_sequence[3] == DNA_sequence[4] && DNA_sequence[4] == DNA_sequence[5] && DNA_sequence[6] == DNA_sequence[7] && DNA_sequence[7] == DNA_sequence[8])
                        {
                            gender_situation = true;
                        }
                        else
                        {
                            message_of_gender = "Gender error.";
                        }

                    }
                    else
                    {
                        message_of_gender = "Gender error.";
                    }

                }
                else
                {
                    message_of_gender = "Gender error.";
                }




                string Blob_Check_message = "";
                if ((indexnumberofATG.Length == indexNumber_of_stopCodons.Length) && (indexnumberofATG.Length >= 2 && indexnumberofATG.Length <= 7))
                {
                    for (int i = 1; i < indexnumberofATG.Length; i++)
                    {
                        int temp = indexNumber_of_stopCodons[i] - (indexnumberofATG[i] + 3);

                        if (temp <= 18 && temp >= 3)
                        {

                            Blob_Check_message = Operation4(DNA_sequence);
                        }
                        else
                        {
                            Blob_Check_message = "Number of Codons error.";
                            break;
                        }
                    }

                }
                else
                {
                    Blob_Check_message = "Number of Gene error.";
                }





                if (gender_situation == true && Blob_Check_message == "DNA structure is OK.")
                {
                    finalMessage = "BLOB is ok";
                }
                else if (gender_situation == false && Blob_Check_message == "DNA structure is OK.")
                {
                    finalMessage = message_of_gender;
                }
                else
                {
                    finalMessage = message_of_gender + " " + Blob_Check_message;
                }



            }
            else
            {
                finalMessage = "Codon structure error";
            }
            return finalMessage;
        }







        //   Operation6     //-------------------------------------------------------
        static char[] Operation6(char[] DNA_sequence)
        {
            char[] operation6result = new char[DNA_sequence.Length];

            for (int i = 0; i < DNA_sequence.Length; i++)
            {
                if (DNA_sequence[i] == 'A')
                    operation6result[i]='T';
                else if (DNA_sequence[i] == 'T')
                    operation6result[i] = 'A';
                else if (DNA_sequence[i] == 'G')
                    operation6result[i] = 'C' ;
                else if (DNA_sequence[i] == 'C')
                    operation6result[i] = 'G';
            }
            return operation6result;
        }







        //   Operation7     //-------------------------------------------------------

















        //   Operation8     //-------------------------------------------------------
        static char[] Operation8(char[] DNA_sequence, int codonCount, int startingFrom)
        {
            DNA_sequence = Space_remover(DNA_sequence);

            char[] operation8result = new char[DNA_sequence.Length-(codonCount*3)];

            int temp = (startingFrom - 1) * 3;// 0

            for (int i = 0; i < DNA_sequence.Length; i++)
            {
                if ( i < temp )
                {
                    operation8result[i] = DNA_sequence[i];
                }
                else if ( i > ( temp + (3 * codonCount) ) )
                {
                    operation8result[ i - (temp * 3) ] = DNA_sequence[i];
                }
            }


            return operation8result;
        }









        //   Operation9     //-------------------------------------------------------
        static char[] Operation9(char[] DNA_sequence, string Codon_sequence, int StartingFrom)
        {
            DNA_sequence = Space_remover(DNA_sequence);
            char[] operation9result = new char[DNA_sequence.Length + Codon_sequence.Length];

            for (int i = 0; i < (StartingFrom - 1) * 3; i++)
            {
                operation9result[i] = DNA_sequence[i];
            }

            for (int l = 0; l < Codon_sequence.Length; l++)
            {
                operation9result[l + (StartingFrom - 1) * 3] = Codon_sequence[l];
            }

            for (int j = 0; j <= DNA_sequence.Length - ((StartingFrom - 1) * 3 + Codon_sequence.Length + 1) + Codon_sequence.Length; j++)
            {
                operation9result[((StartingFrom - 1) * 3) + Codon_sequence.Length + j] = DNA_sequence[j + ((StartingFrom - 1) * 3)];
            }

            return operation9result;
        }










        //   Operation10     //-------------------------------------------------------
        static void Operation10(char[] DNA_sequence, string codonSequence, int startingFrom)
        {
            DNA_sequence = Space_remover(DNA_sequence);
            Console.Write("DNA strand      :\t");
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));
            Console.Write("Codon sequence  :\t");
            char[] search = codonSequence.ToCharArray();
            search = Space_remover(search);
            search = AddSpaceBetweenCodons(search);
            Console.WriteLine(search);
            Console.Write("Starting from   :\t");
            Console.WriteLine(startingFrom);

            int count = 0;
            bool flag = false;

            for (int i = (startingFrom - 1) * 3; i < DNA_sequence.Length - search.Length; i = i + 3)
            {
                count = 0;
                for (int j = 0; j < search.Length; j++)
                {
                    if (DNA_sequence[i + j] == search[j])
                    {
                        count++;
                    }

                    if (count == search.Length)
                    {
                        flag = true;
                        Console.WriteLine("Result          :\t" + ((i / 3) + 1));
                        break;
                    }
                }
            }

            if (flag == false)
            {
                Console.WriteLine("Result          :\t" + (-1) + "(Not found)");
            }
        }









        //   Operation11     //-------------------------------------------------------
        static char[] Operation11(char[] DNA_sequence, int NumberOfCodons, int startingFrom)
        {

            DNA_sequence = Space_remover(DNA_sequence);

            if (NumberOfCodons % 2 == 1)
            {
                for (int i = ((startingFrom - 1) * 3); i < ((startingFrom - 1) * 3) + ((NumberOfCodons / 2) * 3); i++)
                {
                    char temp = DNA_sequence[i];
                    DNA_sequence[i] = DNA_sequence[i + (((NumberOfCodons - 1) * 3))];
                    DNA_sequence[i + (((NumberOfCodons - 1) * 3))] = temp;
                }
            }

            if (NumberOfCodons % 2 == 0)
            {
                for (int i = ((startingFrom - 1) * 3); i <= (((startingFrom - 1) * 3) - 1) + ((NumberOfCodons / 2) * 3); i++)
                {
                    char temp = DNA_sequence[i];
                    DNA_sequence[i] = DNA_sequence[i + ((NumberOfCodons - 1) * 3)];
                    DNA_sequence[i + ((NumberOfCodons - 1) * 3)] = temp;
                }
            }

            return DNA_sequence;
        }








        //   Operation12    //-------------------------------------------------------
        static void Operation12(char[] DNA_sequence)
        {

            DNA_sequence = Space_remover(DNA_sequence);
            int countera = 0, counterb = 0, counterc = 0;

            for (int i = 0; i < DNA_sequence.Length - 2; i++)
            {
                if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
                {
                    countera++;
                }
                else if (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && (DNA_sequence[i + 2] == 'A' || DNA_sequence[i + 2] == 'G'))
                {
                    counterb++;
                }
                else if (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A')
                {
                    counterc++;
                }

            }
            Console.Write("\nDNA strand\t:  ");
            Console.WriteLine( AddSpaceBetweenCodons( DNA_sequence ) );

            if (countera == (counterc + counterb))
            {
                if (2 <= countera && countera <= 7)
                {
                    Console.WriteLine("\nNumber of genes\t:  " + countera);
                }
            }
            else
            {
                Console.WriteLine("This is not a BLOB");
            }

        }









        //   Operation13    //-------------------------------------------------------
        static void Operation13(char[] DNA_sequence)
        {

            DNA_sequence = Space_remover(DNA_sequence);
            Console.Write("DNA strand      :  ");
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));

            int count = 0, count13 = 99, count13sonkucuk = 99, degisken = 0, degisken1 = 0, counttoplam = 0, atgindexson = 0;

            for (int i = 0; i < DNA_sequence.Length - 2; i = i + 3)
            {

                if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
                {
                    degisken1 = i / 3 + 1; ;
                }

                if ((DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'G') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'A'))
                {
                    counttoplam = counttoplam + count;
                    degisken = i / 3 + 1;
                    count = (degisken) - counttoplam;


                    if (count > count13 && count13sonkucuk > count13)
                    {
                        if (count13 != 0 && count13 != 1)
                        {
                            count13sonkucuk = count13;
                            atgindexson = degisken1;
                        }
                    }
                    else if (count13 >= count && count13sonkucuk > count)
                    {
                        if (count != 1)
                        {
                            count13sonkucuk = count;
                            atgindexson = degisken1;
                        }

                    }
                    count13 = count;
                }

            }

            Console.Write("\nShortest gene                :  ");
            for (int i = (atgindexson - 1) * 3; i < (atgindexson - 1) * 3 + (count13sonkucuk * 3); i++)
            {
                Console.Write(DNA_sequence[i]);
            }

            Console.WriteLine("\nNumber of codons in the gene :  " + count13sonkucuk);
            Console.WriteLine("Position of the gene         :  " + atgindexson);

        }







        //   Operation14    //-------------------------------------------------------
        static void Operation14(char[] DNA_sequence)
        {
            DNA_sequence = Space_remover(DNA_sequence);
            Console.Write("DNA strand      :  ");
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));

            int count = 0, count14 = -99, count14sonbuyuk = -99, degisken = 0, degisken1 = 0, counttoplam = 0, atgindexson = 0;

            for (int i = 0; i < DNA_sequence.Length - 2; i = i + 3)
            {

                if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
                {
                    degisken1 = i / 3 + 1; ;
                }

                if ((DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'G') || (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && DNA_sequence[i + 2] == 'A'))
                {
                    counttoplam = counttoplam + count;
                    degisken = i / 3 + 1;
                    count = (degisken) - counttoplam;

                    if (count < count14 && count14sonbuyuk < count14)
                    {
                        count14sonbuyuk = count14;
                        atgindexson = degisken1;
                    }
                    else if (count14 <= count && count14sonbuyuk < count)
                    {
                        count14sonbuyuk = count;
                        atgindexson = degisken1;
                    }
                    count14 = count;
                }
            }

            Console.Write("\nLongest gene                :  ");
            for (int i = (atgindexson - 1) * 3; i < (atgindexson - 1) * 3 + (count14sonbuyuk * 3); i++)
            {
                Console.Write(DNA_sequence[i]);
            }

            Console.WriteLine("\nNumber of codons in the gene :  " + count14sonbuyuk);
            Console.WriteLine("Position of the gene         :  " + atgindexson);
        }










        //   Operation15    //-------------------------------------------------------
        static void Operation15(char[] DNA_sequance, int Nucleotidnumber)
        {
            DNA_sequance = Space_remover(DNA_sequance);
            char[] array = new char[Nucleotidnumber];
            int newindex = 0, temp = 0, maxindex = 0, sırasayac = 0, maxsıra = 0;

            for (int i = 0; i < DNA_sequance.Length - Nucleotidnumber + 1; i++)
            {
                for (int j = 0; j < Nucleotidnumber; j++)
                {
                    array[j] = DNA_sequance[i + j];
                }

                int sayac = 0, sayac2 = 0;
                temp = newindex;

                for (int k = 0; k < DNA_sequance.Length - Nucleotidnumber + 1; k++)
                {
                    sayac = 0;
                    for (int l = 0; l < Nucleotidnumber; l++)
                    {
                        if (array[l] == DNA_sequance[k + l])
                        {
                            sayac++;
                        }
                        if (sayac == array.Length)
                        {
                            sayac2++;
                        }
                    }
                }
                newindex = sayac2;

                if (newindex > temp && maxindex < newindex)
                {
                    maxindex = newindex;
                    maxsıra = sırasayac;
                }
                else if (newindex <= temp && maxindex < temp)
                {
                    maxindex = temp;
                    maxsıra = sırasayac;
                }
                sırasayac++;
            }

            Console.Write("Most repeated sequence\t: ");
            for (int m = maxsıra; m < Nucleotidnumber + maxsıra; m++)
            {
                Console.Write(DNA_sequance[m]);
            }

            Console.WriteLine();
            Console.Write("Frequency:  ");
            Console.WriteLine(maxindex);
        }







        //   Operation16    //-------------------------------------------------------
        static void operation16(char[] DNA_sequence)
        {
                int abonds = 0, tbonds = 0, gbonds = 0, cbonds = 0, totalbonds = 0;
                DNA_sequence = Space_remover(DNA_sequence);

                for (int i = 0; i < DNA_sequence.Length; i++)
                {
                    if (DNA_sequence[i] == 'A')
                    { abonds++; }
                    else if (DNA_sequence[i] == 'T')
                    { tbonds++; }
                    else if (DNA_sequence[i] == 'G')
                    { gbonds++; }
                    else if (DNA_sequence[i] == 'C')
                    { cbonds++; }

                    totalbonds = (gbonds + cbonds) * 3 + (abonds + tbonds) * 2;
                }
                Console.WriteLine("number of pairing with 2-hydrogen bonds  :  {0}", (abonds + tbonds));
                Console.WriteLine("number of pairing with 3-hydrogen bonds  :  {0}", (gbonds + cbonds));
                Console.WriteLine("total bonds is  :  {0}", totalbonds);
        }



















































        //---------------------------------------------------------------------------------------------------------------------
        static char[] Space_remover(char[] array_with_spaces)
        {
            int spaceCounter = 0;
            for(int i = 0; i < array_with_spaces.Length; i++)
            {
                if (array_with_spaces[i] ==' ')
                {
                    spaceCounter++;
                }
            }
            char[] spaceless_Array = new char[array_with_spaces.Length-spaceCounter];

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







        static char[] MyFunctionForArrayConcatenation(char[] first_char_array, char[] second_char_array)
        {
            char[] result = new char[first_char_array.Length + second_char_array.Length + 1];

            for (int i = 0; i < (first_char_array.Length + second_char_array.Length + 1); i++)
            {
                if (i < first_char_array.Length)
                {
                    result[i] = first_char_array[i];
                }
                else if (i == first_char_array.Length)
                {
                    result[i] = ' ';
                }
                else
                {

                    result[i] = second_char_array[i - (first_char_array.Length + 1)];
                }
            }
            return result;
        }







        static char[] AddSpaceBetweenCodons(char[] DNA_sequence_spaceless)
        {
            int SpaceCount = DNA_sequence_spaceless.Length / 3;
            char[] DNA = new char[DNA_sequence_spaceless.Length + SpaceCount];
            int count = 0;

            for (int i = 0; i < DNA.Length; i++)
            {

                if ((i + 1) % 4 == 0)
                {
                    DNA[i] = ' ';
                }
                else
                {
                    DNA[i] = DNA_sequence_spaceless[count];
                    count++;
                }
            }

            return DNA;
        }






        static int[] arrayOfIndexNumbersOfATGs(char[] DNA_sequence)
        {
            int count = 0;
            for (int i = 0; i < DNA_sequence.Length; i += 3)
            {
                if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
                {
                    count++;
                }
            }

            int[] indexnumberofATG = new int[count];
            count = 0;
            for (int i = 0; i < DNA_sequence.Length; i += 3)
            {
                if (DNA_sequence[i] == 'A' && DNA_sequence[i + 1] == 'T' && DNA_sequence[i + 2] == 'G')
                {
                    indexnumberofATG[count] = i;
                    count++;
                }
            }
            return indexnumberofATG;
        }







        static int[] arrayOfIndexNumbersOfStopCodons(char[] DNA_sequence)
        {


            int count1 = 0;
            for (int i = 0; i < DNA_sequence.Length - 2; i += 3)
            {
                if (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && (DNA_sequence[i + 2] == 'G' || DNA_sequence[i + 2] == 'A'))
                {
                    count1++;
                }
                else if (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A')
                {
                    count1++;
                }
            }


            int[] indexNumber_of_stopCodons = new int[count1];
            count1 = 0;
            for (int i = 0; i < DNA_sequence.Length; i += 3)
            {
                if (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'A' && (DNA_sequence[i + 2] == 'G' || DNA_sequence[i + 2] == 'A'))
                {
                    indexNumber_of_stopCodons[count1] = i;
                    count1++;
                }
                else if (DNA_sequence[i] == 'T' && DNA_sequence[i + 1] == 'G' && DNA_sequence[i + 2] == 'A')
                {
                    indexNumber_of_stopCodons[count1] = i;
                    count1++;
                }
            }
            return indexNumber_of_stopCodons;
        }











    }
}
