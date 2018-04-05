using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class Hand
    {
        protected List<Domino> handOfDominos = new List<Domino>();

        public int Count
        {
            get
            {
                return handOfDominos.Count;
            }
        }

        public void add(Domino d)
        {
            handOfDominos.Add(d);
        }

        public void Draw(BoneYard by)
        {
            Domino d = by.Draw();
            this.add(d);
        }

        public bool isEmpty
        {
            get
            {
                if (handOfDominos.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public int Score
        {
            get
            {
                int score = 0;
                foreach (Domino d in handOfDominos)
                {
                    score += d.Side1;
                    score += d.Side2;
                }
                return score;
            }
        }

        public Domino this[int index]
        {
            get
            {
                return handOfDominos[index];
            }
        }

        public int IndexOfDomino(int pipValue)
        {
            for (int i = 0; i < handOfDominos.Count; i++)
            {
                Domino d = handOfDominos[i];
                if (d.Side1 == pipValue || d.Side2 == pipValue) //Gives me one domino
                    return i;
            }
            return -1;
        }

        public int IndexOfDoubleDomino(int pipValue)
        {
            for (int i = 0; i < handOfDominos.Count; i++)
            {
                Domino d = handOfDominos[i];
                if (d.Side1 == pipValue && d.Side2 == pipValue)
                    return i;
            }
            return -1;
        }

        public int IndexOfHighDouble()
        {
            int score = 0;
            foreach (Domino d in handOfDominos)
            {
                //int indexOfDouble = IndexOfDoubleDomino(i);
                //if (indexOfDouble == i)
                    //return i;
                if (d.IsDouble() && d.Score>score)
                {
                    score = d.Score;
                }
            }
            if (score > 0)
            {
                return IndexOfDoubleDomino(score / 2);
            }
            else
                return -1;
        }

        public bool HasDomino(int pipValue)
        {
            if (GetDomino(pipValue) != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool HasDoubleDomino(int pipValue)
        {
            if (GetDoubleDomino(pipValue) != null)
            {
                return true;
            }
            else
                return false;
        }

        public Domino GetDoubleDomino(int pipValue)
        {
            for (int i = 0; i < handOfDominos.Count; i++)
            {
                if (handOfDominos[i].Side1 == pipValue && handOfDominos[i].Side2 == pipValue)
                {
                    return handOfDominos[i];
                }
            }
            return null;
        }

        public Domino GetDomino(int pipValue)
        {
            for (int i = 0; i < handOfDominos.Count; i++)
            {
                if (handOfDominos[i].Side1 == pipValue || handOfDominos[i].Side2 == pipValue)
                {
                    return handOfDominos[i];
                }
            }
            return null;
        }

        //Removes domino from hand
        private void Play(int index, Train t)
        {
            bool mustFlip = false;
            Domino d = handOfDominos[index];
            if (t is PrivateTrain)
            {
                PrivateTrain privateT = (PrivateTrain)t;
                if (privateT.IsPlayable(d, out mustFlip, this))
                {
                    handOfDominos.RemoveAt(index);
                    if (mustFlip)
                        d.Flip();
                    privateT.Play(d, this);
                }
                else
                {
                    throw new Exception("Domino " + d.ToString() + " cannot be played.");
                }
            }
            else
            {
                if (t.isPlayable(d, out mustFlip))
                {
                    handOfDominos.RemoveAt(index);
                    if (mustFlip)
                        d.Flip();
                    t.Play(d);
                }
                else
                {
                    throw new Exception("Domino " + d.ToString() + " does not match");
                }
            }
        }

        public void Play(Domino d, Train t)
        {
            int index = handOfDominos.IndexOf(d);
            if (index != -1)
            {
                Play(index, t);
            }
        }

        public Domino Play(Train t)
        {
            int playableValue = t.PlayableValue;
            int index = IndexOfDomino(playableValue);
            if (index != -1)
            {
                Domino playable = this[index];
                Play(index, t);
                return playable;
            }
            else
            {
                throw new Exception("Blah!");
            }
        }

        public void RemoveAt(int index)
        {
            handOfDominos.RemoveAt(index);
        }

        public override string ToString()
        {
            string result = "";
            foreach (Domino d in handOfDominos)
            {
                result += d.Side1 + " - " + d.Side2 + "\n";
            }
            return result;
        }
    }
}
