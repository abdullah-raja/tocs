using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class State
    {
        State[] transitions;
        bool final;
        DFA dfa;
        int id;

        public State(DFA dfa)
        {
            this.dfa = dfa;
            
            transitions = new State[dfa.getNoOfInputs()];
        }

        public State(DFA dfa, bool final,int id):this(dfa)
        {
            this.id = id;
            this.final = final;
            
        }
        public State(State[] transitions, bool final)
        {
            this.transitions = transitions;
            this.final = final;
        }

        public void setTransitionAt(State s, int i)
        {
            this.transitions[i] = s;
        }

        public State getTransitionAt(int i)
        {
            return transitions[i];
        }

        public void setFinal()
        {
            final = true;
        }
        public bool isFinal()
        {
            return final;
        }

        public void setTransitions(State[] t)
        {
            this.transitions = t;
        }
    }
}
