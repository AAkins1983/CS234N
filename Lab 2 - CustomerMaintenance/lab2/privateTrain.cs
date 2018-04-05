using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class PrivateTrain : Train
    {
        private Hand hand;
        private bool isOpen;

        public PrivateTrain(Hand h) : base()
        {
            hand = h;
            isOpen = false;
        }

        public PrivateTrain(Hand h, int eValue) : base(eValue)
        {
            hand = h;
            isOpen = false;
        }

        public bool IsOpen
        {
            get { return isOpen; }
        }

        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }

        public bool IsPlayable(Domino d, out bool mustFlip, Hand h)
        {
            if (hand == h)
            {
                return base.isPlayable(d, out mustFlip);
            }
            else
            {
                if (IsOpen)
                {
                    return base.isPlayable(d, out mustFlip);
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
        }

        public void Play(Domino d, Hand h)
        {
            bool mustFlip = false;
            if (isPlayable(d, out mustFlip) == true)
            {
                if (mustFlip)
                { d.Flip(); }
                add(d);
            }
            else
                throw new ArgumentException("No play for you!");
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < dominos.Count; i++)
                output += dominos[i].ToString() + "\n";
            return output;
        }
    }
}