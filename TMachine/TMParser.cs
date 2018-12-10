using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMachine
{
    class TMParser
    {



        public string[] stateList = null;
        public string[] startState = null;
        public string[] rejectState = null;
        public string[] acceptState = null;
        public string[] alpha = null;
        public string[] tapeAlpha = null;
        public string[] crudeAlgo = null;
        public ArrayList algorithm = new ArrayList();




        public void ParseFile(string mPath)
        {

            string[] separators = { "{", "}", ":", ".", "transition", "states", " ", "(", ")", "alpha", "trans-func", "start", "final", ",", "Read", "Write", "Right", "Loop", "Left", "Transition", "--", ";", "accept", "Find" };



            StreamReader mStream = new StreamReader(mPath);
            int count = 0;
            String line;


            while ((line = mStream.ReadLine()) != null)
            {
                switch (count)
                {
                    case 0:
                        break;
                    case 1:
                        stateList = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case 2:
                        startState = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case 3:
                        acceptState = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                     
                        break;
                    case 4:
                        rejectState = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case 5:
                        alpha = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    case 6:
                        tapeAlpha = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        break;
                    default:
                        if ((line.Contains("rwRt") != true) && (line.Contains("rRl") != true) && (line.Contains("rRt") != true) && (line.Contains("rLt") != true) && (line.Contains("rwLt") != true) && (line.Contains("rLl") != true))
                        {
                            break;
                        }
                        crudeAlgo = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        algorithm.Add(crudeAlgo);
                        break;

                }
                count++;


            }




        }

        public void PrintTransitions(Machine machine)
        {
            foreach(string[] s in machine.transFunc)
            {
                Console.Write("[");
                foreach(string word in s)
                {
                    Console.Write(word + " ");

                }
                Console.Write("]");
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
