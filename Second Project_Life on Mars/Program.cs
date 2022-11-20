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
                int abonds = 0, tbonds = 0, gbonds =0, cbonds = 0, totalbonds = 0;

                char[] array = a.ToCharArray();
                for (int i = 0; i < array.Length ; i++)
                {
                    if (array[i] == 'a')
                    { abonds++; }
                    else if (array[i] == 't')
                    { tbonds++; }
                    else if (array[i] == 'g' )
                    { gbonds++; }
                    else if (array[i] == 'c' )
                    { cbonds++; }

                    totalbonds = (gbonds+cbonds) * 3 + (abonds+tbonds) * 2;
                }
                Console.WriteLine("number of pairing with 2-hydrogen bonds  :  {0}", (abonds + tbonds));
                Console.WriteLine("number of pairing with 3-hydrogen bonds  :  {0}", (gbonds + cbonds));
                Console.WriteLine("total bonds is  :  {0}", totalbonds);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void Operation3()
        {
            Random random = new Random();
            char[] Nucleotides = { 'A', 'C', 'G', 'T' };
            char[] stop = { 'A', 'G' };
            char[] dna = {};
            char[] space = { ' ' };
            
            for (int j = 0; j < random.Next(1, 7); j++)

            {
                int Nucleotidnumber = random.Next(5, 29);
                int number = Nucleotidnumber % 4;
                number = Nucleotidnumber - number;
                char[] codons = new char[4 + number + 3];
                for (int i = 0; i < codons.Length; i++)
                {
                    codons[i] = Nucleotides[random.Next(0, 4)];

                    if ((i + 1) % 4 == 0)
                    {
                        codons[i] = ' ';
                    }

                    //try
                    //{
                    //    if (codons[i] == 'A' && codons[i + 1] == 'T' && codons[i + 2] == 'G')
                    //    {
                    //        while (codons[i + 2] == 'G')
                    //        {
                    //            codons[i + 2] = Nucleotides[random.Next(0, 4)];
                    //        }
                    //    }
                    //}
                    //catch { }

                    //try
                    //{
                    //    if (codons[i] == 'T' && codons[i + 1] == 'A' && codons[i + 2] == 'A' )
                    //    {
                    //        while (codons[i + 2] == 'A')
                    //        {
                    //            codons[i + 2] = Nucleotides[random.Next(0, 4)];
                    //        }
                    //    }
                    //}
                    //catch { }

                    //try
                    //{
                    //    if (codons[i] == 'T' && codons[i + 1] == 'A' &&  codons[i + 2] == 'G')
                    //    {
                    //        while (codons[i + 2] == 'G')
                    //        {
                    //            codons[i + 2] = Nucleotides[random.Next(0, 4)];
                    //        }
                    //    }
                    //}
                    //catch { }

                    //try
                    //{
                    //    if (codons[i] == 'T' && codons[i + 1] == 'G' && codons[i + 2] == 'A')
                    //    {
                    //        while (codons[i + 2] == 'A')
                    //        {
                    //            codons[i + 2] = Nucleotides[random.Next(0, 4)];
                    //        }
                    //    }
                    //}catch { }

                    //TGG
                    char stop_codon_nucleotid2 = stop[random.Next(0, 2)];
                    char stop_codon_nucleotid3 = stop[random.Next(0, 2)];
                    if (stop_codon_nucleotid2 == 'G' && stop_codon_nucleotid3 == 'G')
                    {
                        while (stop_codon_nucleotid2 == 'G' && stop_codon_nucleotid3 == 'G')
                        {
                            stop_codon_nucleotid2 = stop[random.Next(0, 2)];
                            stop_codon_nucleotid3 = stop[random.Next(0, 2)];
                        }
                    }
                    //adding start and stop codons
                    if (i == 0) { codons[i] = 'A'; }
                    else if (i == 1) { codons[i] = 'T'; }
                    else if (i == 2) { codons[i] = 'G'; }
                    else if (i == codons.Length - 3) { codons[i] = 'T'; }
                    else if (i == codons.Length - 2) { codons[i] = stop_codon_nucleotid2; }
                    else if (i == codons.Length - 1) { codons[i] = stop_codon_nucleotid3; }

                }
                codons=codons.Concat(space).ToArray();
                dna=dna.Concat(codons).ToArray();
            }


            //gender gene
            char[] gender_array = {};
            int gender_gene=random.Next(1, 4);
            if (gender_gene == 1)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'A', 'A', 'A', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G',' '};
                gender_array = f1;
            }
            else if(gender_gene == 2)
            {
                char[] f1 = { 'A', 'T', 'G', ' ','T', 'T', 'T',' ','A', 'A', 'A', ' ', 'T', 'A', 'G',' '};
                gender_array = f1;
            }
            else if (gender_gene == 3)
            {
                char[] f1 = { 'A', 'T', 'G', ' ', 'T', 'T', 'T', ' ', 'T', 'T', 'T', ' ', 'T', 'A', 'G',' '};
                gender_array = f1;
            }

            dna = gender_array.Concat(dna).ToArray();
            Console.WriteLine(dna);
        }
























    }
}
