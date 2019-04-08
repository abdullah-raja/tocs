using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Alphabet
    {
        string alphabet;
        string[] tokenizedAlphabet;
        int tokenCount;


        public Alphabet(string alphabet)
        {
            this.alphabet = alphabet;
            tokenize();
        }

        private void generateStrings(string str, int n, int l)
        {

            if (n == 0)
                Console.WriteLine("^");

            else
            {
                if (l >= n)
                {
                    Console.WriteLine(str);

                }

                else
                {
                    for (int i = 0; i < this.tokenCount; i++)
                        generateStrings(str + tokenizedAlphabet[i], n, l + 1);

                }

            }
        }

        public void generateStrings(int n)
        {
            
            generateStrings("", n, 0);
        
            
        }

        public void generateStrings()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("S T R I N G S   O F   L E N G T H   {0}", i);
                generateStrings("", i, 0);
                Console.WriteLine("\n\n");
            }
        }


        public void setAlphabet(string alphabet)
        {
            this.alphabet = alphabet;
            tokenize();
        }

        public string getAlphabet()
        {
            return this.alphabet;
        }

        public string[] getTokens()
        {
            return tokenizedAlphabet;
        }

        public string getTokenAt(int i)
        {
            return tokenizedAlphabet[i];
        }

        public int getsCount()
        {
            return tokenCount;
        }


        public bool isValid()
        {
            bool valid = true;


            if (tokenizedAlphabet == null)
                return false;


            else
            {
                for (int x = 0; x < tokenCount; x++)
                {
                    for (int y = x + 1; y < tokenCount; y++)
                    {

                        if (!checkValidity(tokenizedAlphabet[x], tokenizedAlphabet[y]))
                        {
                            valid = false;
                            break;
                        }



                    }
                }

                return valid;

            }

            
        }

        bool checkValidity(string s1, string s2)
        {
            bool valid = false;
            int minLength;

            if (s1.Length > s2.Length)
                minLength = s2.Length;
            else
                minLength = s1.Length;

            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] != s2[i])
                {
                    valid = true;
                    break;
                }
            }


            return valid;

        }



        public void tokenize()
        {
            

            int tokenCount = 0;
            String[] tokens = new String[100];





            for (int i = 0; i < this.alphabet.Length; i++)
            {
                if (alphabet[i] == '{')
                {
                    tokens[tokenCount] = "";
                    continue;
                }

                else if (alphabet[i] == '}')
                    break;

                else if (alphabet[i] == ',')
                {
                    tokenCount++;
                    tokens[tokenCount] = "";
                }
                else
                    tokens[tokenCount] += alphabet[i];
            }

            this.tokenCount = tokenCount+1;

            if (tokenCount != 0)
            {
                tokenCount++;
                tokenizedAlphabet = new String[tokenCount];
                for (int i = 0; i < tokenCount; i++)
                {
                    tokenizedAlphabet[i] = tokens[i];
                }

            }

            else
                tokenizedAlphabet = null;

            
        }


    }
}
