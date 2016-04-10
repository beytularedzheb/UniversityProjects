namespace SBM_RentCalculation
{
    partial class frmMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbBigger = new System.Windows.Forms.RadioButton();
            this.rbPTimeRent = new System.Windows.Forms.RadioButton();
            this.rbFixRentTime = new System.Windows.Forms.RadioButton();
            this.rbPreNum = new System.Windows.Forms.RadioButton();
            this.rbPostNum = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.nudA = new System.Windows.Forms.NumericUpDown();
            this.nudB = new System.Windows.Forms.NumericUpDown();
            this.nudC = new System.Windows.Forms.NumericUpDown();
            this.nudD = new System.Windows.Forms.NumericUpDown();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResultLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 75;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(764, 322);
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.rbBigger, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbPTimeRent, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbFixRentTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbPreNum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbPostNum, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rbBigger
            // 
            this.rbBigger.AutoSize = true;
            this.rbBigger.BackColor = System.Drawing.Color.Khaki;
            this.rbBigger.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbBigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbBigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbBigger.Location = new System.Drawing.Point(610, 2);
            this.rbBigger.Margin = new System.Windows.Forms.Padding(0);
            this.rbBigger.Name = "rbBigger";
            this.rbBigger.Size = new System.Drawing.Size(152, 71);
            this.rbBigger.TabIndex = 4;
            this.rbBigger.Text = "Рента с период по-голям от 1 година";
            this.rbBigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBigger.UseVisualStyleBackColor = false;
            this.rbBigger.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPTimeRent
            // 
            this.rbPTimeRent.AutoSize = true;
            this.rbPTimeRent.BackColor = System.Drawing.Color.Thistle;
            this.rbPTimeRent.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbPTimeRent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbPTimeRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPTimeRent.Location = new System.Drawing.Point(458, 2);
            this.rbPTimeRent.Margin = new System.Windows.Forms.Padding(0);
            this.rbPTimeRent.Name = "rbPTimeRent";
            this.rbPTimeRent.Size = new System.Drawing.Size(150, 71);
            this.rbPTimeRent.TabIndex = 3;
            this.rbPTimeRent.Text = "P - срочна рента";
            this.rbPTimeRent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPTimeRent.UseVisualStyleBackColor = false;
            this.rbPTimeRent.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbFixRentTime
            // 
            this.rbFixRentTime.AutoSize = true;
            this.rbFixRentTime.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.rbFixRentTime.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbFixRentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbFixRentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFixRentTime.Location = new System.Drawing.Point(306, 2);
            this.rbFixRentTime.Margin = new System.Windows.Forms.Padding(0);
            this.rbFixRentTime.Name = "rbFixRentTime";
            this.rbFixRentTime.Size = new System.Drawing.Size(150, 71);
            this.rbFixRentTime.TabIndex = 2;
            this.rbFixRentTime.Text = "Определяне срока на рентата";
            this.rbFixRentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbFixRentTime.UseVisualStyleBackColor = false;
            this.rbFixRentTime.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPreNum
            // 
            this.rbPreNum.AutoSize = true;
            this.rbPreNum.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.rbPreNum.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbPreNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbPreNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPreNum.Location = new System.Drawing.Point(154, 2);
            this.rbPreNum.Margin = new System.Windows.Forms.Padding(0);
            this.rbPreNum.Name = "rbPreNum";
            this.rbPreNum.Size = new System.Drawing.Size(150, 71);
            this.rbPreNum.TabIndex = 1;
            this.rbPreNum.Text = "Пренумерандна рента";
            this.rbPreNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPreNum.UseVisualStyleBackColor = false;
            this.rbPreNum.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPostNum
            // 
            this.rbPostNum.AutoSize = true;
            this.rbPostNum.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbPostNum.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbPostNum.Checked = true;
            this.rbPostNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbPostNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbPostNum.Location = new System.Drawing.Point(2, 2);
            this.rbPostNum.Margin = new System.Windows.Forms.Padding(0);
            this.rbPostNum.Name = "rbPostNum";
            this.rbPostNum.Size = new System.Drawing.Size(150, 71);
            this.rbPostNum.TabIndex = 0;
            this.rbPostNum.TabStop = true;
            this.rbPostNum.Text = "Постнумерандна рента";
            this.rbPostNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPostNum.UseVisualStyleBackColor = false;
            this.rbPostNum.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Controls.Add(this.lblA, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblB, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblC, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblD, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.nudA, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudB, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.nudC, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.nudD, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnCalculate, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblResultLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(764, 246);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblA
            // 
            this.lblA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(3, 14);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(97, 17);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "lblA";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblB
            // 
            this.lblB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(3, 59);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(97, 17);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "lblB";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblC
            // 
            this.lblC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(3, 104);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(97, 17);
            this.lblC.TabIndex = 3;
            this.lblC.Text = "lblC";
            this.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblD
            // 
            this.lblD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(3, 149);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(97, 17);
            this.lblD.TabIndex = 4;
            this.lblD.Text = "lblD";
            this.lblD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudA
            // 
            this.nudA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudA.DecimalPlaces = 2;
            this.nudA.Location = new System.Drawing.Point(106, 11);
            this.nudA.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudA.Name = "nudA";
            this.nudA.Size = new System.Drawing.Size(120, 23);
            this.nudA.TabIndex = 5;
            // 
            // nudB
            // 
            this.nudB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudB.DecimalPlaces = 2;
            this.nudB.Location = new System.Drawing.Point(106, 56);
            this.nudB.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudB.Name = "nudB";
            this.nudB.Size = new System.Drawing.Size(120, 23);
            this.nudB.TabIndex = 6;
            // 
            // nudC
            // 
            this.nudC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudC.DecimalPlaces = 2;
            this.nudC.Location = new System.Drawing.Point(106, 101);
            this.nudC.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudC.Name = "nudC";
            this.nudC.Size = new System.Drawing.Size(120, 23);
            this.nudC.TabIndex = 7;
            // 
            // nudD
            // 
            this.nudD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudD.DecimalPlaces = 2;
            this.nudD.Location = new System.Drawing.Point(106, 146);
            this.nudD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudD.Name = "nudD";
            this.nudD.Size = new System.Drawing.Size(120, 23);
            this.nudD.TabIndex = 8;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCalculate.Location = new System.Drawing.Point(232, 187);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(529, 30);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Изчисли";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblResultLabel
            // 
            this.lblResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultLabel.AutoSize = true;
            this.lblResultLabel.Location = new System.Drawing.Point(3, 194);
            this.lblResultLabel.Name = "lblResultLabel";
            this.lblResultLabel.Size = new System.Drawing.Size(97, 17);
            this.lblResultLabel.TabIndex = 10;
            this.lblResultLabel.Text = "lblResultLabel";
            this.lblResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(106, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 39);
            this.panel1.TabIndex = 11;
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(120, 39);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "lblResult";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 322);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рентни изчисления";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rbPostNum;
        private System.Windows.Forms.RadioButton rbBigger;
        private System.Windows.Forms.RadioButton rbPTimeRent;
        private System.Windows.Forms.RadioButton rbFixRentTime;
        private System.Windows.Forms.RadioButton rbPreNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.NumericUpDown nudA;
        private System.Windows.Forms.NumericUpDown nudB;
        private System.Windows.Forms.NumericUpDown nudC;
        private System.Windows.Forms.NumericUpDown nudD;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblResultLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblResult;
    }
}

