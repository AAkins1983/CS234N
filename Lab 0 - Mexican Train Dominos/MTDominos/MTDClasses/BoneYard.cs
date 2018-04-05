using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        private List<Domino> listOfDominos;

        public BoneYard(int maxDots)
        {
            listOfDominos = new List<Domino>();
            for (int leftSide = 0; leftSide <= maxDots; leftSide++)
                for (int rightSide = leftSide; rightSide <= maxDots; rightSide++)
                    listOfDominos.Add(new Domino(leftSide, rightSide));
        }

        public void Shuffle()
        {
            Domino temp;
            Random r = new Random();
            for (int i = 0; i < listOfDominos.Count; i++)
            {
                int rNum = r.Next(0, listOfDominos.Count);
                temp = listOfDominos[i];
                listOfDominos[i] = listOfDominos[rNum];
                listOfDominos[rNum] = temp;
            }
        }

        public bool IsEmpty()
        {
            if (listOfDominos.Count == 0)
                return true;
            else
                return false;
        }

        public int DominosRemaining
        {
            get
            {
                return listOfDominos.Count;
            }
        }

        public Domino Draw()
        {
            if (!IsEmpty())
            {
                Domino top = listOfDominos[0];
                listOfDominos.RemoveAt(0);
                return top;
            }
            else
                throw new Exception("Bone Yard is empty");
        }

        public Domino this[int index]
        {
            get
            {
                return listOfDominos[index];
            }
            set
            {
                listOfDominos[index] = value;
            }
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < listOfDominos.Count; i++)
                output += listOfDominos[i].ToString() + "\n";
            return output;
        }
    }
}
//End Class
