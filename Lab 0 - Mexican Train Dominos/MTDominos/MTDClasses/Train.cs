using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class Train
    {
        protected List<Domino> dominos = new List<Domino>();
        
        protected int engineValue;

        public Train() //Default constructer
        {
        }

        public Train(int eValue) //Overloaded constructor
        {
            engineValue = eValue;
        }

        public int Count
        {
            get
            {
                return dominos.Count; 
            }
        }

        public int EngineValue //First domino played
        {
            get
            {
                return engineValue; 
            }
            set
            {
                engineValue = value;
            }
        }

        public bool isEmpty
        {
            get
            {
                if (dominos.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public Domino LastDomino
        {
            get
            {
                if (Count == 0)
                    return null;
                else
                    return dominos[Count - 1];
            }
        }

        public int PlayableValue
        {
            //if the train is empty the engine value is the playable value
            get
            {
                if (isEmpty)
                {
                    return engineValue;
                }
                else
                {
                    return LastDomino.Side2;
                }
            }       
        }

        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
        }

        public void add(Domino d)
        {
            dominos.Add(d);
        }

        public bool isPlayable(Domino d, out bool mustFlip)
        {
            if (d.Side1 == PlayableValue)
            {
                mustFlip = false;
                return true;
            }
            else if (d.Side2 == PlayableValue)
            {
                mustFlip = true;
                return true;
            }
            else
            {
                mustFlip = false;
                return false;
            }        
        }

        public void play(Domino d)
        {
            bool mustFlip;
            if (isEmpty == false)
            {
                if (isPlayable(d, out mustFlip)) //If this is true it's side 1
                {
                    if (mustFlip == true)
                    {
                        d.Flip();
                        add(d);
                    }
                    add(d);
                }
                else
                {
                    throw new Exception("Ugh.");
                }
            }
        }

        public override string ToString() // Written list of all dominoes
        {
            string output = "";
            for (int i = 0; i < dominos.Count; i++)
                output += dominos[i].ToString() + "\n";
            return output;
        }
    }
}
