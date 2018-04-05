using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardClasses;

namespace Concentration
{
    public partial class boardForm : Form
    {
        public boardForm()
        {
            InitializeComponent();
        }

        #region Instance Variables
        //string[] cards = new string[21];
        Card[] cards = new Card[21];
        int index1 = -1;
        int index2 = -1;
        int seconds = 0;
        int matches = 0;
        #endregion

        #region Methods
        // change this one
        private void FillCards()
        {
            int i = 1;

            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 5; value++)
                {
                    cards[i] = new Card(value, suit);
                    i++;
                }
            }
        }
        // change this one
        private void LoadCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            cards[i].Show(card);
        }
        // change this one
        private void LoadCardBack(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            cards[i].ShowBack(card);
        }

        private void HideCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Enabled = false;
            card.Visible = false;
        }

        // change this one
        private bool IsMatch(int index1, int index2)
        {
            if (cards[index1].HasMatchingValue(cards[index2]))
                return true;
            else
                return false;
        }

        private void HideAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = false;
                card.Visible = false;
            }
        }

        private void ShowAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = true;
                card.Visible = true;
            }
        }

        private void DisableAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = false;
            }
        }

        private void DisableCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Enabled = false;
        }

        private void EnableAllVisibleCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                if (card.Visible)
                    card.Enabled = true;
            }
        }

        #endregion
        private void frmBoard_Load(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            lblElapsedTime.Text = seconds.ToString();

            FillCards();
            for (int i = 1; i <= 20; i++)
            {
                LoadCardBack(i);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
            lblElapsedTime.Text = seconds.ToString();
        }

        private void card_Click(object sender, EventArgs e)
        {
            PictureBox card = (PictureBox)sender;
            int cardIndex = int.Parse(card.Name.Substring(4));
            if (index1 == -1)
            {
                index1 = cardIndex;
                LoadCard(cardIndex);
                DisableCard(cardIndex);
            }
            else
            {
                index2 = cardIndex;
                LoadCard(cardIndex);
                DisableAllCards();
                flipTimer.Enabled = true;
            }
        }

        private void flipTimer_Tick(object sender, EventArgs e)
        {
            flipTimer.Enabled = false;
            if (IsMatch(index1, index2))
            {
                HideCard(index1);
                HideCard(index2);
                index1 = -1;
                index2 = -1;
                matches++;
                if (matches == 10)
                {
                    MessageBox.Show("Game Over");
                }
                else
                    EnableAllVisibleCards();
            }
            else
            {
                LoadCardBack(index1);
                LoadCardBack(index2);
                index1 = -1;
                index2 = -1;
                EnableAllVisibleCards();
            }
        }
    }
}
