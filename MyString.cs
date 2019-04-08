using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyString
    {
        Alphabet alphabet;
        string str;
        string[] tokenizedString;
        bool valid;
        int count;
        string[] combinations;
        int ptr;


        public MyString(string str, Alphabet alphabet)
        {
            this.alphabet = alphabet;
            this.str = str;
            tokenize();
        }

        public string reverseString()
        {
            string revStr = "";
            for (int i = count-1; i >= 0; i--)
                revStr += tokenizedString[i];
            return revStr;

        }

        public string[] getTokenizedStr()
        {
            return tokenizedString;
        }
        public bool isValid()
        {
            return this.valid;
        }

        public string  getStr()
        {
            return this.str;
        }

        public void setStr(string str)
        {
            this.str = str;
            tokenize();
        }

        public void setAlphabet(Alphabet alphabet)
        {
            this.alphabet = alphabet;
            tokenize();
        }

        public Alphabet getAlphabet()
        {
            return alphabet;
        }

        public int getCount()
        {
            return count;
        }
        void tokenize()
        {
            String[] tokenisedString = new string[100];
            int strPtr = 0, strArrayPtr = 0, i = 0, j = 0;
            
            bool flag = true, validString = true;
            string temp = "";
            while (strPtr < str.Length && i < alphabet.getsCount())
            {
                flag = true;
                if (str[strPtr] == alphabet.getTokenAt(i)[j])
                {
                    temp = "";
                    int tempStrPtr = strPtr;
                    for (int k = 0; k < alphabet.getTokenAt(i).Length; k++)
                    {

                        if (str[tempStrPtr] != alphabet.getTokenAt(i)[k])
                        {
                            flag = false;
                            temp = "";
                            break;
                        }

                        else
                        {
                            temp += str[tempStrPtr];
                        }

                        tempStrPtr++;
                    }

                    if (flag)
                    {
                        tokenisedString[strArrayPtr++] = temp;
                        strPtr = tempStrPtr;
                        i = 0;
                        j = 0;
                    }

                    else
                    {
                        if (i < alphabet.getsCount())
                        {
                            i++;
                            j = 0;

                        }

                        else
                        {
                            validString = false;
                            break;
                        }

                    }

                }

                else
                {

                    i++;


                    
                }

            }

            if (i >= alphabet.getsCount())
                validString = false;

            this.valid = validString;

            this.tokenizedString = new string[strArrayPtr];
            for(int n = 0; n < strArrayPtr; n++)
            {
                tokenizedString[n] = tokenisedString[n];
            }

            this.count = strArrayPtr;
        }

    }
}

