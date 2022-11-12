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



































            //try
            //{

            //    //Operation 1.Load a DNA sequence from a file
            //    string FilePath = "C:\\Users\\muzam\\source\\repos\\Second Project_Life on Mars\\Second Project_Life on Mars\\Files\\Codes.txt";
            //string DNA_From_File = "";

            //if (File.Exists(FilePath))
            //{
            //    StreamReader f = File.OpenText(FilePath);
            //    DNA_From_File = f.ReadLine();
            //    f.Close();
            //}
            //Console.WriteLine(DNA_From_File);
            
            //    Operation16(DNA_From_File.ToUpper());

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Console.ReadLine();


        }

        ////function for 16.Operation
        //static void Operation16(string a)
        //{
        //    try
        //    {
        //        int ABonds = 0, TBonds = 0, GBonds =0, CBonds = 0, TotalBonds = 0;

        //        char[] array = a.ToCharArray();
        //        for (int i = 0; i < array.Length ; i++)
        //        {
        //            if (array[i] == 'A')
        //            { ABonds++; }
        //            else if (array[i] == 'T')
        //            { TBonds++; }
        //            else if (array[i] == 'G' )
        //            { GBonds++; }
        //            else if (array[i] == 'C' )
        //            { CBonds++; }

        //            TotalBonds = (GBonds+CBonds) * 3 + (ABonds+TBonds) * 2;
        //        }
        //        Console.WriteLine("Number of pairing with 2-hydrogen bonds  :  {0}", (ABonds + TBonds));
        //        Console.WriteLine("Number of pairing with 3-hydrogen bonds  :  {0}", (GBonds + CBonds));
        //        Console.WriteLine("Total bonds is  :  {0}", TotalBonds);
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

    }
}
