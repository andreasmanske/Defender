using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Defender.Classes
{
    public class Weapon : MoveableObject
    {
        public enum WeaponTypes
        {
            Laser, Missle, SmartBomb
        }
        public void Shoot(WeaponTypes weapon, ref PictureBox Source)
        {

        }
        
    }
}
