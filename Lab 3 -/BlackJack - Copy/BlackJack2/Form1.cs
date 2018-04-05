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
