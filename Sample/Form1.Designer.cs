namespace Sample
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLogin = new Button();
            btnLogout = new Button();
            btnGetMailFolders = new Button();
            lblSharedMailbox = new Label();
            txtSharedMailbox = new TextBox();
            btnGetSharedFolders = new Button();
            lblStatus = new Label();
            rtbInfo = new RichTextBox();
            SuspendLayout();

            // btnLogin
            btnLogin.Location = new Point(12, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 32);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "ログイン";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            // btnLogout
            btnLogout.Enabled = false;
            btnLogout.Location = new Point(120, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 32);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "ログアウト";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;

            // btnGetMailFolders
            btnGetMailFolders.Enabled = false;
            btnGetMailFolders.Location = new Point(228, 12);
            btnGetMailFolders.Name = "btnGetMailFolders";
            btnGetMailFolders.Size = new Size(150, 32);
            btnGetMailFolders.TabIndex = 2;
            btnGetMailFolders.Text = "メールフォルダ取得";
            btnGetMailFolders.UseVisualStyleBackColor = true;
            btnGetMailFolders.Click += btnGetMailFolders_Click;

            // lblSharedMailbox
            lblSharedMailbox.AutoSize = true;
            lblSharedMailbox.Location = new Point(12, 57);
            lblSharedMailbox.Name = "lblSharedMailbox";
            lblSharedMailbox.TabIndex = 3;
            lblSharedMailbox.Text = "共有メールボックス:";

            // txtSharedMailbox
            txtSharedMailbox.Location = new Point(148, 54);
            txtSharedMailbox.Name = "txtSharedMailbox";
            txtSharedMailbox.PlaceholderText = "shared@example.com";
            txtSharedMailbox.Size = new Size(270, 23);
            txtSharedMailbox.TabIndex = 4;

            // btnGetSharedFolders
            btnGetSharedFolders.Enabled = false;
            btnGetSharedFolders.Location = new Point(426, 52);
            btnGetSharedFolders.Name = "btnGetSharedFolders";
            btnGetSharedFolders.Size = new Size(150, 27);
            btnGetSharedFolders.TabIndex = 5;
            btnGetSharedFolders.Text = "共有フォルダ取得";
            btnGetSharedFolders.UseVisualStyleBackColor = true;
            btnGetSharedFolders.Click += btnGetSharedFolders_Click;

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 92);
            lblStatus.Name = "lblStatus";
            lblStatus.TabIndex = 6;
            lblStatus.Text = "状態: -";

            // rtbInfo
            rtbInfo.BackColor = SystemColors.Control;
            rtbInfo.BorderStyle = BorderStyle.FixedSingle;
            rtbInfo.Font = new Font("Consolas", 10F);
            rtbInfo.Location = new Point(12, 116);
            rtbInfo.Name = "rtbInfo";
            rtbInfo.ReadOnly = true;
            rtbInfo.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbInfo.Size = new Size(560, 250);
            rtbInfo.TabIndex = 7;
            rtbInfo.Text = "";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 378);
            Controls.Add(btnLogin);
            Controls.Add(btnLogout);
            Controls.Add(btnGetMailFolders);
            Controls.Add(lblSharedMailbox);
            Controls.Add(txtSharedMailbox);
            Controls.Add(btnGetSharedFolders);
            Controls.Add(lblStatus);
            Controls.Add(rtbInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Graph API 委任型ログイン サンプル";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnLogout;
        private Button btnGetMailFolders;
        private Label lblSharedMailbox;
        private TextBox txtSharedMailbox;
        private Button btnGetSharedFolders;
        private Label lblStatus;
        private RichTextBox rtbInfo;
    }
}
