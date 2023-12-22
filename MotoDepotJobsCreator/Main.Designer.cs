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
            lb1 = new Label();
            cbSerialNumer = new ComboBox();
            cbTaskType = new ComboBox();
            lb2 = new Label();
            btnCreate = new Button();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            generateToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            decodeDepotJobToolStripMenuItem = new ToolStripMenuItem();
            originalToolStripMenuItem = new ToolStripMenuItem();
            selfGeneratedToolStripMenuItem = new ToolStripMenuItem();
            generateCertificateToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            btnPasteSN = new Button();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(13, 43);
            lb1.Name = "lb1";
            lb1.Size = new Size(82, 15);
            lb1.TabIndex = 0;
            lb1.Text = "Serial Number";
            // 
            // cbSerialNumer
            // 
            cbSerialNumer.FormattingEnabled = true;
            cbSerialNumer.Location = new Point(116, 40);
            cbSerialNumer.MaxLength = 10;
            cbSerialNumer.Name = "cbSerialNumer";
            cbSerialNumer.Size = new Size(205, 23);
            cbSerialNumer.TabIndex = 1;
            cbSerialNumer.TextChanged += cbSerialNumer_TextChanged;
            // 
            // cbTaskType
            // 
            cbTaskType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTaskType.FormattingEnabled = true;
            cbTaskType.Items.AddRange(new object[] { "Software Upgrade", "Codeplug Override", "Codeplug Upload", "Switchover", "Write And Switchover", "None", "Update Serial Number", "Factory Reset ", "CBI Program", "Codeplug ForceWrite", "Unkill Radio", "Software Upgrade Bootmode", "Request WiFi Certificate" });
            cbTaskType.Location = new Point(116, 80);
            cbTaskType.Name = "cbTaskType";
            cbTaskType.Size = new Size(235, 23);
            cbTaskType.TabIndex = 2;
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(13, 83);
            lb2.Name = "lb2";
            lb2.Size = new Size(93, 15);
            lb2.TabIndex = 3;
            lb2.Text = "Depot Task Type";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(88, 143);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(216, 23);
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
            menuStrip.Size = new Size(370, 24);
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
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateToolStripMenuItem, toolStripSeparator1, decodeDepotJobToolStripMenuItem, generateCertificateToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // generateToolStripMenuItem
            // 
            generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            generateToolStripMenuItem.Size = new Size(182, 22);
            generateToolStripMenuItem.Text = "Create DepotJob File";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(179, 6);
            // 
            // decodeDepotJobToolStripMenuItem
            // 
            decodeDepotJobToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { originalToolStripMenuItem, selfGeneratedToolStripMenuItem });
            decodeDepotJobToolStripMenuItem.Name = "decodeDepotJobToolStripMenuItem";
            decodeDepotJobToolStripMenuItem.Size = new Size(182, 22);
            decodeDepotJobToolStripMenuItem.Text = "Decode DepotJob ";
            // 
            // originalToolStripMenuItem
            // 
            originalToolStripMenuItem.Name = "originalToolStripMenuItem";
            originalToolStripMenuItem.Size = new Size(168, 22);
            originalToolStripMenuItem.Text = "Motorola Original";
            // 
            // selfGeneratedToolStripMenuItem
            // 
            selfGeneratedToolStripMenuItem.Name = "selfGeneratedToolStripMenuItem";
            selfGeneratedToolStripMenuItem.Size = new Size(168, 22);
            selfGeneratedToolStripMenuItem.Text = "Self Generated";
            // 
            // generateCertificateToolStripMenuItem
            // 
            generateCertificateToolStripMenuItem.Name = "generateCertificateToolStripMenuItem";
            generateCertificateToolStripMenuItem.Size = new Size(182, 22);
            generateCertificateToolStripMenuItem.Text = "Generate Certificate";
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
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 178);
            Controls.Add(btnPasteSN);
            Controls.Add(btnCreate);
            Controls.Add(lb2);
            Controls.Add(cbTaskType);
            Controls.Add(cbSerialNumer);
            Controls.Add(lb1);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "Main";
            Text = "Motorola Depot Jobs Creator";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb1;
        private ComboBox cbSerialNumer;
        private ComboBox cbTaskType;
        private Label lb2;
        private Button btnCreate;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem generateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem decodeDepotJobToolStripMenuItem;
        private ToolStripMenuItem originalToolStripMenuItem;
        private ToolStripMenuItem selfGeneratedToolStripMenuItem;
        private ToolStripMenuItem generateCertificateToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button btnPasteSN;
    }
}
