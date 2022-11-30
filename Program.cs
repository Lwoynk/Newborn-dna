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
            //Random random = new Random();
            //int timing = 300;

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("\t\t\t\t\t--------->    LIFE ON MARS!   <----------");
            //    Console.WriteLine("\t\t\t\t\t--------->    LIFE ON MARS!   <----------");

            //    for (int j = 0; j < 40; j++)
            //    {
            //        Console.SetCursorPosition(random.Next(1, 120), random.Next(3, 28));
            //        Thread.Sleep(2);
            //        Console.Write("*");
            //    }
            //    Thread.Sleep(timing);
            //    timing -= 30;
            //    Console.Clear();
            //}



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
                    Console.Write("how many codons do you want to delete :   ");
                    int codonCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("From which codon do want to start deleting :   ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());

                    Console.Write("DNA strand (stage 1)  :  ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    Console.WriteLine("Delete {0} codons, starting from {1} th codon.", codonCount, startingFrom);
                    Console.Write("DNA strand (stage 2)  :  ");
                    DNA_User1 = Operation8(DNA_User1,3,3);
                    Console.WriteLine( AddSpaceBetweenCodons(DNA_User1) );

                }
                else if (temp1 == 9)
                {





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

            char[] operation8result = new char[DNA_sequence.Length - (codonCount * 3)];

            for (int i = 0; i < DNA_sequence.Length; i++)
            {
                if (i < ((startingFrom - 1) * 3))
                {
                    operation8result[i] = DNA_sequence[i];
                }
                else if (i >= ((startingFrom - 1) * 3) + (3 * codonCount))
                {
                    operation8result[i - ((startingFrom - 1) * 3)] = DNA_sequence[i];
                }
            }
            return operation8result;
        }









        //   Operation9     //-------------------------------------------------------



























































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
