namespace MotoDepotJobsCreator
{
    partial class DepotJobViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepotJobViewer));
            label1 = new Label();
            cbSigningKey = new ComboBox();
            btnOpen = new Button();
            textBox = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 12;
            label1.Text = "Signing Key";
            // 
            // cbSigningKey
            // 
            cbSigningKey.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSigningKey.FormattingEnabled = true;
            cbSigningKey.Location = new Point(85, 12);
            cbSigningKey.Name = "cbSigningKey";
            cbSigningKey.Size = new Size(261, 23);
            cbSigningKey.TabIndex = 11;
            cbSigningKey.SelectedIndexChanged += cbSigningKey_SelectedIndexChanged;
            // 
            // btnOpen
            // 
            btnOpen.Enabled = false;
            btnOpen.Location = new Point(352, 11);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(115, 25);
            btnOpen.TabIndex = 10;
            btnOpen.Text = "Open Depot Job";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(12, 41);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Size = new Size(455, 375);
            textBox.TabIndex = 13;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(200, 432);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 14;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // DepotJobViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 467);
            Controls.Add(btnClose);
            Controls.Add(textBox);
            Controls.Add(label1);
            Controls.Add(cbSigningKey);
            Controls.Add(btnOpen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DepotJobViewer";
            Text = "Depot Job Viewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbSigningKey;
        private Button btnOpen;
        private TextBox textBox;
        private Button btnClose;
    }
}