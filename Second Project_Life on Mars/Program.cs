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

    }
}
