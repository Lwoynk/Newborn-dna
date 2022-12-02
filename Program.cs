using System;
using System.Buffers.Text;
using System.IO;
using System.Threading;

namespace Tigers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int LoadOperationNumbere_user = 0;
            char[] DNA_User1 = { };                                                                 //We are assigning a char that we will use constantly so that it changes according to the applied operations.
            char[] DNA_User_Original = { };



            //A small starting show. We added such a detail to make it look better.
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



            Console.WriteLine("Select an option to load a DNA sequence");                           //We make the user choose one of the first 3 options to generate DNA.
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






            if (1 <= LoadOperationNumbere_user && LoadOperationNumbere_user <= 3) //The user is running the txt file loaded here.
            {
                if (LoadOperationNumbere_user == 1)
                {
                    //Add file path
                    char[] DNA_sequence_in_CharArray;
                    string dna_from_file = "";


                    StreamReader f = File.OpenText("dna1.txt");
                    dna_from_file = f.ReadLine();
                    Console.WriteLine(dna_from_file);
                    f.Close();

                    DNA_User1 = dna_from_file.ToCharArray();

                }
                else if (LoadOperationNumbere_user == 2)                       //Here, the user enters a DNA according to her/his own will.
                {
                    Console.WriteLine("Please enter the DNA sequence:");
                    DNA_User1 = Space_remover(Console.ReadLine().ToCharArray());
                    DNA_User_Original = DNA_User1;
                }
                else if (LoadOperationNumbere_user == 3)                    //In the last option, we give a ready-made DNA to the user thanks to the operation we wrote.
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

                     
                    if (genderSelection_forOperation3 == 'F' || genderSelection_forOperation3 == 'f')      //It makes the user choose the gender of the BLOB as it will be needed in the 17th operation.
                    {
                        DNA_User1 = Space_remover(Operation3('F'));
                        DNA_User_Original = DNA_User1;
                    }
                    else if (genderSelection_forOperation3 == 'M' || genderSelection_forOperation3 == 'm') //It makes the user choose the gender of the BLOB as it will be needed in the 17th operation.
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


            Console.Clear();                                                                                        //Here, we print the rest of our operations in the form of a menu and let the user choose it.
            Console.Write("DNA strand 1: ");
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

            int temp1 = Convert.ToInt32(Console.ReadLine());                                                    //We assign the value that the user will enter for the operation to the variable.

            while (temp1 != 18)                                                                                 //If the user enters 18, the application closes.
            {

                if (temp1 == 4)                                                                                 //We do printing and input operations in all operations here. We customize the printing process according to the operation.
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
                else if (temp1 == 8)                                                                               //For example, we take input values ​​in the 8th operation and use this while creating the algorithm of the operation. 
                {                                                                                                  //Then we perform the output operations according to the values ​​obtained.
                    Console.Write("How many codons do you want to delete :   ");
                    int codonCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("And from which codon do want to start deleting :   ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());

                    Console.Write("DNA strand (stage 1)  :  ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    Console.WriteLine("Delete {0} codons, starting from {1} th codon.", codonCount, startingFrom);
                    Console.Write("DNA strand (stage 2)  :  ");
                    DNA_User1 = Operation8(DNA_User1, codonCount, startingFrom);
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));

                }
                else if (temp1 == 9)
                {
                    Console.Write("Enter codons which you want to insert :   ");
                    string codonSequence = Console.ReadLine();
                    Console.Write("Starting from :   ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());

                    Console.Write("DNA strand (stage 1)  :\t");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));
                    Console.Write("Codon sequence        :\t");
                    Console.WriteLine(AddSpaceBetweenCodons(codonSequence.ToCharArray()));
                    Console.Write("Starting from         :\t");
                    Console.WriteLine(startingFrom);
                    Console.Write("DNA strand (stage 2)  :\t");
                    DNA_User1 = Operation9(DNA_User1, codonSequence, startingFrom);
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));

                }
                else if (temp1 == 10)
                {
                    Console.Write("Please enter the codon sequence you want to find :  ");
                    string Codon_string_Operation10 = Console.ReadLine();
                    Console.Write("From which codon you want to start searching :  ");
                    int codonIndex = Convert.ToInt32(Console.ReadLine());
                    Operation10(DNA_User1, Codon_string_Operation10, codonIndex);
                }
                else if (temp1 == 11)
                {
                    Console.Write("Please enter the number of codons to reverse :  ");
                    int NumberOfCodons = Convert.ToInt32(Console.ReadLine());
                    Console.Write("From which codon you want to start reversing :  ");
                    int startingFrom = Convert.ToInt32(Console.ReadLine());
                    Console.Write("DNA strand (stage 1) :  ");
                    Console.WriteLine(DNA_User1);
                    DNA_User1 = Operation11(DNA_User1, NumberOfCodons, startingFrom);
                    Console.WriteLine("Reverse {0} codons, starting from {1}th codon. ", NumberOfCodons, startingFrom);
                    Console.Write("DNA strand (stage 2) :  ");
                    Console.WriteLine(AddSpaceBetweenCodons(DNA_User1));

                }
                else if (temp1 == 12)
                {
                    Operation12(DNA_User1);
                }
                else if (temp1 == 13)
                {
                    Operation13(DNA_User1);
                }
                else if (temp1 == 14)
                {
                    Operation14(DNA_User1);
                }
                else if (temp1 == 15)
                {
                    Operation15(DNA_User1);

                }
                else if (temp1 == 16)
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
        static char[] Operation1(string filepath)                                               //If the user enters 1, this function works. In this function, we use the txt file in the file as dna.
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
        static char[] Operation3(char gender)                                           //In this function we create a gendered BLOB for the user.
        {
            Random random = new Random();
            char[] Nucleotides = { 'A', 'C', 'G', 'T' };
            char[] stop = { 'A', 'G' };
            char[] dna = { };


            for (int j = 0; j < random.Next(1, 7); j++)                                 //We write certain for loops to conform to the rules.
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

                codons[0] = 'A';                                                      //We print the start codon.
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

                dna = MyFunctionForArrayConcatenation(dna, codons);                //We call the function we wrote to combine the first part of DNA and the part after gender.
            }

            dna = MyFunctionForArrayConcatenation(GenderSelection(gender), dna);  //We call the function we wrote for gender.
            return dna;
        }




        static char[] GenderSelection(char gender)                                  //Based on the user's request, we create a BLOB with an appropriate gender.                                         
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


            if (gender_gene == 1)                                                  //We write down all the possibilities that can happen in terms of gender and choose one at random.
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




        static char[] WrongCodonsInWrongPlaces(char[] array)                        //We wrote a function to avoid the problems we may encounter while generating random codons. 
        {                                                                           //For example, ending or starting codons can be created in an undesirable place.
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

        static string Operation4(char[] DNA_sequence)                           //We check whether our DNA is suitable or not, according to the specified rules. If there is a problem during the control, we print the error on the screen according to the situation encountered.
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
                                        message = "DNA structure is OK.";       //If there is no problem in DNA, we also indicate it.
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

        static string Operation5(char[] DNA_sequence)                                                   //We check our DNA to see if it is a BLOB or not by adhering to certain rules. If there is a problem, we print the problem with its type. For example Gender error,number of genes error.
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
                            message_of_gender = "Gender error.";                                         //We're checking to see if there are codons related to gender.
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
                            Blob_Check_message = "Number of Codons error.";                 //We're checking to see if there's a problem with the codon count.
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
        static char[] Operation6(char[] DNA_sequence)                   //We print the complement of the code.
        {
            char[] operation6result = new char[DNA_sequence.Length];

            for (int i = 0; i < DNA_sequence.Length; i++)
            {
                if (DNA_sequence[i] == 'A')
                    operation6result[i] = 'T';
                else if (DNA_sequence[i] == 'T')
                    operation6result[i] = 'A';
                else if (DNA_sequence[i] == 'G')
                    operation6result[i] = 'C';
                else if (DNA_sequence[i] == 'C')
                    operation6result[i] = 'G';
            }
            return operation6result;
        }







        //   Operation7     //-------------------------------------------------------

















        //   Operation8     //-------------------------------------------------------
        static char[] Operation8(char[] DNA_sequence, int codonCount, int startingFrom)         //By using the entered values ​​in our algorithm, we delete the desired number of codons from the desired location.
        {
            DNA_sequence = Space_remover(DNA_sequence);

            char[] operation8result = new char[DNA_sequence.Length - (codonCount * 3)];         

            int temp = (startingFrom - 1) * 3;// 0          

            if (temp != 0)                                                                      //If we explain the algorithm, we print the DNA in the same way until we want it to be deleted. 
            {                                                                                   //In the remaining part, we skip the deleted part and print the remaining part.
                for (int i = 0; i < DNA_sequence.Length; i++)
                {

                    if (i < temp)
                    {
                        operation8result[i] = DNA_sequence[i];
                    }
                    else if (i > (temp + (3 * codonCount)))
                    {
                        operation8result[i - (temp * 3)] = DNA_sequence[i];
                    }
                }
            }


            else if (temp == 0)                                                                //There was a problem when it was wanted to be deleted from the first code, we wrote another algorithm specifically for it.
            {
                for (int i = 0; i < DNA_sequence.Length - ((codonCount * 3)); i++)
                {
                    if (temp == 0)
                    {
                        operation8result[i] = DNA_sequence[i + (codonCount * 3)];
                    }
                }
            }



            return operation8result;
        }









        //   Operation9     //-------------------------------------------------------
        static char[] Operation9(char[] DNA_sequence, string Codon_sequence, int StartingFrom)          //In this operation, we insert a codon to the DNA according to the values ​​entered by the user.
        {
            DNA_sequence = Space_remover(DNA_sequence);
            char[] operation9result = new char[DNA_sequence.Length + Codon_sequence.Length];

            for (int i = 0; i < (StartingFrom - 1) * 3; i++)                                            //We created a new char and printed it the same way until the added part, then we printed the added part and finally we printed the rest.
            {                                                                                           // We have written formulas that will match the entered values.
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
        static void Operation10(char[] DNA_sequence, string codonSequence, int startingFrom)            //Starting from the codon the user wants, we also search for the desired codon in DNA.
        {
            DNA_sequence = Space_remover(DNA_sequence);
            Console.Write("DNA strand      :\t");
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));
            Console.Write("Codon sequence  :\t");
            char[] search = codonSequence.ToCharArray();
            search = Space_remover(search);
            Console.WriteLine(AddSpaceBetweenCodons(search));
            Console.Write("Starting from   :\t");
            Console.WriteLine(startingFrom);

            int count = 0;
            bool flag = false;

            for (int i = (startingFrom - 1) * 3; i < DNA_sequence.Length - search.Length; i = i + 3)    //As an algorithm, we increased the largest for 3 by 3 because it needed to search for codons properly.
            {
                count = 0;
                for (int j = 0; j < search.Length; j++)                                                //If the number of nested for use increases and the length of the searched codon increases, it says it has found and bool becomes true. 
                {                                                                                      //It calculates and prints its index.
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
        static char[] Operation11(char[] DNA_sequence, int NumberOfCodons, int startingFrom)            //We reverse the specified number of codons in the specified place according to the value entered by the user.
        {

            DNA_sequence = Space_remover(DNA_sequence);

            if (NumberOfCodons % 2 == 1)
            {   
                for (int i = ((startingFrom - 1) * 3); i < ((startingFrom - 1) * 3) + ((NumberOfCodons / 2) * 3); i++)              //We found the appropriate formulas and made an algorithm to be able to reverse it.
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
        static void Operation12(char[] DNA_sequence)                        //In the 12th operation, we found the number of genes in DNA.
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
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));

            if (countera == (counterc + counterb))                          //We calculate the number of ATG and the number of ending codons and print them if they are equal.
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
        static void Operation13(char[] DNA_sequence)                        //We find the shortest gene in DNA.
        {

            DNA_sequence = Space_remover(DNA_sequence);
            Console.Write("DNA strand      :  ");
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));

            //If we explain the algorithm of this function. It finds the values ​​of the ending codons and subtracts them from the previous ones, thus finding the gene length.
            //We assign the gene length to a temporary variable and if the next one is less than ten we assign it as the smallest value. We do this for all and find the smallest.
            //Meanwhile, by assigning an index value, if the smallest value changes, we change our index value because we want to print the shortest width.

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
        static void Operation14(char[] DNA_sequence)                                    //We find the longest gene in DNA.
        {
            DNA_sequence = Space_remover(DNA_sequence);
            Console.Write("DNA strand      :  ");
            Console.WriteLine(AddSpaceBetweenCodons(DNA_sequence));

            int count = 0, count14 = -99, count14sonbuyuk = -99, degisken = 0, degisken1 = 0, counttoplam = 0, atgindexson = 0;

            //The 14th operation and the 13th operation are very similar. We used the same logic in both, but this time we found the long gene.
            //Because this time, if it is longer than the previous gene, we change and use the same index logic.

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
        static void Operation15(char[] DNA_User1)               //We check which nucleotide sequence has the most according to the integer value entered by the user.
        {
            char[] sequance = Space_remover(DNA_User1);
            Console.Write("DNA strand      :  ");
            Console.WriteLine(sequance);

            Console.Write("Please enter sequance number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            char[] array = new char[number];
            int newindex = 0;
            int temp = 0;
            int maxindex = 0;
            int sırasayac = 0;
            int maxsıra = 0;

            //The algorithm of this operation is similar to the search operation. In this operation, we first find all the nucleotide sequences suitable for the desired value thanks to the two fores,
            //and then we use the comparison method we used in the 13th and 14th operations. If there are more than one, it prints it.

            for (int i = 0; i < sequance.Length - number + 1; i++)
            {

                for (int j = 0; j < number; j++)
                {
                    array[j] = sequance[i + j];
                }

                int sayac = 0;
                int sayac2 = 0;

                temp = newindex;
                for (int k = 0; k < sequance.Length - number + 1; k++)
                {
                    sayac = 0;
                    for (int l = 0; l < number; l++)
                    {
                        if (array[l] == sequance[k + l])
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

            Console.WriteLine("");
            Console.Write("Enter number of nucletide: ");
            Console.WriteLine(number);
            Console.Write("Frequency:  ");
            Console.WriteLine(maxindex);
            Console.Write("Most repeated sequence: ");
            for (int m = maxsıra; m < number + maxsıra; m++)
            {
                Console.Write(sequance[m]);
            }
        }







        //   Operation16    //-------------------------------------------------------
        static void operation16(char[] DNA_sequence)                                //We give information about the bond numbers of the DNA we have.
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
            Console.WriteLine("number of pairing with 2-hydrogen bonds  :  {0}", (abonds + tbonds));        //We calculate the number of bonds based on the number of nucleotides found.
            Console.WriteLine("number of pairing with 3-hydrogen bonds  :  {0}", (gbonds + cbonds));
            Console.WriteLine("total bonds is  :  {0}", totalbonds);
        }



















































        //---------------------------------------------------------------------------------------------------------------------
        static char[] Space_remover(char[] array_with_spaces)
        {
            int spaceCounter = 0;
            for (int i = 0; i < array_with_spaces.Length; i++)
            {
                if (array_with_spaces[i] == ' ')
                {
                    spaceCounter++;
                }
            }
            char[] spaceless_Array = new char[array_with_spaces.Length - spaceCounter];

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
