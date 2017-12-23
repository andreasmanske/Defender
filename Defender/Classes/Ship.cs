using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Defender.Classes
{
    public static class Ships
    {
        private static List<Ship> shipRegistry = new List<Ship>();
        public enum ShipTypes
        {
            Defender, BodySnatcher, EnemyCruiser
        }
        public static Ship Add(ShipTypes typeOfShip)
        {
            switch (typeOfShip)
            {
                case ShipTypes.Defender:
                    {
                        Ship newShip = new DefenderShip();
                        shipRegistry.Add(newShip);
                        return newShip;
                    }
                default: throw new Exception("Ship not programmed for");
            }
        }
    }
    public class Ship : MoveableObject
    {
        private Ships.ShipTypes _typeOfShip;
        public Ships.ShipTypes Type
        {
            get { return _typeOfShip; }
        }
        public Ship(Ships.ShipTypes typeOfShip, string name)
        {
            _typeOfShip = typeOfShip;
            this.Name = name;
        }
        private Weapon weaponObject = new Weapon();
        public void Shoot(Weapon.WeaponTypes weapon)
        {
            //weaponObject.Shoot(weapon, ref this);
        }
    }
    public class DefenderShip : Ship
    {
        /// <summary>
        /// probably there will only be one so really no need for the user to name it
        /// </summary>
        public DefenderShip() : this("Defender") { }
        public DefenderShip(string name) :base(Ships.ShipTypes.Defender,name)
        {
            ImageLocation = @"..\..\Images\DefenderShip.jpg";
            Image = Image.FromFile(ImageLocation);
            Location = new Point(125, 120);
            Size = new Size(100,40 );
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
