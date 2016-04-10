namespace P2_Histogram
{
    partial class FormMain
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMagicNumber = new System.Windows.Forms.Label();
            this.labelDetails = new System.Windows.Forms.Label();
            this.labelMaxVal = new System.Windows.Forms.Label();
            this.labelHieght = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.checkBoxOriginalSize = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelHistogram = new System.Windows.Forms.Label();
            this.panelResultImage = new System.Windows.Forms.Panel();
            this.pictureBoxHistogram = new System.Windows.Forms.PictureBox();
            this.panelOriginalImage = new System.Windows.Forms.Panel();
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.labelImage = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelResultImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
            this.panelOriginalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1173, 553);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelMagicNumber, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelDetails, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelMaxVal, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelHieght, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelWidth, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxOriginalSize, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(282, 216);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // labelMagicNumber
            // 
            this.labelMagicNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMagicNumber.AutoSize = true;
            this.labelMagicNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMagicNumber.Location = new System.Drawing.Point(6, 29);
            this.labelMagicNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMagicNumber.Name = "labelMagicNumber";
            this.labelMagicNumber.Size = new System.Drawing.Size(270, 25);
            this.labelMagicNumber.TabIndex = 9;
            this.labelMagicNumber.Text = "Magic Number:";
            this.labelMagicNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDetails
            // 
            this.labelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDetails.AutoSize = true;
            this.labelDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDetails.Location = new System.Drawing.Point(2, 2);
            this.labelDetails.Margin = new System.Windows.Forms.Padding(0);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(278, 25);
            this.labelDetails.TabIndex = 8;
            this.labelDetails.Text = "Details";
            this.labelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaxVal
            // 
            this.labelMaxVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaxVal.AutoSize = true;
            this.labelMaxVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaxVal.Location = new System.Drawing.Point(6, 122);
            this.labelMaxVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxVal.Name = "labelMaxVal";
            this.labelMaxVal.Size = new System.Drawing.Size(270, 31);
            this.labelMaxVal.TabIndex = 6;
            this.labelMaxVal.Text = "Maximum Gray Value:";
            this.labelMaxVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHieght
            // 
            this.labelHieght.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHieght.AutoSize = true;
            this.labelHieght.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHieght.Location = new System.Drawing.Point(6, 89);
            this.labelHieght.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHieght.Name = "labelHieght";
            this.labelHieght.Size = new System.Drawing.Size(270, 31);
            this.labelHieght.TabIndex = 5;
            this.labelHieght.Text = "Height:";
            this.labelHieght.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWidth.Location = new System.Drawing.Point(6, 56);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(270, 31);
            this.labelWidth.TabIndex = 4;
            this.labelWidth.Text = "Width:";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxOriginalSize
            // 
            this.checkBoxOriginalSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxOriginalSize.AutoSize = true;
            this.checkBoxOriginalSize.Enabled = false;
            this.checkBoxOriginalSize.Location = new System.Drawing.Point(6, 191);
            this.checkBoxOriginalSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.checkBoxOriginalSize.Name = "checkBoxOriginalSize";
            this.checkBoxOriginalSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxOriginalSize.Size = new System.Drawing.Size(102, 20);
            this.checkBoxOriginalSize.TabIndex = 10;
            this.checkBoxOriginalSize.Text = "Original Size";
            this.checkBoxOriginalSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxOriginalSize.UseVisualStyleBackColor = true;
            this.checkBoxOriginalSize.Click += new System.EventHandler(this.checkBoxOriginalSize_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelHistogram, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelResultImage, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelOriginalImage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelImage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 553);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelHistogram
            // 
            this.labelHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHistogram.AutoSize = true;
            this.labelHistogram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHistogram.Location = new System.Drawing.Point(2, 277);
            this.labelHistogram.Margin = new System.Windows.Forms.Padding(0);
            this.labelHistogram.Name = "labelHistogram";
            this.labelHistogram.Size = new System.Drawing.Size(882, 25);
            this.labelHistogram.TabIndex = 3;
            this.labelHistogram.Text = "Histogram";
            this.labelHistogram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelResultImage
            // 
            this.panelResultImage.AutoScroll = true;
            this.panelResultImage.Controls.Add(this.pictureBoxHistogram);
            this.panelResultImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResultImage.Location = new System.Drawing.Point(2, 304);
            this.panelResultImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelResultImage.Name = "panelResultImage";
            this.panelResultImage.Size = new System.Drawing.Size(882, 247);
            this.panelResultImage.TabIndex = 1;
            // 
            // pictureBoxHistogram
            // 
            this.pictureBoxHistogram.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHistogram.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHistogram.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxHistogram.Name = "pictureBoxHistogram";
            this.pictureBoxHistogram.Size = new System.Drawing.Size(550, 245);
            this.pictureBoxHistogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHistogram.TabIndex = 1;
            this.pictureBoxHistogram.TabStop = false;
            this.pictureBoxHistogram.WaitOnLoad = true;
            // 
            // panelOriginalImage
            // 
            this.panelOriginalImage.AutoScroll = true;
            this.panelOriginalImage.Controls.Add(this.pictureBoxOriginalImage);
            this.panelOriginalImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOriginalImage.Location = new System.Drawing.Point(2, 29);
            this.panelOriginalImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelOriginalImage.Name = "panelOriginalImage";
            this.panelOriginalImage.Size = new System.Drawing.Size(882, 246);
            this.panelOriginalImage.TabIndex = 0;
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOriginalImage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            this.pictureBoxOriginalImage.WaitOnLoad = true;
            // 
            // labelImage
            // 
            this.labelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImage.AutoSize = true;
            this.labelImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelImage.Location = new System.Drawing.Point(2, 2);
            this.labelImage.Margin = new System.Windows.Forms.Padding(0);
            this.labelImage.Name = "labelImage";
            this.labelImage.Size = new System.Drawing.Size(882, 25);
            this.labelImage.TabIndex = 2;
            this.labelImage.Text = "Image";
            this.labelImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1173, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Portable Gray Map | *.pgm";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Portable Gray Map | *.pgm";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 577);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Изчисляване на хистограма на P2 изображение";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelResultImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
            this.panelOriginalImage.ResumeLayout(false);
            this.panelOriginalImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelMagicNumber;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Label labelMaxVal;
        private System.Windows.Forms.Label labelHieght;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelHistogram;
        private System.Windows.Forms.Panel panelResultImage;
        private System.Windows.Forms.Panel panelOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.Label labelImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxHistogram;
        private System.Windows.Forms.CheckBox checkBoxOriginalSize;
    }
}

