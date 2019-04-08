using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myStr;
            Alphabet alphabet;
            String givenString;
            String[] tokens = new string[100];
            string a;
            System.ConsoleKeyInfo c;


            do
            {


                Console.WriteLine("ENTER A VALID ALPHABET");
                alphabet = new Alphabet(Console.ReadLine());


                if (!alphabet.isValid())
                {
                    Console.WriteLine("INVALID ALPHABET");
                    Console.Clear();
                }




                //  Console.Clear();

            } while (!alphabet.isValid());


            String[] inputs = { "a", "b","c"};
            Console.WriteLine("ENTER NUMBER OF STATES");
            int noOfStates = Convert.ToInt32(Console.ReadLine());
            State[] states = new State[noOfStates];

            DFA dfa = new DFA(alphabet.getTokens(),noOfStates);

            for (int i = 0; i < noOfStates; i++)
            {
                for (int j = 0; j < alphabet.getsCount(); j++)
                {
                    Console.Write("STATE :  " + (i+1) + " INPUT :  " + alphabet.getTokenAt(j) + "\nTRANSITION TO:  ");
                    dfa.getStateAt(i).setTransitionAt(dfa.getStateAt(Convert.ToInt32(Console.ReadLine()) - 1), j);
                    Console.WriteLine();
                    
                    
                    
                }

                Console.WriteLine();
                Console.WriteLine();
            }


            Console.Write("Number Of Final States:  ");
            int f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();
            for(int i = 0; i < f; i++)
            {
                Console.Write("FINAL STATE 1:   ");
                dfa.getStateAt(Convert.ToInt32(Console.ReadLine())-1).setFinal();
                Console.WriteLine();
            }


            
            {
                Console.WriteLine("ENTER A VALID STRING");
                myStr = new MyString(Console.ReadLine(), alphabet);

                Console.WriteLine();
                Console.WriteLine();

            } while (!myStr.isValid());

            if(dfa.verify(myStr.getTokenizedStr()))
            {
                Console.WriteLine("THE GIVEN STRING IS SATISFYING THE DFA");
            }

            else
                Console.WriteLine("THE GIVEN STRING IS NOT SATISFYING THE DFA");





            do
            {
                Console.WriteLine("ENTER A VALID STRING");
                myStr = new MyString(Console.ReadLine(), alphabet);

                Console.WriteLine();
                Console.WriteLine();

            } while (!myStr.isValid());

            Console.WriteLine("L E N G T H  {0}\nR E V E R S E OF STRING IS {1}", myStr.getCount(), myStr.reverseString());
            
            Console.WriteLine("ENTER LENGTH, ENTER 'A' FOR ALL POSSIBLE COMBINATIONS");
            a = Console.ReadLine();
            try
            {
                
                alphabet.generateStrings(Convert.ToInt32(a));

            }

            catch (Exception)
            {
                if (a == "A")
                {
                    alphabet.generateStrings();
                    Console.WriteLine(".................");
                }
                else
                    Console.WriteLine("Enter a valid input");
            }
            

        }

      


    }

}
