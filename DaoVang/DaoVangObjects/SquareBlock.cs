using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVangObjects
{
    [Serializable]
    public class SquareBlock
    {
        protected int size; // 25, 40, 100
        protected int xLocation;
        protected int yLocation;
        protected int type; // 1->gold, 2->rock, 3->diamond

        public SquareBlock()
        {

        }
        public SquareBlock(int size, int type, int x, int y)
        {
            this.size = size;
            this.xLocation = x;
            this.yLocation = y;
            this.type = type;
        }

        public int getSize()
        {
            return size;
        }

        public int getType()
        {
            return type;
        }

        public void setSize(int size)
        {
            this.size = size;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public int getX()
        {
            return xLocation;
        }
        public void setX(int x)
        {
            xLocation = x;
        }

        public int getY()
        {
            return yLocation;
        }
        public void setY(int y)
        {
            yLocation = y;
        }

        public int value()
        {
            int result = 0;
            switch (type)
            {
                case 1: //gold
                    result = size * 3; // 75, 120, 300 
                    break;
                case 2:
                    result = size; // 25, 40
                    break;
                case 3:
                    result = size * 25; // 625
                    break;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            var block = obj as SquareBlock;
            return block != null &&
                   size == block.size &&
                   xLocation == block.xLocation &&
                   yLocation == block.yLocation &&
                   type == block.type;
        }
    }
}
