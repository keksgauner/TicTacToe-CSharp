namespace TTT
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_topleft = new System.Windows.Forms.Button();
            this.btn_topmid = new System.Windows.Forms.Button();
            this.btn_topright = new System.Windows.Forms.Button();
            this.btn_midleft = new System.Windows.Forms.Button();
            this.btn_mid = new System.Windows.Forms.Button();
            this.btn_midright = new System.Windows.Forms.Button();
            this.btn_bottomleft = new System.Windows.Forms.Button();
            this.btn_bottommid = new System.Windows.Forms.Button();
            this.btn_bottomright = new System.Windows.Forms.Button();
            this.lbl_player = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_topleft
            // 
            this.btn_topleft.Location = new System.Drawing.Point(12, 27);
            this.btn_topleft.Name = "btn_topleft";
            this.btn_topleft.Size = new System.Drawing.Size(75, 75);
            this.btn_topleft.TabIndex = 0;
            this.btn_topleft.UseVisualStyleBackColor = true;
            // 
            // btn_topmid
            // 
            this.btn_topmid.Location = new System.Drawing.Point(93, 27);
            this.btn_topmid.Name = "btn_topmid";
            this.btn_topmid.Size = new System.Drawing.Size(75, 75);
            this.btn_topmid.TabIndex = 1;
            this.btn_topmid.UseVisualStyleBackColor = true;
            // 
            // btn_topright
            // 
            this.btn_topright.Location = new System.Drawing.Point(174, 27);
            this.btn_topright.Name = "btn_topright";
            this.btn_topright.Size = new System.Drawing.Size(75, 75);
            this.btn_topright.TabIndex = 1;
            this.btn_topright.UseVisualStyleBackColor = true;
            // 
            // btn_midleft
            // 
            this.btn_midleft.Location = new System.Drawing.Point(12, 108);
            this.btn_midleft.Name = "btn_midleft";
            this.btn_midleft.Size = new System.Drawing.Size(75, 75);
            this.btn_midleft.TabIndex = 0;
            this.btn_midleft.UseVisualStyleBackColor = true;
            // 
            // btn_mid
            // 
            this.btn_mid.Location = new System.Drawing.Point(93, 108);
            this.btn_mid.Name = "btn_mid";
            this.btn_mid.Size = new System.Drawing.Size(75, 75);
            this.btn_mid.TabIndex = 1;
            this.btn_mid.UseVisualStyleBackColor = true;
            // 
            // btn_midright
            // 
            this.btn_midright.Location = new System.Drawing.Point(174, 108);
            this.btn_midright.Name = "btn_midright";
            this.btn_midright.Size = new System.Drawing.Size(75, 75);
            this.btn_midright.TabIndex = 1;
            this.btn_midright.UseVisualStyleBackColor = true;
            // 
            // btn_bottomleft
            // 
            this.btn_bottomleft.Location = new System.Drawing.Point(12, 189);
            this.btn_bottomleft.Name = "btn_bottomleft";
            this.btn_bottomleft.Size = new System.Drawing.Size(75, 75);
            this.btn_bottomleft.TabIndex = 0;
            this.btn_bottomleft.UseVisualStyleBackColor = true;
            // 
            // btn_bottommid
            // 
            this.btn_bottommid.Location = new System.Drawing.Point(93, 189);
            this.btn_bottommid.Name = "btn_bottommid";
            this.btn_bottommid.Size = new System.Drawing.Size(75, 75);
            this.btn_bottommid.TabIndex = 1;
            this.btn_bottommid.UseVisualStyleBackColor = true;
            // 
            // btn_bottomright
            // 
            this.btn_bottomright.Location = new System.Drawing.Point(174, 189);
            this.btn_bottomright.Name = "btn_bottomright";
            this.btn_bottomright.Size = new System.Drawing.Size(75, 75);
            this.btn_bottomright.TabIndex = 1;
            this.btn_bottomright.UseVisualStyleBackColor = true;
            // 
            // lbl_player
            // 
            this.lbl_player.AutoSize = true;
            this.lbl_player.Location = new System.Drawing.Point(255, 27);
            this.lbl_player.Name = "lbl_player";
            this.lbl_player.Size = new System.Drawing.Size(101, 13);
            this.lbl_player.TabIndex = 3;
            this.lbl_player.Text = "Spieler X ist am Zug";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(372, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.githubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.githubToolStripMenuItem.Text = "Github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 273);
            this.Controls.Add(this.lbl_player);
            this.Controls.Add(this.btn_bottomright);
            this.Controls.Add(this.btn_midright);
            this.Controls.Add(this.btn_topright);
            this.Controls.Add(this.btn_bottommid);
            this.Controls.Add(this.btn_mid);
            this.Controls.Add(this.btn_topmid);
            this.Controls.Add(this.btn_bottomleft);
            this.Controls.Add(this.btn_midleft);
            this.Controls.Add(this.btn_topleft);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Tic Tac Toe | Sebastian Schindler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_topleft;
        private System.Windows.Forms.Button btn_topmid;
        private System.Windows.Forms.Button btn_topright;
        private System.Windows.Forms.Button btn_midleft;
        private System.Windows.Forms.Button btn_mid;
        private System.Windows.Forms.Button btn_midright;
        private System.Windows.Forms.Button btn_bottomleft;
        private System.Windows.Forms.Button btn_bottommid;
        private System.Windows.Forms.Button btn_bottomright;
        private System.Windows.Forms.Label lbl_player;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
    }
}

