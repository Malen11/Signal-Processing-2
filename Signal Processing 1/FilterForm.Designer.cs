namespace Signal_Processing_1
{
    partial class FilterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lPFilterNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lPFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lPFilterButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hPFilterNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hPFilterButton = new System.Windows.Forms.Button();
            this.hPFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bPFilterNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.bPFilterButton = new System.Windows.Forms.Button();
            this.bPFilterNnumericUpDown0 = new System.Windows.Forms.NumericUpDown();
            this.bPFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.notchNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.notchButton = new System.Windows.Forms.Button();
            this.notchNumericUpDown0 = new System.Windows.Forms.NumericUpDown();
            this.notchComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lPFilterNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPFilterNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bPFilterNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPFilterNnumericUpDown0)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notchNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notchNumericUpDown0)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lPFilterNumericUpDown);
            this.groupBox1.Controls.Add(this.lPFilterComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lPFilterButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 124);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "НЧ фильтр";
            // 
            // lPFilterNumericUpDown
            // 
            this.lPFilterNumericUpDown.Location = new System.Drawing.Point(53, 27);
            this.lPFilterNumericUpDown.Name = "lPFilterNumericUpDown";
            this.lPFilterNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.lPFilterNumericUpDown.TabIndex = 8;
            // 
            // lPFilterComboBox
            // 
            this.lPFilterComboBox.FormattingEnabled = true;
            this.lPFilterComboBox.Items.AddRange(new object[] {
            "Гц",
            "Отсчётов"});
            this.lPFilterComboBox.Location = new System.Drawing.Point(109, 26);
            this.lPFilterComboBox.Name = "lPFilterComboBox";
            this.lPFilterComboBox.Size = new System.Drawing.Size(80, 21);
            this.lPFilterComboBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Порог:";
            // 
            // lPFilterButton
            // 
            this.lPFilterButton.Location = new System.Drawing.Point(53, 79);
            this.lPFilterButton.Name = "lPFilterButton";
            this.lPFilterButton.Size = new System.Drawing.Size(88, 37);
            this.lPFilterButton.TabIndex = 6;
            this.lPFilterButton.Text = "Показать";
            this.lPFilterButton.UseVisualStyleBackColor = true;
            this.lPFilterButton.Click += new System.EventHandler(this.lPFilterButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hPFilterNumericUpDown);
            this.groupBox2.Controls.Add(this.hPFilterButton);
            this.groupBox2.Controls.Add(this.hPFilterComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 124);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ВЧ фильтр";
            // 
            // hPFilterNumericUpDown
            // 
            this.hPFilterNumericUpDown.Location = new System.Drawing.Point(53, 27);
            this.hPFilterNumericUpDown.Name = "hPFilterNumericUpDown";
            this.hPFilterNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.hPFilterNumericUpDown.TabIndex = 11;
            // 
            // hPFilterButton
            // 
            this.hPFilterButton.Location = new System.Drawing.Point(53, 79);
            this.hPFilterButton.Name = "hPFilterButton";
            this.hPFilterButton.Size = new System.Drawing.Size(88, 37);
            this.hPFilterButton.TabIndex = 6;
            this.hPFilterButton.Text = "Показать";
            this.hPFilterButton.UseVisualStyleBackColor = true;
            this.hPFilterButton.Click += new System.EventHandler(this.hPFilterButton_Click);
            // 
            // hPFilterComboBox
            // 
            this.hPFilterComboBox.FormattingEnabled = true;
            this.hPFilterComboBox.Items.AddRange(new object[] {
            "Гц",
            "Отсчётов"});
            this.hPFilterComboBox.Location = new System.Drawing.Point(109, 26);
            this.hPFilterComboBox.Name = "hPFilterComboBox";
            this.hPFilterComboBox.Size = new System.Drawing.Size(80, 21);
            this.hPFilterComboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Порог:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bPFilterNumericUpDown1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.bPFilterButton);
            this.groupBox3.Controls.Add(this.bPFilterNnumericUpDown0);
            this.groupBox3.Controls.Add(this.bPFilterComboBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(228, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 124);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Полосовой фильтр";
            // 
            // bPFilterNumericUpDown1
            // 
            this.bPFilterNumericUpDown1.Location = new System.Drawing.Point(62, 53);
            this.bPFilterNumericUpDown1.Name = "bPFilterNumericUpDown1";
            this.bPFilterNumericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.bPFilterNumericUpDown1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Порог 2:";
            // 
            // bPFilterButton
            // 
            this.bPFilterButton.Location = new System.Drawing.Point(62, 79);
            this.bPFilterButton.Name = "bPFilterButton";
            this.bPFilterButton.Size = new System.Drawing.Size(88, 37);
            this.bPFilterButton.TabIndex = 6;
            this.bPFilterButton.Text = "Показать";
            this.bPFilterButton.UseVisualStyleBackColor = true;
            this.bPFilterButton.Click += new System.EventHandler(this.bPFilterButton_Click);
            // 
            // bPFilterNnumericUpDown0
            // 
            this.bPFilterNnumericUpDown0.Location = new System.Drawing.Point(62, 27);
            this.bPFilterNnumericUpDown0.Name = "bPFilterNnumericUpDown0";
            this.bPFilterNnumericUpDown0.Size = new System.Drawing.Size(50, 20);
            this.bPFilterNnumericUpDown0.TabIndex = 11;
            // 
            // bPFilterComboBox
            // 
            this.bPFilterComboBox.FormattingEnabled = true;
            this.bPFilterComboBox.Items.AddRange(new object[] {
            "Гц",
            "Отсчётов"});
            this.bPFilterComboBox.Location = new System.Drawing.Point(118, 38);
            this.bPFilterComboBox.Name = "bPFilterComboBox";
            this.bPFilterComboBox.Size = new System.Drawing.Size(80, 21);
            this.bPFilterComboBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Порог 1:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.notchNumericUpDown1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.notchButton);
            this.groupBox4.Controls.Add(this.notchNumericUpDown0);
            this.groupBox4.Controls.Add(this.notchComboBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(228, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 124);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Режекторный фильтр";
            // 
            // notchNumericUpDown1
            // 
            this.notchNumericUpDown1.Location = new System.Drawing.Point(62, 53);
            this.notchNumericUpDown1.Name = "notchNumericUpDown1";
            this.notchNumericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.notchNumericUpDown1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Порог 2:";
            // 
            // notchButton
            // 
            this.notchButton.Location = new System.Drawing.Point(62, 79);
            this.notchButton.Name = "notchButton";
            this.notchButton.Size = new System.Drawing.Size(88, 37);
            this.notchButton.TabIndex = 6;
            this.notchButton.Text = "Показать";
            this.notchButton.UseVisualStyleBackColor = true;
            this.notchButton.Click += new System.EventHandler(this.notchFilterButton_Click);
            // 
            // notchNumericUpDown0
            // 
            this.notchNumericUpDown0.Location = new System.Drawing.Point(62, 27);
            this.notchNumericUpDown0.Name = "notchNumericUpDown0";
            this.notchNumericUpDown0.Size = new System.Drawing.Size(50, 20);
            this.notchNumericUpDown0.TabIndex = 11;
            // 
            // notchComboBox
            // 
            this.notchComboBox.FormattingEnabled = true;
            this.notchComboBox.Items.AddRange(new object[] {
            "Гц",
            "Отсчётов"});
            this.notchComboBox.Location = new System.Drawing.Point(118, 38);
            this.notchComboBox.Name = "notchComboBox";
            this.notchComboBox.Size = new System.Drawing.Size(80, 21);
            this.notchComboBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Порог 1:";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 282);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FilterForm";
            this.Text = "Фильтры";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lPFilterNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPFilterNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bPFilterNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPFilterNnumericUpDown0)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notchNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notchNumericUpDown0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button lPFilterButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button hPFilterButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bPFilterButton;
        private System.Windows.Forms.NumericUpDown lPFilterNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lPFilterComboBox;
        private System.Windows.Forms.NumericUpDown hPFilterNumericUpDown;
        private System.Windows.Forms.ComboBox hPFilterComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown bPFilterNumericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bPFilterNnumericUpDown0;
        private System.Windows.Forms.ComboBox bPFilterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown notchNumericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button notchButton;
        private System.Windows.Forms.NumericUpDown notchNumericUpDown0;
        private System.Windows.Forms.ComboBox notchComboBox;
        private System.Windows.Forms.Label label6;
    }
}