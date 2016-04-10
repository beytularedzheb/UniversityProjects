namespace NegativeRotationP2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.btn180 = new System.Windows.Forms.Button();
            this.btnPlus90 = new System.Windows.Forms.Button();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblNegative = new System.Windows.Forms.Label();
            this.chbNegative = new System.Windows.Forms.CheckBox();
            this.btnMinus90 = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(743, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tlpActions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pbImage);
            this.splitContainer1.Size = new System.Drawing.Size(743, 425);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 1;
            // 
            // tlpActions
            // 
            this.tlpActions.AutoSize = true;
            this.tlpActions.ColumnCount = 1;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Controls.Add(this.btn180, 0, 5);
            this.tlpActions.Controls.Add(this.btnPlus90, 0, 4);
            this.tlpActions.Controls.Add(this.lblRotation, 0, 2);
            this.tlpActions.Controls.Add(this.lblNegative, 0, 0);
            this.tlpActions.Controls.Add(this.chbNegative, 0, 1);
            this.tlpActions.Controls.Add(this.btnMinus90, 0, 3);
            this.tlpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpActions.Enabled = false;
            this.tlpActions.Location = new System.Drawing.Point(0, 0);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 7;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpActions.Size = new System.Drawing.Size(192, 160);
            this.tlpActions.TabIndex = 0;
            // 
            // btn180
            // 
            this.btn180.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn180.Location = new System.Drawing.Point(58, 136);
            this.btn180.Margin = new System.Windows.Forms.Padding(0);
            this.btn180.Name = "btn180";
            this.btn180.Size = new System.Drawing.Size(75, 23);
            this.btn180.TabIndex = 5;
            this.btn180.Text = "180";
            this.btn180.UseVisualStyleBackColor = true;
            this.btn180.Click += new System.EventHandler(this.btn180_Click);
            // 
            // btnPlus90
            // 
            this.btnPlus90.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlus90.Location = new System.Drawing.Point(58, 111);
            this.btnPlus90.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlus90.Name = "btnPlus90";
            this.btnPlus90.Size = new System.Drawing.Size(75, 23);
            this.btnPlus90.TabIndex = 4;
            this.btnPlus90.Text = "+90";
            this.btnPlus90.UseVisualStyleBackColor = true;
            this.btnPlus90.Click += new System.EventHandler(this.btnPlus90_Click);
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblRotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRotation.Location = new System.Drawing.Point(0, 55);
            this.lblRotation.Margin = new System.Windows.Forms.Padding(0);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(192, 30);
            this.lblRotation.TabIndex = 1;
            this.lblRotation.Text = "Rotation";
            this.lblRotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNegative
            // 
            this.lblNegative.AutoSize = true;
            this.lblNegative.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNegative.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNegative.Location = new System.Drawing.Point(0, 0);
            this.lblNegative.Margin = new System.Windows.Forms.Padding(0);
            this.lblNegative.Name = "lblNegative";
            this.lblNegative.Size = new System.Drawing.Size(192, 30);
            this.lblNegative.TabIndex = 0;
            this.lblNegative.Text = "Negative";
            this.lblNegative.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbNegative
            // 
            this.chbNegative.AutoSize = true;
            this.chbNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbNegative.Location = new System.Drawing.Point(0, 30);
            this.chbNegative.Margin = new System.Windows.Forms.Padding(0);
            this.chbNegative.Name = "chbNegative";
            this.chbNegative.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.chbNegative.Size = new System.Drawing.Size(192, 25);
            this.chbNegative.TabIndex = 2;
            this.chbNegative.Text = "Off";
            this.chbNegative.UseVisualStyleBackColor = true;
            this.chbNegative.Click += new System.EventHandler(this.chbNegative_Click);
            // 
            // btnMinus90
            // 
            this.btnMinus90.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMinus90.Location = new System.Drawing.Point(58, 86);
            this.btnMinus90.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinus90.Name = "btnMinus90";
            this.btnMinus90.Size = new System.Drawing.Size(75, 23);
            this.btnMinus90.TabIndex = 3;
            this.btnMinus90.Text = "-90";
            this.btnMinus90.UseVisualStyleBackColor = true;
            this.btnMinus90.Click += new System.EventHandler(this.btnMinus90_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(100, 50);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 449);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpActions.ResumeLayout(false);
            this.tlpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Label lblNegative;
        private System.Windows.Forms.CheckBox chbNegative;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn180;
        private System.Windows.Forms.Button btnPlus90;
        private System.Windows.Forms.Button btnMinus90;
    }
}

