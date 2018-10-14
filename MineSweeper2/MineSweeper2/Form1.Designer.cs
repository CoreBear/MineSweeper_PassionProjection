namespace MineSweeper2
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.buttonSmiley = new System.Windows.Forms.Button();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsPanel1 = new MineSweeper2.GraphicsPanel();
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.textBoxFlags = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(791, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // buttonSmiley
            // 
            this.buttonSmiley.Location = new System.Drawing.Point(384, 0);
            this.buttonSmiley.Name = "buttonSmiley";
            this.buttonSmiley.Size = new System.Drawing.Size(23, 23);
            this.buttonSmiley.TabIndex = 4;
            this.buttonSmiley.UseVisualStyleBackColor = true;
            this.buttonSmiley.Click += new System.EventHandler(this.buttonSmiley_Click);
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripMenuItem1});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.difficultyToolStripMenuItem.Text = "Menu";
            // 
            // difficultyToolStripMenuItem1
            // 
            this.difficultyToolStripMenuItem1.Name = "difficultyToolStripMenuItem1";
            this.difficultyToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.difficultyToolStripMenuItem1.Text = "Difficulty";
            this.difficultyToolStripMenuItem1.Click += new System.EventHandler(this.difficultyToolStripMenuItem1_Click);
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 24);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(791, 493);
            this.graphicsPanel1.TabIndex = 3;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Location = new System.Drawing.Point(764, 4);
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(27, 20);
            this.textBoxTimer.TabIndex = 5;
            this.textBoxTimer.Text = "000";
            this.textBoxTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxFlags
            // 
            this.textBoxFlags.Location = new System.Drawing.Point(60, 4);
            this.textBoxFlags.Name = "textBoxFlags";
            this.textBoxFlags.Size = new System.Drawing.Size(26, 20);
            this.textBoxFlags.TabIndex = 5;
            this.textBoxFlags.Text = "000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 539);
            this.Controls.Add(this.textBoxFlags);
            this.Controls.Add(this.textBoxTimer);
            this.Controls.Add(this.buttonSmiley);
            this.Controls.Add(this.graphicsPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.Button buttonSmiley;
        private System.Windows.Forms.TextBox textBoxFlags;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem1;
    }
}

