using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVangObjects
{
    [Serializable]
    public class Mine
    {
        public List<SquareBlock> listOfMine;
        private int numberOfSmallMine;
        private int numberOfMediumMine;
        private int numberOfBigMine;
        private int numberOfSmallRock;
        private int numberOfBigRock;
        private int numberOfDiamond;
        private int sizeOfSmallMine;
        private int sizeOfMediumMine;
        private int sizeOfBigMine;

        public Mine()
        {
            numberOfSmallMine = 14;
            numberOfMediumMine = 10;
            numberOfBigMine = 7;
            numberOfSmallRock = 15;
            numberOfBigRock = 20;
            numberOfDiamond = 3;
            sizeOfSmallMine = 25;
            sizeOfMediumMine = 40;
            sizeOfBigMine = 100;
            listOfMine = new List<SquareBlock>();
        }

        Random rd = new Random();


        public void generateListOfBlocks(int xleft, int xright, int ytop, int ybot, int size, int type)
        {
            int xLocation = int.Parse(rd.Next(xleft, xright).ToString());
            int yLocation = int.Parse(rd.Next(ytop, ybot).ToString());
            SquareBlock block = new SquareBlock();
            if (type == 1)
                block = new Gold(size, xLocation, yLocation);
            else if (type == 2)
                block = new Rock(size, xLocation, yLocation);
            else if (type == 3)
                block = new Diamond(xLocation, yLocation);
            listOfMine.Add(block);
        }

        public void init()
        {
            int i;
            /*
            //gold
            for (i = 0; i < numberOfSmallMine; i++)
            {
                generateListOfBlocks(12, 747, 100, 450, sizeOfSmallMine, 1);
            }
            for (i = 0; i < numberOfMediumMine; i++)
            {
                generateListOfBlocks(12, 700, 100, 600, sizeOfMediumMine, 1);
            }
            for (i = 0; i < numberOfBigMine; i++)
            {
                generateListOfBlocks(12, 670, 380, 640, sizeOfBigMine, 1);
            }

            //rock
            for (i = 0; i < numberOfSmallRock; i++)
            {
                generateListOfBlocks(12, 700, 100, 400, sizeOfSmallMine, 2);
            }
            for (i = 0; i < numberOfBigRock; i++)
            {
                generateListOfBlocks(12, 700, 200, 680, sizeOfMediumMine, 2);
            }
            */
            //diamond
            for (i = 0; i < numberOfDiamond; i++)
            {
                generateListOfBlocks(12, 700, 600, 700, sizeOfSmallMine, 3);
            }
        }

        public int getSmallMineSize()
        {
            return sizeOfSmallMine;
        }

        public int getMediumMineSize()
        {
            return sizeOfMediumMine;
        }

        public int getBigMineSize()
        {
            return sizeOfBigMine;
        }
    }
}
