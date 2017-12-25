using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVangObjects
{
    [Serializable]
    public class Grabber
    {
        public int isMoveRight; // left=0 or right=1
        public int isGrabbing;
        public SquareBlock grabbedItem;
        public int grabbedItem_index;
        private int xLocation;
        private int yLocation;

        private int widthSize;
        private int heightSize;


        public Grabber()
        {
            isMoveRight = 0;
            isGrabbing = 0;
            xLocation = 12;
            yLocation = 12;

            widthSize = 25;
            heightSize = 25;

            grabbedItem = null;
            grabbedItem_index = -1;
        }

        public void moveGrabber()
        {
            if (xLocation == 12)
                isMoveRight = 0;
            else if (xLocation == 747)
                isMoveRight = 1;

            if (isMoveRight == 0)
                xLocation = xLocation + 15;
            else
                xLocation = xLocation - 15;
        }

        public void extendGrabber()
        {
            if (isGrabbing == 0)
            {
                heightSize = heightSize + 30;
            }
            else
            {
                if (grabbedItem != null)
                    grabbedItem.setY(grabbedItem.getY() - 30);
                heightSize = heightSize - 30;      
            }
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

        public int getWidth()
        {
            return widthSize;
        }

        public void setWidth(int width)
        {
            widthSize = width;
        }

        public int getHeight()
        {
            return heightSize;
        }

        public void setHeight(int height)
        {
            heightSize = height;
        }

        public override bool Equals(object obj)
        {
            var grabber = obj as Grabber;
            return grabber != null &&
                   isMoveRight == grabber.isMoveRight &&
                   isGrabbing == grabber.isGrabbing &&
                   EqualityComparer<SquareBlock>.Default.Equals(grabbedItem, grabber.grabbedItem) &&
                   grabbedItem_index == grabber.grabbedItem_index &&
                   xLocation == grabber.xLocation &&
                   yLocation == grabber.yLocation &&
                   widthSize == grabber.widthSize &&
                   heightSize == grabber.heightSize;
        }
    }
}
