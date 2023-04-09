namespace DrawingApp
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.defaultTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.elipseBtn = new System.Windows.Forms.Button();
            this.circleBtn = new System.Windows.Forms.Button();
            this.squareBtn = new System.Windows.Forms.Button();
            this.rectangleBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.areaLbl = new System.Windows.Forms.Label();
            this.perLbl = new System.Windows.Forms.Label();
            this.tyyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.defaultTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1258, 641);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Perimeter: ";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.defaultTab);
            this.tabControl.Location = new System.Drawing.Point(65, 3);
            this.tabControl.Name = "tabControl";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl, 3);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1063, 599);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // defaultTab
            // 
            this.defaultTab.Controls.Add(this.pictureBox1);
            this.defaultTab.Location = new System.Drawing.Point(4, 25);
            this.defaultTab.Name = "defaultTab";
            this.defaultTab.Padding = new System.Windows.Forms.Padding(3);
            this.defaultTab.Size = new System.Drawing.Size(1055, 570);
            this.defaultTab.TabIndex = 0;
            this.defaultTab.Text = "Untitled";
            this.defaultTab.UseVisualStyleBackColor = true;
            this.defaultTab.Paint += new System.Windows.Forms.PaintEventHandler(this.rePaint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1049, 564);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tpMouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.lineBtn);
            this.panel1.Controls.Add(this.elipseBtn);
            this.panel1.Controls.Add(this.circleBtn);
            this.panel1.Controls.Add(this.squareBtn);
            this.panel1.Controls.Add(this.rectangleBtn);
            this.panel1.Controls.Add(this.selectBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 346);
            this.panel1.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::DrawingApp.Properties.Resources.text;
            this.button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.Location = new System.Drawing.Point(9, 232);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 32);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // lineBtn
            // 
            this.lineBtn.BackgroundImage = global::DrawingApp.Properties.Resources.diagonal_line;
            this.lineBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lineBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.lineBtn.FlatAppearance.BorderSize = 2;
            this.lineBtn.Location = new System.Drawing.Point(9, 194);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(32, 32);
            this.lineBtn.TabIndex = 5;
            this.lineBtn.UseVisualStyleBackColor = true;
            this.lineBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // elipseBtn
            // 
            this.elipseBtn.BackgroundImage = global::DrawingApp.Properties.Resources.ellipse;
            this.elipseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.elipseBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.elipseBtn.FlatAppearance.BorderSize = 2;
            this.elipseBtn.Location = new System.Drawing.Point(9, 156);
            this.elipseBtn.Name = "elipseBtn";
            this.elipseBtn.Size = new System.Drawing.Size(32, 32);
            this.elipseBtn.TabIndex = 4;
            this.elipseBtn.UseVisualStyleBackColor = true;
            this.elipseBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // circleBtn
            // 
            this.circleBtn.BackgroundImage = global::DrawingApp.Properties.Resources.new_moon;
            this.circleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.circleBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.circleBtn.FlatAppearance.BorderSize = 2;
            this.circleBtn.Location = new System.Drawing.Point(9, 118);
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.Size = new System.Drawing.Size(32, 32);
            this.circleBtn.TabIndex = 3;
            this.circleBtn.UseVisualStyleBackColor = true;
            this.circleBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // squareBtn
            // 
            this.squareBtn.BackgroundImage = global::DrawingApp.Properties.Resources.black_square;
            this.squareBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.squareBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.squareBtn.FlatAppearance.BorderSize = 2;
            this.squareBtn.Location = new System.Drawing.Point(10, 80);
            this.squareBtn.Name = "squareBtn";
            this.squareBtn.Size = new System.Drawing.Size(32, 32);
            this.squareBtn.TabIndex = 2;
            this.squareBtn.UseVisualStyleBackColor = true;
            this.squareBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // rectangleBtn
            // 
            this.rectangleBtn.BackgroundImage = global::DrawingApp.Properties.Resources.rectangle;
            this.rectangleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangleBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.rectangleBtn.FlatAppearance.BorderSize = 2;
            this.rectangleBtn.Location = new System.Drawing.Point(10, 42);
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.Size = new System.Drawing.Size(32, 32);
            this.rectangleBtn.TabIndex = 1;
            this.rectangleBtn.UseVisualStyleBackColor = true;
            this.rectangleBtn.Click += new System.EventHandler(this.rectangleBtn_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.BackgroundImage = global::DrawingApp.Properties.Resources.cursor_1_;
            this.selectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.selectBtn.FlatAppearance.BorderSize = 2;
            this.selectBtn.Location = new System.Drawing.Point(10, 4);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(32, 32);
            this.selectBtn.TabIndex = 0;
            this.selectBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.areaLbl);
            this.panel2.Controls.Add(this.perLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1134, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 346);
            this.panel2.TabIndex = 4;
            // 
            // areaLbl
            // 
            this.areaLbl.AutoSize = true;
            this.areaLbl.Location = new System.Drawing.Point(3, 42);
            this.areaLbl.Name = "areaLbl";
            this.areaLbl.Size = new System.Drawing.Size(42, 16);
            this.areaLbl.TabIndex = 1;
            this.areaLbl.Text = "Area: ";
            // 
            // perLbl
            // 
            this.perLbl.AutoSize = true;
            this.perLbl.Location = new System.Drawing.Point(3, 12);
            this.perLbl.Name = "perLbl";
            this.perLbl.Size = new System.Drawing.Size(71, 16);
            this.perLbl.TabIndex = 0;
            this.perLbl.Text = "Perimeter: ";
            // 
            // tyyToolStripMenuItem
            // 
            this.tyyToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tyyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.tyyToolStripMenuItem.Name = "tyyToolStripMenuItem";
            this.tyyToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.tyyToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tyyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1258, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1258, 669);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "KolevDraw";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.defaultTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tyyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage defaultTab;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Button elipseBtn;
        private System.Windows.Forms.Button circleBtn;
        private System.Windows.Forms.Button squareBtn;
        private System.Windows.Forms.Button rectangleBtn;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label areaLbl;
        private System.Windows.Forms.Label perLbl;
    }
}

