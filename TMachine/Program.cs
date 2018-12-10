using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMachine
{
    class Program
    {
        static void Main(string[] args)

        {

            Console.Write("Enter filepath: ");
            string path = Console.ReadLine();
            TMParser mParser = new TMParser();
            mParser.ParseFile(path);
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            Machine machine = new Machine(mParser.stateList, mParser.startState,mParser.alpha, mParser.tapeAlpha, mParser.algorithm, mParser.acceptState[0], mParser.rejectState[0], word);

            bool verify = machine.RunMachine();
            Console.WriteLine(verify);
            Console.ReadKey();
            
        }
    }
}
