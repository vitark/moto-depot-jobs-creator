namespace MotoDepotJobsCreator
{
    partial class Main
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
            ToolStripStatusLabel lbStatusText;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            lb1 = new Label();
            cbTaskType = new ComboBox();
            lb2 = new Label();
            btnCreate = new Button();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            generateMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            decodeDepotJobToolStripMenuItem = new ToolStripMenuItem();
            originalToolStripMenuItem = new ToolStripMenuItem();
            selfGeneratedToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            generateCertificateToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            btnPasteSN = new Button();
            tbSerialNumber = new TextBox();
            cbSigningKey = new ComboBox();
            label1 = new Label();
            statusStrip = new StatusStrip();
            lbStatusText = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lbStatusText
            // 
            lbStatusText.Name = "lbStatusText";
            lbStatusText.Size = new Size(0, 17);
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(6, 43);
            lb1.Name = "lb1";
            lb1.Size = new Size(82, 15);
            lb1.TabIndex = 0;
            lb1.Text = "Serial Number";
            // 
            // cbTaskType
            // 
            cbTaskType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTaskType.FormattingEnabled = true;
            cbTaskType.Items.AddRange(new object[] { "Software Upgrade", "Codeplug Override", "Codeplug Upload", "Switchover", "Write And Switchover", "None", "Update Serial Number", "Factory Reset ", "CBI Program", "Codeplug ForceWrite", "Unkill Radio", "Software Upgrade Bootmode", "Request WiFi Certificate" });
            cbTaskType.Location = new Point(105, 80);
            cbTaskType.Name = "cbTaskType";
            cbTaskType.Size = new Size(246, 23);
            cbTaskType.TabIndex = 2;
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(6, 83);
            lb2.Name = "lb2";
            lb2.Size = new Size(93, 15);
            lb2.TabIndex = 3;
            lb2.Text = "Depot Task Type";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(236, 142);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(115, 25);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create Depot Job";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(376, 24);
            menuStrip.TabIndex = 5;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(134, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateMenuItem, toolStripSeparator1, decodeDepotJobToolStripMenuItem, toolStripSeparator2, generateCertificateToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // generateMenuItem
            // 
            generateMenuItem.Name = "generateMenuItem";
            generateMenuItem.Size = new Size(224, 22);
            generateMenuItem.Text = "Create DepotJob File";
            generateMenuItem.Click += btnCreate_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // decodeDepotJobToolStripMenuItem
            // 
            decodeDepotJobToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { originalToolStripMenuItem, selfGeneratedToolStripMenuItem });
            decodeDepotJobToolStripMenuItem.Name = "decodeDepotJobToolStripMenuItem";
            decodeDepotJobToolStripMenuItem.Size = new Size(224, 22);
            decodeDepotJobToolStripMenuItem.Text = "Decode DepotJob ";
            // 
            // originalToolStripMenuItem
            // 
            originalToolStripMenuItem.Name = "originalToolStripMenuItem";
            originalToolStripMenuItem.Size = new Size(180, 22);
            originalToolStripMenuItem.Text = "Motorola Original";
            originalToolStripMenuItem.Click += originalToolStripMenuItem_Click;
            // 
            // selfGeneratedToolStripMenuItem
            // 
            selfGeneratedToolStripMenuItem.Name = "selfGeneratedToolStripMenuItem";
            selfGeneratedToolStripMenuItem.Size = new Size(180, 22);
            selfGeneratedToolStripMenuItem.Text = "Self Generated";
            selfGeneratedToolStripMenuItem.Click += selfGeneratedToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // generateCertificateToolStripMenuItem
            // 
            generateCertificateToolStripMenuItem.Enabled = false;
            generateCertificateToolStripMenuItem.Name = "generateCertificateToolStripMenuItem";
            generateCertificateToolStripMenuItem.Size = new Size(224, 22);
            generateCertificateToolStripMenuItem.Text = "Generate Public/Private keys";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // btnPasteSN
            // 
            btnPasteSN.Image = Properties.Resources.Paste;
            btnPasteSN.Location = new Point(327, 40);
            btnPasteSN.Name = "btnPasteSN";
            btnPasteSN.Size = new Size(24, 24);
            btnPasteSN.TabIndex = 6;
            btnPasteSN.UseVisualStyleBackColor = true;
            btnPasteSN.Click += btnPasteSN_Click;
            // 
            // tbSerialNumber
            // 
            tbSerialNumber.BackColor = SystemColors.Window;
            tbSerialNumber.Location = new Point(105, 40);
            tbSerialNumber.Name = "tbSerialNumber";
            tbSerialNumber.Size = new Size(216, 23);
            tbSerialNumber.TabIndex = 7;
            tbSerialNumber.TextChanged += tbSerialNumber_TextChanged;
            // 
            // cbSigningKey
            // 
            cbSigningKey.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSigningKey.FormattingEnabled = true;
            cbSigningKey.Location = new Point(105, 144);
            cbSigningKey.Name = "cbSigningKey";
            cbSigningKey.Size = new Size(114, 23);
            cbSigningKey.TabIndex = 8;
            cbSigningKey.SelectedIndexChanged += cbSigningKey_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 147);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 9;
            label1.Text = "Signing Key";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lbStatusText });
            statusStrip.Location = new Point(0, 184);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(376, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 206);
            Controls.Add(statusStrip);
            Controls.Add(label1);
            Controls.Add(cbSigningKey);
            Controls.Add(tbSerialNumber);
            Controls.Add(btnPasteSN);
            Controls.Add(btnCreate);
            Controls.Add(lb2);
            Controls.Add(cbTaskType);
            Controls.Add(lb1);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "Main";
            Text = "Motorola Depot Jobs Creator";
            FormClosing += Main_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb1;
        private ComboBox cbTaskType;
        private Label lb2;
        private Button btnCreate;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem generateMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem decodeDepotJobToolStripMenuItem;
        private ToolStripMenuItem originalToolStripMenuItem;
        private ToolStripMenuItem selfGeneratedToolStripMenuItem;
        private ToolStripMenuItem generateCertificateToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button btnPasteSN;
        private TextBox tbSerialNumber;
        private ToolStripSeparator toolStripSeparator2;
        private ComboBox cbSigningKey;
        private Label label1;
        private StatusStrip statusStrip;
    }
}
