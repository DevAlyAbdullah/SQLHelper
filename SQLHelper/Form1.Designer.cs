namespace SQLHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_Backup = new System.Windows.Forms.Button();
            this.BTN_Restore = new System.Windows.Forms.Button();
            this.BTN_Delete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_Delete = new System.Windows.Forms.Label();
            this.Label_Restore = new System.Windows.Forms.Label();
            this.Label_Backup = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(323, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // BTN_Backup
            // 
            this.BTN_Backup.Location = new System.Drawing.Point(3, 3);
            this.BTN_Backup.Name = "BTN_Backup";
            this.BTN_Backup.Size = new System.Drawing.Size(75, 23);
            this.BTN_Backup.TabIndex = 1;
            this.BTN_Backup.Text = "Backup";
            this.BTN_Backup.UseVisualStyleBackColor = true;
            this.BTN_Backup.Click += new System.EventHandler(this.BTN_Backup_Click);
            // 
            // BTN_Restore
            // 
            this.BTN_Restore.Location = new System.Drawing.Point(3, 32);
            this.BTN_Restore.Name = "BTN_Restore";
            this.BTN_Restore.Size = new System.Drawing.Size(75, 23);
            this.BTN_Restore.TabIndex = 2;
            this.BTN_Restore.Text = "Restore";
            this.BTN_Restore.UseVisualStyleBackColor = true;
            this.BTN_Restore.Click += new System.EventHandler(this.BTN_Restore_Click);
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.Location = new System.Drawing.Point(3, 61);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(75, 23);
            this.BTN_Delete.TabIndex = 3;
            this.BTN_Delete.Text = "Delete";
            this.BTN_Delete.UseVisualStyleBackColor = true;
            this.BTN_Delete.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_Backup);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Restore);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Delete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(81, 87);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_Delete);
            this.groupBox1.Controls.Add(this.Label_Restore);
            this.groupBox1.Controls.Add(this.Label_Backup);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 115);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Control";
            // 
            // Label_Delete
            // 
            this.Label_Delete.AutoSize = true;
            this.Label_Delete.Location = new System.Drawing.Point(93, 87);
            this.Label_Delete.Name = "Label_Delete";
            this.Label_Delete.Size = new System.Drawing.Size(39, 15);
            this.Label_Delete.TabIndex = 7;
            this.Label_Delete.Text = "Status";
            // 
            // Label_Restore
            // 
            this.Label_Restore.AutoSize = true;
            this.Label_Restore.Location = new System.Drawing.Point(93, 58);
            this.Label_Restore.Name = "Label_Restore";
            this.Label_Restore.Size = new System.Drawing.Size(39, 15);
            this.Label_Restore.TabIndex = 6;
            this.Label_Restore.Text = "Status";
            // 
            // Label_Backup
            // 
            this.Label_Backup.AutoSize = true;
            this.Label_Backup.Location = new System.Drawing.Point(93, 29);
            this.Label_Backup.Name = "Label_Backup";
            this.Label_Backup.Size = new System.Drawing.Size(39, 15);
            this.Label_Backup.TabIndex = 5;
            this.Label_Backup.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 163);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLHelper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem connectionToolStripMenuItem;
        private Button BTN_Backup;
        private Button BTN_Restore;
        private Button BTN_Delete;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private Label Label_Delete;
        private Label Label_Restore;
        private Label Label_Backup;
    }
}