using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMachine
{
    class Machine
    {
        public ArrayList states = new ArrayList();
        public List<State> indexStates = new List<State>();
        public ArrayList start = new ArrayList();
        public ArrayList Tape = new ArrayList();
        public ArrayList Alpha = new ArrayList();
        public ArrayList Gamma = new ArrayList();
        public ArrayList transFunc = new ArrayList();
        public State acceptState = new State("name");
        public State rejectState = new State("name");
        public int Head = 0;
        public State currentState;
        public string currentInput;



        public Machine(string[] mStates, string[] mStart, string[] mAlpha, string[] mGamma, ArrayList mAlgorithm, string accept, string reject ,string word)
        {
            foreach(string s in mStates)
            {
                State newState = new State(s);
                indexStates.Add(newState);
                states.Add(newState);

                if (newState.name.Equals(mStart[0]))
                {
                    currentState = newState;
                }

            }

            foreach(string s in mAlpha)
            {
                Alpha.Add(s);
            }

            foreach(string s in mGamma)
            {
                Gamma.Add(s);
            }

            foreach(string[] s in mAlgorithm)
            {
                transFunc.Add(s);

            }

            foreach(char c in word)
            {
                Tape.Add(c);
            }

            currentInput = word;
            acceptState.name = accept;
        }

        


        public bool RunMachine()
        {
            foreach(char c in Tape)
            {
                if(Gamma.Contains(c) != true)
                {
                    throw new Exception("Error. Word contains symbols not in tape alphabet");
                }
            }
            string current = Tape[Head].ToString();

            while (currentState.name.Equals(acceptState.name) != true)
            {
                
                current = Tape[Head].ToString();

                var thisTrans = from string[] transition in transFunc where transition[1].Equals(currentState.name) && transition[2].Equals(current) select transition;
           
                thisTrans = thisTrans.ToList();
                if (currentState.name.Equals(rejectState))
                {
                    return false;

                }

                if (thisTrans.ElementAt(0).ElementAt(0).Equals("rRl"))
                {

                    this.moveRight();
                    this.printTape();


                }
                if (thisTrans.ElementAt(0).ElementAt(0).Equals("rwRt"))
                {

                    
                    Tape[Head] = thisTrans.ElementAt(0).ElementAt(3);
                   
                    State nextState = indexStates.Where(x => x.name.Equals(thisTrans.ElementAt(0).ElementAt(4))).FirstOrDefault();
                    this.moveRight();
                    currentState = nextState;


                    this.printTape();
                }
                if (thisTrans.ElementAt(0).ElementAt(0).Equals("rRt"))
                {


                    
                    State nextState = indexStates.Where(x => x.name.Equals(thisTrans.ElementAt(0).ElementAt(3))).FirstOrDefault();
                    this.moveRight();
                    currentState = nextState;
                    this.printTape();

                }
                if (thisTrans.ElementAt(0).ElementAt(0).Equals("rLl"))
                {
                    moveLeft();
                    current = Tape[Head].ToString();
                    
                    printTape();
                }
                if (thisTrans.ElementAt(0).ElementAt(0).Equals("rwLt"))
                {

                    Tape[Head] = thisTrans.ElementAt(0).ElementAt(3);
                    
                    State nextState = indexStates.Where(x => x.name.Equals(thisTrans.ElementAt(0).ElementAt(4))).FirstOrDefault();
                    moveLeft();
                    currentState = nextState;
                    printTape();
                }
                if (thisTrans.ElementAt(0).ElementAt(0).Equals("rLt"))
                {


                    
                    State nextState = indexStates.Where(x => x.name.Equals(thisTrans.ElementAt(0).ElementAt(3))).FirstOrDefault();
                    moveLeft();
                    currentState = nextState;
                    printTape();

                }



            }
            return true;

        }

        public void printTape()
        {


            for (int i = 0; i < Tape.Count; i++)
            {


                if (i == Head)
                {
                    Console.Write("[" + currentState.name + "]");
                }
               
                
                Console.Write(Tape[i]);
                
                

            }
            Console.WriteLine();
            
        }
        

        public void changeState(State newState)
        {

            currentState = newState;

        }


        public void stateCreator(string stateName)
        {
            State newState = new State(stateName);
            states.Add(newState);

        }
        
        public void moveRight()
        {
            if ((Head + 1) >= Tape.Count)
            {
                Tape.Add("_");
                Head += 1;
            }
            else
            {
                Head += 1;
            }
        }

        public void moveLeft()
        {
            if (Head == 0)
            {
                Head = 0;
            }
            Head -= 1;

        }

    }


    
}
