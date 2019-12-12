namespace Signal_Processing_1
{
    partial class showSpectrumForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.maxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minValueLabel = new System.Windows.Forms.Label();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.changeIntervalButton = new System.Windows.Forms.Button();
            this.execTimeLabel = new System.Windows.Forms.Label();
            this.execTimeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dataChart
            // 
            this.dataChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.CursorX.Interval = 0.01D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "DataChartArea";
            this.dataChart.ChartAreas.Add(chartArea2);
            this.dataChart.Location = new System.Drawing.Point(12, 63);
            this.dataChart.Name = "dataChart";
            series2.ChartArea = "DataChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "DataChartSeries";
            this.dataChart.Series.Add(series2);
            this.dataChart.Size = new System.Drawing.Size(760, 486);
            this.dataChart.TabIndex = 44;
            this.dataChart.Text = "chart1";
            title2.Name = "DataChartTitle";
            title2.Text = "Данные";
            this.dataChart.Titles.Add(title2);
            // 
            // maxNumericUpDown
            // 
            this.maxNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxNumericUpDown.Location = new System.Drawing.Point(597, 37);
            this.maxNumericUpDown.Name = "maxNumericUpDown";
            this.maxNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.maxNumericUpDown.TabIndex = 51;
            this.maxNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // minNumericUpDown
            // 
            this.minNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minNumericUpDown.Location = new System.Drawing.Point(597, 12);
            this.minNumericUpDown.Name = "minNumericUpDown";
            this.minNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.minNumericUpDown.TabIndex = 50;
            // 
            // minValueLabel
            // 
            this.minValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Location = new System.Drawing.Point(457, 14);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(128, 13);
            this.minValueLabel.TabIndex = 48;
            this.minValueLabel.Text = "Минимальное значение";
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Location = new System.Drawing.Point(457, 39);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(134, 13);
            this.maxValueLabel.TabIndex = 49;
            this.maxValueLabel.Text = "Максимальное значение";
            // 
            // changeIntervalButton
            // 
            this.changeIntervalButton.Location = new System.Drawing.Point(652, 12);
            this.changeIntervalButton.Name = "changeIntervalButton";
            this.changeIntervalButton.Size = new System.Drawing.Size(120, 40);
            this.changeIntervalButton.TabIndex = 52;
            this.changeIntervalButton.Text = "Перерисовать график";
            this.changeIntervalButton.UseVisualStyleBackColor = true;
            this.changeIntervalButton.Click += new System.EventHandler(this.changeIntervalButton_Click);
            // 
            // execTimeLabel
            // 
            this.execTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.execTimeLabel.AutoSize = true;
            this.execTimeLabel.Location = new System.Drawing.Point(12, 9);
            this.execTimeLabel.Name = "execTimeLabel";
            this.execTimeLabel.Size = new System.Drawing.Size(109, 13);
            this.execTimeLabel.TabIndex = 53;
            this.execTimeLabel.Text = "Время расчёта (мс):";
            // 
            // execTimeTextBox
            // 
            this.execTimeTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.execTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.execTimeTextBox.Location = new System.Drawing.Point(119, 9);
            this.execTimeTextBox.Name = "execTimeTextBox";
            this.execTimeTextBox.ReadOnly = true;
            this.execTimeTextBox.Size = new System.Drawing.Size(100, 13);
            this.execTimeTextBox.TabIndex = 54;
            // 
            // showSpectrumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.execTimeTextBox);
            this.Controls.Add(this.execTimeLabel);
            this.Controls.Add(this.changeIntervalButton);
            this.Controls.Add(this.maxNumericUpDown);
            this.Controls.Add(this.minNumericUpDown);
            this.Controls.Add(this.minValueLabel);
            this.Controls.Add(this.maxValueLabel);
            this.Controls.Add(this.dataChart);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "showSpectrumForm";
            this.Text = "showSpectrumForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.NumericUpDown maxNumericUpDown;
        private System.Windows.Forms.NumericUpDown minNumericUpDown;
        private System.Windows.Forms.Label minValueLabel;
        private System.Windows.Forms.Label maxValueLabel;
        private System.Windows.Forms.Button changeIntervalButton;
        private System.Windows.Forms.Label execTimeLabel;
        private System.Windows.Forms.TextBox execTimeTextBox;
    }
}