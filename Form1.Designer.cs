namespace StarAlignment
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAlignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxInput = new System.Windows.Forms.ListBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.buttonDoAlignment = new System.Windows.Forms.Button();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAuthors = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.saveAlignmentToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addToolStripMenuItem.Text = "&Add Sequence";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // saveAlignmentToolStripMenuItem
            // 
            this.saveAlignmentToolStripMenuItem.Enabled = false;
            this.saveAlignmentToolStripMenuItem.Name = "saveAlignmentToolStripMenuItem";
            this.saveAlignmentToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveAlignmentToolStripMenuItem.Text = "&Save Alignment";
            // 
            // listBoxInput
            // 
            this.listBoxInput.FormattingEnabled = true;
            this.listBoxInput.Location = new System.Drawing.Point(13, 100);
            this.listBoxInput.Name = "listBoxInput";
            this.listBoxInput.Size = new System.Drawing.Size(431, 251);
            this.listBoxInput.TabIndex = 1;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(13, 79);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(88, 13);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Input Sequences";
            // 
            // buttonDoAlignment
            // 
            this.buttonDoAlignment.Location = new System.Drawing.Point(450, 100);
            this.buttonDoAlignment.Name = "buttonDoAlignment";
            this.buttonDoAlignment.Size = new System.Drawing.Size(34, 251);
            this.buttonDoAlignment.TabIndex = 5;
            this.buttonDoAlignment.Text = ">";
            this.buttonDoAlignment.UseVisualStyleBackColor = true;
            this.buttonDoAlignment.Click += new System.EventHandler(this.buttonDoAlignment_Click);
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.Location = new System.Drawing.Point(490, 100);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(506, 251);
            this.listBoxOutput.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Output Sequences";
            // 
            // labelAuthors
            // 
            this.labelAuthors.AutoSize = true;
            this.labelAuthors.Location = new System.Drawing.Point(650, 426);
            this.labelAuthors.Name = "labelAuthors";
            this.labelAuthors.Size = new System.Drawing.Size(346, 13);
            this.labelAuthors.TabIndex = 8;
            this.labelAuthors.Text = "Programmed and Designed by: Alex Addy, Nick Thompson, Cory Sutyak";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 448);
            this.Controls.Add(this.labelAuthors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.buttonDoAlignment);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.listBoxInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "STAR Algorithm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAlignmentToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxInput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Button buttonDoAlignment;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAuthors;
    }
}

