using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardClasses;

namespace CardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Card c1 = new Card();
            //Card c2 = new Card(1, 2);
            //Card c3 = new Card(13, 4);

            //Console.WriteLine("Testing default constructor.  Expecting random values: " + c1);
            //Console.WriteLine("Testing overloaded constructor. Expecting Ace of Diamonds: " + c2);
            //Console.WriteLine("Testing overloaded constructor. Expecting King of Spades: " + c3);

            //Console.WriteLine("Testing IsRed.  Expecting true, false: " + c2.IsRed() + " " + c3.IsRed());

            //BJHandTestHasAce();
            //BJHandTestIsBusted();
            //BJHandTestScore();

            Console.WriteLine();
            Console.ReadLine();
        }

        static void BJHandTestHasAce()
        {
            BJHand h1 = new BJHand();

            Console.WriteLine("Testing Has Ace");
            
            h1.AddCard (new Card(3, 4));
            h1.AddCard(new Card(11, 12));
            Console.WriteLine("No aces in hand. Expecting false. " + h1.HasAce());
            
            h1.AddCard(new Card(1, 1));
            Console.WriteLine("One ace in the hand. Expecting true. " + h1.HasAce());
        }

        //static void BJHandTestIsBusted()
        //{
        //    BJHand h1 = new BJHand();

        //    Console.WriteLine("Testing Is Busted");

        //    Console.WriteLine("Two aces in hand. Expecting true. " + h1.IsBusted());
        //}

        static void BJHandTestScore()
        {

        }
    }
}
