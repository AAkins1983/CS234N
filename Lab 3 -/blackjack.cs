//BJHand Class
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

//Card Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CardClasses
{
    public class Card
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        public Card()
        {
            value = generator.Next(1, 14);
            suit = generator.Next(1, 5); 
        }

        public Card(int v, int s)
        {
            value = v;
            suit = s;
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int Suit
        {
            get
            {
                return this.suit;
            }
            set
            {
                this.suit = value;
            }
        }

        public bool IsRed()
        {
            return !IsBlack();
        }

        public bool IsBlack()
        {
            if (IsSpade() || IsClub())
                return true;
            else
                return false;
        }

        public bool IsFaceCard()
        {
            switch (value)
            {
                case 11: case 12: case 13:
                    return true;
                default:
                    return false;
            }
        }

        public bool IsAce()
        {
            if (value == 1)
                return true;
            else
                return false;
        }

        public bool IsClub()
        {
            if (suit == 1)
                return true;
            else
                return false;
        }

        public bool IsDiamond()
        {
            if (suit == 2)
                return true;
            else
                return false;
        }

        public bool IsHeart()
        {
            if (suit == 3)
                return true;
            else
                return false;
        }

        public bool IsSpade()
        {
            if (suit == 4)
                return true;
            else
                return false;
        }

        public bool HasMatchingValue(Card other)
        {
            if (other.Value == value)
                return true;
            else
                return false;
        }

        public string FileName
        {
            get
            {
                return "card" + values[value].Substring(0, 1) + 
                       suits[suit].Substring(0, 1) + ".jpg";
            }
        }

        public void Show(PictureBox p)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory 
                + "\\Cards\\" + FileName);
        }

        public void ShowBack(PictureBox p)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory 
                + "\\Cards\\black_back.jpg");
        }

        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }

        public override bool Equals(object obj)
        {
            Card c = (Card)obj;
            if (c.value == this.value && c.suit == this.suit)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}

//Hand Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards = new List<Card>();

        public Hand() { }

        //???
        public int Count()
        {
            int i = 0;
            foreach (Card count in cards)
            {
                i++;
            }
            return i;
        }

        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }

        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        public Card GetCard(int index)
        {
            return cards[index];
        }

        public int IndexOf(Card c)
        {
            return cards.IndexOf(c);
        }

        public int IndexOf(int value)
        {
            int i = 0;
            foreach (Card c in cards)
            {
                if (c.Value == value)
                    return i;
                i++;
            }
            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            int i = 0;
            foreach (Card c in cards)
            {
                if (c.Value == value && c.Suit == suit)
                    return i;
                i++;
            }
            return -1;
        }

        public bool HasCard(Card c)
        {
            return cards.Contains(c);
        }

        public bool HasCard(int value)
        {
            foreach (Card c in cards)
                if (c.Value == value)
                    return true;
            return false;
        }

        public bool HasCard(int value, int suit)
        {
            foreach (Card c in cards)
                if (c.Value == value && c.Suit == suit)
                    return true;
            return false;
        }

        public Card Discard(int index)
        {
            Card c = cards[index];
            cards.Remove(c);
            return c;
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
                output += (c.ToString() + "\n");
            return output;
        }
    }
}

//Deck Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            for (int value = 1; value <= 13; value++)
            { 
                for (int suit = 1; suit <= 4; suit++)
                {
                    cards.Add(new Card(value, suit));
                    value++;
                }
            }
        }

        public int NumCards
        {
            get 
            {
                return cards.Count;
            }
        }

        //I don't know if I need this??
        public int Count()
        {
            int i = 0;
            foreach (Card count in cards)
            {
                i++;
            }
            return i;
        }

        public bool IsEmpty
        {
            get
            {
                return (cards.Count == 0);
            }
        }

        public Card Deal()
        {
            if (!IsEmpty)
            {
                Card c = cards[0];
                cards.Remove(c);
                return c;
            }
            return
                null;
        }

        public void Shuffle()
        {
            Random gen = new Random();
            for (int i = 0; i < NumCards; i++)
            {
                int rnd = gen.Next(i, NumCards);
                Card c = cards[rnd];
                cards[rnd] = cards[i];
                cards[i] = c;
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }
    }
}

//Form
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardClasses;

namespace BlackJack2
{
    public partial class blackJack : Form
    {
        public blackJack()
        {
            InitializeComponent();
        }

        private Deck deck = new Deck();
        private BJHand player, dealer;

        private void LoadPlayerCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["pCard " + i];
            card.Image = Image.FromFile(System.Environment.CurrentDirectory +
            "\\Cards\\" + player.GetCard(i).FileName);
        }

        private void LoadDealerCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["dCard " + i];
            card.Image = Image.FromFile(System.Environment.CurrentDirectory +
            "\\Cards\\" + dealer.GetCard(i).FileName);
        }

        private void LoadCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Image = Image.FromFile(System.Environment.CurrentDirectory +
            "\\Cards\\" + player.GetCard(i).FileName);
        }

        private void LoadPlayerHand()
        {
            for (int i = 0; i < player.NumCards; i++)
                LoadPlayerCard(i);
            for (int i = player.NumCards; i < 5; i++)
                HidePlayerCard(i);
        }

        private void LoadDealerHand()
        {
            for (int i = 0; i < dealer.NumCards; i++)
                LoadDealerCard(i);
            for (int i = dealer.NumCards; i < 5; i++)
                HideDealerCard(i);
        }

        private void LoadCardBack(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.GetCard(i).ShowBack(card);
        }

        private void HidePlayerCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["pCard" + i];
            card.Enabled = false;
            card.Visible = false;
        }

        private void HideDealerCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["dCard" + i];
            card.Enabled = false;
            card.Visible = false;
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            deck = new Deck();
            player = new BJHand();
            dealer = new BJHand();

            deck.Shuffle();
            player.Add(deck.Deal());    
            dealer.Add(deck.Deal());
            player.Add(deck.Deal());
            dealer.Add(deck.Deal());

            LoadPlayerHand();
            LoadDealerHand();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            player.Add(deck.Deal());
            LoadPlayerHand();
            PlayerScore();

            if (player.IsBusted())
                MessageBox.Show("BOOHOO, you bust!");
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            while (dealer.Score() <= 17)
            {
                dealer.Add(deck.Deal());
            }
            LoadDealerHand();
            DealerScore();

            if (dealer.IsBusted())
                MessageBox.Show("BOOHOO, you bust!");
        }     
    }
}
