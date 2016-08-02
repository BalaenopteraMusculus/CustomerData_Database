namespace CustomerApplication
{
    partial class Customer_Application
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.NameText = new System.Windows.Forms.TextBox();
            this.NumberText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.oNameText = new System.Windows.Forms.TextBox();
            this.oNumberText = new System.Windows.Forms.TextBox();
            this.oEmailText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(933, 476);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerID";
            this.Column1.HeaderText = "CustomerID";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CustomerName";
            this.Column2.HeaderText = "CustomerName";
            this.Column2.Name = "Column2";
            this.Column2.Width = 290;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PhoneNumber";
            this.Column3.HeaderText = "PhoneNumber";
            this.Column3.Name = "Column3";
            this.Column3.Width = 165;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Email";
            this.Column4.HeaderText = "Email";
            this.Column4.Name = "Column4";
            this.Column4.Width = 285;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(440, 598);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(208, 40);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(713, 598);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(208, 40);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(226, 598);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(208, 40);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 598);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(208, 40);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(177, 511);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(295, 20);
            this.NameText.TabIndex = 7;
            // 
            // NumberText
            // 
            this.NumberText.Location = new System.Drawing.Point(478, 511);
            this.NumberText.Name = "NumberText";
            this.NumberText.Size = new System.Drawing.Size(180, 20);
            this.NumberText.TabIndex = 8;
            // 
            // EmailText
            // 
            this.EmailText.Location = new System.Drawing.Point(667, 511);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(254, 20);
            this.EmailText.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "NewCustomerName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "NewPhoneNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "NewEmail";
            // 
            // IDText
            // 
            this.IDText.Location = new System.Drawing.Point(12, 536);
            this.IDText.Name = "IDText";
            this.IDText.Size = new System.Drawing.Size(162, 20);
            this.IDText.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "CustomerID";
            // 
            // oNameText
            // 
            this.oNameText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.oNameText.Location = new System.Drawing.Point(180, 559);
            this.oNameText.Name = "oNameText";
            this.oNameText.Size = new System.Drawing.Size(292, 20);
            this.oNameText.TabIndex = 16;
            // 
            // oNumberText
            // 
            this.oNumberText.Location = new System.Drawing.Point(478, 559);
            this.oNumberText.Name = "oNumberText";
            this.oNumberText.Size = new System.Drawing.Size(180, 20);
            this.oNumberText.TabIndex = 17;
            // 
            // oEmailText
            // 
            this.oEmailText.Location = new System.Drawing.Point(667, 559);
            this.oEmailText.Name = "oEmailText";
            this.oEmailText.Size = new System.Drawing.Size(254, 20);
            this.oEmailText.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "OldCustomerName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "OldPhoneNumber";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(664, 543);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "OldEmail";
            // 
            // Customer_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 650);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.oEmailText);
            this.Controls.Add(this.oNumberText);
            this.Controls.Add(this.oNameText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EmailText);
            this.Controls.Add(this.NumberText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Customer_Application";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Customer Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox NumberText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oNameText;
        private System.Windows.Forms.TextBox oNumberText;
        private System.Windows.Forms.TextBox oEmailText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

