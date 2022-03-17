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
            this.SuspendLayout();
            // 
            // btn_topleft
            // 
            this.btn_topleft.Location = new System.Drawing.Point(12, 12);
            this.btn_topleft.Name = "btn_topleft";
            this.btn_topleft.Size = new System.Drawing.Size(75, 75);
            this.btn_topleft.TabIndex = 0;
            this.btn_topleft.UseVisualStyleBackColor = true;
            // 
            // btn_topmid
            // 
            this.btn_topmid.Location = new System.Drawing.Point(93, 12);
            this.btn_topmid.Name = "btn_topmid";
            this.btn_topmid.Size = new System.Drawing.Size(75, 75);
            this.btn_topmid.TabIndex = 1;
            this.btn_topmid.UseVisualStyleBackColor = true;
            // 
            // btn_topright
            // 
            this.btn_topright.Location = new System.Drawing.Point(174, 12);
            this.btn_topright.Name = "btn_topright";
            this.btn_topright.Size = new System.Drawing.Size(75, 75);
            this.btn_topright.TabIndex = 1;
            this.btn_topright.UseVisualStyleBackColor = true;
            // 
            // btn_midleft
            // 
            this.btn_midleft.Location = new System.Drawing.Point(12, 93);
            this.btn_midleft.Name = "btn_midleft";
            this.btn_midleft.Size = new System.Drawing.Size(75, 75);
            this.btn_midleft.TabIndex = 0;
            this.btn_midleft.UseVisualStyleBackColor = true;
            // 
            // btn_mid
            // 
            this.btn_mid.Location = new System.Drawing.Point(93, 93);
            this.btn_mid.Name = "btn_mid";
            this.btn_mid.Size = new System.Drawing.Size(75, 75);
            this.btn_mid.TabIndex = 1;
            this.btn_mid.UseVisualStyleBackColor = true;
            // 
            // btn_midright
            // 
            this.btn_midright.Location = new System.Drawing.Point(174, 93);
            this.btn_midright.Name = "btn_midright";
            this.btn_midright.Size = new System.Drawing.Size(75, 75);
            this.btn_midright.TabIndex = 1;
            this.btn_midright.UseVisualStyleBackColor = true;
            // 
            // btn_bottomleft
            // 
            this.btn_bottomleft.Location = new System.Drawing.Point(12, 174);
            this.btn_bottomleft.Name = "btn_bottomleft";
            this.btn_bottomleft.Size = new System.Drawing.Size(75, 75);
            this.btn_bottomleft.TabIndex = 0;
            this.btn_bottomleft.UseVisualStyleBackColor = true;
            // 
            // btn_bottommid
            // 
            this.btn_bottommid.Location = new System.Drawing.Point(93, 174);
            this.btn_bottommid.Name = "btn_bottommid";
            this.btn_bottommid.Size = new System.Drawing.Size(75, 75);
            this.btn_bottommid.TabIndex = 1;
            this.btn_bottommid.UseVisualStyleBackColor = true;
            // 
            // btn_bottomright
            // 
            this.btn_bottomright.Location = new System.Drawing.Point(174, 174);
            this.btn_bottomright.Name = "btn_bottomright";
            this.btn_bottomright.Size = new System.Drawing.Size(75, 75);
            this.btn_bottomright.TabIndex = 1;
            this.btn_bottomright.UseVisualStyleBackColor = true;
            // 
            // lbl_player
            // 
            this.lbl_player.AutoSize = true;
            this.lbl_player.Location = new System.Drawing.Point(255, 12);
            this.lbl_player.Name = "lbl_player";
            this.lbl_player.Size = new System.Drawing.Size(101, 13);
            this.lbl_player.TabIndex = 3;
            this.lbl_player.Text = "Spieler X ist am Zug";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 256);
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
            this.Name = "Form1";
            this.Text = "Tic Tac Toe | Sebastian Schindler";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

