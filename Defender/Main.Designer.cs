namespace Defender
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.TerrainArea = new System.Windows.Forms.PictureBox();
            this.TerrainScoller = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TerrainArea)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(835, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TerrainArea
            // 
            this.TerrainArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TerrainArea.BackColor = System.Drawing.Color.Black;
            this.TerrainArea.Location = new System.Drawing.Point(0, 681);
            this.TerrainArea.Name = "TerrainArea";
            this.TerrainArea.Size = new System.Drawing.Size(1924, 272);
            this.TerrainArea.TabIndex = 2;
            this.TerrainArea.TabStop = false;
            // 
            // TerrainScoller
            // 
            this.TerrainScoller.Interval = 50;
            this.TerrainScoller.Tick += new System.EventHandler(this.TerrainScoller_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 953);
            this.Controls.Add(this.TerrainArea);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "D E F E N D E R";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.TerrainArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox TerrainArea;
        private System.Windows.Forms.Timer TerrainScoller;
    }
}

