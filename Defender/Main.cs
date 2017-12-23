using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Defender.Classes;


namespace Defender
{
    public partial class Main : Form
    {
        
        Terrain.Mountains mountains;
        public Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mountains = new Terrain.Mountains(this, ref TerrainArea);
            this.Invalidate();
            TerrainArea.Left=0;
            TerrainScoller.Enabled = true;
            Sounds.Play(Sounds.SoundTypes.SavePeople);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            TerrainArea.Width = Main.ActiveForm.Width;
            this.KeyPreview = true;
            this.KeyPress +=  new KeyPressEventHandler(Main_KeyPress);
            Ship newShip = Ships.Add(Ships.ShipTypes.Defender);
            this.Controls.Add(newShip);
        }
        private void TerrainScoller_Tick(object sender, EventArgs e)
        {
            TerrainArea.Left -= 6;
            mountains.RedrawLastVisibleSection(ref TerrainArea, this.Size.Width);
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.Write(e.KeyChar);
            if (e.KeyChar == 122) ((DefenderShip)Controls.Find("Defender", false).Where(c => c is DefenderShip).First()).MoveDown();
            if (e.KeyChar == 119) ((DefenderShip)Controls.Find("Defender", false).Where(c => c is DefenderShip).First()).MoveUp();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            Console.Write(e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Z:
                    {
                        //MoveableObject.MoveDown(ref imgShip1);
                        break;
                    }
                case Keys.W:
                    {
                        //MoveableObject.MoveUp(ref imgShip1);
                        break;
                    }
            }
        }
    }
}
