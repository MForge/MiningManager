namespace MiningManager
{
    partial class MinerFrm
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
            this.tbMinerPath = new System.Windows.Forms.TextBox();
            this.lblMinerPath = new System.Windows.Forms.Label();
            this.filedialogBtn = new System.Windows.Forms.Button();
            this.tbMinerName = new System.Windows.Forms.TextBox();
            this.lblMinerName = new System.Windows.Forms.Label();
            this.saveAndClosebtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMinerPath
            // 
            this.tbMinerPath.Enabled = false;
            this.tbMinerPath.Location = new System.Drawing.Point(116, 6);
            this.tbMinerPath.Name = "tbMinerPath";
            this.tbMinerPath.ReadOnly = true;
            this.tbMinerPath.Size = new System.Drawing.Size(366, 20);
            this.tbMinerPath.TabIndex = 4;
            // 
            // lblMinerPath
            // 
            this.lblMinerPath.AutoSize = true;
            this.lblMinerPath.BackColor = System.Drawing.Color.Transparent;
            this.lblMinerPath.ForeColor = System.Drawing.Color.Black;
            this.lblMinerPath.Location = new System.Drawing.Point(12, 9);
            this.lblMinerPath.Name = "lblMinerPath";
            this.lblMinerPath.Size = new System.Drawing.Size(93, 13);
            this.lblMinerPath.TabIndex = 3;
            this.lblMinerPath.Text = "Path to the miner :";
            // 
            // filedialogBtn
            // 
            this.filedialogBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.filedialogBtn.Location = new System.Drawing.Point(488, 3);
            this.filedialogBtn.Name = "filedialogBtn";
            this.filedialogBtn.Size = new System.Drawing.Size(24, 24);
            this.filedialogBtn.TabIndex = 5;
            this.filedialogBtn.Text = "...";
            this.filedialogBtn.UseVisualStyleBackColor = true;
            this.filedialogBtn.Click += new System.EventHandler(this.filedialofBtn_Click);
            // 
            // tbMinerName
            // 
            this.tbMinerName.Location = new System.Drawing.Point(116, 32);
            this.tbMinerName.Name = "tbMinerName";
            this.tbMinerName.Size = new System.Drawing.Size(396, 20);
            this.tbMinerName.TabIndex = 7;
            // 
            // lblMinerName
            // 
            this.lblMinerName.AutoSize = true;
            this.lblMinerName.BackColor = System.Drawing.Color.Transparent;
            this.lblMinerName.ForeColor = System.Drawing.Color.Black;
            this.lblMinerName.Location = new System.Drawing.Point(12, 35);
            this.lblMinerName.Name = "lblMinerName";
            this.lblMinerName.Size = new System.Drawing.Size(68, 13);
            this.lblMinerName.TabIndex = 6;
            this.lblMinerName.Text = "Miner name :";
            // 
            // saveAndClosebtn
            // 
            this.saveAndClosebtn.Location = new System.Drawing.Point(337, 58);
            this.saveAndClosebtn.Name = "saveAndClosebtn";
            this.saveAndClosebtn.Size = new System.Drawing.Size(94, 23);
            this.saveAndClosebtn.TabIndex = 8;
            this.saveAndClosebtn.Text = "Save && Close";
            this.saveAndClosebtn.UseVisualStyleBackColor = true;
            this.saveAndClosebtn.Click += new System.EventHandler(this.saveAndclosebtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(437, 58);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MinerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(517, 91);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.saveAndClosebtn);
            this.Controls.Add(this.tbMinerName);
            this.Controls.Add(this.lblMinerName);
            this.Controls.Add(this.filedialogBtn);
            this.Controls.Add(this.tbMinerPath);
            this.Controls.Add(this.lblMinerPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MinerFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Miner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filedialogBtn;
        private System.Windows.Forms.TextBox tbMinerPath;
        private System.Windows.Forms.Label lblMinerPath;
        private System.Windows.Forms.TextBox tbMinerName;
        private System.Windows.Forms.Label lblMinerName;
        private System.Windows.Forms.Button saveAndClosebtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}