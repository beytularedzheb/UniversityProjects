namespace IS_2D
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMainForm = new System.Windows.Forms.StatusStrip();
            this.startToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.endToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainerMainFormContent = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelIButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonText = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonHorizontalLine = new System.Windows.Forms.Button();
            this.buttonEllipse = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBrushStyle = new System.Windows.Forms.Label();
            this.comboBoxBrushStyle = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelText = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanelColors = new System.Windows.Forms.TableLayoutPanel();
            this.labelPenColor = new System.Windows.Forms.Label();
            this.panelBrushColor = new System.Windows.Forms.Panel();
            this.panelPenColor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPenStroke = new System.Windows.Forms.Label();
            this.trackBarPenStroke = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMainForm.SuspendLayout();
            this.statusStripMainForm.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainFormContent)).BeginInit();
            this.splitContainerMainFormContent.Panel1.SuspendLayout();
            this.splitContainerMainFormContent.Panel2.SuspendLayout();
            this.splitContainerMainFormContent.SuspendLayout();
            this.tableLayoutPanelIButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCanvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanelColors.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPenStroke)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMainForm
            // 
            this.menuStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainForm.Name = "menuStripMainForm";
            this.menuStripMainForm.Size = new System.Drawing.Size(1150, 24);
            this.menuStripMainForm.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newToolStripMenuItem.Text = "Нов";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openToolStripMenuItem.Text = "Отвори...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveToolStripMenuItem.Text = "Запиши";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveAsToolStripMenuItem.Text = "Запиши като...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Изход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.editToolStripMenuItem.Text = "Редактиране";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.fontToolStripMenuItem.Text = "Шрифт...";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.helpToolStripMenuItem.Text = "Помощ";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "Относно";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStripMainForm
            // 
            this.statusStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripStatusLabel,
            this.currentToolStripStatusLabel,
            this.endToolStripStatusLabel});
            this.statusStripMainForm.Location = new System.Drawing.Point(0, 534);
            this.statusStripMainForm.Name = "statusStripMainForm";
            this.statusStripMainForm.Size = new System.Drawing.Size(1150, 22);
            this.statusStripMainForm.TabIndex = 2;
            // 
            // startToolStripStatusLabel
            // 
            this.startToolStripStatusLabel.AutoSize = false;
            this.startToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.startToolStripStatusLabel.Name = "startToolStripStatusLabel";
            this.startToolStripStatusLabel.Size = new System.Drawing.Size(100, 17);
            this.startToolStripStatusLabel.ToolTipText = "Начална точка";
            // 
            // currentToolStripStatusLabel
            // 
            this.currentToolStripStatusLabel.AutoSize = false;
            this.currentToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.currentToolStripStatusLabel.Name = "currentToolStripStatusLabel";
            this.currentToolStripStatusLabel.Size = new System.Drawing.Size(100, 17);
            this.currentToolStripStatusLabel.ToolTipText = "Текуща позиция на мишката";
            // 
            // endToolStripStatusLabel
            // 
            this.endToolStripStatusLabel.AutoSize = false;
            this.endToolStripStatusLabel.Name = "endToolStripStatusLabel";
            this.endToolStripStatusLabel.Size = new System.Drawing.Size(100, 17);
            this.endToolStripStatusLabel.ToolTipText = "Крайна точка";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.splitContainerMainFormContent, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1150, 510);
            this.tableLayoutPanelMain.TabIndex = 3;
            // 
            // splitContainerMainFormContent
            // 
            this.splitContainerMainFormContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainFormContent.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMainFormContent.Name = "splitContainerMainFormContent";
            // 
            // splitContainerMainFormContent.Panel1
            // 
            this.splitContainerMainFormContent.Panel1.AutoScroll = true;
            this.splitContainerMainFormContent.Panel1.Controls.Add(this.tableLayoutPanelIButtons);
            // 
            // splitContainerMainFormContent.Panel2
            // 
            this.splitContainerMainFormContent.Panel2.AutoScroll = true;
            this.splitContainerMainFormContent.Panel2.Controls.Add(this.panelCanvas);
            this.splitContainerMainFormContent.Size = new System.Drawing.Size(1144, 452);
            this.splitContainerMainFormContent.SplitterDistance = 121;
            this.splitContainerMainFormContent.TabIndex = 0;
            // 
            // tableLayoutPanelIButtons
            // 
            this.tableLayoutPanelIButtons.AutoScroll = true;
            this.tableLayoutPanelIButtons.ColumnCount = 1;
            this.tableLayoutPanelIButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelIButtons.Controls.Add(this.buttonText, 0, 4);
            this.tableLayoutPanelIButtons.Controls.Add(this.buttonLine, 0, 3);
            this.tableLayoutPanelIButtons.Controls.Add(this.buttonHorizontalLine, 0, 2);
            this.tableLayoutPanelIButtons.Controls.Add(this.buttonEllipse, 0, 1);
            this.tableLayoutPanelIButtons.Controls.Add(this.buttonRectangle, 0, 0);
            this.tableLayoutPanelIButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelIButtons.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelIButtons.Name = "tableLayoutPanelIButtons";
            this.tableLayoutPanelIButtons.RowCount = 6;
            this.tableLayoutPanelIButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelIButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelIButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelIButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelIButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelIButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelIButtons.Size = new System.Drawing.Size(121, 452);
            this.tableLayoutPanelIButtons.TabIndex = 1;
            // 
            // buttonText
            // 
            this.buttonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonText.Image = ((System.Drawing.Image)(resources.GetObject("buttonText.Image")));
            this.buttonText.Location = new System.Drawing.Point(3, 323);
            this.buttonText.Name = "buttonText";
            this.buttonText.Padding = new System.Windows.Forms.Padding(5);
            this.buttonText.Size = new System.Drawing.Size(115, 74);
            this.buttonText.TabIndex = 4;
            this.buttonText.UseVisualStyleBackColor = false;
            this.buttonText.Click += new System.EventHandler(this.buttonText_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLine.Image = ((System.Drawing.Image)(resources.GetObject("buttonLine.Image")));
            this.buttonLine.Location = new System.Drawing.Point(3, 243);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Padding = new System.Windows.Forms.Padding(5);
            this.buttonLine.Size = new System.Drawing.Size(115, 74);
            this.buttonLine.TabIndex = 3;
            this.buttonLine.UseVisualStyleBackColor = false;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonHorizontalLine
            // 
            this.buttonHorizontalLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHorizontalLine.Image = ((System.Drawing.Image)(resources.GetObject("buttonHorizontalLine.Image")));
            this.buttonHorizontalLine.Location = new System.Drawing.Point(3, 163);
            this.buttonHorizontalLine.Name = "buttonHorizontalLine";
            this.buttonHorizontalLine.Padding = new System.Windows.Forms.Padding(5);
            this.buttonHorizontalLine.Size = new System.Drawing.Size(115, 74);
            this.buttonHorizontalLine.TabIndex = 2;
            this.buttonHorizontalLine.UseVisualStyleBackColor = false;
            this.buttonHorizontalLine.Click += new System.EventHandler(this.buttonHorizontalLine_Click);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("buttonEllipse.Image")));
            this.buttonEllipse.Location = new System.Drawing.Point(3, 83);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Padding = new System.Windows.Forms.Padding(5);
            this.buttonEllipse.Size = new System.Drawing.Size(115, 74);
            this.buttonEllipse.TabIndex = 1;
            this.buttonEllipse.UseVisualStyleBackColor = false;
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipse_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRectangle.Image = ((System.Drawing.Image)(resources.GetObject("buttonRectangle.Image")));
            this.buttonRectangle.Location = new System.Drawing.Point(3, 3);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Padding = new System.Windows.Forms.Padding(5);
            this.buttonRectangle.Size = new System.Drawing.Size(115, 74);
            this.buttonRectangle.TabIndex = 0;
            this.buttonRectangle.UseVisualStyleBackColor = false;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Location = new System.Drawing.Point(0, 0);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(1019, 452);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.TabStop = false;
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 458);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 52);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.48387F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.51613F));
            this.tableLayoutPanel4.Controls.Add(this.labelBrushStyle, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxBrushStyle, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(840, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(310, 52);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // labelBrushStyle
            // 
            this.labelBrushStyle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBrushStyle.AutoSize = true;
            this.labelBrushStyle.Location = new System.Drawing.Point(16, 19);
            this.labelBrushStyle.Name = "labelBrushStyle";
            this.labelBrushStyle.Size = new System.Drawing.Size(91, 13);
            this.labelBrushStyle.TabIndex = 1;
            this.labelBrushStyle.Text = "Стил на четката:";
            // 
            // comboBoxBrushStyle
            // 
            this.comboBoxBrushStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBrushStyle.FormattingEnabled = true;
            this.comboBoxBrushStyle.Location = new System.Drawing.Point(113, 15);
            this.comboBoxBrushStyle.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.comboBoxBrushStyle.Name = "comboBoxBrushStyle";
            this.comboBoxBrushStyle.Size = new System.Drawing.Size(187, 21);
            this.comboBoxBrushStyle.TabIndex = 2;
            this.comboBoxBrushStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxBrushStyle_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelColors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 52);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.labelText, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxMessage, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonOK, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Enabled = false;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(560, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(280, 52);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // labelText
            // 
            this.labelText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(3, 19);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(40, 13);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Текст:";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.Location = new System.Drawing.Point(49, 16);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(100, 20);
            this.textBoxMessage.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonOK.Location = new System.Drawing.Point(155, 14);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tableLayoutPanelColors
            // 
            this.tableLayoutPanelColors.AutoSize = true;
            this.tableLayoutPanelColors.ColumnCount = 2;
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanelColors.Controls.Add(this.labelPenColor, 0, 0);
            this.tableLayoutPanelColors.Controls.Add(this.panelBrushColor, 1, 1);
            this.tableLayoutPanelColors.Controls.Add(this.panelPenColor, 1, 0);
            this.tableLayoutPanelColors.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanelColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColors.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelColors.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelColors.Name = "tableLayoutPanelColors";
            this.tableLayoutPanelColors.RowCount = 2;
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelColors.Size = new System.Drawing.Size(280, 52);
            this.tableLayoutPanelColors.TabIndex = 3;
            // 
            // labelPenColor
            // 
            this.labelPenColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPenColor.AutoSize = true;
            this.labelPenColor.Location = new System.Drawing.Point(3, 6);
            this.labelPenColor.Name = "labelPenColor";
            this.labelPenColor.Size = new System.Drawing.Size(106, 13);
            this.labelPenColor.TabIndex = 0;
            this.labelPenColor.Text = "Цвят на писалката:";
            this.labelPenColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelBrushColor
            // 
            this.panelBrushColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelBrushColor.BackColor = System.Drawing.Color.White;
            this.panelBrushColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBrushColor.Location = new System.Drawing.Point(115, 29);
            this.panelBrushColor.Name = "panelBrushColor";
            this.panelBrushColor.Size = new System.Drawing.Size(20, 20);
            this.panelBrushColor.TabIndex = 2;
            this.panelBrushColor.Click += new System.EventHandler(this.panelBrushColor_Click);
            // 
            // panelPenColor
            // 
            this.panelPenColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelPenColor.BackColor = System.Drawing.Color.Black;
            this.panelPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPenColor.Location = new System.Drawing.Point(115, 3);
            this.panelPenColor.Name = "panelPenColor";
            this.panelPenColor.Size = new System.Drawing.Size(20, 20);
            this.panelPenColor.TabIndex = 1;
            this.panelPenColor.Click += new System.EventHandler(this.panelPenColor_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Цвят на четката:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.labelPenStroke, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBarPenStroke, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(280, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(280, 52);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // labelPenStroke
            // 
            this.labelPenStroke.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPenStroke.AutoSize = true;
            this.labelPenStroke.Location = new System.Drawing.Point(3, 19);
            this.labelPenStroke.Name = "labelPenStroke";
            this.labelPenStroke.Size = new System.Drawing.Size(120, 13);
            this.labelPenStroke.TabIndex = 0;
            this.labelPenStroke.Text = "Размер на писалката:";
            // 
            // trackBarPenStroke
            // 
            this.trackBarPenStroke.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarPenStroke.Location = new System.Drawing.Point(129, 3);
            this.trackBarPenStroke.Minimum = 1;
            this.trackBarPenStroke.Name = "trackBarPenStroke";
            this.trackBarPenStroke.Size = new System.Drawing.Size(181, 45);
            this.trackBarPenStroke.TabIndex = 1;
            this.trackBarPenStroke.Value = 1;
            this.trackBarPenStroke.Scroll += new System.EventHandler(this.trackBarPenStroke_Scroll);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Bitmap Image (*.bmp)|*.bmp|JPEG Image (*.jpeg)|*.jpeg|Vector Image (*.vec)|*.vec";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Vector Image (*.vec)|*.vec";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 556);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStripMainForm);
            this.Controls.Add(this.menuStripMainForm);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMainForm;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графичен редактор на 2D елементи";
            this.menuStripMainForm.ResumeLayout(false);
            this.menuStripMainForm.PerformLayout();
            this.statusStripMainForm.ResumeLayout(false);
            this.statusStripMainForm.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.splitContainerMainFormContent.Panel1.ResumeLayout(false);
            this.splitContainerMainFormContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainFormContent)).EndInit();
            this.splitContainerMainFormContent.ResumeLayout(false);
            this.tableLayoutPanelIButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCanvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanelColors.ResumeLayout(false);
            this.tableLayoutPanelColors.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPenStroke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMainForm;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMainForm;
        private System.Windows.Forms.ToolStripStatusLabel startToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel currentToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel endToolStripStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.SplitContainer splitContainerMainFormContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIButtons;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonHorizontalLine;
        private System.Windows.Forms.Button buttonEllipse;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelColors;
        private System.Windows.Forms.Label labelPenColor;
        private System.Windows.Forms.Panel panelBrushColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPenColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelPenStroke;
        private System.Windows.Forms.TrackBar trackBarPenStroke;
        private System.Windows.Forms.Button buttonText;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox panelCanvas;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelBrushStyle;
        private System.Windows.Forms.ComboBox comboBoxBrushStyle;
    }
}

