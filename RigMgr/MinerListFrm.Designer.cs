namespace MiningManager
{
    partial class MinerListFrm
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.dgvMinsers = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.addClient = new System.Windows.Forms.DataGridViewImageColumn();
            this.editclient = new System.Windows.Forms.DataGridViewImageColumn();
            this.dellclient = new System.Windows.Forms.DataGridViewImageColumn();
            this.descriptionClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upClient = new System.Windows.Forms.DataGridViewImageColumn();
            this.downClient = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinsers)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(434, 164);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // dgvMinsers
            // 
            this.dgvMinsers.AllowUserToAddRows = false;
            this.dgvMinsers.AllowUserToDeleteRows = false;
            this.dgvMinsers.AllowUserToResizeColumns = false;
            this.dgvMinsers.AllowUserToResizeRows = false;
            this.dgvMinsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMinsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMinsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMinsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addClient,
            this.editclient,
            this.dellclient,
            this.descriptionClient,
            this.pathClient,
            this.upClient,
            this.downClient});
            this.dgvMinsers.Location = new System.Drawing.Point(12, 12);
            this.dgvMinsers.MultiSelect = false;
            this.dgvMinsers.Name = "dgvMinsers";
            this.dgvMinsers.RowHeadersVisible = false;
            this.dgvMinsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMinsers.Size = new System.Drawing.Size(497, 146);
            this.dgvMinsers.TabIndex = 8;
            this.dgvMinsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewImageColumn1.HeaderText = "add";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 22;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewImageColumn2.HeaderText = "del";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "addClient";
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            // 
            // addClient
            // 
            this.addClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.addClient.HeaderText = "";
            this.addClient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.addClient.Name = "addClient";
            this.addClient.ReadOnly = true;
            this.addClient.Width = 5;
            // 
            // editclient
            // 
            this.editclient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.editclient.HeaderText = "";
            this.editclient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.editclient.Name = "editclient";
            this.editclient.ReadOnly = true;
            this.editclient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editclient.Width = 5;
            // 
            // dellclient
            // 
            this.dellclient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dellclient.HeaderText = "";
            this.dellclient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dellclient.Name = "dellclient";
            this.dellclient.ReadOnly = true;
            this.dellclient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dellclient.Width = 5;
            // 
            // descriptionClient
            // 
            this.descriptionClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descriptionClient.HeaderText = "Name";
            this.descriptionClient.Name = "descriptionClient";
            this.descriptionClient.ReadOnly = true;
            this.descriptionClient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.descriptionClient.Width = 41;
            // 
            // pathClient
            // 
            this.pathClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathClient.HeaderText = "Path";
            this.pathClient.Name = "pathClient";
            this.pathClient.ReadOnly = true;
            this.pathClient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // upClient
            // 
            this.upClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.upClient.HeaderText = "";
            this.upClient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.upClient.Name = "upClient";
            this.upClient.ReadOnly = true;
            this.upClient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.upClient.Width = 5;
            // 
            // downClient
            // 
            this.downClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.downClient.HeaderText = "";
            this.downClient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.downClient.Name = "downClient";
            this.downClient.ReadOnly = true;
            this.downClient.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.downClient.Width = 5;
            // 
            // MinerListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(522, 197);
            this.Controls.Add(this.dgvMinsers);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MinerListFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clients links";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridView dgvMinsers;
        private System.Windows.Forms.DataGridViewImageColumn addClient;
        private System.Windows.Forms.DataGridViewImageColumn editclient;
        private System.Windows.Forms.DataGridViewImageColumn dellclient;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathClient;
        private System.Windows.Forms.DataGridViewImageColumn upClient;
        private System.Windows.Forms.DataGridViewImageColumn downClient;
    }
}