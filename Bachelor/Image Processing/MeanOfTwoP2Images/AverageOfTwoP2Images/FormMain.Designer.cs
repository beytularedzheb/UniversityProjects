namespace AverageOfTwoP2Images
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFirstImage = new System.Windows.Forms.Panel();
            this.pbFirstImage = new System.Windows.Forms.PictureBox();
            this.pnlSecondImage = new System.Windows.Forms.Panel();
            this.pbSecondImage = new System.Windows.Forms.PictureBox();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.pbResultImage = new System.Windows.Forms.PictureBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.btnLoadSecondImage = new System.Windows.Forms.Button();
            this.btnLoadFirstImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlFirstImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstImage)).BeginInit();
            this.pnlSecondImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecondImage)).BeginInit();
            this.pnlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultImage)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlButtons, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(929, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlResult, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(150, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(779, 568);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.pnlFirstImage, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pnlSecondImage, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(779, 198);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // pnlFirstImage
            // 
            this.pnlFirstImage.AutoScroll = true;
            this.pnlFirstImage.Controls.Add(this.pbFirstImage);
            this.pnlFirstImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirstImage.Location = new System.Drawing.Point(3, 3);
            this.pnlFirstImage.Name = "pnlFirstImage";
            this.pnlFirstImage.Size = new System.Drawing.Size(383, 192);
            this.pnlFirstImage.TabIndex = 2;
            // 
            // pbFirstImage
            // 
            this.pbFirstImage.BackColor = System.Drawing.Color.Transparent;
            this.pbFirstImage.Location = new System.Drawing.Point(0, 0);
            this.pbFirstImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbFirstImage.Name = "pbFirstImage";
            this.pbFirstImage.Size = new System.Drawing.Size(50, 50);
            this.pbFirstImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFirstImage.TabIndex = 1;
            this.pbFirstImage.TabStop = false;
            // 
            // pnlSecondImage
            // 
            this.pnlSecondImage.AutoScroll = true;
            this.pnlSecondImage.Controls.Add(this.pbSecondImage);
            this.pnlSecondImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSecondImage.Location = new System.Drawing.Point(392, 3);
            this.pnlSecondImage.Name = "pnlSecondImage";
            this.pnlSecondImage.Size = new System.Drawing.Size(384, 192);
            this.pnlSecondImage.TabIndex = 3;
            // 
            // pbSecondImage
            // 
            this.pbSecondImage.BackColor = System.Drawing.Color.Transparent;
            this.pbSecondImage.Location = new System.Drawing.Point(0, 0);
            this.pbSecondImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbSecondImage.Name = "pbSecondImage";
            this.pbSecondImage.Size = new System.Drawing.Size(50, 50);
            this.pbSecondImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSecondImage.TabIndex = 2;
            this.pbSecondImage.TabStop = false;
            // 
            // pnlResult
            // 
            this.pnlResult.AutoScroll = true;
            this.pnlResult.Controls.Add(this.pbResultImage);
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResult.Location = new System.Drawing.Point(3, 201);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(773, 364);
            this.pnlResult.TabIndex = 1;
            // 
            // pbResultImage
            // 
            this.pbResultImage.BackColor = System.Drawing.Color.Transparent;
            this.pbResultImage.Location = new System.Drawing.Point(0, 0);
            this.pbResultImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbResultImage.Name = "pbResultImage";
            this.pbResultImage.Size = new System.Drawing.Size(50, 50);
            this.pbResultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbResultImage.TabIndex = 2;
            this.pbResultImage.TabStop = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnShowResult);
            this.pnlButtons.Controls.Add(this.btnLoadSecondImage);
            this.pnlButtons.Controls.Add(this.btnLoadFirstImage);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(150, 568);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(12, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Запази резултата";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowResult
            // 
            this.btnShowResult.Enabled = false;
            this.btnShowResult.Location = new System.Drawing.Point(12, 100);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(125, 25);
            this.btnShowResult.TabIndex = 2;
            this.btnShowResult.Text = "Покажи резултата";
            this.btnShowResult.UseVisualStyleBackColor = true;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
            // 
            // btnLoadSecondImage
            // 
            this.btnLoadSecondImage.Location = new System.Drawing.Point(12, 41);
            this.btnLoadSecondImage.Name = "btnLoadSecondImage";
            this.btnLoadSecondImage.Size = new System.Drawing.Size(125, 25);
            this.btnLoadSecondImage.TabIndex = 1;
            this.btnLoadSecondImage.Text = "Изображение 2";
            this.btnLoadSecondImage.UseVisualStyleBackColor = true;
            this.btnLoadSecondImage.Click += new System.EventHandler(this.btnLoadSecondImage_Click);
            // 
            // btnLoadFirstImage
            // 
            this.btnLoadFirstImage.Location = new System.Drawing.Point(12, 12);
            this.btnLoadFirstImage.Name = "btnLoadFirstImage";
            this.btnLoadFirstImage.Size = new System.Drawing.Size(125, 23);
            this.btnLoadFirstImage.TabIndex = 0;
            this.btnLoadFirstImage.Text = "Изображение 1";
            this.btnLoadFirstImage.UseVisualStyleBackColor = true;
            this.btnLoadFirstImage.Click += new System.EventHandler(this.btnLoadFirstImage_Click);
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
            this.ClientSize = new System.Drawing.Size(929, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Средноаритметично на две Р2 изображения";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnlFirstImage.ResumeLayout(false);
            this.pnlFirstImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstImage)).EndInit();
            this.pnlSecondImage.ResumeLayout(false);
            this.pnlSecondImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecondImage)).EndInit();
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultImage)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.Button btnLoadSecondImage;
        private System.Windows.Forms.Button btnLoadFirstImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlFirstImage;
        private System.Windows.Forms.PictureBox pbFirstImage;
        private System.Windows.Forms.Panel pnlSecondImage;
        private System.Windows.Forms.PictureBox pbSecondImage;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.PictureBox pbResultImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

