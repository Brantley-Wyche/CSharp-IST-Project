namespace WycheP3
{
    partial class EmpTables
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
            this.emp_title = new System.Windows.Forms.Label();
            this.coop_title = new System.Windows.Forms.Label();
            this.dg_coopTable = new System.Windows.Forms.DataGridView();
            this.Employer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_empTable = new System.Windows.Forms.DataGridView();
            this.Employer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dg_coopTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_empTable)).BeginInit();
            this.SuspendLayout();
            // 
            // emp_title
            // 
            this.emp_title.AutoSize = true;
            this.emp_title.BackColor = System.Drawing.Color.WhiteSmoke;
            this.emp_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emp_title.Font = new System.Drawing.Font("qtquickcontrols", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_title.Location = new System.Drawing.Point(112, 291);
            this.emp_title.Name = "emp_title";
            this.emp_title.Size = new System.Drawing.Size(152, 24);
            this.emp_title.TabIndex = 14;
            this.emp_title.Text = "Employment title";
            // 
            // coop_title
            // 
            this.coop_title.AutoSize = true;
            this.coop_title.BackColor = System.Drawing.Color.WhiteSmoke;
            this.coop_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coop_title.Font = new System.Drawing.Font("qtquickcontrols", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coop_title.Location = new System.Drawing.Point(112, 16);
            this.coop_title.Name = "coop_title";
            this.coop_title.Size = new System.Drawing.Size(100, 24);
            this.coop_title.TabIndex = 13;
            this.coop_title.Text = "Co-op title";
            // 
            // dg_coopTable
            // 
            this.dg_coopTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dg_coopTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_coopTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employer,
            this.Degree,
            this.City,
            this.Term});
            this.dg_coopTable.Location = new System.Drawing.Point(112, 52);
            this.dg_coopTable.Name = "dg_coopTable";
            this.dg_coopTable.Size = new System.Drawing.Size(461, 223);
            this.dg_coopTable.TabIndex = 15;
            // 
            // Employer
            // 
            this.Employer.HeaderText = "Employer";
            this.Employer.Name = "Employer";
            // 
            // Degree
            // 
            this.Degree.HeaderText = "Degree";
            this.Degree.Name = "Degree";
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Term
            // 
            this.Term.HeaderText = "Term";
            this.Term.Name = "Term";
            // 
            // dg_empTable
            // 
            this.dg_empTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dg_empTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_empTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employer2,
            this.Degree2,
            this.City2,
            this.Title,
            this.StartDate});
            this.dg_empTable.Location = new System.Drawing.Point(112, 331);
            this.dg_empTable.Name = "dg_empTable";
            this.dg_empTable.Size = new System.Drawing.Size(552, 224);
            this.dg_empTable.TabIndex = 16;
            // 
            // Employer2
            // 
            this.Employer2.HeaderText = "Employer";
            this.Employer2.Name = "Employer2";
            // 
            // Degree2
            // 
            this.Degree2.HeaderText = "Degree";
            this.Degree2.Name = "Degree2";
            // 
            // City2
            // 
            this.City2.HeaderText = "City";
            this.City2.Name = "City2";
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(52, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 561);
            this.panel1.TabIndex = 17;
            // 
            // EmpTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.dg_empTable);
            this.Controls.Add(this.dg_coopTable);
            this.Controls.Add(this.emp_title);
            this.Controls.Add(this.coop_title);
            this.Controls.Add(this.panel1);
            this.Name = "EmpTables";
            this.Text = "Co-op and Employment Tables";
            this.Load += new System.EventHandler(this.EmpTables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_coopTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_empTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emp_title;
        private System.Windows.Forms.Label coop_title;
        private System.Windows.Forms.DataGridView dg_coopTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Term;
        private System.Windows.Forms.DataGridView dg_empTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree2;
        private System.Windows.Forms.DataGridViewTextBoxColumn City2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.Panel panel1;
    }
}