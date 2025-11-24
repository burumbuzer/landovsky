namespace hw1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.lblMediana = new System.Windows.Forms.Label();
            this.lblDisp = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.tbMu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSigma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Тесты в интервале";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(577, 443);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(583, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество повторений";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(586, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "10000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(586, 124);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(583, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество столбцов";
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMean.Location = new System.Drawing.Point(586, 269);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(87, 23);
            this.lblMean.TabIndex = 6;
            this.lblMean.Text = "Среднее: ";
            // 
            // lblMediana
            // 
            this.lblMediana.AutoSize = true;
            this.lblMediana.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMediana.Location = new System.Drawing.Point(586, 292);
            this.lblMediana.Name = "lblMediana";
            this.lblMediana.Size = new System.Drawing.Size(93, 23);
            this.lblMediana.TabIndex = 7;
            this.lblMediana.Text = "Медиана: ";
            // 
            // lblDisp
            // 
            this.lblDisp.AutoSize = true;
            this.lblDisp.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDisp.Location = new System.Drawing.Point(586, 338);
            this.lblDisp.Name = "lblDisp";
            this.lblDisp.Size = new System.Drawing.Size(147, 23);
            this.lblDisp.TabIndex = 8;
            this.lblDisp.Text = "Выб. Дисперсия: ";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMode.Location = new System.Drawing.Point(586, 315);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(64, 23);
            this.lblMode.TabIndex = 9;
            this.lblMode.Text = "Мода: ";
            // 
            // tbMu
            // 
            this.tbMu.Location = new System.Drawing.Point(586, 188);
            this.tbMu.Name = "tbMu";
            this.tbMu.Size = new System.Drawing.Size(100, 20);
            this.tbMu.TabIndex = 11;
            this.tbMu.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(583, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "μ";
            // 
            // tbSigma
            // 
            this.tbSigma.Location = new System.Drawing.Point(586, 246);
            this.tbSigma.Name = "tbSigma";
            this.tbSigma.Size = new System.Drawing.Size(100, 20);
            this.tbSigma.TabIndex = 13;
            this.tbSigma.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(583, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "σ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.tbSigma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblDisp);
            this.Controls.Add(this.lblMediana);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Разделение на интервалы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label lblMediana;
        private System.Windows.Forms.Label lblDisp;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TextBox tbMu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSigma;
        private System.Windows.Forms.Label label4;
    }
}

