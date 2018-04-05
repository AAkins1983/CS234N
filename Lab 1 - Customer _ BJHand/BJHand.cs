//BJHand

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        public BJHand() : base() { }

        public bool HasAce()
        {
            if (HasCard(1)) //No object out in front of this; calling "HasCard" on yourself
                return true;
            else
                return false;
        }

        //return HasCard(1);

        public int Score
        {
            get
            {
                int score = 0;
                foreach (Card c in cards)
                {
                    if (c.IsFaceCard())
                        score += 10;
                    else
                        score += c.Value;
                }

                if (HasAce() && score <= 11)
                    score += 10;

                return score;
            }

        }

        public bool IsBusted()
        {
            if (Score > 21) // Score property getter calculates score
                return true;
            else
                return false;
        }
    }
}