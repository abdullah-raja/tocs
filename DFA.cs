using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DFA
    {
        
        State[] states;
        string[] inputs;
        State currentState;


        public DFA(String[] inputs, int noOfStates)
        {
            this.inputs = inputs;
            this.states = new State[noOfStates];
            for (int i = 0; i < noOfStates; i++)
                this.states[i] = new State(this, false,i);
            currentState = this.states[0];
        }
        public DFA(State[] states, string[] inputs)
        {
            this.states = states;
            this.inputs = inputs;
            currentState = states[0];
        }

        public State transitionMapping(State s, string str)
        {
            if (str.Length == 1)
                return s.getTransitionAt(Array.IndexOf(inputs, str));

            else
            {
                
                return transitionMapping(s, str.Remove(str.Length - 1));
            }
            //currentState = currentState.transition(Array.IndexOf(inputs, str));
        }

        public bool verify(String[] str)
        {
            int n = 0;
            while(n < str.Length)
            {
                
                currentState = currentState.getTransitionAt(Array.IndexOf(inputs, str[n++].ToString()));
            }

            return currentState.isFinal();
        }

        public State getStateAt(int i)
        {
            return states[i];
        }

        public void setStateAt(State s, int i)
        {
            this.states[i] = s;
        }
        public int getNoOfInputs()
        {
            return inputs.Length;
        }
    }
}
