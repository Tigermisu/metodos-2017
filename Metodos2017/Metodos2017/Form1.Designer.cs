namespace Metodos2017 {
    partial class Ventana {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelGradoCurva = new System.Windows.Forms.Label();
            this.textBoxGradoCurva = new System.Windows.Forms.TextBox();
            this.labelLogarithmicResult = new System.Windows.Forms.Label();
            this.labelLogarithmicHeader = new System.Windows.Forms.Label();
            this.labelPolinomialResult = new System.Windows.Forms.Label();
            this.labelPolinomialHeader = new System.Windows.Forms.Label();
            this.buttonAjustar = new System.Windows.Forms.Button();
            this.textBoxValoresAjuste = new System.Windows.Forms.TextBox();
            this.labelInstruccionesAjuste = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.labelExponencialHeader = new System.Windows.Forms.Label();
            this.labelExponencialResultado = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1397, 919);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelExponencialResultado);
            this.tabPage1.Controls.Add(this.labelExponencialHeader);
            this.tabPage1.Controls.Add(this.chart);
            this.tabPage1.Controls.Add(this.labelGradoCurva);
            this.tabPage1.Controls.Add(this.textBoxGradoCurva);
            this.tabPage1.Controls.Add(this.labelLogarithmicResult);
            this.tabPage1.Controls.Add(this.labelLogarithmicHeader);
            this.tabPage1.Controls.Add(this.labelPolinomialResult);
            this.tabPage1.Controls.Add(this.labelPolinomialHeader);
            this.tabPage1.Controls.Add(this.buttonAjustar);
            this.tabPage1.Controls.Add(this.textBoxValoresAjuste);
            this.tabPage1.Controls.Add(this.labelInstruccionesAjuste);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1381, 872);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ajuste de Curvas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(423, 40);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 3, 3, 80);
            this.chart.Name = "chart";
            this.chart.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(901, 660);
            this.chart.TabIndex = 9;
            this.chart.Text = "chart1";
            // 
            // labelGradoCurva
            // 
            this.labelGradoCurva.AutoSize = true;
            this.labelGradoCurva.Location = new System.Drawing.Point(30, 383);
            this.labelGradoCurva.Name = "labelGradoCurva";
            this.labelGradoCurva.Size = new System.Drawing.Size(176, 25);
            this.labelGradoCurva.TabIndex = 8;
            this.labelGradoCurva.Text = "Grado Polinomial";
            // 
            // textBoxGradoCurva
            // 
            this.textBoxGradoCurva.Location = new System.Drawing.Point(35, 411);
            this.textBoxGradoCurva.Name = "textBoxGradoCurva";
            this.textBoxGradoCurva.Size = new System.Drawing.Size(171, 31);
            this.textBoxGradoCurva.TabIndex = 7;
            // 
            // labelLogarithmicResult
            // 
            this.labelLogarithmicResult.AutoSize = true;
            this.labelLogarithmicResult.Location = new System.Drawing.Point(32, 676);
            this.labelLogarithmicResult.Name = "labelLogarithmicResult";
            this.labelLogarithmicResult.Size = new System.Drawing.Size(70, 25);
            this.labelLogarithmicResult.TabIndex = 6;
            this.labelLogarithmicResult.Text = "label1";
            // 
            // labelLogarithmicHeader
            // 
            this.labelLogarithmicHeader.AutoSize = true;
            this.labelLogarithmicHeader.Location = new System.Drawing.Point(30, 651);
            this.labelLogarithmicHeader.Name = "labelLogarithmicHeader";
            this.labelLogarithmicHeader.Size = new System.Drawing.Size(224, 25);
            this.labelLogarithmicHeader.TabIndex = 5;
            this.labelLogarithmicHeader.Text = "Ecuación Logarítmica:";
            // 
            // labelPolinomialResult
            // 
            this.labelPolinomialResult.AutoSize = true;
            this.labelPolinomialResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPolinomialResult.Location = new System.Drawing.Point(30, 504);
            this.labelPolinomialResult.Name = "labelPolinomialResult";
            this.labelPolinomialResult.Size = new System.Drawing.Size(100, 37);
            this.labelPolinomialResult.TabIndex = 4;
            this.labelPolinomialResult.Text = "label1";
            // 
            // labelPolinomialHeader
            // 
            this.labelPolinomialHeader.AutoSize = true;
            this.labelPolinomialHeader.Location = new System.Drawing.Point(30, 479);
            this.labelPolinomialHeader.Name = "labelPolinomialHeader";
            this.labelPolinomialHeader.Size = new System.Drawing.Size(212, 25);
            this.labelPolinomialHeader.TabIndex = 3;
            this.labelPolinomialHeader.Text = "Ecuación Polinomial:";
            // 
            // buttonAjustar
            // 
            this.buttonAjustar.Location = new System.Drawing.Point(218, 386);
            this.buttonAjustar.Name = "buttonAjustar";
            this.buttonAjustar.Size = new System.Drawing.Size(143, 56);
            this.buttonAjustar.TabIndex = 2;
            this.buttonAjustar.Text = "Ajustar";
            this.buttonAjustar.UseVisualStyleBackColor = true;
            this.buttonAjustar.Click += new System.EventHandler(this.buttonAjustar_Click);
            // 
            // textBoxValoresAjuste
            // 
            this.textBoxValoresAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxValoresAjuste.Location = new System.Drawing.Point(35, 55);
            this.textBoxValoresAjuste.Multiline = true;
            this.textBoxValoresAjuste.Name = "textBoxValoresAjuste";
            this.textBoxValoresAjuste.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxValoresAjuste.Size = new System.Drawing.Size(326, 310);
            this.textBoxValoresAjuste.TabIndex = 1;
            this.textBoxValoresAjuste.TextChanged += new System.EventHandler(this.p);
            this.textBoxValoresAjuste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValoresAjuste_KeyPress);
            this.textBoxValoresAjuste.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxValoresAjuste_KeyUp);
            // 
            // labelInstruccionesAjuste
            // 
            this.labelInstruccionesAjuste.AutoSize = true;
            this.labelInstruccionesAjuste.Location = new System.Drawing.Point(30, 13);
            this.labelInstruccionesAjuste.Name = "labelInstruccionesAjuste";
            this.labelInstruccionesAjuste.Size = new System.Drawing.Size(458, 25);
            this.labelInstruccionesAjuste.TabIndex = 0;
            this.labelInstruccionesAjuste.Text = "Introduce los datos del crecimiento bacteriano:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1381, 872);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dream Team";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelExponencialHeader
            // 
            this.labelExponencialHeader.AutoSize = true;
            this.labelExponencialHeader.Location = new System.Drawing.Point(37, 755);
            this.labelExponencialHeader.Name = "labelExponencialHeader";
            this.labelExponencialHeader.Size = new System.Drawing.Size(225, 25);
            this.labelExponencialHeader.TabIndex = 10;
            this.labelExponencialHeader.Text = "Ecuación Exponencial";
            // 
            // labelExponencialResultado
            // 
            this.labelExponencialResultado.AutoSize = true;
            this.labelExponencialResultado.Location = new System.Drawing.Point(42, 784);
            this.labelExponencialResultado.Name = "labelExponencialResultado";
            this.labelExponencialResultado.Size = new System.Drawing.Size(70, 25);
            this.labelExponencialResultado.TabIndex = 11;
            this.labelExponencialResultado.Text = "label1";
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 938);
            this.Controls.Add(this.tabControl1);
            this.Name = "Ventana";
            this.Text = "Metodos Dream Team";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelLogarithmicResult;
        private System.Windows.Forms.Label labelLogarithmicHeader;
        private System.Windows.Forms.Label labelPolinomialResult;
        private System.Windows.Forms.Label labelPolinomialHeader;
        private System.Windows.Forms.Button buttonAjustar;
        private System.Windows.Forms.TextBox textBoxValoresAjuste;
        private System.Windows.Forms.Label labelInstruccionesAjuste;
        private System.Windows.Forms.Label labelGradoCurva;
        private System.Windows.Forms.TextBox textBoxGradoCurva;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label labelExponencialResultado;
        private System.Windows.Forms.Label labelExponencialHeader;
    }
}

