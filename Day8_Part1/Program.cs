using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Part1
{
    class Program
    {
        static void Main(string[] args)
        {



            string[] lines = File.ReadAllLines(@".\Day8Part1.txt");

            int totalCodeLength = 0;
            int totalRealStringLength = 0;

            foreach (string line in lines)
            {

                totalCodeLength += line.Length + 2; // rajouter les " de debut et de fin
                int realStringLength = 0;

                for (int i = 0; i < line.Length; ++i)
                {


                    if (line[i] == '\\')
                    {
                        bool isNotHexa = true;

                        if (i + 1 < line.Length)
                        {
                            if (line[i + 1] == 'x') // \x
                            {
                                ++realStringLength;
                                i += 3;
                                isNotHexa = false;
                            }
                            
                        }

                        if (isNotHexa) // \
                        {
                            ++realStringLength;
                            ++i;
                        }
                        

                    }
                    else if (line[i] == '\"') // "
                    {
                        ++realStringLength;
                        ++i;
                    }
                    else
                    {
                        ++realStringLength;
                    }

                }

                totalRealStringLength += realStringLength;
            }

            int total = totalCodeLength - totalRealStringLength;

            Console.WriteLine(total);



        }


    }
}
