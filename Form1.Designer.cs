
namespace SCV
{
    partial class Form1
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
            this.SCVGrid = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.num1 = new System.Windows.Forms.NumericUpDown();
            this.num3 = new System.Windows.Forms.NumericUpDown();
            this.num2 = new System.Windows.Forms.NumericUpDown();
            this.shop2 = new System.Windows.Forms.NumericUpDown();
            this.shop3 = new System.Windows.Forms.NumericUpDown();
            this.shop1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.comm2 = new System.Windows.Forms.NumericUpDown();
            this.comm3 = new System.Windows.Forms.NumericUpDown();
            this.comm1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SCVGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comm3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // SCVGrid
            // 
            this.SCVGrid.AllowUserToAddRows = false;
            this.SCVGrid.AllowUserToDeleteRows = false;
            this.SCVGrid.AllowUserToOrderColumns = true;
            this.SCVGrid.AllowUserToResizeRows = false;
            this.SCVGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SCVGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SCVGrid.Location = new System.Drawing.Point(12, 338);
            this.SCVGrid.MultiSelect = false;
            this.SCVGrid.Name = "SCVGrid";
            this.SCVGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.SCVGrid.RowTemplate.Height = 24;
            this.SCVGrid.Size = new System.Drawing.Size(1800, 600);
            this.SCVGrid.TabIndex = 5;
            this.SCVGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SCVGrid_CellContentClick);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Green;
            this.button5.Location = new System.Drawing.Point(720, 190);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 40);
            this.button5.TabIndex = 6;
            this.button5.Text = "Compare";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(73, 250);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(318, 56);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // cmbCat
            // 
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(446, 280);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(183, 24);
            this.cmbCat.TabIndex = 8;
            this.cmbCat.SelectedIndexChanged += new System.EventHandler(this.cmbCat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pref";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Value";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(126, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 12;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(281, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 13;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(440, 38);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Preference 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Preference 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Preference 3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Pref Weight";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // num1
            // 
            this.num1.Location = new System.Drawing.Point(126, 71);
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(120, 22);
            this.num1.TabIndex = 19;
            this.num1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // num3
            // 
            this.num3.Location = new System.Drawing.Point(440, 71);
            this.num3.Name = "num3";
            this.num3.Size = new System.Drawing.Size(120, 22);
            this.num3.TabIndex = 20;
            this.num3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // num2
            // 
            this.num2.Location = new System.Drawing.Point(281, 71);
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(120, 22);
            this.num2.TabIndex = 21;
            this.num2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // shop2
            // 
            this.shop2.Location = new System.Drawing.Point(282, 108);
            this.shop2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.shop2.Name = "shop2";
            this.shop2.Size = new System.Drawing.Size(120, 22);
            this.shop2.TabIndex = 25;
            this.shop2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shop3
            // 
            this.shop3.Location = new System.Drawing.Point(441, 108);
            this.shop3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.shop3.Name = "shop3";
            this.shop3.Size = new System.Drawing.Size(120, 22);
            this.shop3.TabIndex = 24;
            this.shop3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shop1
            // 
            this.shop1.Location = new System.Drawing.Point(127, 108);
            this.shop1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.shop1.Name = "shop1";
            this.shop1.Size = new System.Drawing.Size(120, 22);
            this.shop1.TabIndex = 23;
            this.shop1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Shopper Purch";
            // 
            // comm2
            // 
            this.comm2.Location = new System.Drawing.Point(282, 147);
            this.comm2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.comm2.Name = "comm2";
            this.comm2.Size = new System.Drawing.Size(120, 22);
            this.comm2.TabIndex = 29;
            this.comm2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comm3
            // 
            this.comm3.Location = new System.Drawing.Point(441, 147);
            this.comm3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.comm3.Name = "comm3";
            this.comm3.Size = new System.Drawing.Size(120, 22);
            this.comm3.TabIndex = 28;
            this.comm3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comm1
            // 
            this.comm1.Location = new System.Drawing.Point(127, 147);
            this.comm1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.comm1.Name = "comm1";
            this.comm1.Size = new System.Drawing.Size(120, 22);
            this.comm1.TabIndex = 27;
            this.comm1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Comm Purch";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(800, 108);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 22);
            this.numericUpDown1.TabIndex = 31;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(800, 147);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(61, 22);
            this.numericUpDown2.TabIndex = 33;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(601, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 21);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Use Shopper Popularity";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(601, 147);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(195, 21);
            this.checkBox2.TabIndex = 35;
            this.checkBox2.Text = "Use Community Popularity";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(656, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(219, 80);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(725, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Selected Product:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(869, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Select";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1752, 780);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comm2);
            this.Controls.Add(this.comm3);
            this.Controls.Add(this.comm1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.shop2);
            this.Controls.Add(this.shop3);
            this.Controls.Add(this.shop1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.num2);
            this.Controls.Add(this.num3);
            this.Controls.Add(this.num1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.SCVGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SCVGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comm3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView SCVGrid;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ComboBox cmbCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num1;
        private System.Windows.Forms.NumericUpDown num3;
        private System.Windows.Forms.NumericUpDown num2;
        private System.Windows.Forms.NumericUpDown shop2;
        private System.Windows.Forms.NumericUpDown shop3;
        private System.Windows.Forms.NumericUpDown shop1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown comm2;
        private System.Windows.Forms.NumericUpDown comm3;
        private System.Windows.Forms.NumericUpDown comm1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

