using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Defender.Classes
{
    public class MoveableObject : PictureBox
    {
        private const int VerticalIncrements = 6;
        public void MoveDown()
        {
            this.Top += VerticalIncrements;
        }
        public void MoveUp()
        {
            this.Top -= VerticalIncrements;
        }
    }
}
