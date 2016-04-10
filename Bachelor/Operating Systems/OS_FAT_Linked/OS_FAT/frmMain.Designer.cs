namespace OS_FAT
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSetMemory = new System.Windows.Forms.Button();
            this.nudMemorySize = new System.Windows.Forms.NumericUpDown();
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.lblMemorySize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scContent = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMemorySizeStatusValue = new System.Windows.Forms.Label();
            this.lblFreeMemoryStatus = new System.Windows.Forms.Label();
            this.lblMemorySizeStatus = new System.Windows.Forms.Label();
            this.lblFreeMemoryStatusValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.nudFileSize = new System.Windows.Forms.NumericUpDown();
            this.lblFileSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemorySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scContent)).BeginInit();
            this.scContent.Panel1.SuspendLayout();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileSize)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scContent);
            this.scMain.Size = new System.Drawing.Size(879, 564);
            this.scMain.SplitterDistance = 90;
            this.scMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.Controls.Add(this.btnSetMemory, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudMemorySize, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudBlockSize, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMemorySize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSetMemory
            // 
            this.btnSetMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetMemory.Location = new System.Drawing.Point(683, 47);
            this.btnSetMemory.Name = "btnSetMemory";
            this.btnSetMemory.Size = new System.Drawing.Size(191, 38);
            this.btnSetMemory.TabIndex = 0;
            this.btnSetMemory.Text = "Зареди";
            this.btnSetMemory.UseVisualStyleBackColor = true;
            this.btnSetMemory.Click += new System.EventHandler(this.btnSetMemory_Click);
            // 
            // nudMemorySize
            // 
            this.nudMemorySize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMemorySize.Location = new System.Drawing.Point(3, 12);
            this.nudMemorySize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudMemorySize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMemorySize.Name = "nudMemorySize";
            this.nudMemorySize.Size = new System.Drawing.Size(334, 20);
            this.nudMemorySize.TabIndex = 1;
            this.nudMemorySize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBlockSize.Location = new System.Drawing.Point(3, 56);
            this.nudBlockSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBlockSize.Name = "nudBlockSize";
            this.nudBlockSize.Size = new System.Drawing.Size(334, 20);
            this.nudBlockSize.TabIndex = 2;
            this.nudBlockSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMemorySize
            // 
            this.lblMemorySize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemorySize.AutoSize = true;
            this.lblMemorySize.Location = new System.Drawing.Point(343, 15);
            this.lblMemorySize.Name = "lblMemorySize";
            this.lblMemorySize.Size = new System.Drawing.Size(129, 13);
            this.lblMemorySize.TabIndex = 3;
            this.lblMemorySize.Text = "Размер на паметта (KB)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Големина на един блок (KB)";
            // 
            // scContent
            // 
            this.scContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContent.Enabled = false;
            this.scContent.Location = new System.Drawing.Point(0, 0);
            this.scContent.Name = "scContent";
            // 
            // scContent.Panel1
            // 
            this.scContent.Panel1.Controls.Add(this.tableLayoutPanel6);
            // 
            // scContent.Panel2
            // 
            this.scContent.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.scContent.Size = new System.Drawing.Size(879, 470);
            this.scContent.SplitterDistance = 644;
            this.scContent.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 630F));
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(642, 468);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(229, 468);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnDelete, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(223, 251);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(145, 224);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Изтрий";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(223, 221);
            this.dataGridView1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblMemorySizeStatusValue, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblFreeMemoryStatus, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblMemorySizeStatus, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblFreeMemoryStatusValue, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 400);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(223, 65);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblMemorySizeStatusValue
            // 
            this.lblMemorySizeStatusValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemorySizeStatusValue.AutoSize = true;
            this.lblMemorySizeStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMemorySizeStatusValue.Location = new System.Drawing.Point(113, 42);
            this.lblMemorySizeStatusValue.Name = "lblMemorySizeStatusValue";
            this.lblMemorySizeStatusValue.Size = new System.Drawing.Size(14, 13);
            this.lblMemorySizeStatusValue.TabIndex = 3;
            this.lblMemorySizeStatusValue.Text = "0";
            // 
            // lblFreeMemoryStatus
            // 
            this.lblFreeMemoryStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFreeMemoryStatus.AutoSize = true;
            this.lblFreeMemoryStatus.Location = new System.Drawing.Point(3, 9);
            this.lblFreeMemoryStatus.Name = "lblFreeMemoryStatus";
            this.lblFreeMemoryStatus.Size = new System.Drawing.Size(104, 13);
            this.lblFreeMemoryStatus.TabIndex = 0;
            this.lblFreeMemoryStatus.Text = "Свободни блокове:";
            // 
            // lblMemorySizeStatus
            // 
            this.lblMemorySizeStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemorySizeStatus.AutoSize = true;
            this.lblMemorySizeStatus.Location = new System.Drawing.Point(3, 42);
            this.lblMemorySizeStatus.Name = "lblMemorySizeStatus";
            this.lblMemorySizeStatus.Size = new System.Drawing.Size(80, 13);
            this.lblMemorySizeStatus.TabIndex = 1;
            this.lblMemorySizeStatus.Text = "Брой блокове:";
            // 
            // lblFreeMemoryStatusValue
            // 
            this.lblFreeMemoryStatusValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFreeMemoryStatusValue.AutoSize = true;
            this.lblFreeMemoryStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFreeMemoryStatusValue.Location = new System.Drawing.Point(113, 9);
            this.lblFreeMemoryStatusValue.Name = "lblFreeMemoryStatusValue";
            this.lblFreeMemoryStatusValue.Size = new System.Drawing.Size(14, 13);
            this.lblFreeMemoryStatusValue.TabIndex = 2;
            this.lblFreeMemoryStatusValue.Text = "0";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel5.Controls.Add(this.btnSaveFile, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.tbFileName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblFileName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.nudFileSize, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblFileSize, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 260);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(223, 100);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Location = new System.Drawing.Point(145, 55);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 30);
            this.btnSaveFile.TabIndex = 2;
            this.btnSaveFile.Text = "Запази";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Location = new System.Drawing.Point(104, 3);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(116, 20);
            this.tbFileName.TabIndex = 0;
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(3, 6);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(36, 13);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "Файл";
            // 
            // nudFileSize
            // 
            this.nudFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFileSize.Location = new System.Drawing.Point(104, 29);
            this.nudFileSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudFileSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFileSize.Name = "nudFileSize";
            this.nudFileSize.Size = new System.Drawing.Size(116, 20);
            this.nudFileSize.TabIndex = 1;
            this.nudFileSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFileSize
            // 
            this.lblFileSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(3, 32);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(69, 13);
            this.lblFileSize.TabIndex = 4;
            this.lblFileSize.Text = "Размер (KB)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 564);
            this.Controls.Add(this.scMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление на външната памет - организация FAT";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemorySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            this.scContent.Panel1.ResumeLayout(false);
            this.scContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scContent)).EndInit();
            this.scContent.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSetMemory;
        private System.Windows.Forms.NumericUpDown nudMemorySize;
        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.Label lblMemorySize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer scContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblMemorySizeStatusValue;
        private System.Windows.Forms.Label lblFreeMemoryStatus;
        private System.Windows.Forms.Label lblMemorySizeStatus;
        private System.Windows.Forms.Label lblFreeMemoryStatusValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.NumericUpDown nudFileSize;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

