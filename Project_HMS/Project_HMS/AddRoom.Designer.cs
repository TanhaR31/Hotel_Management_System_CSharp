
namespace Project_HMS
{
    partial class AddRoom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRCost = new System.Windows.Forms.TextBox();
            this.lblRCost = new System.Windows.Forms.Label();
            this.txtIsBooked = new System.Windows.Forms.TextBox();
            this.lblBooked = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtRId = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblRId = new System.Windows.Forms.Label();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.RId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBooked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtRCost);
            this.panel1.Controls.Add(this.lblRCost);
            this.panel1.Controls.Add(this.txtIsBooked);
            this.panel1.Controls.Add(this.lblBooked);
            this.panel1.Controls.Add(this.txtCategory);
            this.panel1.Controls.Add(this.txtRId);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.lblRId);
            this.panel1.Controls.Add(this.dgvRoom);
            this.panel1.Location = new System.Drawing.Point(39, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 426);
            this.panel1.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(247, 324);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(92, 75);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(129, 324);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 75);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(25, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 75);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRCost
            // 
            this.txtRCost.Location = new System.Drawing.Point(191, 218);
            this.txtRCost.Name = "txtRCost";
            this.txtRCost.Size = new System.Drawing.Size(100, 22);
            this.txtRCost.TabIndex = 19;
            // 
            // lblRCost
            // 
            this.lblRCost.AutoSize = true;
            this.lblRCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRCost.Location = new System.Drawing.Point(42, 223);
            this.lblRCost.Name = "lblRCost";
            this.lblRCost.Size = new System.Drawing.Size(86, 17);
            this.lblRCost.TabIndex = 18;
            this.lblRCost.Text = "Room Cost";
            // 
            // txtIsBooked
            // 
            this.txtIsBooked.Location = new System.Drawing.Point(191, 160);
            this.txtIsBooked.Name = "txtIsBooked";
            this.txtIsBooked.Size = new System.Drawing.Size(100, 22);
            this.txtIsBooked.TabIndex = 17;
            // 
            // lblBooked
            // 
            this.lblBooked.AutoSize = true;
            this.lblBooked.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooked.Location = new System.Drawing.Point(42, 165);
            this.lblBooked.Name = "lblBooked";
            this.lblBooked.Size = new System.Drawing.Size(117, 17);
            this.lblBooked.TabIndex = 16;
            this.lblBooked.Text = "Booking Status";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(191, 105);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 22);
            this.txtCategory.TabIndex = 15;
            // 
            // txtRId
            // 
            this.txtRId.Location = new System.Drawing.Point(191, 56);
            this.txtRId.Name = "txtRId";
            this.txtRId.Size = new System.Drawing.Size(100, 22);
            this.txtRId.TabIndex = 14;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(42, 110);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 17);
            this.lblCategory.TabIndex = 13;
            this.lblCategory.Text = "Category";
            // 
            // lblRId
            // 
            this.lblRId.AutoSize = true;
            this.lblRId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRId.Location = new System.Drawing.Point(42, 56);
            this.lblRId.Name = "lblRId";
            this.lblRId.Size = new System.Drawing.Size(67, 17);
            this.lblRId.TabIndex = 12;
            this.lblRId.Text = "Room Id";
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RId,
            this.Category,
            this.IsBooked,
            this.RoomCost});
            this.dgvRoom.Location = new System.Drawing.Point(372, 56);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.RowHeadersWidth = 51;
            this.dgvRoom.RowTemplate.Height = 24;
            this.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoom.Size = new System.Drawing.Size(564, 343);
            this.dgvRoom.TabIndex = 3;
            this.dgvRoom.DoubleClick += new System.EventHandler(this.dgvRoom_DoubleClick);
            // 
            // RId
            // 
            this.RId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RId.DataPropertyName = "RId";
            this.RId.HeaderText = "Room ID";
            this.RId.MinimumWidth = 6;
            this.RId.Name = "RId";
            this.RId.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // IsBooked
            // 
            this.IsBooked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsBooked.DataPropertyName = "IsBooked";
            this.IsBooked.HeaderText = "Booked";
            this.IsBooked.MinimumWidth = 6;
            this.IsBooked.Name = "IsBooked";
            this.IsBooked.ReadOnly = true;
            // 
            // RoomCost
            // 
            this.RoomCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoomCost.DataPropertyName = "RoomCost";
            this.RoomCost.HeaderText = "Cost (Per Day)";
            this.RoomCost.MinimumWidth = 6;
            this.RoomCost.Name = "RoomCost";
            this.RoomCost.ReadOnly = true;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(837, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 37);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1054, 508);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddRoom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddRoom_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.TextBox txtRCost;
        private System.Windows.Forms.Label lblRCost;
        private System.Windows.Forms.TextBox txtIsBooked;
        private System.Windows.Forms.Label lblBooked;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtRId;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblRId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsBooked;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomCost;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}