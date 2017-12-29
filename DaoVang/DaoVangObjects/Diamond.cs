using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVangObjects
{
    [Serializable]
    public class Diamond : SquareBlock
    {
        public Diamond(int xLocation, int yLocation) : base(25, 3, xLocation, yLocation)
        {
        }
    }
}
