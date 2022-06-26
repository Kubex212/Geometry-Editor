
namespace Geometry_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalizacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorWierzchołkówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorKrawędziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorTłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorWybranejKrawędziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorWybranejKrawędziToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.deleterelationbutton = new System.Windows.Forms.Button();
            this.okbutton2 = new System.Windows.Forms.Button();
            this.lockradiusbutton = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.okbutton = new System.Windows.Forms.Button();
            this.lockedgebutton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.addingslbutton = new System.Windows.Forms.Button();
            this.addtangencybutton = new System.Windows.Forms.Button();
            this.addrelationbutton = new System.Windows.Forms.Button();
            this.addcirclebutton = new System.Windows.Forms.Button();
            this.movebutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vertexBar = new System.Windows.Forms.TrackBar();
            this.thicknessSlider = new System.Windows.Forms.TrackBar();
            this.addbutton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.personalizacjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapiszToolStripMenuItem,
            this.otwórzToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // personalizacjaToolStripMenuItem
            // 
            this.personalizacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kolorWierzchołkówToolStripMenuItem,
            this.kolorKrawędziToolStripMenuItem,
            this.kolorTłaToolStripMenuItem,
            this.kolorWybranejKrawędziToolStripMenuItem,
            this.kolorWybranejKrawędziToolStripMenuItem1});
            this.personalizacjaToolStripMenuItem.Name = "personalizacjaToolStripMenuItem";
            this.personalizacjaToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.personalizacjaToolStripMenuItem.Text = "Personalizacja";
            // 
            // kolorWierzchołkówToolStripMenuItem
            // 
            this.kolorWierzchołkówToolStripMenuItem.Name = "kolorWierzchołkówToolStripMenuItem";
            this.kolorWierzchołkówToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.kolorWierzchołkówToolStripMenuItem.Text = "Kolor wierzchołków";
            this.kolorWierzchołkówToolStripMenuItem.Click += new System.EventHandler(this.kolorWierzchołkówToolStripMenuItem_Click);
            // 
            // kolorKrawędziToolStripMenuItem
            // 
            this.kolorKrawędziToolStripMenuItem.Name = "kolorKrawędziToolStripMenuItem";
            this.kolorKrawędziToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.kolorKrawędziToolStripMenuItem.Text = "Kolor krawędzi";
            this.kolorKrawędziToolStripMenuItem.Click += new System.EventHandler(this.kolorKrawędziToolStripMenuItem_Click);
            // 
            // kolorTłaToolStripMenuItem
            // 
            this.kolorTłaToolStripMenuItem.Name = "kolorTłaToolStripMenuItem";
            this.kolorTłaToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.kolorTłaToolStripMenuItem.Text = "Kolor tła";
            this.kolorTłaToolStripMenuItem.Click += new System.EventHandler(this.kolorTłaToolStripMenuItem_Click);
            // 
            // kolorWybranejKrawędziToolStripMenuItem
            // 
            this.kolorWybranejKrawędziToolStripMenuItem.Name = "kolorWybranejKrawędziToolStripMenuItem";
            this.kolorWybranejKrawędziToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.kolorWybranejKrawędziToolStripMenuItem.Text = "Kolor wybranego wierzchołka";
            // 
            // kolorWybranejKrawędziToolStripMenuItem1
            // 
            this.kolorWybranejKrawędziToolStripMenuItem1.Name = "kolorWybranejKrawędziToolStripMenuItem1";
            this.kolorWybranejKrawędziToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.kolorWybranejKrawędziToolStripMenuItem1.Text = "Kolor wybranej krawędzi";
            this.kolorWybranejKrawędziToolStripMenuItem1.Click += new System.EventHandler(this.kolorWybranejKrawędziToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.deleterelationbutton);
            this.splitContainer1.Panel2.Controls.Add(this.okbutton2);
            this.splitContainer1.Panel2.Controls.Add(this.lockradiusbutton);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown2);
            this.splitContainer1.Panel2.Controls.Add(this.okbutton);
            this.splitContainer1.Panel2.Controls.Add(this.lockedgebutton);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.addingslbutton);
            this.splitContainer1.Panel2.Controls.Add(this.addtangencybutton);
            this.splitContainer1.Panel2.Controls.Add(this.addrelationbutton);
            this.splitContainer1.Panel2.Controls.Add(this.addcirclebutton);
            this.splitContainer1.Panel2.Controls.Add(this.movebutton);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.vertexBar);
            this.splitContainer1.Panel2.Controls.Add(this.thicknessSlider);
            this.splitContainer1.Panel2.Controls.Add(this.addbutton);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 645);
            this.splitContainer1.SplitterDistance = 890;
            this.splitContainer1.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox.Size = new System.Drawing.Size(890, 645);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // deleterelationbutton
            // 
            this.deleterelationbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleterelationbutton.BackColor = System.Drawing.SystemColors.Control;
            this.deleterelationbutton.Location = new System.Drawing.Point(1, 343);
            this.deleterelationbutton.Name = "deleterelationbutton";
            this.deleterelationbutton.Size = new System.Drawing.Size(232, 30);
            this.deleterelationbutton.TabIndex = 16;
            this.deleterelationbutton.Text = "Delete relation";
            this.deleterelationbutton.UseVisualStyleBackColor = false;
            this.deleterelationbutton.Click += new System.EventHandler(this.deleterelationbutton_Click);
            // 
            // okbutton2
            // 
            this.okbutton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.okbutton2.Location = new System.Drawing.Point(169, 318);
            this.okbutton2.Name = "okbutton2";
            this.okbutton2.Size = new System.Drawing.Size(56, 19);
            this.okbutton2.TabIndex = 15;
            this.okbutton2.Text = "OK";
            this.okbutton2.UseVisualStyleBackColor = true;
            this.okbutton2.Visible = false;
            this.okbutton2.Click += new System.EventHandler(this.okbutton2_Click);
            // 
            // lockradiusbutton
            // 
            this.lockradiusbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lockradiusbutton.BackColor = System.Drawing.SystemColors.Control;
            this.lockradiusbutton.Location = new System.Drawing.Point(2, 281);
            this.lockradiusbutton.Name = "lockradiusbutton";
            this.lockradiusbutton.Size = new System.Drawing.Size(232, 30);
            this.lockradiusbutton.TabIndex = 14;
            this.lockradiusbutton.Text = "Lock radius";
            this.lockradiusbutton.UseVisualStyleBackColor = false;
            this.lockradiusbutton.Click += new System.EventHandler(this.lockradiusbutton_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(9, 317);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(146, 20);
            this.numericUpDown2.TabIndex = 13;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Visible = false;
            // 
            // okbutton
            // 
            this.okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.okbutton.Location = new System.Drawing.Point(169, 256);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(56, 19);
            this.okbutton.TabIndex = 12;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Visible = false;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // lockedgebutton
            // 
            this.lockedgebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lockedgebutton.BackColor = System.Drawing.SystemColors.Control;
            this.lockedgebutton.Location = new System.Drawing.Point(2, 219);
            this.lockedgebutton.Name = "lockedgebutton";
            this.lockedgebutton.Size = new System.Drawing.Size(232, 30);
            this.lockedgebutton.TabIndex = 11;
            this.lockedgebutton.Text = "Lock edge length";
            this.lockedgebutton.UseVisualStyleBackColor = false;
            this.lockedgebutton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(9, 255);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(146, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            // 
            // addingslbutton
            // 
            this.addingslbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addingslbutton.BackColor = System.Drawing.SystemColors.Control;
            this.addingslbutton.Location = new System.Drawing.Point(1, 147);
            this.addingslbutton.Name = "addingslbutton";
            this.addingslbutton.Size = new System.Drawing.Size(232, 30);
            this.addingslbutton.TabIndex = 9;
            this.addingslbutton.Text = "Add same length relation";
            this.addingslbutton.UseVisualStyleBackColor = false;
            this.addingslbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addtangencybutton
            // 
            this.addtangencybutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addtangencybutton.BackColor = System.Drawing.SystemColors.Control;
            this.addtangencybutton.Location = new System.Drawing.Point(2, 183);
            this.addtangencybutton.Name = "addtangencybutton";
            this.addtangencybutton.Size = new System.Drawing.Size(232, 30);
            this.addtangencybutton.TabIndex = 8;
            this.addtangencybutton.Text = "Add tangency relation";
            this.addtangencybutton.UseVisualStyleBackColor = false;
            this.addtangencybutton.Click += new System.EventHandler(this.addtangencybutton_Click);
            // 
            // addrelationbutton
            // 
            this.addrelationbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addrelationbutton.BackColor = System.Drawing.SystemColors.Control;
            this.addrelationbutton.Location = new System.Drawing.Point(2, 111);
            this.addrelationbutton.Name = "addrelationbutton";
            this.addrelationbutton.Size = new System.Drawing.Size(232, 30);
            this.addrelationbutton.TabIndex = 7;
            this.addrelationbutton.Text = "Add parallelism relation";
            this.addrelationbutton.UseVisualStyleBackColor = false;
            this.addrelationbutton.Click += new System.EventHandler(this.addrelationbutton_Click);
            // 
            // addcirclebutton
            // 
            this.addcirclebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addcirclebutton.BackColor = System.Drawing.SystemColors.Control;
            this.addcirclebutton.Location = new System.Drawing.Point(2, 39);
            this.addcirclebutton.Name = "addcirclebutton";
            this.addcirclebutton.Size = new System.Drawing.Size(232, 30);
            this.addcirclebutton.TabIndex = 6;
            this.addcirclebutton.Text = "Add circle";
            this.addcirclebutton.UseVisualStyleBackColor = false;
            this.addcirclebutton.Click += new System.EventHandler(this.addcirclebutton_Click);
            // 
            // movebutton
            // 
            this.movebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movebutton.BackColor = System.Drawing.Color.Gray;
            this.movebutton.Location = new System.Drawing.Point(1, 75);
            this.movebutton.Name = "movebutton";
            this.movebutton.Size = new System.Drawing.Size(232, 30);
            this.movebutton.TabIndex = 5;
            this.movebutton.Text = "Move";
            this.movebutton.UseVisualStyleBackColor = false;
            this.movebutton.Click += new System.EventHandler(this.movebutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(-3, 482);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vertex diameter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(-3, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Line thickness";
            // 
            // vertexBar
            // 
            this.vertexBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vertexBar.Location = new System.Drawing.Point(-3, 505);
            this.vertexBar.Maximum = 20;
            this.vertexBar.Minimum = 4;
            this.vertexBar.Name = "vertexBar";
            this.vertexBar.Size = new System.Drawing.Size(230, 45);
            this.vertexBar.TabIndex = 2;
            this.vertexBar.Value = 15;
            this.vertexBar.Scroll += new System.EventHandler(this.vertexBar_Scroll);
            // 
            // thicknessSlider
            // 
            this.thicknessSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thicknessSlider.Location = new System.Drawing.Point(-3, 434);
            this.thicknessSlider.Minimum = 1;
            this.thicknessSlider.Name = "thicknessSlider";
            this.thicknessSlider.Size = new System.Drawing.Size(231, 45);
            this.thicknessSlider.TabIndex = 1;
            this.thicknessSlider.Value = 4;
            this.thicknessSlider.Scroll += new System.EventHandler(this.thicknessSlider_Scroll);
            // 
            // addbutton
            // 
            this.addbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addbutton.BackColor = System.Drawing.Color.White;
            this.addbutton.Location = new System.Drawing.Point(2, 3);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(232, 30);
            this.addbutton.TabIndex = 0;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 669);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.TrackBar thicknessSlider;
        private System.Windows.Forms.ToolStripMenuItem personalizacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorWierzchołkówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorKrawędziToolStripMenuItem;
        private System.Windows.Forms.TrackBar vertexBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button movebutton;
        private System.Windows.Forms.Button addcirclebutton;
        private System.Windows.Forms.Button addrelationbutton;
        private System.Windows.Forms.Button addtangencybutton;
        private System.Windows.Forms.ToolStripMenuItem kolorTłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorWybranejKrawędziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorWybranejKrawędziToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button addingslbutton;
        private System.Windows.Forms.Button lockedgebutton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button okbutton2;
        private System.Windows.Forms.Button lockradiusbutton;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button deleterelationbutton;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
    }
}

